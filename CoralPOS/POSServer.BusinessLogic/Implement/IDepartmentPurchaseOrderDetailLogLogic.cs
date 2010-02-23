			 
			 

using System;
using System.Collections;
using CoralPOS.Models;

namespace POSServer.DataLayer.Implement
{
    public interface IDepartmentPurchaseOrderDetailLogLogic
    {
        /// <summary>
        /// Find  DepartmentPurchaseOrderDetailLog object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of  DepartmentPurchaseOrderDetailLog</param>
        /// <returns></returns>
         DepartmentPurchaseOrderDetailLog FindById(object id);
        
        /// <summary>
        /// Add  DepartmentPurchaseOrderDetailLog to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
         DepartmentPurchaseOrderDetailLog Add( DepartmentPurchaseOrderDetailLog data);
        
        /// <summary>
        /// Update  DepartmentPurchaseOrderDetailLog to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update( DepartmentPurchaseOrderDetailLog data);
        
        /// <summary>
        /// Delete  DepartmentPurchaseOrderDetailLog from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete( DepartmentPurchaseOrderDetailLog data);
        
        /// <summary>
        /// Delete  DepartmentPurchaseOrderDetailLog from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all  DepartmentPurchaseOrderDetailLog from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all  DepartmentPurchaseOrderDetailLog from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
    }
}