			 
using System;
using System.Collections;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;
using Spring.Data.NHibernate;
using CoralPOS.Models;

namespace POSServer.DataLayer.Implement
{
	
    public interface IDepartmentReturnDetailDao
    {
        /// <summary>
        /// Find DepartmentReturnDetail object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of DepartmentReturnDetail</param>
        /// <returns></returns>
        DepartmentReturnDetail FindById(object id);
        
        /// <summary>
        /// Add DepartmentReturnDetail to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        DepartmentReturnDetail Add(DepartmentReturnDetail data);
        
        /// <summary>
        /// Update DepartmentReturnDetail to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Update(DepartmentReturnDetail data);
        
        /// <summary>
        /// Delete DepartmentReturnDetail from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Delete(DepartmentReturnDetail data);
        
        /// <summary>
        /// Delete DepartmentReturnDetail from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DeleteById(object id);
        
        /// <summary>
        /// Find all DepartmentReturnDetail from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList<DepartmentReturnDetail> FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all DepartmentReturnDetail from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
        
        /// <summary>
        /// Find min, max, count... DepartmentReturnDetail from database.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        object SelectSpecificType(ObjectCriteria criteria, IProjection type); 
    }
}
