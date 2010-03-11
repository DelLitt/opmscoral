			 


using System.Collections;
using System.Collections.Generic;
using Spring.Transaction.Interceptor;
using  CoralPOS.Models;
using  POSServer.DataLayer.Implement;

namespace POSServer.BusinessLogic.Implement
{
    public class ReceiptLogic : IReceiptLogic
    {
        private IReceiptDao _innerDao;
        public IReceiptDao ReceiptDao
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
        /// Find Receipt object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of Receipt</param>
        /// <returns></returns>
        public Receipt FindById(object id)
        {
            return ReceiptDao.FindById(id);
        }
        
        /// <summary>
        /// Add Receipt to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public Receipt Add(Receipt data)
        {
            ReceiptDao.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update Receipt to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(Receipt data)
        {
            ReceiptDao.Update(data);
        }
        
        /// <summary>
        /// Delete Receipt from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(Receipt data)
        {
            ReceiptDao.Delete(data);
        }
        
        /// <summary>
        /// Delete Receipt from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            ReceiptDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all Receipt from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<Receipt> FindAll(ObjectCriteria criteria)
        {
            return ReceiptDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all Receipt from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return ReceiptDao.FindPaging(criteria);
        }
    }
}