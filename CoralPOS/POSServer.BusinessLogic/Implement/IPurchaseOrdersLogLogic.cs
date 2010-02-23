			 
			 

using System;
using System.Collections;
using CoralPOS.Models;

namespace POSServer.DataLayer.Implement
{
    public interface IPurchaseOrdersLogLogic
    {
        /// <summary>
        /// Find  PurchaseOrdersLog object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of  PurchaseOrdersLog</param>
        /// <returns></returns>
         PurchaseOrdersLog FindById(object id);
        
        /// <summary>
        /// Add  PurchaseOrdersLog to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
         PurchaseOrdersLog Add( PurchaseOrdersLog data);
        
        /// <summary>
        /// Update  PurchaseOrdersLog to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update( PurchaseOrdersLog data);
        
        /// <summary>
        /// Delete  PurchaseOrdersLog from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete( PurchaseOrdersLog data);
        
        /// <summary>
        /// Delete  PurchaseOrdersLog from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all  PurchaseOrdersLog from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all  PurchaseOrdersLog from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
    }
}