			 
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
    public interface ICustomerLogic
    {
        /// <summary>
        /// Find  Customer object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of  Customer</param>
        /// <returns></returns>
         Customer FindById(object id);
        
        /// <summary>
        /// Add  Customer to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
         Customer Add( Customer data);
        
        /// <summary>
        /// Update  Customer to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update( Customer data);
        
        /// <summary>
        /// Delete  Customer from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete( Customer data);
        
        /// <summary>
        /// Delete  Customer from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all  Customer from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList<Customer> FindAll(ObjectCriteria<Customer> criteria);
        
        /// <summary>
        /// Find all  Customer from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria<Customer> criteria);
    }
}