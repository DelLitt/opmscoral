			 
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
    public interface IPurchaseOrdersTransactionLogic
    {
        /// <summary>
        /// Find  PurchaseOrdersTransaction object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of  PurchaseOrdersTransaction</param>
        /// <returns></returns>
         PurchaseOrdersTransaction FindById(object id);
        
        /// <summary>
        /// Add  PurchaseOrdersTransaction to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
         PurchaseOrdersTransaction Add( PurchaseOrdersTransaction data);
        
        /// <summary>
        /// Update  PurchaseOrdersTransaction to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update( PurchaseOrdersTransaction data);
        
        /// <summary>
        /// Delete  PurchaseOrdersTransaction from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete( PurchaseOrdersTransaction data);
        
        /// <summary>
        /// Delete  PurchaseOrdersTransaction from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all  PurchaseOrdersTransaction from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList<PurchaseOrdersTransaction> FindAll(ObjectCriteria<PurchaseOrdersTransaction> criteria);
        
        /// <summary>
        /// Find all  PurchaseOrdersTransaction from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria<PurchaseOrdersTransaction> criteria);
    }
}