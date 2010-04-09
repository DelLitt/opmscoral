			 


using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AppFrame.Utils;
using NHibernate.Linq;
using NHibernate.SqlCommand;
using Spring.Dao;
using Spring.Transaction.Interceptor;
using System.Linq.Expressions;
using AppFrame.DataLayer;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.LambdaExtensions;
using NHibernate.Linq.Expressions;
using Spring.Data.NHibernate;
using  CoralPOS.Models;
using  POSServer.DataLayer.Implement;

namespace POSServer.BusinessLogic.Implement
{
    public class StockOutLogic : IStockOutLogic
    {
        private IStockOutDao _innerDao;
        public IStockOutDao StockOutDao
        {
            get 
            { 
                return _innerDao; 
            }
            set 
            { 
                _innerDao = value; 
            }
        }

        public IProductMasterDao ProductMasterDao { get; set; }
        public IProductDao ProductDao { get; set; }
        public IStockOutDetailDao StockOutDetailDao { get; set; }
        public IMainStockDao MainStockDao { get; set; }
        public IMainPriceDao MainPriceDao { get; set; }
        /// <summary>
        /// Find StockOut object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of StockOut</param>
        /// <returns></returns>
        public StockOut FindById(object id)
        {
            return StockOutDao.FindById(id);
        }
        
        /// <summary>
        /// Add StockOut to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public StockOut Add(StockOut data)
        {
            IDictionary<string, MainPrice> prices = new Dictionary<string, MainPrice>();
            var maxIdResult = StockOutDao.SelectSpecificType(null, Projections.Max("StockOutId"));
            long nextStockOutId = maxIdResult != null ? Int64.Parse(maxIdResult.ToString()) + 1 : 1;
            var maxDetailIdResult = StockOutDetailDao.SelectSpecificType(null, Projections.Max("StockOutDetailId"));
            long nextStockOutDetailId = maxIdResult != null ? Int64.Parse(maxIdResult.ToString()) + 1 : 1;


            data.StockOutId = nextStockOutId;
            StockOutDao.Add(data);
            foreach (StockOutDetail outDetail in data.StockOutDetails)
            {
                outDetail.StockOutDetailId = nextStockOutDetailId++;
                StockOutDetailDao.Add(outDetail);

                ObjectCriteria<MainStock> findStock = new ObjectCriteria<MainStock>();
                string productId = outDetail.Product.ProductId;
                findStock.AddCriteria(stk => stk.Product.ProductId == productId);

                MainStock currentStock = MainStockDao.FindFirst(findStock) as MainStock;
                if (currentStock == null) // create new stock
                {
                    throw new DataIntegrityViolationException();
                }
                else // update current stock
                {
                    currentStock.Quantity -= outDetail.Quantity;
                    currentStock.GoodQuantity -= outDetail.Quantity;
                    currentStock.ExclusiveKey += 1;
                    if(currentStock.Quantity <0 || currentStock.GoodQuantity <0)
                        throw new DataIntegrityViolationException();
                    MainStockDao.Update(currentStock);
                }
            }
            
            return data;
        }
        
        /// <summary>
        /// Update StockOut to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(StockOut data)
        {
            StockOutDao.Update(data);
        }
        
        /// <summary>
        /// Delete StockOut from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(StockOut data)
        {
            StockOutDao.Delete(data);
        }
        
        /// <summary>
        /// Delete StockOut from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            StockOutDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all StockOut from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<StockOut> FindAll(ObjectCriteria<StockOut> criteria)
        {
            return StockOutDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all StockOut from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria<StockOut> criteria)
        {
            return StockOutDao.FindPaging(criteria);
        }

        public IList<StockOut> FindByCriteria(object criteria)
        {
            return (IList<StockOut>)StockOutDao.Execute(delegate(ISession session)
                                   {
                                       var sql = from c in session.Linq<StockOut>()
                                                 from o in c.StockOutDetails.Cast<StockOutDetail>()
                                                 //on c.StockOutId equals o.StockOut.StockOutId into sods
                                                 select c;
                                       StockInEqualityComparer x = new StockInEqualityComparer();
                                       return sql.ToList().Distinct().ToList();
                                   }
                                 );
        }

        public IList<StockOut> FindByMultiCriteria(StockOutCriteria criteria)
        {
            bool hasDetailQuery = false;
            StockOutDetail detail = null;
            DetachedCriteria critMaster = DetachedCriteria.For<StockOut>();
            DetachedCriteria critDetail = critMaster.CreateCriteria<StockOut>(so => so.StockOutDetails, () => detail,
                                                                              JoinType.InnerJoin);

            if (criteria != null)
            {
                if (!ObjectUtility.IsNullOrEmpty(criteria.DepartmentName))
                {
                    critMaster.Add<StockOut>(so => so.Department.DepartmentName == criteria.DepartmentName);
                }

                if (!ObjectUtility.IsNullOrEmpty(criteria.ProductMasterNames))
                {
                    hasDetailQuery = true;
                    critDetail.Add(SqlExpression.In<StockOutDetail>(sod => sod.ProductMaster.ProductName,
                                                                    criteria.ProductMasterNames.ToArray()));
                }

                if (!ObjectUtility.IsNullOrEmpty(criteria.CategoryName))
                {
                    hasDetailQuery = true;
                    critDetail.Add<StockOutDetail>(
                        sod => sod.ProductMaster.Category.CategoryName == criteria.CategoryName);
                }

                if (!ObjectUtility.IsNullOrEmpty(criteria.TypeNames))
                {
                    hasDetailQuery = true;
                    critDetail.Add(SqlExpression.In<StockOutDetail>(sod => sod.ProductMaster.ProductType.TypeName,
                                                                    criteria.TypeNames.ToArray()));
                }
            }

            return (IList<StockOut>)StockOutDao.Execute(delegate(ISession session)
            {
                if (hasDetailQuery)
                {
                    return critDetail.GetExecutableCriteria(session).SetMaxResults(50).List<StockOut>();
                }
                return critMaster.GetExecutableCriteria(session).SetMaxResults(50).List<StockOut>();
            }
                                 );
        }
    }


    public class StockOutCriteria
    {
        public string DepartmentName { get; set; }
        public IList<string> ProductMasterNames { get; set; }
        public string CategoryName { get; set; }
        public IList<string> TypeNames { get; set; }
        
    }

    class StockInEqualityComparer : IEqualityComparer<StockIn>
    {
        public bool Equals(StockIn x, StockIn y)
        {
            return x.StockInId == y.StockInId;
        }

        public int GetHashCode(StockIn obj)
        {
            return obj.GetHashCode();
        }
    }
}