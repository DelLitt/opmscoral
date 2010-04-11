			 


using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AppFrame.Utility;
using AppFrame.Utils;
using NHibernate.Linq;
using NHibernate.SqlCommand;
using NHibernate.Transform;
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
            long nextStockOutDetailId = maxDetailIdResult != null ? Int64.Parse(maxDetailIdResult.ToString()) + 1 : 1;


            data.StockOutId = nextStockOutId;
            StockOutDao.Add(data);
            foreach (StockOutDetail outDetail in data.StockOutDetails)
            {
                outDetail.StockOutDetailId = nextStockOutDetailId++;
                StockOutDetailDao.Add(outDetail);

                ObjectCriteria<MainStock> findStock = new ObjectCriteria<MainStock>();
                string productId = outDetail.Product.ProductId;
                findStock.Add(stk => stk.Product.ProductId == productId);

                MainStock currentStock = MainStockDao.FindFirst(findStock) as MainStock;
                if (currentStock == null) // create new stock
                {
                    throw new DataIntegrityViolationException("Could not find the product id in stock");
                }
                else // update current stock
                {
                    currentStock.Quantity -= outDetail.Quantity;
                    currentStock.GoodQuantity -= outDetail.Quantity;
                    currentStock.ExclusiveKey += 1;
                    if(currentStock.Quantity <0 || currentStock.GoodQuantity <0)
                        throw new DataIntegrityViolationException("Stock quantity of " + currentStock.Product.ProductId + " is zero.");
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
            DetachedCriteria critDetail = DetachedCriteria.For<StockOutDetail>();
            
            if (criteria != null)
            {
                if (criteria.DepartmentPick && !ObjectUtility.IsNullOrEmpty(criteria.DepartmentName))
                {
                    critMaster.Add<StockOut>(so => so.Department.DepartmentName == criteria.DepartmentName);
                }

                if (!ObjectUtility.IsNullOrEmpty(criteria.ProductMasterNames))
                {
                    hasDetailQuery = true;
                    foreach (string masterName in criteria.ProductMasterNames)
                    {
                        critDetail.Add(SqlExpression.Like<StockOutDetail>(sod => sod.ProductMaster.ProductName,masterName));
                    }
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
                    foreach (string typeName in criteria.TypeNames)
                    {
                        critDetail.Add(SqlExpression.Like<StockOutDetail>(sod => sod.ProductMaster.ProductType.TypeName,typeName));    
                    }
                }
                if(criteria.DatePick)
                {
                    
                    critMaster.Add(SqlExpression.Between<StockOut>(so => so.StockOutDate, 
                                                                   DateUtility.ZeroTime(criteria.FromDate),
                                                                   DateUtility.MaxTime(criteria.ToDate)));
                }
            }

            return (IList<StockOut>)StockOutDao.Execute(delegate(ISession session)
            {
                ICriteria executeCrit = critMaster.GetExecutableCriteria(session);    
                if(hasDetailQuery)
                {
                    critDetail.SetProjection(Projections.Distinct(Projections.Property("StockOutId")));
                    executeCrit.Add(LambdaSubquery.Property<StockOut>(p => p.StockOutId).In(critDetail)); 
                }

                executeCrit.SetMaxResults(20);
                //executeCrit.SetResultTransformer(Transformers.DistinctRootEntity);
                return executeCrit.List<StockOut>();
            }
                                 );
        }

        public StockOut Fetch(StockOut stockOut)
        {
            return StockOutDao.Fetch(stockOut);
        }
    }


    public class StockOutCriteria
    {
        public bool DatePick { get; set; }
        public bool DepartmentPick { get; set; }
        public DateTime ToDate { get; set;}
        public DateTime FromDate { get; set;}
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