			 
using System;
using System.Collections;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;
using Spring.Data.NHibernate;
using CoralPOS.Models;

namespace POSServer.DataLayer.Implement
{
	
    public interface IMainPriceDao
    {
        /// <summary>
        /// Find MainPrice object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of MainPrice</param>
        /// <returns></returns>
        MainPrice FindById(object id);
        
        /// <summary>
        /// Add MainPrice to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        MainPrice Add(MainPrice data);
        
        /// <summary>
        /// Update MainPrice to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Update(MainPrice data);
        
        /// <summary>
        /// Delete MainPrice from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Delete(MainPrice data);
        
        /// <summary>
        /// Delete MainPrice from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DeleteById(object id);
        
        /// <summary>
        /// Find all MainPrice from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList<MainPrice> FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all MainPrice from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
        
        /// <summary>
        /// Find min, max, count... MainPrice from database.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        object SelectSpecificType(ObjectCriteria criteria, IProjection type); 
    }
}
