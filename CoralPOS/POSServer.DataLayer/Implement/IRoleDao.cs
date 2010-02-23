
using System;

namespace POSServer.DataLayer.Implement
{
	
    public interface IRoleDao
    {
        /// <summary>
        /// Find Role object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of Role</param>
        /// <returns></returns>
        Role FindById(object id);
        
        /// <summary>
        /// Add Role to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Role Add(Role data);
        
        /// <summary>
        /// Update Role to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Update(Role data);
        
        /// <summary>
        /// Delete Role from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Delete(Role data);
        
        /// <summary>
        /// Delete Role from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DeleteById(object id);
        
        /// <summary>
        /// Find all Role from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList<Role> FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all Role from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
        
        /// <summary>
        /// Find min, max, count... Role from database.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        object SelectSpecificType(ObjectCriteria criteria, IProjection type); 
    }
}
