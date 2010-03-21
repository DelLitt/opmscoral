			 
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
    public interface IGiftLogic
    {
        /// <summary>
        /// Find  Gift object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of  Gift</param>
        /// <returns></returns>
         Gift FindById(object id);
        
        /// <summary>
        /// Add  Gift to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
         Gift Add( Gift data);
        
        /// <summary>
        /// Update  Gift to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update( Gift data);
        
        /// <summary>
        /// Delete  Gift from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete( Gift data);
        
        /// <summary>
        /// Delete  Gift from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all  Gift from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList<Gift> FindAll(ObjectCriteria<Gift> criteria);
        
        /// <summary>
        /// Find all  Gift from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria<Gift> criteria);
    }
}