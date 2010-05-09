			 


using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AppFrame.Utility;
using AppFrame.Utils;
using NHibernate.Linq;
using NHibernate.SqlCommand;
using Spring.Transaction.Interceptor;
using System.Linq.Expressions;
using AppFrame.DataLayer;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.LambdaExtensions;
using NHibernate.Linq.Expressions;
using Spring.Data.NHibernate;
using  CoralPOS.Models;
using  POSClient.DataLayer.Implement;
using Expression = NHibernate.Criterion.Expression;

namespace POSClient.BusinessLogic.Implement
{
    public class DepartmentStockInLogic : IDepartmentStockInLogic
    {
        private IDepartmentStockInDao _innerDao;
        public IDepartmentStockInDao DepartmentStockInDao
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
        
        /// <summary>
        /// Find DepartmentStockIn object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of DepartmentStockIn</param>
        /// <returns></returns>
        public DepartmentStockIn FindById(object id)
        {
            return DepartmentStockInDao.FindById(id);
        }
        
        /// <summary>
        /// Add DepartmentStockIn to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public DepartmentStockIn Add(DepartmentStockIn data)
        {
            DepartmentStockInDao.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update DepartmentStockIn to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(DepartmentStockIn data)
        {
            DepartmentStockInDao.Update(data);
        }
        
        /// <summary>
        /// Delete DepartmentStockIn from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(DepartmentStockIn data)
        {
            DepartmentStockInDao.Delete(data);
        }
        
        /// <summary>
        /// Delete DepartmentStockIn from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            DepartmentStockInDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all DepartmentStockIn from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<DepartmentStockIn> FindAll(ObjectCriteria<DepartmentStockIn> criteria)
        {
            return DepartmentStockInDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all DepartmentStockIn from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria<DepartmentStockIn> criteria)
        {
            return DepartmentStockInDao.FindPaging(criteria);
        }

        public DepartmentStockIn Fetch(DepartmentStockIn selectedStockIn)
        {
            return DepartmentStockInDao.Fetch(selectedStockIn);
        }

        public void FetchDeptStock(DepartmentStockIn stockIn)
        {
            DepartmentStockInDao.Execute(delegate(ISession session)
            {
                foreach (DepartmentStockInDetail inDetail in stockIn.DepartmentStockInDetails)
                {
                    DepartmentStock stock = (from stk in session.Linq<DepartmentStock>()
                                       where
                                           stk.DepartmentStockPK.ProductId.Equals(inDetail.Product.ProductId)
                                       select stk).FirstOrDefault();
                    inDetail.DepartmentStock = stock;
                }

                return null;
            });
        }

        public IList<DepartmentStockIn> FindByMultiCriteria(DeptStockInCriteria criteria)
        {
            bool hasDetailQuery = false;
            StockInDetail detail = null;
            // create detached criteria
            DetachedCriteria critMaster = DetachedCriteria.For<DepartmentStockIn>();
            DetachedCriteria critDetail = DetachedCriteria.For<DepartmentStockInDetail>();

            if (criteria != null)
            {
                // create ICriteria provider for all properties we need to search
                ProductMaster pm = null;
                DetachedCriteria pmCrit = critDetail.CreateCriteria((DepartmentStockInDetail sod) => sod.ProductMaster,
                                                                    () => pm, JoinType.InnerJoin);
                Category cat = null;
                DetachedCriteria catCrit = pmCrit.CreateCriteria((ProductMaster p) => p.Category, () => cat,
                                                                 JoinType.InnerJoin);

                ProductType type = null;
                DetachedCriteria typeCrit = pmCrit.CreateCriteria((ProductMaster p) => p.ProductType, () => type,
                                                                 JoinType.InnerJoin);

                // has search product master name
                if (!ObjectUtility.IsNullOrEmpty(criteria.ProductMasterNames))
                {
                    hasDetailQuery = true;
                    int count = 1;
                    // create OR expression A or B or C
                    Junction pmJunction = Expression.Disjunction();
                    foreach (string masterName in criteria.ProductMasterNames)
                    {
                        pmJunction.Add(SqlExpression.Like<ProductMaster>(sod => sod.ProductName, masterName, MatchMode.Anywhere));
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
                        typeJunction.Add(SqlExpression.Like<ProductType>(sod => sod.TypeName, typeName, MatchMode.Anywhere));
                    }
                    typeCrit.Add(typeJunction);
                }

                // search from date to date
                if (criteria.DatePick)
                {
                    critMaster.Add(SqlExpression.Between<StockIn>(so => so.StockInDate,
                                                                   DateUtility.ZeroTime(criteria.FromDate),
                                                                   DateUtility.MaxTime(criteria.ToDate)));
                }
            }

            return (IList<DepartmentStockIn>)DepartmentStockInDao.Execute(delegate(ISession session)
            {
                ICriteria executeCrit = critMaster.GetExecutableCriteria(session);
                if (hasDetailQuery) // if has search in detail
                {
                    // set projection so detail return stock_in_id
                    critDetail.SetProjection(LambdaProjection.Property<DepartmentStockInDetail>(p => p.DepartmentStockIn.DepartmentStockInPK.StockInId));
                    // set master follow return values in subquery of detail
                    executeCrit.Add(LambdaSubquery.Property<DepartmentStockIn>(p => p.DepartmentStockInPK.StockInId).In(critDetail));
                }

                // max result, should put in common properties
                executeCrit.SetMaxResults(20);
                //executeCrit.SetResultTransformer(Transformers.DistinctRootEntity);
                return executeCrit.List<StockIn>();
            }
                                 ); 
        }
    }

    public class DeptStockInCriteria
    {
        public bool DatePick { get; set; }
        public DateTime ToDate { get; set; }
        public DateTime FromDate { get; set; }
        public string Description { get; set; }
        public IList<string> ProductMasterNames { get; set; }
        public string CategoryName { get; set; }
        public IList<string> TypeNames { get; set; }

    }
}