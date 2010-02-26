			 
using System;
using System.Collections;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;
using Spring.Data.NHibernate;
using CoralPOS.Models;

namespace POSServer.DataLayer.Implement
{
	
    public interface IProductUnitDao
    {
        /// <summary>
        /// Find ProductUnit object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of ProductUnit</param>
        /// <returns></returns>
        ProductUnit FindById(object id);
        
        /// <summary>
        /// Add ProductUnit to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        ProductUnit Add(ProductUnit data);
        
        /// <summary>
        /// Update ProductUnit to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Update(ProductUnit data);
        
        /// <summary>
        /// Delete ProductUnit from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Delete(ProductUnit data);
        
        /// <summary>
        /// Delete ProductUnit from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DeleteById(object id);
        
        /// <summary>
        /// Find all ProductUnit from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList<ProductUnit> FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all ProductUnit from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
        
        /// <summary>
        /// Find min, max, count... ProductUnit from database.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        object SelectSpecificType(ObjectCriteria criteria, IProjection type); 
    }
}
