			 
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
    public interface IExProductSizeLogic
    {
        /// <summary>
        /// Find  ExProductSize object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of  ExProductSize</param>
        /// <returns></returns>
         ExProductSize FindById(object id);
        
        /// <summary>
        /// Add  ExProductSize to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
         ExProductSize Add( ExProductSize data);
        
        /// <summary>
        /// Update  ExProductSize to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update( ExProductSize data);
        
        /// <summary>
        /// Delete  ExProductSize from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete( ExProductSize data);
        
        /// <summary>
        /// Delete  ExProductSize from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all  ExProductSize from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList<ExProductSize> FindAll(ObjectCriteria<ExProductSize> criteria);
        
        /// <summary>
        /// Find all  ExProductSize from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria<ExProductSize> criteria);
    }
}