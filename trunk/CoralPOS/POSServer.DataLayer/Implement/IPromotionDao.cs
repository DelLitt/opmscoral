			 
using System;
using System.Collections;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;
using Spring.Data.NHibernate;
using CoralPOS.Models;

namespace POSServer.DataLayer.Implement
{
	
    public interface IPromotionDao
    {
        /// <summary>
        /// Find Promotion object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of Promotion</param>
        /// <returns></returns>
        Promotion FindById(object id);
        
        /// <summary>
        /// Add Promotion to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Promotion Add(Promotion data);
        
        /// <summary>
        /// Update Promotion to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Update(Promotion data);
        
        /// <summary>
        /// Delete Promotion from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Delete(Promotion data);
        
        /// <summary>
        /// Delete Promotion from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DeleteById(object id);
        
        /// <summary>
        /// Find all Promotion from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList<Promotion> FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all Promotion from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
        
        /// <summary>
        /// Find min, max, count... Promotion from database.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        object SelectSpecificType(ObjectCriteria criteria, IProjection type); 
    }
}