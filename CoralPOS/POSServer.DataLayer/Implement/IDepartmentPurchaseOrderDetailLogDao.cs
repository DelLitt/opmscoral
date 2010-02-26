			 
using System;
using System.Collections;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;
using Spring.Data.NHibernate;
using CoralPOS.Models;

namespace POSServer.DataLayer.Implement
{
	
    public interface IDepartmentPurchaseOrderDetailLogDao
    {
        /// <summary>
        /// Find DepartmentPurchaseOrderDetailLog object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of DepartmentPurchaseOrderDetailLog</param>
        /// <returns></returns>
        DepartmentPurchaseOrderDetailLog FindById(object id);
        
        /// <summary>
        /// Add DepartmentPurchaseOrderDetailLog to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        DepartmentPurchaseOrderDetailLog Add(DepartmentPurchaseOrderDetailLog data);
        
        /// <summary>
        /// Update DepartmentPurchaseOrderDetailLog to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Update(DepartmentPurchaseOrderDetailLog data);
        
        /// <summary>
        /// Delete DepartmentPurchaseOrderDetailLog from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Delete(DepartmentPurchaseOrderDetailLog data);
        
        /// <summary>
        /// Delete DepartmentPurchaseOrderDetailLog from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DeleteById(object id);
        
        /// <summary>
        /// Find all DepartmentPurchaseOrderDetailLog from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList<DepartmentPurchaseOrderDetailLog> FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all DepartmentPurchaseOrderDetailLog from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
        
        /// <summary>
        /// Find min, max, count... DepartmentPurchaseOrderDetailLog from database.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        object SelectSpecificType(ObjectCriteria criteria, IProjection type); 
    }
}
