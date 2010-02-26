			 
using System;
using System.Collections;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;
using Spring.Data.NHibernate;
using CoralPOS.Models;

namespace POSServer.DataLayer.Implement
{
	
    public interface IStockDefinitionStatusDao
    {
        /// <summary>
        /// Find StockDefinitionStatus object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of StockDefinitionStatus</param>
        /// <returns></returns>
        StockDefinitionStatus FindById(object id);
        
        /// <summary>
        /// Add StockDefinitionStatus to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        StockDefinitionStatus Add(StockDefinitionStatus data);
        
        /// <summary>
        /// Update StockDefinitionStatus to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Update(StockDefinitionStatus data);
        
        /// <summary>
        /// Delete StockDefinitionStatus from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Delete(StockDefinitionStatus data);
        
        /// <summary>
        /// Delete StockDefinitionStatus from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DeleteById(object id);
        
        /// <summary>
        /// Find all StockDefinitionStatus from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList<StockDefinitionStatus> FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all StockDefinitionStatus from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
        
        /// <summary>
        /// Find min, max, count... StockDefinitionStatus from database.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        object SelectSpecificType(ObjectCriteria criteria, IProjection type); 
    }
}
