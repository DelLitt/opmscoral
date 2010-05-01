			 


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
using Expression = NHibernate.Criterion.Expression;

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
            var maxDetailIdResult = StockOutDetailDao.SelectSpecificType(null, Projections.Max("StockOutDetailPK.StockOutDetailId"));
            long nextStockOutDetailId = maxDetailIdResult != null ? Int64.Parse(maxDetailIdResult.ToString()) + 1 : 1;


            data.StockOutId = nextStockOutId;
            StockOutDao.Add(data);
            foreach (StockOutDetail outDetail in data.StockOutDetails)
            {
                StockOutDetailPK detailPK = new StockOutDetailPK
                                                {
                                                    StockOutDetailId = nextStockOutDetailId++,
                                                    StockOutId = nextStockOutId
                                                };
                outDetail.StockOutDetailPK = detailPK;
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

        /// <summary>
        /// Find by a criteria
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Find by multicriteria define in StockOutCriteria
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<StockOut> FindByMultiCriteria(StockOutCriteria criteria)
        {
            bool hasDetailQuery = false;
            StockOutDetail detail = null;
            // create detached criteria
            DetachedCriteria critMaster = DetachedCriteria.For<StockOut>();
            DetachedCriteria critDetail = DetachedCriteria.For<StockOutDetail>();
            

            if (criteria != null)
            {
                // create ICriteria provider for all properties we need to search
                Department dep = null;
                DetachedCriteria depCrit = critMaster.CreateCriteria((StockOut so) => so.Department,
                                                                    () => dep, JoinType.InnerJoin);
                ProductMaster pm = null;
                DetachedCriteria pmCrit = critDetail.CreateCriteria((StockOutDetail sod) => sod.ProductMaster,
                                                                    () => pm, JoinType.InnerJoin);
                Category cat = null;
                DetachedCriteria catCrit = pmCrit.CreateCriteria((ProductMaster p) => p.Category, () => cat,
                                                                 JoinType.InnerJoin);

                ProductType type = null;
                DetachedCriteria typeCrit = pmCrit.CreateCriteria((ProductMaster p) => p.ProductType, () => type,
                                                                 JoinType.InnerJoin);
                
                // search by department
                if (criteria.DepartmentPick && !ObjectUtility.IsNullOrEmpty(criteria.DepartmentName))
                {
                    depCrit.Add<Department>(so => so.DepartmentName == criteria.DepartmentName);
                }

                // has search product master name
                if (!ObjectUtility.IsNullOrEmpty(criteria.ProductMasterNames))
                {
                    hasDetailQuery = true;
                    // create OR expression A or B or C
                    Junction pmJunction = Expression.Disjunction();
                    foreach (string masterName in criteria.ProductMasterNames)
                    {
                        pmJunction.Add(SqlExpression.Like<ProductMaster>(sod => sod.ProductName, 
                            masterName.ToUpper().Trim(),MatchMode.Anywhere));
                    }
                    pmCrit.Add(pmJunction);
                }

                // search follow category name
                if (!ObjectUtility.IsNullOrEmpty(criteria.CategoryName))
                {
                    hasDetailQuery = true;
                    catCrit.Add<Category>(
                        sod => sod.CategoryName == criteria.CategoryName);
                }

                // search follow type names
                if (!ObjectUtility.IsNullOrEmpty(criteria.TypeNames))
                {
                    hasDetailQuery = true;
                    // create OR expression A or B or C
                    Junction typeJunction = Expression.Disjunction();
                    foreach (string typeName in criteria.TypeNames)
                    {
                        typeJunction.Add(SqlExpression.Like<ProductType>(
                            sod => sod.TypeName, typeName.ToUpper().Trim(), MatchMode.Anywhere));    
                    }
                    typeCrit.Add(typeJunction);
                }

                // search from date to date
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
                    critDetail.SetProjection(LambdaProjection.Property<StockOutDetail>(p=>p.StockOut.StockOutId));
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