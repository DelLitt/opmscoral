using System.Collections;
using Spring.Transaction.Interceptor;
using AppFrame.Model;
using AppFrame.DataLayer;

namespace AppFrame.Logic
{
    public class PurchaseOrderPromotionLogicImpl : IPurchaseOrderPromotionLogic
    {
        private IPurchaseOrderPromotionDAO _purchaseOrderPromotionDAO;

        public IPurchaseOrderPromotionDAO PurchaseOrderPromotionDAO
        {
            get 
            { 
                return _purchaseOrderPromotionDAO; 
            }
            set 
            { 
                _purchaseOrderPromotionDAO = value; 
            }
        }
        
        /// <summary>
        /// Find PurchaseOrderPromotion object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of PurchaseOrderPromotion</param>
        /// <returns></returns>
        public PurchaseOrderPromotion FindById(object id)
        {
            return PurchaseOrderPromotionDAO.FindById(id);
        }
        
        /// <summary>
        /// Add PurchaseOrderPromotion to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public PurchaseOrderPromotion Add(PurchaseOrderPromotion data)
        {
            PurchaseOrderPromotionDAO.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update PurchaseOrderPromotion to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(PurchaseOrderPromotion data)
        {
            PurchaseOrderPromotionDAO.Update(data);
        }
        
        /// <summary>
        /// Delete PurchaseOrderPromotion from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(PurchaseOrderPromotion data)
        {
            PurchaseOrderPromotionDAO.Delete(data);
        }
        
        /// <summary>
        /// Delete PurchaseOrderPromotion from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            PurchaseOrderPromotionDAO.DeleteById(id);
        }
        
        /// <summary>
        /// Find all PurchaseOrderPromotion from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return PurchaseOrderPromotionDAO.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all PurchaseOrderPromotion from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return PurchaseOrderPromotionDAO.FindPaging(criteria);
        }
    }
}