			 
using System;
using System.Collections;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;
using Spring.Data.NHibernate;
using CoralPOS.Models;

namespace POSServer.DataLayer.Implement
{
	
    public interface ICategoryDao
    {
        /// <summary>
        /// Find Category object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of Category</param>
        /// <returns></returns>
        Category FindById(object id);
        
        /// <summary>
        /// Add Category to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Category Add(Category data);
        
        /// <summary>
        /// Update Category to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Update(Category data);
        
        /// <summary>
        /// Delete Category from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Delete(Category data);
        
        /// <summary>
        /// Delete Category from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DeleteById(object id);
        
        /// <summary>
        /// Find all Category from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList<Category> FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all Category from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
        
        /// <summary>
        /// Find min, max, count... Category from database.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        object SelectSpecificType(ObjectCriteria criteria, IProjection type); 
    }
}
