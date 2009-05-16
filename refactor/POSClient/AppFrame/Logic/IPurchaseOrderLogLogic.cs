using System;
using System.Collections;
using AppFrame.Model;

namespace AppFrame.Logic
{
    public interface IPurchaseOrderLogLogic
    {
        /// <summary>
        /// Find PurchaseOrderLog object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of PurchaseOrderLog</param>
        /// <returns></returns>
        PurchaseOrderLog FindById(object id);
        
        /// <summary>
        /// Add PurchaseOrderLog to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        PurchaseOrderLog Add(PurchaseOrderLog data);
        
        /// <summary>
        /// Update PurchaseOrderLog to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update(PurchaseOrderLog data);
        
        /// <summary>
        /// Delete PurchaseOrderLog from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete(PurchaseOrderLog data);
        
        /// <summary>
        /// Delete PurchaseOrderLog from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all PurchaseOrderLog from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all PurchaseOrderLog from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
    }
}