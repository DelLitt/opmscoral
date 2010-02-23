
using System;

namespace POSServer.DataLayer.Implement
{
	
    public interface ISyncStatususDao
    {
        /// <summary>
        /// Find SyncStatusus object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of SyncStatusus</param>
        /// <returns></returns>
        SyncStatusus FindById(object id);
        
        /// <summary>
        /// Add SyncStatusus to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        SyncStatusus Add(SyncStatusus data);
        
        /// <summary>
        /// Update SyncStatusus to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Update(SyncStatusus data);
        
        /// <summary>
        /// Delete SyncStatusus from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Delete(SyncStatusus data);
        
        /// <summary>
        /// Delete SyncStatusus from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DeleteById(object id);
        
        /// <summary>
        /// Find all SyncStatusus from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList<SyncStatusus> FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all SyncStatusus from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
        
        /// <summary>
        /// Find min, max, count... SyncStatusus from database.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        object SelectSpecificType(ObjectCriteria criteria, IProjection type); 
    }
}
