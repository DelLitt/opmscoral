using System;
using System.Collections;
using AppFrame.Model;
using NHibernate.Criterion;

namespace AppFrame.DataLayer
{
    public interface IEmployeeDayoffDAO
    {
        /// <summary>
        /// Find EmployeeDayoff object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of EmployeeDayoff</param>
        /// <returns></returns>
        EmployeeDayoff FindById(object id);
        
        /// <summary>
        /// Add EmployeeDayoff to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        EmployeeDayoff Add(EmployeeDayoff data);
        
        /// <summary>
        /// Update EmployeeDayoff to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update(EmployeeDayoff data);
        
        /// <summary>
        /// Delete EmployeeDayoff from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete(EmployeeDayoff data);
        
        /// <summary>
        /// Delete EmployeeDayoff from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all EmployeeDayoff from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all EmployeeDayoff from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
        
        /// <summary>
        /// Find min, max, count... EmployeeDayoff from database.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        object SelectSpecificType(ObjectCriteria criteria, IProjection type);
    }
}