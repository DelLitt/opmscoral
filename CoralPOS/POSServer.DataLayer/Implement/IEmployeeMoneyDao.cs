			 
using System;
using System.Collections;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;
using Spring.Data.NHibernate;
using CoralPOS.Models;

namespace POSServer.DataLayer.Implement
{
	
    public interface IEmployeeMoneyDao
    {
        /// <summary>
        /// Find EmployeeMoney object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of EmployeeMoney</param>
        /// <returns></returns>
        EmployeeMoney FindById(object id);
        
        /// <summary>
        /// Add EmployeeMoney to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        EmployeeMoney Add(EmployeeMoney data);
        
        /// <summary>
        /// Update EmployeeMoney to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Update(EmployeeMoney data);
        
        /// <summary>
        /// Delete EmployeeMoney from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Delete(EmployeeMoney data);
        
        /// <summary>
        /// Delete EmployeeMoney from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DeleteById(object id);
        
        /// <summary>
        /// Find all EmployeeMoney from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList<EmployeeMoney> FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all EmployeeMoney from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
        
        /// <summary>
        /// Find min, max, count... EmployeeMoney from database.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        object SelectSpecificType(ObjectCriteria criteria, IProjection type); 
    }
}
