
using System;

namespace POSServer.DataLayer.Implement
{
	
    public interface IDistributorDao
    {
        /// <summary>
        /// Find Distributor object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of Distributor</param>
        /// <returns></returns>
        Distributor FindById(object id);
        
        /// <summary>
        /// Add Distributor to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Distributor Add(Distributor data);
        
        /// <summary>
        /// Update Distributor to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Update(Distributor data);
        
        /// <summary>
        /// Delete Distributor from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Delete(Distributor data);
        
        /// <summary>
        /// Delete Distributor from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DeleteById(object id);
        
        /// <summary>
        /// Find all Distributor from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList<Distributor> FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all Distributor from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
        
        /// <summary>
        /// Find min, max, count... Distributor from database.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        object SelectSpecificType(ObjectCriteria criteria, IProjection type); 
    }
}
