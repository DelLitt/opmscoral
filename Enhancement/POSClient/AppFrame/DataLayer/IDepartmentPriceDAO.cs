using System;
using System.Collections;
using AppFrame.Model;
using NHibernate.Criterion;

namespace AppFrame.DataLayer
{
    public interface IDepartmentPriceDAO
    {
        /// <summary>
        /// Find DepartmentPrice object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of DepartmentPrice</param>
        /// <returns></returns>
        DepartmentPrice FindById(object id);
        
        /// <summary>
        /// Add DepartmentPrice to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        DepartmentPrice Add(DepartmentPrice data);
        
        /// <summary>
        /// Update DepartmentPrice to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update(DepartmentPrice data);
        
        /// <summary>
        /// Delete DepartmentPrice from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete(DepartmentPrice data);
        
        /// <summary>
        /// Delete DepartmentPrice from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all DepartmentPrice from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all DepartmentPrice from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
        
        /// <summary>
        /// Find min, max, count... DepartmentPrice from database.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        object SelectSpecificType(ObjectCriteria criteria, IProjection type);
    }
}