			 
using System;
using System.Collections;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;
using Spring.Data.NHibernate;
using CoralPOS.Models;

namespace POSServer.DataLayer.Implement
{
	
    public interface IPurchaseOrdersTransactionDao
    {
        /// <summary>
        /// Find PurchaseOrdersTransaction object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of PurchaseOrdersTransaction</param>
        /// <returns></returns>
        PurchaseOrdersTransaction FindById(object id);
        
        /// <summary>
        /// Add PurchaseOrdersTransaction to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        PurchaseOrdersTransaction Add(PurchaseOrdersTransaction data);
        
        /// <summary>
        /// Update PurchaseOrdersTransaction to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Update(PurchaseOrdersTransaction data);
        
        /// <summary>
        /// Delete PurchaseOrdersTransaction from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Delete(PurchaseOrdersTransaction data);
        
        /// <summary>
        /// Delete PurchaseOrdersTransaction from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DeleteById(object id);
        
        /// <summary>
        /// Find all PurchaseOrdersTransaction from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList<PurchaseOrdersTransaction> FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all PurchaseOrdersTransaction from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
        
        /// <summary>
        /// Find min, max, count... PurchaseOrdersTransaction from database.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        object SelectSpecificType(ObjectCriteria criteria, IProjection type); 
    }
}
