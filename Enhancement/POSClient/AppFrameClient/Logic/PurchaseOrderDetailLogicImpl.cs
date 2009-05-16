using System.Collections;
using Spring.Transaction.Interceptor;
using AppFrame.Model;
using AppFrame.DataLayer;

namespace AppFrame.Logic
{
    public class PurchaseOrderDetailLogicImpl : IPurchaseOrderDetailLogic
    {
        private IPurchaseOrderDetailDAO _purchaseOrderDetailDAO;

        public IPurchaseOrderDetailDAO PurchaseOrderDetailDAO
        {
            get 
            { 
                return _purchaseOrderDetailDAO; 
            }
            set 
            { 
                _purchaseOrderDetailDAO = value; 
            }
        }
        
        /// <summary>
        /// Find PurchaseOrderDetail object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of PurchaseOrderDetail</param>
        /// <returns></returns>
        public PurchaseOrderDetail FindById(object id)
        {
            return PurchaseOrderDetailDAO.FindById(id);
        }
        
        /// <summary>
        /// Add PurchaseOrderDetail to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public PurchaseOrderDetail Add(PurchaseOrderDetail data)
        {
            PurchaseOrderDetailDAO.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update PurchaseOrderDetail to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(PurchaseOrderDetail data)
        {
            PurchaseOrderDetailDAO.Update(data);
        }
        
        /// <summary>
        /// Delete PurchaseOrderDetail from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(PurchaseOrderDetail data)
        {
            PurchaseOrderDetailDAO.Delete(data);
        }
        
        /// <summary>
        /// Delete PurchaseOrderDetail from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            PurchaseOrderDetailDAO.DeleteById(id);
        }
        
        /// <summary>
        /// Find all PurchaseOrderDetail from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return PurchaseOrderDetailDAO.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all PurchaseOrderDetail from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return PurchaseOrderDetailDAO.FindPaging(criteria);
        }
    }
}