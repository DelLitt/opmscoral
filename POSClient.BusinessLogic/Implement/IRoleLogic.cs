			 
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
    public interface IRoleLogic
    {
        /// <summary>
        /// Find  Role object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of  Role</param>
        /// <returns></returns>
         Role FindById(object id);
        
        /// <summary>
        /// Add  Role to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
         Role Add( Role data);
        
        /// <summary>
        /// Update  Role to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update( Role data);
        
        /// <summary>
        /// Delete  Role from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete( Role data);
        
        /// <summary>
        /// Delete  Role from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all  Role from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList<Role> FindAll(ObjectCriteria<Role> criteria);
        
        /// <summary>
        /// Find all  Role from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria<Role> criteria);
    }
}