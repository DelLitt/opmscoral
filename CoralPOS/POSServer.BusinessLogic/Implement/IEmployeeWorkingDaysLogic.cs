			 
			 

using System;
using System.Collections;
using System.Collections.Generic;
using CoralPOS.Models;
using POSServer.DataLayer.Implement;

namespace POSServer.BusinessLogic.Implement
{
    public interface IEmployeeWorkingDaysLogic
    {
        /// <summary>
        /// Find  EmployeeWorkingDays object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of  EmployeeWorkingDays</param>
        /// <returns></returns>
         EmployeeWorkingDays FindById(object id);
        
        /// <summary>
        /// Add  EmployeeWorkingDays to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
         EmployeeWorkingDays Add( EmployeeWorkingDays data);
        
        /// <summary>
        /// Update  EmployeeWorkingDays to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update( EmployeeWorkingDays data);
        
        /// <summary>
        /// Delete  EmployeeWorkingDays from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete( EmployeeWorkingDays data);
        
        /// <summary>
        /// Delete  EmployeeWorkingDays from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all  EmployeeWorkingDays from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList<EmployeeWorkingDays> FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all  EmployeeWorkingDays from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
    }
}