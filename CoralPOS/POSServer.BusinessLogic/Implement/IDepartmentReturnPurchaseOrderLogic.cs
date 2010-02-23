			 
			 

using System;
using System.Collections;
using CoralPOS.Models;

namespace POSServer.DataLayer.Implement
{
    public interface IDepartmentReturnPurchaseOrderLogic
    {
        /// <summary>
        /// Find  DepartmentReturnPurchaseOrder object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of  DepartmentReturnPurchaseOrder</param>
        /// <returns></returns>
         DepartmentReturnPurchaseOrder FindById(object id);
        
        /// <summary>
        /// Add  DepartmentReturnPurchaseOrder to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
         DepartmentReturnPurchaseOrder Add( DepartmentReturnPurchaseOrder data);
        
        /// <summary>
        /// Update  DepartmentReturnPurchaseOrder to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update( DepartmentReturnPurchaseOrder data);
        
        /// <summary>
        /// Delete  DepartmentReturnPurchaseOrder from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete( DepartmentReturnPurchaseOrder data);
        
        /// <summary>
        /// Delete  DepartmentReturnPurchaseOrder from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all  DepartmentReturnPurchaseOrder from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all  DepartmentReturnPurchaseOrder from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
    }
}