
using System;

namespace POSServer.DataLayer.Implement
{
	
    public interface IMainStockDao
    {
        /// <summary>
        /// Find MainStock object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of MainStock</param>
        /// <returns></returns>
        MainStock FindById(object id);
        
        /// <summary>
        /// Add MainStock to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        MainStock Add(MainStock data);
        
        /// <summary>
        /// Update MainStock to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Update(MainStock data);
        
        /// <summary>
        /// Delete MainStock from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Delete(MainStock data);
        
        /// <summary>
        /// Delete MainStock from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DeleteById(object id);
        
        /// <summary>
        /// Find all MainStock from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList<MainStock> FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all MainStock from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
        
        /// <summary>
        /// Find min, max, count... MainStock from database.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        object SelectSpecificType(ObjectCriteria criteria, IProjection type); 
    }
}
