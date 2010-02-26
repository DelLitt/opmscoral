			 
using System;
using System.Collections;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;
using Spring.Data.NHibernate;
using CoralPOS.Models;

namespace POSServer.DataLayer.Implement
{
	
    public interface IDepartmentReturnPurchaseOrderDao
    {
        /// <summary>
        /// Find DepartmentReturnPurchaseOrder object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of DepartmentReturnPurchaseOrder</param>
        /// <returns></returns>
        DepartmentReturnPurchaseOrder FindById(object id);
        
        /// <summary>
        /// Add DepartmentReturnPurchaseOrder to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        DepartmentReturnPurchaseOrder Add(DepartmentReturnPurchaseOrder data);
        
        /// <summary>
        /// Update DepartmentReturnPurchaseOrder to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Update(DepartmentReturnPurchaseOrder data);
        
        /// <summary>
        /// Delete DepartmentReturnPurchaseOrder from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Delete(DepartmentReturnPurchaseOrder data);
        
        /// <summary>
        /// Delete DepartmentReturnPurchaseOrder from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DeleteById(object id);
        
        /// <summary>
        /// Find all DepartmentReturnPurchaseOrder from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList<DepartmentReturnPurchaseOrder> FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all DepartmentReturnPurchaseOrder from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
        
        /// <summary>
        /// Find min, max, count... DepartmentReturnPurchaseOrder from database.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        object SelectSpecificType(ObjectCriteria criteria, IProjection type); 
    }
}
