			 
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
    public interface IActiveDepartmentLogic
    {
        /// <summary>
        /// Find  ActiveDepartment object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of  ActiveDepartment</param>
        /// <returns></returns>
         ActiveDepartment FindById(object id);
        
        /// <summary>
        /// Add  ActiveDepartment to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
         ActiveDepartment Add( ActiveDepartment data);
        
        /// <summary>
        /// Update  ActiveDepartment to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update( ActiveDepartment data);
        
        /// <summary>
        /// Delete  ActiveDepartment from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete( ActiveDepartment data);
        
        /// <summary>
        /// Delete  ActiveDepartment from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all  ActiveDepartment from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList<ActiveDepartment> FindAll(ObjectCriteria<ActiveDepartment> criteria);
        
        /// <summary>
        /// Find all  ActiveDepartment from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria<ActiveDepartment> criteria);
    }
}