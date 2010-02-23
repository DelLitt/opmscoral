
using System;

namespace POSServer.DataLayer.Implement
{
	
    public interface IDepartmentStockHistoryDao
    {
        /// <summary>
        /// Find DepartmentStockHistory object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of DepartmentStockHistory</param>
        /// <returns></returns>
        DepartmentStockHistory FindById(object id);
        
        /// <summary>
        /// Add DepartmentStockHistory to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        DepartmentStockHistory Add(DepartmentStockHistory data);
        
        /// <summary>
        /// Update DepartmentStockHistory to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Update(DepartmentStockHistory data);
        
        /// <summary>
        /// Delete DepartmentStockHistory from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Delete(DepartmentStockHistory data);
        
        /// <summary>
        /// Delete DepartmentStockHistory from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DeleteById(object id);
        
        /// <summary>
        /// Find all DepartmentStockHistory from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList<DepartmentStockHistory> FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all DepartmentStockHistory from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
        
        /// <summary>
        /// Find min, max, count... DepartmentStockHistory from database.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        object SelectSpecificType(ObjectCriteria criteria, IProjection type); 
    }
}
