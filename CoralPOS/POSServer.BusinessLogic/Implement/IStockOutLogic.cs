			 
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
    public interface IStockOutLogic
    {
        /// <summary>
        /// Find  StockOut object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of  StockOut</param>
        /// <returns></returns>
         StockOut FindById(object id);
        
        /// <summary>
        /// Add  StockOut to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
         StockOut Add( StockOut data);
        
        /// <summary>
        /// Update  StockOut to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update( StockOut data);
        
        /// <summary>
        /// Delete  StockOut from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete( StockOut data);
        
        /// <summary>
        /// Delete  StockOut from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all  StockOut from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList<StockOut> FindAll(ObjectCriteria<StockOut> criteria);
        
        /// <summary>
        /// Find all  StockOut from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria<StockOut> criteria);

        IList<StockOut> FindByCriteria(object criteria);
    }
}