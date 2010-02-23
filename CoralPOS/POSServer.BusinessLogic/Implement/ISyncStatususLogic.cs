			 
			 

using System;
using System.Collections;
using CoralPOS.Models;

namespace POSServer.DataLayer.Implement
{
    public interface ISyncStatususLogic
    {
        /// <summary>
        /// Find  SyncStatusus object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of  SyncStatusus</param>
        /// <returns></returns>
         SyncStatusus FindById(object id);
        
        /// <summary>
        /// Add  SyncStatusus to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
         SyncStatusus Add( SyncStatusus data);
        
        /// <summary>
        /// Update  SyncStatusus to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update( SyncStatusus data);
        
        /// <summary>
        /// Delete  SyncStatusus from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete( SyncStatusus data);
        
        /// <summary>
        /// Delete  SyncStatusus from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all  SyncStatusus from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all  SyncStatusus from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
    }
}