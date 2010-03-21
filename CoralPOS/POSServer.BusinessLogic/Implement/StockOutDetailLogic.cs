			 


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
    public class StockOutDetailLogic : IStockOutDetailLogic
    {
        private IStockOutDetailDao _innerDao;
        public IStockOutDetailDao StockOutDetailDao
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
        /// Find StockOutDetail object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of StockOutDetail</param>
        /// <returns></returns>
        public StockOutDetail FindById(object id)
        {
            return StockOutDetailDao.FindById(id);
        }
        
        /// <summary>
        /// Add StockOutDetail to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public StockOutDetail Add(StockOutDetail data)
        {
            StockOutDetailDao.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update StockOutDetail to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(StockOutDetail data)
        {
            StockOutDetailDao.Update(data);
        }
        
        /// <summary>
        /// Delete StockOutDetail from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(StockOutDetail data)
        {
            StockOutDetailDao.Delete(data);
        }
        
        /// <summary>
        /// Delete StockOutDetail from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            StockOutDetailDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all StockOutDetail from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<StockOutDetail> FindAll(ObjectCriteria<StockOutDetail> criteria)
        {
            return StockOutDetailDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all StockOutDetail from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria<StockOutDetail> criteria)
        {
            return StockOutDetailDao.FindPaging(criteria);
        }
    }
}