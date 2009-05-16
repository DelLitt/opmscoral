using System;
using System.Collections;
using AppFrame.Model;
using NHibernate.Criterion;

namespace AppFrame.DataLayer
{
    public interface IDepartmentReturnDetailDAO
    {
        /// <summary>
        /// Find DepartmentReturnDetail object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of DepartmentReturnDetail</param>
        /// <returns></returns>
        DepartmentReturnDetail FindById(object id);
        
        /// <summary>
        /// Add DepartmentReturnDetail to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        DepartmentReturnDetail Add(DepartmentReturnDetail data);
        
        /// <summary>
        /// Update DepartmentReturnDetail to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update(DepartmentReturnDetail data);
        
        /// <summary>
        /// Delete DepartmentReturnDetail from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete(DepartmentReturnDetail data);
        
        /// <summary>
        /// Delete DepartmentReturnDetail from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all DepartmentReturnDetail from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all DepartmentReturnDetail from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
        
        /// <summary>
        /// Find min, max, count... DepartmentReturnDetail from database.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        object SelectSpecificType(ObjectCriteria criteria, IProjection type);
    }
}