			 
using System;
using System.Collections;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;
using Spring.Data.NHibernate;
using CoralPOS.Models;

namespace POSServer.DataLayer.Implement
{
	
    public interface IDepartmentManagerDao
    {
        /// <summary>
        /// Find DepartmentManager object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of DepartmentManager</param>
        /// <returns></returns>
        DepartmentManager FindById(object id);
        
        /// <summary>
        /// Add DepartmentManager to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        DepartmentManager Add(DepartmentManager data);
        
        /// <summary>
        /// Update DepartmentManager to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Update(DepartmentManager data);
        
        /// <summary>
        /// Delete DepartmentManager from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Delete(DepartmentManager data);
        
        /// <summary>
        /// Delete DepartmentManager from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DeleteById(object id);
        
        /// <summary>
        /// Find all DepartmentManager from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList<DepartmentManager> FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all DepartmentManager from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
        
        /// <summary>
        /// Find min, max, count... DepartmentManager from database.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        object SelectSpecificType(ObjectCriteria criteria, IProjection type); 
    }
}
