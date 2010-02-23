
using System;

namespace POSServer.DataLayer.Implement
{
	
    public interface IDepartmentStockTemployeeValidSaveDao
    {
        /// <summary>
        /// Find DepartmentStockTemployeeValidSave object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of DepartmentStockTemployeeValidSave</param>
        /// <returns></returns>
        DepartmentStockTemployeeValidSave FindById(object id);
        
        /// <summary>
        /// Add DepartmentStockTemployeeValidSave to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        DepartmentStockTemployeeValidSave Add(DepartmentStockTemployeeValidSave data);
        
        /// <summary>
        /// Update DepartmentStockTemployeeValidSave to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Update(DepartmentStockTemployeeValidSave data);
        
        /// <summary>
        /// Delete DepartmentStockTemployeeValidSave from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Delete(DepartmentStockTemployeeValidSave data);
        
        /// <summary>
        /// Delete DepartmentStockTemployeeValidSave from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DeleteById(object id);
        
        /// <summary>
        /// Find all DepartmentStockTemployeeValidSave from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList<DepartmentStockTemployeeValidSave> FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all DepartmentStockTemployeeValidSave from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
        
        /// <summary>
        /// Find min, max, count... DepartmentStockTemployeeValidSave from database.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        object SelectSpecificType(ObjectCriteria criteria, IProjection type); 
    }
}
