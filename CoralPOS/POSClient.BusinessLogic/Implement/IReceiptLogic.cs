			 
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
    public interface IReceiptLogic
    {
        /// <summary>
        /// Find  Receipt object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of  Receipt</param>
        /// <returns></returns>
         Receipt FindById(object id);
        
        /// <summary>
        /// Add  Receipt to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
         Receipt Add( Receipt data);
        
        /// <summary>
        /// Update  Receipt to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update( Receipt data);
        
        /// <summary>
        /// Delete  Receipt from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete( Receipt data);
        
        /// <summary>
        /// Delete  Receipt from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all  Receipt from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList<Receipt> FindAll(ObjectCriteria<Receipt> criteria);
        
        /// <summary>
        /// Find all  Receipt from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria<Receipt> criteria);
    }
}