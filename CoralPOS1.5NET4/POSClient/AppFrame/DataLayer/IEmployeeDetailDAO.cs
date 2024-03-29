using System;
using System.Collections;
using AppFrame.Model;
using NHibernate.Criterion;

namespace AppFrame.DataLayer
{
    public interface IEmployeeDetailDAO
    {
        /// <summary>
        /// Find EmployeeInfo object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of EmployeeInfo</param>
        /// <returns></returns>
        EmployeeInfo FindById(object id);
        
        /// <summary>
        /// Add EmployeeInfo to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        EmployeeInfo Add(EmployeeInfo data);
        
        /// <summary>
        /// Update EmployeeInfo to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update(EmployeeInfo data);
        
        /// <summary>
        /// Delete EmployeeInfo from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete(EmployeeInfo data);
        
        /// <summary>
        /// Delete EmployeeInfo from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all EmployeeInfo from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all EmployeeInfo from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);

        /// <summary>
        /// Find min, max, count... EmployeeInfo from database.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        object SelectSpecificType(ObjectCriteria criteria, IProjection type);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        string GetMaxId(string name);
    }
}