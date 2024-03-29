			 
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
    public interface ITaxLogic
    {
        /// <summary>
        /// Find  Tax object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of  Tax</param>
        /// <returns></returns>
         Tax FindById(object id);
        
        /// <summary>
        /// Add  Tax to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
         Tax Add( Tax data);
        
        /// <summary>
        /// Update  Tax to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update( Tax data);
        
        /// <summary>
        /// Delete  Tax from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete( Tax data);
        
        /// <summary>
        /// Delete  Tax from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all  Tax from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList<Tax> FindAll(ObjectCriteria<Tax> criteria);
        
        /// <summary>
        /// Find all  Tax from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria<Tax> criteria);
    }
}