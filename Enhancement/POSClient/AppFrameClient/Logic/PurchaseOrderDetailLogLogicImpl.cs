using System.Collections;
using Spring.Transaction.Interceptor;
using AppFrame.Model;
using AppFrame.DataLayer;

namespace AppFrame.Logic
{
    public class PurchaseOrderDetailLogLogicImpl : IPurchaseOrderDetailLogLogic
    {
        private IPurchaseOrderDetailLogDAO _purchaseOrderDetailLogDAO;

        public IPurchaseOrderDetailLogDAO PurchaseOrderDetailLogDAO
        {
            get 
            { 
                return _purchaseOrderDetailLogDAO; 
            }
            set 
            { 
                _purchaseOrderDetailLogDAO = value; 
            }
        }
        
        /// <summary>
        /// Find PurchaseOrderDetailLog object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of PurchaseOrderDetailLog</param>
        /// <returns></returns>
        public PurchaseOrderDetailLog FindById(object id)
        {
            return PurchaseOrderDetailLogDAO.FindById(id);
        }
        
        /// <summary>
        /// Add PurchaseOrderDetailLog to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public PurchaseOrderDetailLog Add(PurchaseOrderDetailLog data)
        {
            PurchaseOrderDetailLogDAO.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update PurchaseOrderDetailLog to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(PurchaseOrderDetailLog data)
        {
            PurchaseOrderDetailLogDAO.Update(data);
        }
        
        /// <summary>
        /// Delete PurchaseOrderDetailLog from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(PurchaseOrderDetailLog data)
        {
            PurchaseOrderDetailLogDAO.Delete(data);
        }
        
        /// <summary>
        /// Delete PurchaseOrderDetailLog from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            PurchaseOrderDetailLogDAO.DeleteById(id);
        }
        
        /// <summary>
        /// Find all PurchaseOrderDetailLog from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return PurchaseOrderDetailLogDAO.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all PurchaseOrderDetailLog from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return PurchaseOrderDetailLogDAO.FindPaging(criteria);
        }
    }
}