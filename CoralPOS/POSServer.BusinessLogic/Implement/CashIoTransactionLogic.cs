			 


using System.Collections;
using Spring.Transaction.Interceptor;
using  CoralPOS.Models;
using  POSServer.DataLayer.Implement;

namespace POSServer.DataLayer.Implement
{
    public class CashIoTransactionLogicImpl : ICashIoTransactionLogic
    {
        private ICashIoTransactionDao _innerDao;

        public ICashIoTransactionDao CashIoTransactionDao
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
        /// Find CashIoTransaction object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of CashIoTransaction</param>
        /// <returns></returns>
        public CashIoTransaction FindById(object id)
        {
            return _innerDao.FindById(id);
        }
        
        /// <summary>
        /// Add CashIoTransaction to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public CashIoTransaction Add(CashIoTransaction data)
        {
            _innerDao.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update CashIoTransaction to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(CashIoTransaction data)
        {
            _innerDao.Update(data);
        }
        
        /// <summary>
        /// Delete CashIoTransaction from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(CashIoTransaction data)
        {
            _innerDao.Delete(data);
        }
        
        /// <summary>
        /// Delete CashIoTransaction from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            _innerDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all CashIoTransaction from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return _innerDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all CashIoTransaction from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return _innerDao.FindPaging(criteria);
        }
    }
}