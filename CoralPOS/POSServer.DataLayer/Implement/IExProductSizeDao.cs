			 
using System;
using System.Collections;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;
using Spring.Data.NHibernate;
using CoralPOS.Models;

namespace POSServer.DataLayer.Implement
{
	
    public interface IExProductSizeDao
    {
        /// <summary>
        /// Find ExProductSize object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of ExProductSize</param>
        /// <returns></returns>
        ExProductSize FindById(object id);
        
        /// <summary>
        /// Add ExProductSize to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        ExProductSize Add(ExProductSize data);
        
        /// <summary>
        /// Update ExProductSize to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Update(ExProductSize data);
        
        /// <summary>
        /// Delete ExProductSize from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Delete(ExProductSize data);
        
        /// <summary>
        /// Delete ExProductSize from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DeleteById(object id);
        
        /// <summary>
        /// Find all ExProductSize from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList<ExProductSize> FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all ExProductSize from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
        
        /// <summary>
        /// Find min, max, count... ExProductSize from database.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        object SelectSpecificType(ObjectCriteria criteria, IProjection type); 
    }
}
