using System;
using System.Collections;
using AppFrame.Model;
using NHibernate.Criterion;

namespace AppFrame.DataLayer
{
    public interface IDepartmentDAO
    {
        /// <summary>
        /// Find Department object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of Department</param>
        /// <returns></returns>
        Department FindById(object id);
        
        /// <summary>
        /// Add Department to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Department Add(Department data);
        
        /// <summary>
        /// Update Department to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update(Department data);
        
        /// <summary>
        /// Delete Department from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete(Department data);
        
        /// <summary>
        /// Delete Department from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all Department from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all Department from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
        
        /// <summary>
        /// Find min, max, count... Department from database.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        object SelectSpecificType(ObjectCriteria criteria, IProjection type);

        Department LoadDepartment(Department department);
        void SetInActiveAll();
    }
}