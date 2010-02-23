			 
			 

using System;
using System.Collections;
using CoralPOS.Models;

namespace POSServer.DataLayer.Implement
{
    public interface IDepartmentStockOutCostLogic
    {
        /// <summary>
        /// Find  DepartmentStockOutCost object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of  DepartmentStockOutCost</param>
        /// <returns></returns>
         DepartmentStockOutCost FindById(object id);
        
        /// <summary>
        /// Add  DepartmentStockOutCost to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
         DepartmentStockOutCost Add( DepartmentStockOutCost data);
        
        /// <summary>
        /// Update  DepartmentStockOutCost to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update( DepartmentStockOutCost data);
        
        /// <summary>
        /// Delete  DepartmentStockOutCost from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete( DepartmentStockOutCost data);
        
        /// <summary>
        /// Delete  DepartmentStockOutCost from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all  DepartmentStockOutCost from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all  DepartmentStockOutCost from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
    }
}