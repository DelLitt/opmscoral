			 
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
    public interface ISaleTransactionLogic
    {
        /// <summary>
        /// Find  SaleTransaction object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of  SaleTransaction</param>
        /// <returns></returns>
         SaleTransaction FindById(object id);
        
        /// <summary>
        /// Add  SaleTransaction to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
         SaleTransaction Add( SaleTransaction data);
        
        /// <summary>
        /// Update  SaleTransaction to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update( SaleTransaction data);
        
        /// <summary>
        /// Delete  SaleTransaction from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete( SaleTransaction data);
        
        /// <summary>
        /// Delete  SaleTransaction from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all  SaleTransaction from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList<SaleTransaction> FindAll(ObjectCriteria<SaleTransaction> criteria);
        
        /// <summary>
        /// Find all  SaleTransaction from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria<SaleTransaction> criteria);
    }
}