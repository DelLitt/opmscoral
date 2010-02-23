
using System;

namespace POSServer.DataLayer.Implement
{
	
    public interface IMainftrDao
    {
        /// <summary>
        /// Find Mainftr object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of Mainftr</param>
        /// <returns></returns>
        Mainftr FindById(object id);
        
        /// <summary>
        /// Add Mainftr to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Mainftr Add(Mainftr data);
        
        /// <summary>
        /// Update Mainftr to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Update(Mainftr data);
        
        /// <summary>
        /// Delete Mainftr from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Delete(Mainftr data);
        
        /// <summary>
        /// Delete Mainftr from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DeleteById(object id);
        
        /// <summary>
        /// Find all Mainftr from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList<Mainftr> FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all Mainftr from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
        
        /// <summary>
        /// Find min, max, count... Mainftr from database.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        object SelectSpecificType(ObjectCriteria criteria, IProjection type); 
    }
}
