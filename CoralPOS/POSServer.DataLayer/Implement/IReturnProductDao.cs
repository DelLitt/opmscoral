			 
using System;
using System.Collections;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;
using Spring.Data.NHibernate;
using CoralPOS.Models;

namespace POSServer.DataLayer.Implement
{
	
    public interface IReturnProductDao
    {
        /// <summary>
        /// Find ReturnProduct object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of ReturnProduct</param>
        /// <returns></returns>
        ReturnProduct FindById(object id);
        
        /// <summary>
        /// Add ReturnProduct to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        ReturnProduct Add(ReturnProduct data);
        
        /// <summary>
        /// Update ReturnProduct to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Update(ReturnProduct data);
        
        /// <summary>
        /// Delete ReturnProduct from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Delete(ReturnProduct data);
        
        /// <summary>
        /// Delete ReturnProduct from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DeleteById(object id);
        
        /// <summary>
        /// Find all ReturnProduct from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList<ReturnProduct> FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all ReturnProduct from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
        
        /// <summary>
        /// Find min, max, count... ReturnProduct from database.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        object SelectSpecificType(ObjectCriteria criteria, IProjection type); 
    }
}
