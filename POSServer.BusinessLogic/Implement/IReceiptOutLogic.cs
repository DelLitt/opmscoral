			 
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
    public interface IReceiptOutLogic
    {
        /// <summary>
        /// Find  ReceiptOut object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of  ReceiptOut</param>
        /// <returns></returns>
         ReceiptOut FindById(object id);
        
        /// <summary>
        /// Add  ReceiptOut to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
         ReceiptOut Add( ReceiptOut data);
        
        /// <summary>
        /// Update  ReceiptOut to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update( ReceiptOut data);
        
        /// <summary>
        /// Delete  ReceiptOut from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete( ReceiptOut data);
        
        /// <summary>
        /// Delete  ReceiptOut from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all  ReceiptOut from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList<ReceiptOut> FindAll(ObjectCriteria<ReceiptOut> criteria);
        
        /// <summary>
        /// Find all  ReceiptOut from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria<ReceiptOut> criteria);
    }
}