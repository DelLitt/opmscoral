			 


using System.Collections;
using Spring.Transaction.Interceptor;
using  CoralPOS.Models;
using  POSServer.DataLayer.Implement;

namespace POSServer.DataLayer.Implement
{
    public class StockInDetailLogicImpl : IStockInDetailLogic
    {
        private IStockInDetailDao _innerDao;

        public IStockInDetailDao StockInDetailDao
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
        /// Find StockInDetail object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of StockInDetail</param>
        /// <returns></returns>
        public StockInDetail FindById(object id)
        {
            return _innerDao.FindById(id);
        }
        
        /// <summary>
        /// Add StockInDetail to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public StockInDetail Add(StockInDetail data)
        {
            _innerDao.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update StockInDetail to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(StockInDetail data)
        {
            _innerDao.Update(data);
        }
        
        /// <summary>
        /// Delete StockInDetail from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(StockInDetail data)
        {
            _innerDao.Delete(data);
        }
        
        /// <summary>
        /// Delete StockInDetail from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            _innerDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all StockInDetail from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return _innerDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all StockInDetail from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return _innerDao.FindPaging(criteria);
        }
    }
}