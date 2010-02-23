
using System;

namespace POSServer.DataLayer.Implement
{
	
    public interface IEmpDao
    {
        /// <summary>
        /// Find Emp object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of Emp</param>
        /// <returns></returns>
        Emp FindById(object id);
        
        /// <summary>
        /// Add Emp to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Emp Add(Emp data);
        
        /// <summary>
        /// Update Emp to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Update(Emp data);
        
        /// <summary>
        /// Delete Emp from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Delete(Emp data);
        
        /// <summary>
        /// Delete Emp from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DeleteById(object id);
        
        /// <summary>
        /// Find all Emp from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList<Emp> FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all Emp from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
        
        /// <summary>
        /// Find min, max, count... Emp from database.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        object SelectSpecificType(ObjectCriteria criteria, IProjection type); 
    }
}
