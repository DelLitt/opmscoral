			 


using System.Collections;
using Spring.Transaction.Interceptor;
using  CoralPOS.Models;
using  POSServer.DataLayer.Implement;

namespace POSServer.DataLayer.Implement
{
    public class StockDefinitionStatusLogicImpl : IStockDefinitionStatusLogic
    {
        private IStockDefinitionStatusDao _innerDao;

        public IStockDefinitionStatusDao StockDefinitionStatusDao
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
        /// Find StockDefinitionStatus object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of StockDefinitionStatus</param>
        /// <returns></returns>
        public StockDefinitionStatus FindById(object id)
        {
            return _innerDao.FindById(id);
        }
        
        /// <summary>
        /// Add StockDefinitionStatus to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public StockDefinitionStatus Add(StockDefinitionStatus data)
        {
            _innerDao.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update StockDefinitionStatus to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(StockDefinitionStatus data)
        {
            _innerDao.Update(data);
        }
        
        /// <summary>
        /// Delete StockDefinitionStatus from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(StockDefinitionStatus data)
        {
            _innerDao.Delete(data);
        }
        
        /// <summary>
        /// Delete StockDefinitionStatus from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            _innerDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all StockDefinitionStatus from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return _innerDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all StockDefinitionStatus from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return _innerDao.FindPaging(criteria);
        }
    }
}