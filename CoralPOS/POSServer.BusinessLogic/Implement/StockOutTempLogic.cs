			 


using System.Collections;
using Spring.Transaction.Interceptor;
using  CoralPOS.Models;
using  POSServer.DataLayer.Implement;

namespace POSServer.DataLayer.Implement
{
    public class StockOutTempLogicImpl : IStockOutTempLogic
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
            return _innerDao.FindById(id);
        }
        
        /// <summary>
        /// Add StockOutTemp to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public StockOutTemp Add(StockOutTemp data)
        {
            _innerDao.Add(data);
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
            _innerDao.Update(data);
        }
        
        /// <summary>
        /// Delete StockOutTemp from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(StockOutTemp data)
        {
            _innerDao.Delete(data);
        }
        
        /// <summary>
        /// Delete StockOutTemp from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            _innerDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all StockOutTemp from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return _innerDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all StockOutTemp from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return _innerDao.FindPaging(criteria);
        }
    }
}