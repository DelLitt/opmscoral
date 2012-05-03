			 


using System.Collections;
using System.Collections.Generic;
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

namespace POSClient.BusinessLogic.Implement
{
    public class StockOutCostLogic : IStockOutCostLogic
    {
        private IStockOutCostDao _innerDao;
        public IStockOutCostDao StockOutCostDao
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
        /// Find StockOutCost object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of StockOutCost</param>
        /// <returns></returns>
        public StockOutCost FindById(object id)
        {
            return StockOutCostDao.FindById(id);
        }
        
        /// <summary>
        /// Add StockOutCost to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public StockOutCost Add(StockOutCost data)
        {
            StockOutCostDao.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update StockOutCost to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(StockOutCost data)
        {
            StockOutCostDao.Update(data);
        }
        
        /// <summary>
        /// Delete StockOutCost from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(StockOutCost data)
        {
            StockOutCostDao.Delete(data);
        }
        
        /// <summary>
        /// Delete StockOutCost from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            StockOutCostDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all StockOutCost from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<StockOutCost> FindAll(ObjectCriteria<StockOutCost> criteria)
        {
            return StockOutCostDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all StockOutCost from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria<StockOutCost> criteria)
        {
            return StockOutCostDao.FindPaging(criteria);
        }
    }
}