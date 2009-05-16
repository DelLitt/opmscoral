using System;
using System.Collections;
using AppFrame.Model;
using NHibernate.Criterion;

namespace AppFrame.DataLayer
{
    public interface IPurchaseOrderPromotionDAO
    {
        /// <summary>
        /// Find PurchaseOrderPromotion object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of PurchaseOrderPromotion</param>
        /// <returns></returns>
        PurchaseOrderPromotion FindById(object id);
        
        /// <summary>
        /// Add PurchaseOrderPromotion to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        PurchaseOrderPromotion Add(PurchaseOrderPromotion data);
        
        /// <summary>
        /// Update PurchaseOrderPromotion to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update(PurchaseOrderPromotion data);
        
        /// <summary>
        /// Delete PurchaseOrderPromotion from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete(PurchaseOrderPromotion data);
        
        /// <summary>
        /// Delete PurchaseOrderPromotion from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all PurchaseOrderPromotion from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all PurchaseOrderPromotion from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
        
        /// <summary>
        /// Find min, max, count... PurchaseOrderPromotion from database.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        object SelectSpecificType(ObjectCriteria criteria, IProjection type);
    }
}