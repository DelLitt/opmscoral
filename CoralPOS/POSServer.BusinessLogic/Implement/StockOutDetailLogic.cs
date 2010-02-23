			 


using System.Collections;
using Spring.Transaction.Interceptor;
using  CoralPOS.Models;
using  POSServer.DataLayer.Implement;

namespace POSServer.DataLayer.Implement
{
    public class StockOutDetailLogicImpl : IStockOutDetailLogic
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
            return _innerDao.FindById(id);
        }
        
        /// <summary>
        /// Add StockOutDetail to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public StockOutDetail Add(StockOutDetail data)
        {
            _innerDao.Add(data);
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
            _innerDao.Update(data);
        }
        
        /// <summary>
        /// Delete StockOutDetail from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(StockOutDetail data)
        {
            _innerDao.Delete(data);
        }
        
        /// <summary>
        /// Delete StockOutDetail from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            _innerDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all StockOutDetail from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return _innerDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all StockOutDetail from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return _innerDao.FindPaging(criteria);
        }
    }
}