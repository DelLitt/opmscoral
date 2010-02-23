			 
			 

using System;
using System.Collections;
using CoralPOS.Models;

namespace POSServer.DataLayer.Implement
{
    public interface IDepartmentReturnCostLogic
    {
        /// <summary>
        /// Find  DepartmentReturnCost object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of  DepartmentReturnCost</param>
        /// <returns></returns>
         DepartmentReturnCost FindById(object id);
        
        /// <summary>
        /// Add  DepartmentReturnCost to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
         DepartmentReturnCost Add( DepartmentReturnCost data);
        
        /// <summary>
        /// Update  DepartmentReturnCost to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update( DepartmentReturnCost data);
        
        /// <summary>
        /// Delete  DepartmentReturnCost from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete( DepartmentReturnCost data);
        
        /// <summary>
        /// Delete  DepartmentReturnCost from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all  DepartmentReturnCost from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all  DepartmentReturnCost from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
    }
}