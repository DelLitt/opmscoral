
using System;

namespace POSServer.DataLayer.Implement
{
	
    public interface IReturnTransactionDao
    {
        /// <summary>
        /// Find ReturnTransaction object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of ReturnTransaction</param>
        /// <returns></returns>
        ReturnTransaction FindById(object id);
        
        /// <summary>
        /// Add ReturnTransaction to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        ReturnTransaction Add(ReturnTransaction data);
        
        /// <summary>
        /// Update ReturnTransaction to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Update(ReturnTransaction data);
        
        /// <summary>
        /// Delete ReturnTransaction from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Delete(ReturnTransaction data);
        
        /// <summary>
        /// Delete ReturnTransaction from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DeleteById(object id);
        
        /// <summary>
        /// Find all ReturnTransaction from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList<ReturnTransaction> FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all ReturnTransaction from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
        
        /// <summary>
        /// Find min, max, count... ReturnTransaction from database.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        object SelectSpecificType(ObjectCriteria criteria, IProjection type); 
    }
}
