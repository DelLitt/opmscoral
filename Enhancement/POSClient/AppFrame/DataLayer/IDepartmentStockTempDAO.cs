using System;
using System.Collections;
using AppFrame.Model;
using NHibernate.Criterion;

namespace AppFrame.DataLayer
{
    public interface IDepartmentStockTempDAO
    {
        /// <summary>
        /// Find DepartmentStockTemp object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of DepartmentStockTemp</param>
        /// <returns></returns>
        DepartmentStockTemp FindById(object id);
        
        /// <summary>
        /// Add DepartmentStockTemp to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        DepartmentStockTemp Add(DepartmentStockTemp data);
        
        /// <summary>
        /// Update DepartmentStockTemp to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update(DepartmentStockTemp data);
        
        /// <summary>
        /// Delete DepartmentStockTemp from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete(DepartmentStockTemp data);
        
        /// <summary>
        /// Delete DepartmentStockTemp from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all DepartmentStockTemp from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all DepartmentStockTemp from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
        
        /// <summary>
        /// Find min, max, count... DepartmentStockTemp from database.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        object SelectSpecificType(ObjectCriteria criteria, IProjection type);
        
    }
}