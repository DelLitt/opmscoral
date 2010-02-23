
using System;

namespace POSServer.DataLayer.Implement
{
	
    public interface IUserInfoDao
    {
        /// <summary>
        /// Find UserInfo object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of UserInfo</param>
        /// <returns></returns>
        UserInfo FindById(object id);
        
        /// <summary>
        /// Add UserInfo to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        UserInfo Add(UserInfo data);
        
        /// <summary>
        /// Update UserInfo to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Update(UserInfo data);
        
        /// <summary>
        /// Delete UserInfo from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Delete(UserInfo data);
        
        /// <summary>
        /// Delete UserInfo from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DeleteById(object id);
        
        /// <summary>
        /// Find all UserInfo from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList<UserInfo> FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all UserInfo from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
        
        /// <summary>
        /// Find min, max, count... UserInfo from database.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        object SelectSpecificType(ObjectCriteria criteria, IProjection type); 
    }
}
