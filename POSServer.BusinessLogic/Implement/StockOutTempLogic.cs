			 


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
using  POSServer.DataLayer.Implement;

namespace POSServer.BusinessLogic.Implement
{
    public class StockOutTempLogic : IStockOutTempLogic
    {
        private IStockOutTempDao _innerDao;
        public IStockOutTempDao StockOutTempDao
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
        /// Find StockOutTemp object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of StockOutTemp</param>
        /// <returns></returns>
        public StockOutTemp FindById(object id)
        {
            return StockOutTempDao.FindById(id);
        }
        
        /// <summary>
        /// Add StockOutTemp to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public StockOutTemp Add(StockOutTemp data)
        {
            StockOutTempDao.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update StockOutTemp to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(StockOutTemp data)
        {
            StockOutTempDao.Update(data);
        }
        
        /// <summary>
        /// Delete StockOutTemp from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(StockOutTemp data)
        {
            StockOutTempDao.Delete(data);
        }
        
        /// <summary>
        /// Delete StockOutTemp from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            StockOutTempDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all StockOutTemp from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<StockOutTemp> FindAll(ObjectCriteria<StockOutTemp> criteria)
        {
            return StockOutTempDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all StockOutTemp from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria<StockOutTemp> criteria)
        {
            return StockOutTempDao.FindPaging(criteria);
        }
    }
}