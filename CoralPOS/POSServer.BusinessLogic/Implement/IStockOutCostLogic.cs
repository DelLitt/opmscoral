			 
			 

using System;
using System.Collections;
using CoralPOS.Models;

namespace POSServer.DataLayer.Implement
{
    public interface IStockOutCostLogic
    {
        /// <summary>
        /// Find  StockOutCost object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of  StockOutCost</param>
        /// <returns></returns>
         StockOutCost FindById(object id);
        
        /// <summary>
        /// Add  StockOutCost to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
         StockOutCost Add( StockOutCost data);
        
        /// <summary>
        /// Update  StockOutCost to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update( StockOutCost data);
        
        /// <summary>
        /// Delete  StockOutCost from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete( StockOutCost data);
        
        /// <summary>
        /// Delete  StockOutCost from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all  StockOutCost from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all  StockOutCost from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
    }
}