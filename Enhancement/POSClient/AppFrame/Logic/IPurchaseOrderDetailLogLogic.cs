using System;
using System.Collections;
using AppFrame.Model;

namespace AppFrame.Logic
{
    public interface IPurchaseOrderDetailLogLogic
    {
        /// <summary>
        /// Find PurchaseOrderDetailLog object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of PurchaseOrderDetailLog</param>
        /// <returns></returns>
        PurchaseOrderDetailLog FindById(object id);
        
        /// <summary>
        /// Add PurchaseOrderDetailLog to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        PurchaseOrderDetailLog Add(PurchaseOrderDetailLog data);
        
        /// <summary>
        /// Update PurchaseOrderDetailLog to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update(PurchaseOrderDetailLog data);
        
        /// <summary>
        /// Delete PurchaseOrderDetailLog from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete(PurchaseOrderDetailLog data);
        
        /// <summary>
        /// Delete PurchaseOrderDetailLog from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all PurchaseOrderDetailLog from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all PurchaseOrderDetailLog from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
    }
}