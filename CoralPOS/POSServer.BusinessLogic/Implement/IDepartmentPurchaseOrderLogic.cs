			 
			 

using System;
using System.Collections;
using CoralPOS.Models;

namespace POSServer.DataLayer.Implement
{
    public interface IDepartmentPurchaseOrderLogic
    {
        /// <summary>
        /// Find  DepartmentPurchaseOrder object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of  DepartmentPurchaseOrder</param>
        /// <returns></returns>
         DepartmentPurchaseOrder FindById(object id);
        
        /// <summary>
        /// Add  DepartmentPurchaseOrder to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
         DepartmentPurchaseOrder Add( DepartmentPurchaseOrder data);
        
        /// <summary>
        /// Update  DepartmentPurchaseOrder to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update( DepartmentPurchaseOrder data);
        
        /// <summary>
        /// Delete  DepartmentPurchaseOrder from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete( DepartmentPurchaseOrder data);
        
        /// <summary>
        /// Delete  DepartmentPurchaseOrder from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all  DepartmentPurchaseOrder from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all  DepartmentPurchaseOrder from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
    }
}