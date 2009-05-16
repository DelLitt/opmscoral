using System.Collections;
using Spring.Transaction.Interceptor;
using AppFrame.Model;
using AppFrame.DataLayer;

namespace AppFrame.Logic
{
    public class ReceiptLogicImpl : IReceiptLogic
    {
        private IReceiptDAO _receiptDAO;

        public IReceiptDAO ReceiptDAO
        {
            get 
            { 
                return _receiptDAO; 
            }
            set 
            { 
                _receiptDAO = value; 
            }
        }
        
        /// <summary>
        /// Find Receipt object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of Receipt</param>
        /// <returns></returns>
        public Receipt FindById(object id)
        {
            return ReceiptDAO.FindById(id);
        }
        
        /// <summary>
        /// Add Receipt to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public Receipt Add(Receipt data)
        {
            ReceiptDAO.Add(data);
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
            ReceiptDAO.Update(data);
        }
        
        /// <summary>
        /// Delete Receipt from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(Receipt data)
        {
            ReceiptDAO.Delete(data);
        }
        
        /// <summary>
        /// Delete Receipt from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            ReceiptDAO.DeleteById(id);
        }
        
        /// <summary>
        /// Find all Receipt from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return ReceiptDAO.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all Receipt from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return ReceiptDAO.FindPaging(criteria);
        }
    }
}