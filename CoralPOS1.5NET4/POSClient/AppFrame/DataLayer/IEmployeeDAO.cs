using System;
using System.Collections;
using AppFrame.Model;
using NHibernate.Criterion;

namespace AppFrame.DataLayer
{
    public interface IEmployeeDAO
    {
        /// <summary>
        /// Find Employee object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of Employee</param>
        /// <returns></returns>
        Employee FindById(object id);
        
        /// <summary>
        /// Add Employee to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Employee Add(Employee data);
        
        /// <summary>
        /// Update Employee to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update(Employee data);
        
        /// <summary>
        /// Delete Employee from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete(Employee data);
        
        /// <summary>
        /// Delete Employee from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all Employee from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all Employee from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
        
        /// <summary>
        /// Find min, max, count... Employee from database.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        object SelectSpecificType(ObjectCriteria criteria, IProjection type);
    }
}