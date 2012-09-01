			 
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
    public interface IDepartmentReturnLogic
    {
        /// <summary>
        /// Find  DepartmentReturn object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of  DepartmentReturn</param>
        /// <returns></returns>
         DepartmentReturn FindById(object id);
        
        /// <summary>
        /// Add  DepartmentReturn to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
         DepartmentReturn Add( DepartmentReturn data);
        
        /// <summary>
        /// Update  DepartmentReturn to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update( DepartmentReturn data);
        
        /// <summary>
        /// Delete  DepartmentReturn from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete( DepartmentReturn data);
        
        /// <summary>
        /// Delete  DepartmentReturn from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all  DepartmentReturn from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList<DepartmentReturn> FindAll(ObjectCriteria<DepartmentReturn> criteria);
        
        /// <summary>
        /// Find all  DepartmentReturn from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria<DepartmentReturn> criteria);
    }
}