			 


using System.Collections;
using System.Collections.Generic;
using Spring.Transaction.Interceptor;
using  CoralPOS.Models;
using  POSServer.DataLayer.Implement;

namespace POSServer.BusinessLogic.Implement
{
    public class SaleTransactionLogic : ISaleTransactionLogic
    {
        private ISaleTransactionDao _innerDao;
        public ISaleTransactionDao SaleTransactionDao
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
        /// Find SaleTransaction object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of SaleTransaction</param>
        /// <returns></returns>
        public SaleTransaction FindById(object id)
        {
            return SaleTransactionDao.FindById(id);
        }
        
        /// <summary>
        /// Add SaleTransaction to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public SaleTransaction Add(SaleTransaction data)
        {
            SaleTransactionDao.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update SaleTransaction to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(SaleTransaction data)
        {
            SaleTransactionDao.Update(data);
        }
        
        /// <summary>
        /// Delete SaleTransaction from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(SaleTransaction data)
        {
            SaleTransactionDao.Delete(data);
        }
        
        /// <summary>
        /// Delete SaleTransaction from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            SaleTransactionDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all SaleTransaction from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<SaleTransaction> FindAll(ObjectCriteria criteria)
        {
            return SaleTransactionDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all SaleTransaction from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return SaleTransactionDao.FindPaging(criteria);
        }
    }
}