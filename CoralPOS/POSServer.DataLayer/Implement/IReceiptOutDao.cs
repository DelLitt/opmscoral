			 
using System;
using System.Collections;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;
using Spring.Data.NHibernate;
using CoralPOS.Models;

namespace POSServer.DataLayer.Implement
{
	
    public interface IReceiptOutDao
    {
        /// <summary>
        /// Find ReceiptOut object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of ReceiptOut</param>
        /// <returns></returns>
        ReceiptOut FindById(object id);
        
        /// <summary>
        /// Add ReceiptOut to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        ReceiptOut Add(ReceiptOut data);
        
        /// <summary>
        /// Update ReceiptOut to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Update(ReceiptOut data);
        
        /// <summary>
        /// Delete ReceiptOut from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Delete(ReceiptOut data);
        
        /// <summary>
        /// Delete ReceiptOut from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DeleteById(object id);
        
        /// <summary>
        /// Find all ReceiptOut from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList<ReceiptOut> FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all ReceiptOut from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
        
        /// <summary>
        /// Find min, max, count... ReceiptOut from database.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        object SelectSpecificType(ObjectCriteria criteria, IProjection type); 
    }
}
