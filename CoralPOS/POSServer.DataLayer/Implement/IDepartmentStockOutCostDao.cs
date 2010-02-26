			 
using System;
using System.Collections;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;
using Spring.Data.NHibernate;
using CoralPOS.Models;

namespace POSServer.DataLayer.Implement
{
	
    public interface IDepartmentStockOutCostDao
    {
        /// <summary>
        /// Find DepartmentStockOutCost object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of DepartmentStockOutCost</param>
        /// <returns></returns>
        DepartmentStockOutCost FindById(object id);
        
        /// <summary>
        /// Add DepartmentStockOutCost to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        DepartmentStockOutCost Add(DepartmentStockOutCost data);
        
        /// <summary>
        /// Update DepartmentStockOutCost to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Update(DepartmentStockOutCost data);
        
        /// <summary>
        /// Delete DepartmentStockOutCost from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Delete(DepartmentStockOutCost data);
        
        /// <summary>
        /// Delete DepartmentStockOutCost from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DeleteById(object id);
        
        /// <summary>
        /// Find all DepartmentStockOutCost from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList<DepartmentStockOutCost> FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all DepartmentStockOutCost from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
        
        /// <summary>
        /// Find min, max, count... DepartmentStockOutCost from database.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        object SelectSpecificType(ObjectCriteria criteria, IProjection type); 
    }
}
