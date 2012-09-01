			 
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
    public interface IDepartmentPurchaseOrderLogLogic
    {
        /// <summary>
        /// Find  DepartmentPurchaseOrderLog object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of  DepartmentPurchaseOrderLog</param>
        /// <returns></returns>
         DepartmentPurchaseOrderLog FindById(object id);
        
        /// <summary>
        /// Add  DepartmentPurchaseOrderLog to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
         DepartmentPurchaseOrderLog Add( DepartmentPurchaseOrderLog data);
        
        /// <summary>
        /// Update  DepartmentPurchaseOrderLog to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update( DepartmentPurchaseOrderLog data);
        
        /// <summary>
        /// Delete  DepartmentPurchaseOrderLog from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete( DepartmentPurchaseOrderLog data);
        
        /// <summary>
        /// Delete  DepartmentPurchaseOrderLog from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all  DepartmentPurchaseOrderLog from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList<DepartmentPurchaseOrderLog> FindAll(ObjectCriteria<DepartmentPurchaseOrderLog> criteria);
        
        /// <summary>
        /// Find all  DepartmentPurchaseOrderLog from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria<DepartmentPurchaseOrderLog> criteria);
    }
}