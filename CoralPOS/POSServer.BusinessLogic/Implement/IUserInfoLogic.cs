			 
			 

using System;
using System.Collections;
using CoralPOS.Models;

namespace POSServer.DataLayer.Implement
{
    public interface IUserInfoLogic
    {
        /// <summary>
        /// Find  UserInfo object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of  UserInfo</param>
        /// <returns></returns>
         UserInfo FindById(object id);
        
        /// <summary>
        /// Add  UserInfo to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
         UserInfo Add( UserInfo data);
        
        /// <summary>
        /// Update  UserInfo to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update( UserInfo data);
        
        /// <summary>
        /// Delete  UserInfo from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete( UserInfo data);
        
        /// <summary>
        /// Delete  UserInfo from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all  UserInfo from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all  UserInfo from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
    }
}