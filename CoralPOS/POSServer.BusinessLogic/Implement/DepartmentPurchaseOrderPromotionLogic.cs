			 


using System.Collections;
using System.Collections.Generic;
using Spring.Transaction.Interceptor;
using  CoralPOS.Models;
using  POSServer.DataLayer.Implement;

namespace POSServer.BusinessLogic.Implement
{
    public class DepartmentPurchaseOrderPromotionLogic : IDepartmentPurchaseOrderPromotionLogic
    {
        private IDepartmentPurchaseOrderPromotionDao _innerDao;
        public IDepartmentPurchaseOrderPromotionDao DepartmentPurchaseOrderPromotionDao
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
        /// Find DepartmentPurchaseOrderPromotion object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of DepartmentPurchaseOrderPromotion</param>
        /// <returns></returns>
        public DepartmentPurchaseOrderPromotion FindById(object id)
        {
            return DepartmentPurchaseOrderPromotionDao.FindById(id);
        }
        
        /// <summary>
        /// Add DepartmentPurchaseOrderPromotion to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public DepartmentPurchaseOrderPromotion Add(DepartmentPurchaseOrderPromotion data)
        {
            DepartmentPurchaseOrderPromotionDao.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update DepartmentPurchaseOrderPromotion to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(DepartmentPurchaseOrderPromotion data)
        {
            DepartmentPurchaseOrderPromotionDao.Update(data);
        }
        
        /// <summary>
        /// Delete DepartmentPurchaseOrderPromotion from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(DepartmentPurchaseOrderPromotion data)
        {
            DepartmentPurchaseOrderPromotionDao.Delete(data);
        }
        
        /// <summary>
        /// Delete DepartmentPurchaseOrderPromotion from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            DepartmentPurchaseOrderPromotionDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all DepartmentPurchaseOrderPromotion from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<DepartmentPurchaseOrderPromotion> FindAll(ObjectCriteria criteria)
        {
            return DepartmentPurchaseOrderPromotionDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all DepartmentPurchaseOrderPromotion from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return DepartmentPurchaseOrderPromotionDao.FindPaging(criteria);
        }
    }
}