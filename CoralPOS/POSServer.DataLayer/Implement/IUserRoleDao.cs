
using System;

namespace POSServer.DataLayer.Implement
{
	
    public interface IUserRoleDao
    {
        /// <summary>
        /// Find UserRole object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of UserRole</param>
        /// <returns></returns>
        UserRole FindById(object id);
        
        /// <summary>
        /// Add UserRole to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        UserRole Add(UserRole data);
        
        /// <summary>
        /// Update UserRole to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Update(UserRole data);
        
        /// <summary>
        /// Delete UserRole from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Delete(UserRole data);
        
        /// <summary>
        /// Delete UserRole from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DeleteById(object id);
        
        /// <summary>
        /// Find all UserRole from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList<UserRole> FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all UserRole from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
        
        /// <summary>
        /// Find min, max, count... UserRole from database.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        object SelectSpecificType(ObjectCriteria criteria, IProjection type); 
    }
}
