			 
using System;
using System.Collections;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;
using Spring.Data.NHibernate;
using CoralPOS.Models;

namespace POSServer.DataLayer.Implement
{
	
    public interface IDepartmentPromotionDao
    {
        /// <summary>
        /// Find DepartmentPromotion object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of DepartmentPromotion</param>
        /// <returns></returns>
        DepartmentPromotion FindById(object id);
        
        /// <summary>
        /// Add DepartmentPromotion to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        DepartmentPromotion Add(DepartmentPromotion data);
        
        /// <summary>
        /// Update DepartmentPromotion to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Update(DepartmentPromotion data);
        
        /// <summary>
        /// Delete DepartmentPromotion from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Delete(DepartmentPromotion data);
        
        /// <summary>
        /// Delete DepartmentPromotion from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DeleteById(object id);
        
        /// <summary>
        /// Find all DepartmentPromotion from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList<DepartmentPromotion> FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all DepartmentPromotion from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
        
        /// <summary>
        /// Find min, max, count... DepartmentPromotion from database.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        object SelectSpecificType(ObjectCriteria criteria, IProjection type); 
    }
}
