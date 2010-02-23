
using System;

namespace POSServer.DataLayer.Implement
{
	
    public interface IEmployeeWorkingDaysDao
    {
        /// <summary>
        /// Find EmployeeWorkingDays object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of EmployeeWorkingDays</param>
        /// <returns></returns>
        EmployeeWorkingDays FindById(object id);
        
        /// <summary>
        /// Add EmployeeWorkingDays to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        EmployeeWorkingDays Add(EmployeeWorkingDays data);
        
        /// <summary>
        /// Update EmployeeWorkingDays to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Update(EmployeeWorkingDays data);
        
        /// <summary>
        /// Delete EmployeeWorkingDays from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Delete(EmployeeWorkingDays data);
        
        /// <summary>
        /// Delete EmployeeWorkingDays from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DeleteById(object id);
        
        /// <summary>
        /// Find all EmployeeWorkingDays from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList<EmployeeWorkingDays> FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all EmployeeWorkingDays from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
        
        /// <summary>
        /// Find min, max, count... EmployeeWorkingDays from database.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        object SelectSpecificType(ObjectCriteria criteria, IProjection type); 
    }
}
