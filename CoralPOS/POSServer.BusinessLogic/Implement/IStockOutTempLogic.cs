			 
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
    public interface IStockOutTempLogic
    {
        /// <summary>
        /// Find  StockOutTemp object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of  StockOutTemp</param>
        /// <returns></returns>
         StockOutTemp FindById(object id);
        
        /// <summary>
        /// Add  StockOutTemp to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
         StockOutTemp Add( StockOutTemp data);
        
        /// <summary>
        /// Update  StockOutTemp to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update( StockOutTemp data);
        
        /// <summary>
        /// Delete  StockOutTemp from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete( StockOutTemp data);
        
        /// <summary>
        /// Delete  StockOutTemp from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all  StockOutTemp from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList<StockOutTemp> FindAll(ObjectCriteria<StockOutTemp> criteria);
        
        /// <summary>
        /// Find all  StockOutTemp from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria<StockOutTemp> criteria);
    }
}