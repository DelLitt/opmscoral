			 
using System;
using System.Collections;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;
using Spring.Data.NHibernate;
using CoralPOS.Models;

namespace POSServer.DataLayer.Implement
{
	
    public interface IDepartmentPurchaseOrderLogDao
    {
        /// <summary>
        /// Find DepartmentPurchaseOrderLog object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of DepartmentPurchaseOrderLog</param>
        /// <returns></returns>
        DepartmentPurchaseOrderLog FindById(object id);
        
        /// <summary>
        /// Add DepartmentPurchaseOrderLog to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        DepartmentPurchaseOrderLog Add(DepartmentPurchaseOrderLog data);
        
        /// <summary>
        /// Update DepartmentPurchaseOrderLog to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Update(DepartmentPurchaseOrderLog data);
        
        /// <summary>
        /// Delete DepartmentPurchaseOrderLog from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Delete(DepartmentPurchaseOrderLog data);
        
        /// <summary>
        /// Delete DepartmentPurchaseOrderLog from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DeleteById(object id);
        
        /// <summary>
        /// Find all DepartmentPurchaseOrderLog from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList<DepartmentPurchaseOrderLog> FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all DepartmentPurchaseOrderLog from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
        
        /// <summary>
        /// Find min, max, count... DepartmentPurchaseOrderLog from database.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        object SelectSpecificType(ObjectCriteria criteria, IProjection type); 
    }
}
