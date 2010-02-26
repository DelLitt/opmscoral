			 
			 

using System;
using System.Collections;
using System.Collections.Generic;
using CoralPOS.Models;
using POSServer.DataLayer.Implement;

namespace POSServer.BusinessLogic.Implement
{
    public interface IStockDefinitionStatusLogic
    {
        /// <summary>
        /// Find  StockDefinitionStatus object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of  StockDefinitionStatus</param>
        /// <returns></returns>
         StockDefinitionStatus FindById(object id);
        
        /// <summary>
        /// Add  StockDefinitionStatus to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
         StockDefinitionStatus Add( StockDefinitionStatus data);
        
        /// <summary>
        /// Update  StockDefinitionStatus to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update( StockDefinitionStatus data);
        
        /// <summary>
        /// Delete  StockDefinitionStatus from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete( StockDefinitionStatus data);
        
        /// <summary>
        /// Delete  StockDefinitionStatus from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all  StockDefinitionStatus from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList<StockDefinitionStatus> FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all  StockDefinitionStatus from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
    }
}