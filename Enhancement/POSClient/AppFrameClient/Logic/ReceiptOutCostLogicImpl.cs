using System.Collections;
using Spring.Transaction.Interceptor;
using AppFrame.Model;
using AppFrame.DataLayer;

namespace AppFrame.Logic
{
    public class ReceiptOutCostLogicImpl : IReceiptOutCostLogic
    {
        private IReceiptOutCostDAO _receiptOutCostDAO;

        public IReceiptOutCostDAO ReceiptOutCostDAO
        {
            get 
            { 
                return _receiptOutCostDAO; 
            }
            set 
            { 
                _receiptOutCostDAO = value; 
            }
        }
        
        /// <summary>
        /// Find ReceiptOutCost object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of ReceiptOutCost</param>
        /// <returns></returns>
        public ReceiptOutCost FindById(object id)
        {
            return ReceiptOutCostDAO.FindById(id);
        }
        
        /// <summary>
        /// Add ReceiptOutCost to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public ReceiptOutCost Add(ReceiptOutCost data)
        {
            ReceiptOutCostDAO.Add(data);
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
            ReceiptOutCostDAO.Update(data);
        }
        
        /// <summary>
        /// Delete ReceiptOutCost from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(ReceiptOutCost data)
        {
            ReceiptOutCostDAO.Delete(data);
        }
        
        /// <summary>
        /// Delete ReceiptOutCost from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            ReceiptOutCostDAO.DeleteById(id);
        }
        
        /// <summary>
        /// Find all ReceiptOutCost from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return ReceiptOutCostDAO.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all ReceiptOutCost from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return ReceiptOutCostDAO.FindPaging(criteria);
        }
    }
}