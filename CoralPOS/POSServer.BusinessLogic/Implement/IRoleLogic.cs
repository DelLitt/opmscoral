			 
			 

using System;
using System.Collections;
using CoralPOS.Models;

namespace POSServer.DataLayer.Implement
{
    public interface IRoleLogic
    {
        /// <summary>
        /// Find  Role object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of  Role</param>
        /// <returns></returns>
         Role FindById(object id);
        
        /// <summary>
        /// Add  Role to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
         Role Add( Role data);
        
        /// <summary>
        /// Update  Role to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update( Role data);
        
        /// <summary>
        /// Delete  Role from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete( Role data);
        
        /// <summary>
        /// Delete  Role from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all  Role from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all  Role from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
    }
}