			 


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
    public class ReceiptOutLogic : IReceiptOutLogic
    {
        private IReceiptOutDao _innerDao;
        public IReceiptOutDao ReceiptOutDao
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
        /// Find ReceiptOut object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of ReceiptOut</param>
        /// <returns></returns>
        public ReceiptOut FindById(object id)
        {
            return ReceiptOutDao.FindById(id);
        }
        
        /// <summary>
        /// Add ReceiptOut to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public ReceiptOut Add(ReceiptOut data)
        {
            ReceiptOutDao.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update ReceiptOut to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(ReceiptOut data)
        {
            ReceiptOutDao.Update(data);
        }
        
        /// <summary>
        /// Delete ReceiptOut from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(ReceiptOut data)
        {
            ReceiptOutDao.Delete(data);
        }
        
        /// <summary>
        /// Delete ReceiptOut from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            ReceiptOutDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all ReceiptOut from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<ReceiptOut> FindAll(ObjectCriteria<ReceiptOut> criteria)
        {
            return ReceiptOutDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all ReceiptOut from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria<ReceiptOut> criteria)
        {
            return ReceiptOutDao.FindPaging(criteria);
        }
    }
}