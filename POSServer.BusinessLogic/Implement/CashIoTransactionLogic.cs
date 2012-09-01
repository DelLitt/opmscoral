			 


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
    public class CashIoTransactionLogic : ICashIoTransactionLogic
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
            return CashIoTransactionDao.FindById(id);
        }
        
        /// <summary>
        /// Add CashIoTransaction to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public CashIoTransaction Add(CashIoTransaction data)
        {
            CashIoTransactionDao.Add(data);
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
            CashIoTransactionDao.Update(data);
        }
        
        /// <summary>
        /// Delete CashIoTransaction from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(CashIoTransaction data)
        {
            CashIoTransactionDao.Delete(data);
        }
        
        /// <summary>
        /// Delete CashIoTransaction from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            CashIoTransactionDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all CashIoTransaction from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<CashIoTransaction> FindAll(ObjectCriteria<CashIoTransaction> criteria)
        {
            return CashIoTransactionDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all CashIoTransaction from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria<CashIoTransaction> criteria)
        {
            return CashIoTransactionDao.FindPaging(criteria);
        }
    }
}