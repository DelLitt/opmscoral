			 
			 

using System;
using System.Collections;
using CoralPOS.Models;

namespace POSServer.DataLayer.Implement
{
    public interface IDepartmentReturnLogic
    {
        /// <summary>
        /// Find  DepartmentReturn object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of  DepartmentReturn</param>
        /// <returns></returns>
         DepartmentReturn FindById(object id);
        
        /// <summary>
        /// Add  DepartmentReturn to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
         DepartmentReturn Add( DepartmentReturn data);
        
        /// <summary>
        /// Update  DepartmentReturn to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update( DepartmentReturn data);
        
        /// <summary>
        /// Delete  DepartmentReturn from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete( DepartmentReturn data);
        
        /// <summary>
        /// Delete  DepartmentReturn from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all  DepartmentReturn from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all  DepartmentReturn from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
    }
}