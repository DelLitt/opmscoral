			 
			 

using System;
using System.Collections;
using CoralPOS.Models;

namespace POSServer.DataLayer.Implement
{
    public interface IDepartmentStockTemployeeValidSaveLogic
    {
        /// <summary>
        /// Find  DepartmentStockTemployeeValidSave object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of  DepartmentStockTemployeeValidSave</param>
        /// <returns></returns>
         DepartmentStockTemployeeValidSave FindById(object id);
        
        /// <summary>
        /// Add  DepartmentStockTemployeeValidSave to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
         DepartmentStockTemployeeValidSave Add( DepartmentStockTemployeeValidSave data);
        
        /// <summary>
        /// Update  DepartmentStockTemployeeValidSave to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update( DepartmentStockTemployeeValidSave data);
        
        /// <summary>
        /// Delete  DepartmentStockTemployeeValidSave from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete( DepartmentStockTemployeeValidSave data);
        
        /// <summary>
        /// Delete  DepartmentStockTemployeeValidSave from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all  DepartmentStockTemployeeValidSave from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all  DepartmentStockTemployeeValidSave from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
    }
}