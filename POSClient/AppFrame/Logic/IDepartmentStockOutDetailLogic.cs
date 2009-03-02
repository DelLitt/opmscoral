using System;
using System.Collections;
using AppFrame.Model;

namespace AppFrame.Logic
{
    public interface IDepartmentStockOutDetailLogic
    {
        /// <summary>
        /// Find DepartmentStockOutDetail object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of DepartmentStockOutDetail</param>
        /// <returns></returns>
        DepartmentStockOutDetail FindById(object id);
        
        /// <summary>
        /// Add DepartmentStockOutDetail to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        DepartmentStockOutDetail Add(DepartmentStockOutDetail data);
        
        /// <summary>
        /// Update DepartmentStockOutDetail to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update(DepartmentStockOutDetail data);
        
        /// <summary>
        /// Delete DepartmentStockOutDetail from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete(DepartmentStockOutDetail data);
        
        /// <summary>
        /// Delete DepartmentStockOutDetail from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all DepartmentStockOutDetail from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all DepartmentStockOutDetail from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
    }
}