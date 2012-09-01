			 


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
using  POSClient.DataLayer.Implement;

namespace POSClient.BusinessLogic.Implement
{
    public class TransactionLogic : ITransactionLogic
    {
        private ITransactionDao _innerDao;
        public ITransactionDao TransactionDao
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
        /// Find Transaction object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of Transaction</param>
        /// <returns></returns>
        public Transaction FindById(object id)
        {
            return TransactionDao.FindById(id);
        }
        
        /// <summary>
        /// Add Transaction to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public Transaction Add(Transaction data)
        {
            TransactionDao.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update Transaction to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(Transaction data)
        {
            TransactionDao.Update(data);
        }
        
        /// <summary>
        /// Delete Transaction from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(Transaction data)
        {
            TransactionDao.Delete(data);
        }
        
        /// <summary>
        /// Delete Transaction from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            TransactionDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all Transaction from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<Transaction> FindAll(ObjectCriteria<Transaction> criteria)
        {
            return TransactionDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all Transaction from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria<Transaction> criteria)
        {
            return TransactionDao.FindPaging(criteria);
        }
    }
}