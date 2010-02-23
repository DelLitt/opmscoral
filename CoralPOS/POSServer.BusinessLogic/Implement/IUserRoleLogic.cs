			 
			 

using System;
using System.Collections;
using CoralPOS.Models;

namespace POSServer.DataLayer.Implement
{
    public interface IUserRoleLogic
    {
        /// <summary>
        /// Find  UserRole object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of  UserRole</param>
        /// <returns></returns>
         UserRole FindById(object id);
        
        /// <summary>
        /// Add  UserRole to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
         UserRole Add( UserRole data);
        
        /// <summary>
        /// Update  UserRole to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update( UserRole data);
        
        /// <summary>
        /// Delete  UserRole from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete( UserRole data);
        
        /// <summary>
        /// Delete  UserRole from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all  UserRole from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all  UserRole from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
    }
}