			 
using System;
using System.Collections;
using System.Collections.Generic;
using AppFrame.DataLayer;
using NHibernate;
using NHibernate.Criterion;
using Spring.Data.NHibernate;
using CoralPOS.Models;
using POSClient.DataLayer.Implement;

namespace POSClient.BusinessLogic.Implement
{
    public interface IDepartmentPromotionLogic
    {
        /// <summary>
        /// Find  DepartmentPromotion object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of  DepartmentPromotion</param>
        /// <returns></returns>
         DepartmentPromotion FindById(object id);
        
        /// <summary>
        /// Add  DepartmentPromotion to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
         DepartmentPromotion Add( DepartmentPromotion data);
        
        /// <summary>
        /// Update  DepartmentPromotion to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update( DepartmentPromotion data);
        
        /// <summary>
        /// Delete  DepartmentPromotion from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete( DepartmentPromotion data);
        
        /// <summary>
        /// Delete  DepartmentPromotion from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all  DepartmentPromotion from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList<DepartmentPromotion> FindAll(ObjectCriteria<DepartmentPromotion> criteria);
        
        /// <summary>
        /// Find all  DepartmentPromotion from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria<DepartmentPromotion> criteria);
    }
}