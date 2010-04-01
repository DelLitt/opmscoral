			 
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
    public interface IEmployeeInfoLogic
    {
        /// <summary>
        /// Find  EmployeeInfo object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of  EmployeeInfo</param>
        /// <returns></returns>
         EmployeeInfo FindById(object id);
        
        /// <summary>
        /// Add  EmployeeInfo to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
         EmployeeInfo Add( EmployeeInfo data);
        
        /// <summary>
        /// Update  EmployeeInfo to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update( EmployeeInfo data);
        
        /// <summary>
        /// Delete  EmployeeInfo from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete( EmployeeInfo data);
        
        /// <summary>
        /// Delete  EmployeeInfo from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all  EmployeeInfo from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList<EmployeeInfo> FindAll(ObjectCriteria<EmployeeInfo> criteria);
        
        /// <summary>
        /// Find all  EmployeeInfo from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria<EmployeeInfo> criteria);
    }
}