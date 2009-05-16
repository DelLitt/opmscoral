using System;
using System.Collections;
using AppFrame.Model;

namespace AppFrame.Logic
{
    public interface IPurchaseOrderLogic
    {
        /// <summary>
        /// Find PurchaseOrder object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of PurchaseOrder</param>
        /// <returns></returns>
        PurchaseOrder FindById(object id);
        
        /// <summary>
        /// Add PurchaseOrder to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        PurchaseOrder Add(PurchaseOrder data);
        
        /// <summary>
        /// Update PurchaseOrder to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update(PurchaseOrder data);
        
        /// <summary>
        /// Delete PurchaseOrder from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete(PurchaseOrder data);
        
        /// <summary>
        /// Delete PurchaseOrder from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all PurchaseOrder from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all PurchaseOrder from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
    }
}