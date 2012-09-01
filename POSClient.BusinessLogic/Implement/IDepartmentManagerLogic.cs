			 
using System;
using System.Collections;
using System.Collections.Generic;
using AppFrame.DataLayer;
using NHibernate;
using NHibernate.Criterion;
using Spring.Data.NHibernate;
using CoralPOS.Models;
using POSClient.DataLayer.Implement;

namespace POSClient.BusinessLogic.Implement
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
        IList<DepartmentManager> FindAll(ObjectCriteria<DepartmentManager> criteria);
        
        /// <summary>
        /// Find all  DepartmentManager from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria<DepartmentManager> criteria);
    }
}