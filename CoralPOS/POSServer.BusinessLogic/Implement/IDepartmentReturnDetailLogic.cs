			 
using System;
using System.Collections;
using System.Collections.Generic;
using AppFrame.DataLayer;
using NHibernate;
using NHibernate.Criterion;
using Spring.Data.NHibernate;
using CoralPOS.Models;
using POSServer.DataLayer.Implement;

namespace POSServer.BusinessLogic.Implement
{
    public interface IDepartmentReturnDetailLogic
    {
        /// <summary>
        /// Find  DepartmentReturnDetail object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of  DepartmentReturnDetail</param>
        /// <returns></returns>
         DepartmentReturnDetail FindById(object id);
        
        /// <summary>
        /// Add  DepartmentReturnDetail to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
         DepartmentReturnDetail Add( DepartmentReturnDetail data);
        
        /// <summary>
        /// Update  DepartmentReturnDetail to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update( DepartmentReturnDetail data);
        
        /// <summary>
        /// Delete  DepartmentReturnDetail from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete( DepartmentReturnDetail data);
        
        /// <summary>
        /// Delete  DepartmentReturnDetail from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all  DepartmentReturnDetail from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList<DepartmentReturnDetail> FindAll(ObjectCriteria<DepartmentReturnDetail> criteria);
        
        /// <summary>
        /// Find all  DepartmentReturnDetail from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria<DepartmentReturnDetail> criteria);
    }
}