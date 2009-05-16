using System;
using System.Collections;
using AppFrame.Model;

namespace AppFrame.Logic
{
    public interface IPurchaseOrderDetailLogic
    {
        /// <summary>
        /// Find PurchaseOrderDetail object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of PurchaseOrderDetail</param>
        /// <returns></returns>
        PurchaseOrderDetail FindById(object id);
        
        /// <summary>
        /// Add PurchaseOrderDetail to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        PurchaseOrderDetail Add(PurchaseOrderDetail data);
        
        /// <summary>
        /// Update PurchaseOrderDetail to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update(PurchaseOrderDetail data);
        
        /// <summary>
        /// Delete PurchaseOrderDetail from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete(PurchaseOrderDetail data);
        
        /// <summary>
        /// Delete PurchaseOrderDetail from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all PurchaseOrderDetail from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all PurchaseOrderDetail from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
    }
}