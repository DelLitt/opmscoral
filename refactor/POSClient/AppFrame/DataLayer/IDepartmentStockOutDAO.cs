using System;
using System.Collections;
using AppFrame.Model;
using NHibernate.Criterion;

namespace AppFrame.DataLayer
{
    public interface IDepartmentStockOutDAO
    {
        /// <summary>
        /// Find DepartmentStockOut object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of DepartmentStockOut</param>
        /// <returns></returns>
        DepartmentStockOut FindById(object id);
        
        /// <summary>
        /// Add DepartmentStockOut to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        DepartmentStockOut Add(DepartmentStockOut data);
        
        /// <summary>
        /// Update DepartmentStockOut to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update(DepartmentStockOut data);
        
        /// <summary>
        /// Delete DepartmentStockOut from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete(DepartmentStockOut data);
        
        /// <summary>
        /// Delete DepartmentStockOut from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all DepartmentStockOut from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all DepartmentStockOut from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
        
        /// <summary>
        /// Find min, max, count... DepartmentStockOut from database.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        object SelectSpecificType(ObjectCriteria criteria, IProjection type);

        IList FindStockOut(DateTime date, DateTime toDate);
    }
}