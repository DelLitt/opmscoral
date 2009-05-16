using System.Collections;
using Spring.Transaction.Interceptor;
using AppFrame.Model;
using AppFrame.DataLayer;

namespace AppFrame.Logic
{
    public class ReceiptOutLogicImpl : IReceiptOutLogic
    {
        private IReceiptOutDAO _receiptOutDAO;

        public IReceiptOutDAO ReceiptOutDAO
        {
            get 
            { 
                return _receiptOutDAO; 
            }
            set 
            { 
                _receiptOutDAO = value; 
            }
        }
        
        /// <summary>
        /// Find ReceiptOut object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of ReceiptOut</param>
        /// <returns></returns>
        public ReceiptOut FindById(object id)
        {
            return ReceiptOutDAO.FindById(id);
        }
        
        /// <summary>
        /// Add ReceiptOut to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public ReceiptOut Add(ReceiptOut data)
        {
            ReceiptOutDAO.Add(data);
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
            ReceiptOutDAO.Update(data);
        }
        
        /// <summary>
        /// Delete ReceiptOut from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(ReceiptOut data)
        {
            ReceiptOutDAO.Delete(data);
        }
        
        /// <summary>
        /// Delete ReceiptOut from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            ReceiptOutDAO.DeleteById(id);
        }
        
        /// <summary>
        /// Find all ReceiptOut from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return ReceiptOutDAO.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all ReceiptOut from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return ReceiptOutDAO.FindPaging(criteria);
        }
    }
}