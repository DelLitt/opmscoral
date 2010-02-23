			 


using System.Collections;
using Spring.Transaction.Interceptor;
using  CoralPOS.Models;
using  POSServer.DataLayer.Implement;

namespace POSServer.DataLayer.Implement
{
    public class StockInLogicImpl : IStockInLogic
    {
        private IStockInDao _innerDao;

        public IStockInDao StockInDao
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
        /// Find StockIn object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of StockIn</param>
        /// <returns></returns>
        public StockIn FindById(object id)
        {
            return _innerDao.FindById(id);
        }
        
        /// <summary>
        /// Add StockIn to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public StockIn Add(StockIn data)
        {
            _innerDao.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update StockIn to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(StockIn data)
        {
            _innerDao.Update(data);
        }
        
        /// <summary>
        /// Delete StockIn from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(StockIn data)
        {
            _innerDao.Delete(data);
        }
        
        /// <summary>
        /// Delete StockIn from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            _innerDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all StockIn from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return _innerDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all StockIn from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return _innerDao.FindPaging(criteria);
        }
    }
}