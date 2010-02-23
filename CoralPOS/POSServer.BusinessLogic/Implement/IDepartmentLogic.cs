			 
			 

using System;
using System.Collections;
using CoralPOS.Models;

namespace POSServer.DataLayer.Implement
{
    public interface IDepartmentLogic
    {
        /// <summary>
        /// Find  Department object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of  Department</param>
        /// <returns></returns>
         Department FindById(object id);
        
        /// <summary>
        /// Add  Department to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
         Department Add( Department data);
        
        /// <summary>
        /// Update  Department to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update( Department data);
        
        /// <summary>
        /// Delete  Department from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete( Department data);
        
        /// <summary>
        /// Delete  Department from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all  Department from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all  Department from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
    }
}