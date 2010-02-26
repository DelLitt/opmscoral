			 
using System;
using System.Collections;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;
using Spring.Data.NHibernate;
using CoralPOS.Models;

namespace POSServer.DataLayer.Implement
{
	
    public interface IMainStockHistoryDao
    {
        /// <summary>
        /// Find MainStockHistory object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of MainStockHistory</param>
        /// <returns></returns>
        MainStockHistory FindById(object id);
        
        /// <summary>
        /// Add MainStockHistory to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        MainStockHistory Add(MainStockHistory data);
        
        /// <summary>
        /// Update MainStockHistory to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Update(MainStockHistory data);
        
        /// <summary>
        /// Delete MainStockHistory from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Delete(MainStockHistory data);
        
        /// <summary>
        /// Delete MainStockHistory from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DeleteById(object id);
        
        /// <summary>
        /// Find all MainStockHistory from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList<MainStockHistory> FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all MainStockHistory from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
        
        /// <summary>
        /// Find min, max, count... MainStockHistory from database.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        object SelectSpecificType(ObjectCriteria criteria, IProjection type); 
    }
}
