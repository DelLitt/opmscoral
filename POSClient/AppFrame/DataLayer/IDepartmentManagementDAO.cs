using System;
using System.Collections;
using AppFrame.Model;
using NHibernate.Criterion;

namespace AppFrame.DataLayer
{
    public interface IDepartmentManagementDAO
    {
        /// <summary>
        /// Find DepartmentManagement object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of DepartmentManagement</param>
        /// <returns></returns>
        DepartmentManagement FindById(object id);
        
        /// <summary>
        /// Add DepartmentManagement to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        DepartmentManagement Add(DepartmentManagement data);
        
        /// <summary>
        /// Update DepartmentManagement to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update(DepartmentManagement data);
        
        /// <summary>
        /// Delete DepartmentManagement from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete(DepartmentManagement data);
        
        /// <summary>
        /// Delete DepartmentManagement from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all DepartmentManagement from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all DepartmentManagement from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
        
        /// <summary>
        /// Find min, max, count... DepartmentManagement from database.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        object SelectSpecificType(ObjectCriteria criteria, IProjection type);
    }
}