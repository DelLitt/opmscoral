			 
using System;
using System.Collections;
using System.Collections.Generic;
using AppFrame.DataLayer;
using NHibernate;
using NHibernate.Criterion;
using Spring.Data.NHibernate;
using CoralPOS.Models;
using POSServer.DataLayer.Implement;

namespace POSServer.BusinessLogic.Implement
{
    public interface IDepartmentPurchaseOrderPromotionLogic
    {
        /// <summary>
        /// Find  DepartmentPurchaseOrderPromotion object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of  DepartmentPurchaseOrderPromotion</param>
        /// <returns></returns>
         DepartmentPurchaseOrderPromotion FindById(object id);
        
        /// <summary>
        /// Add  DepartmentPurchaseOrderPromotion to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
         DepartmentPurchaseOrderPromotion Add( DepartmentPurchaseOrderPromotion data);
        
        /// <summary>
        /// Update  DepartmentPurchaseOrderPromotion to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update( DepartmentPurchaseOrderPromotion data);
        
        /// <summary>
        /// Delete  DepartmentPurchaseOrderPromotion from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete( DepartmentPurchaseOrderPromotion data);
        
        /// <summary>
        /// Delete  DepartmentPurchaseOrderPromotion from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all  DepartmentPurchaseOrderPromotion from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList<DepartmentPurchaseOrderPromotion> FindAll(ObjectCriteria<DepartmentPurchaseOrderPromotion> criteria);
        
        /// <summary>
        /// Find all  DepartmentPurchaseOrderPromotion from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria<DepartmentPurchaseOrderPromotion> criteria);
    }
}