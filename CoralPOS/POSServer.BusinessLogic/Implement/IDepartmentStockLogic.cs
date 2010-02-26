			 
			 

using System;
using System.Collections;
using System.Collections.Generic;
using CoralPOS.Models;
using POSServer.DataLayer.Implement;

namespace POSServer.BusinessLogic.Implement
{
    public interface IDepartmentStockLogic
    {
        /// <summary>
        /// Find  DepartmentStock object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of  DepartmentStock</param>
        /// <returns></returns>
         DepartmentStock FindById(object id);
        
        /// <summary>
        /// Add  DepartmentStock to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
         DepartmentStock Add( DepartmentStock data);
        
        /// <summary>
        /// Update  DepartmentStock to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update( DepartmentStock data);
        
        /// <summary>
        /// Delete  DepartmentStock from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete( DepartmentStock data);
        
        /// <summary>
        /// Delete  DepartmentStock from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all  DepartmentStock from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList<DepartmentStock> FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all  DepartmentStock from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
    }
}