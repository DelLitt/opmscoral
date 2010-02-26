			 


using System.Collections;
using System.Collections.Generic;
using Spring.Transaction.Interceptor;
using  CoralPOS.Models;
using  POSServer.DataLayer.Implement;

namespace POSServer.BusinessLogic.Implement
{
    public class ReceiptOutLogicImpl : IReceiptOutLogic
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
            return _innerDao.FindById(id);
        }
        
        /// <summary>
        /// Add ReceiptOut to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public ReceiptOut Add(ReceiptOut data)
        {
            _innerDao.Add(data);
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
            _innerDao.Update(data);
        }
        
        /// <summary>
        /// Delete ReceiptOut from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(ReceiptOut data)
        {
            _innerDao.Delete(data);
        }
        
        /// <summary>
        /// Delete ReceiptOut from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            _innerDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all ReceiptOut from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<ReceiptOut> FindAll(ObjectCriteria criteria)
        {
            return _innerDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all ReceiptOut from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return _innerDao.FindPaging(criteria);
        }
    }
}