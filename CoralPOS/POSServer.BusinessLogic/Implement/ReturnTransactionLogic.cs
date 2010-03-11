			 


using System.Collections;
using System.Collections.Generic;
using Spring.Transaction.Interceptor;
using  CoralPOS.Models;
using  POSServer.DataLayer.Implement;

namespace POSServer.BusinessLogic.Implement
{
    public class ReturnTransactionLogic : IReturnTransactionLogic
    {
        private IReturnTransactionDao _innerDao;
        public IReturnTransactionDao ReturnTransactionDao
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
        /// Find ReturnTransaction object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of ReturnTransaction</param>
        /// <returns></returns>
        public ReturnTransaction FindById(object id)
        {
            return ReturnTransactionDao.FindById(id);
        }
        
        /// <summary>
        /// Add ReturnTransaction to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public ReturnTransaction Add(ReturnTransaction data)
        {
            ReturnTransactionDao.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update ReturnTransaction to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(ReturnTransaction data)
        {
            ReturnTransactionDao.Update(data);
        }
        
        /// <summary>
        /// Delete ReturnTransaction from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(ReturnTransaction data)
        {
            ReturnTransactionDao.Delete(data);
        }
        
        /// <summary>
        /// Delete ReturnTransaction from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            ReturnTransactionDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all ReturnTransaction from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<ReturnTransaction> FindAll(ObjectCriteria criteria)
        {
            return ReturnTransactionDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all ReturnTransaction from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return ReturnTransactionDao.FindPaging(criteria);
        }
    }
}