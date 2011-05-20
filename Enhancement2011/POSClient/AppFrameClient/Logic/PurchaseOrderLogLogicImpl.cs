using System.Collections;
using Spring.Transaction.Interceptor;
using AppFrame.Model;
using AppFrame.DataLayer;

namespace AppFrame.Logic
{
    public class PurchaseOrderLogLogicImpl : IPurchaseOrderLogLogic
    {
        private IPurchaseOrderLogDAO _purchaseOrderLogDAO;

        public IPurchaseOrderLogDAO PurchaseOrderLogDAO
        {
            get 
            { 
                return _purchaseOrderLogDAO; 
            }
            set 
            { 
                _purchaseOrderLogDAO = value; 
            }
        }
        
        /// <summary>
        /// Find PurchaseOrderLog object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of PurchaseOrderLog</param>
        /// <returns></returns>
        public PurchaseOrderLog FindById(object id)
        {
            return PurchaseOrderLogDAO.FindById(id);
        }
        
        /// <summary>
        /// Add PurchaseOrderLog to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public PurchaseOrderLog Add(PurchaseOrderLog data)
        {
            PurchaseOrderLogDAO.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update PurchaseOrderLog to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(PurchaseOrderLog data)
        {
            PurchaseOrderLogDAO.Update(data);
        }
        
        /// <summary>
        /// Delete PurchaseOrderLog from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(PurchaseOrderLog data)
        {
            PurchaseOrderLogDAO.Delete(data);
        }
        
        /// <summary>
        /// Delete PurchaseOrderLog from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            PurchaseOrderLogDAO.DeleteById(id);
        }
        
        /// <summary>
        /// Find all PurchaseOrderLog from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return PurchaseOrderLogDAO.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all PurchaseOrderLog from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return PurchaseOrderLogDAO.FindPaging(criteria);
        }
    }
}