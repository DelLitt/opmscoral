using System;
using System.Collections;
using AppFrame.Model;
using NHibernate.Criterion;

namespace AppFrame.DataLayer
{
    public interface IEmployeeWorkingDayDAO
    {
        /// <summary>
        /// Find EmployeeWorkingDay object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of EmployeeWorkingDay</param>
        /// <returns></returns>
        EmployeeWorkingDay FindById(object id);
        
        /// <summary>
        /// Add EmployeeWorkingDay to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        EmployeeWorkingDay Add(EmployeeWorkingDay data);
        
        /// <summary>
        /// Update EmployeeWorkingDay to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update(EmployeeWorkingDay data);
        
        /// <summary>
        /// Delete EmployeeWorkingDay from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete(EmployeeWorkingDay data);
        
        /// <summary>
        /// Delete EmployeeWorkingDay from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all EmployeeWorkingDay from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all EmployeeWorkingDay from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
        
        /// <summary>
        /// Find min, max, count... EmployeeWorkingDay from database.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        object SelectSpecificType(ObjectCriteria criteria, IProjection type);
    }
}