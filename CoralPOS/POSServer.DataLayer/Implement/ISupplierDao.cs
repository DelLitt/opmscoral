			 
using System;
using System.Collections;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;
using Spring.Data.NHibernate;
using CoralPOS.Models;

namespace POSServer.DataLayer.Implement
{
	
    public interface ISupplierDao
    {
        /// <summary>
        /// Find Supplier object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of Supplier</param>
        /// <returns></returns>
        Supplier FindById(object id);
        
        /// <summary>
        /// Add Supplier to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Supplier Add(Supplier data);
        
        /// <summary>
        /// Update Supplier to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Update(Supplier data);
        
        /// <summary>
        /// Delete Supplier from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Delete(Supplier data);
        
        /// <summary>
        /// Delete Supplier from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DeleteById(object id);
        
        /// <summary>
        /// Find all Supplier from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList<Supplier> FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all Supplier from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
        
        /// <summary>
        /// Find min, max, count... Supplier from database.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        object SelectSpecificType(ObjectCriteria criteria, IProjection type); 
    }
}
