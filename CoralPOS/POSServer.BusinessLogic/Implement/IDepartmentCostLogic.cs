			 
			 

using System;
using System.Collections;
using CoralPOS.Models;

namespace POSServer.DataLayer.Implement
{
    public interface IDepartmentCostLogic
    {
        /// <summary>
        /// Find  DepartmentCost object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of  DepartmentCost</param>
        /// <returns></returns>
         DepartmentCost FindById(object id);
        
        /// <summary>
        /// Add  DepartmentCost to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
         DepartmentCost Add( DepartmentCost data);
        
        /// <summary>
        /// Update  DepartmentCost to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update( DepartmentCost data);
        
        /// <summary>
        /// Delete  DepartmentCost from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete( DepartmentCost data);
        
        /// <summary>
        /// Delete  DepartmentCost from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all  DepartmentCost from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all  DepartmentCost from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
    }
}