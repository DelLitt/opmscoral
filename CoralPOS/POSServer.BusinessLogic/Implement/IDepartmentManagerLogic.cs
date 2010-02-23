			 
			 

using System;
using System.Collections;
using CoralPOS.Models;

namespace POSServer.DataLayer.Implement
{
    public interface IDepartmentManagerLogic
    {
        /// <summary>
        /// Find  DepartmentManager object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of  DepartmentManager</param>
        /// <returns></returns>
         DepartmentManager FindById(object id);
        
        /// <summary>
        /// Add  DepartmentManager to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
         DepartmentManager Add( DepartmentManager data);
        
        /// <summary>
        /// Update  DepartmentManager to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update( DepartmentManager data);
        
        /// <summary>
        /// Delete  DepartmentManager from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete( DepartmentManager data);
        
        /// <summary>
        /// Delete  DepartmentManager from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all  DepartmentManager from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all  DepartmentManager from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
    }
}