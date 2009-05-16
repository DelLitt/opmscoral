using System;
using System.Collections;
using AppFrame.Model;
using NHibernate.Criterion;

namespace AppFrame.DataLayer
{
    public interface ISyncStatusDAO
    {
        /// <summary>
        /// Find SyncStatus object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of SyncStatus</param>
        /// <returns></returns>
        SyncStatus FindById(object id);
        
        /// <summary>
        /// Add SyncStatus to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        SyncStatus Add(SyncStatus data);
        
        /// <summary>
        /// Update SyncStatus to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update(SyncStatus data);
        
        /// <summary>
        /// Delete SyncStatus from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete(SyncStatus data);
        
        /// <summary>
        /// Delete SyncStatus from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all SyncStatus from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all SyncStatus from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
        
        /// <summary>
        /// Find min, max, count... SyncStatus from database.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        object SelectSpecificType(ObjectCriteria criteria, IProjection type);
    }
}