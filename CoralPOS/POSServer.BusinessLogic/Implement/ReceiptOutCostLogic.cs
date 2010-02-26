			 


using System.Collections;
using System.Collections.Generic;
using Spring.Transaction.Interceptor;
using  CoralPOS.Models;
using  POSServer.DataLayer.Implement;

namespace POSServer.BusinessLogic.Implement
{
    public class ReceiptOutCostLogicImpl : IReceiptOutCostLogic
    {
        private IReceiptOutCostDao _innerDao;

        public IReceiptOutCostDao ReceiptOutCostDao
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
        /// Find ReceiptOutCost object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of ReceiptOutCost</param>
        /// <returns></returns>
        public ReceiptOutCost FindById(object id)
        {
            return _innerDao.FindById(id);
        }
        
        /// <summary>
        /// Add ReceiptOutCost to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public ReceiptOutCost Add(ReceiptOutCost data)
        {
            _innerDao.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update ReceiptOutCost to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(ReceiptOutCost data)
        {
            _innerDao.Update(data);
        }
        
        /// <summary>
        /// Delete ReceiptOutCost from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(ReceiptOutCost data)
        {
            _innerDao.Delete(data);
        }
        
        /// <summary>
        /// Delete ReceiptOutCost from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            _innerDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all ReceiptOutCost from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<ReceiptOutCost> FindAll(ObjectCriteria criteria)
        {
            return _innerDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all ReceiptOutCost from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return _innerDao.FindPaging(criteria);
        }
    }
}