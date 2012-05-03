			 
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
    public interface IDepartmentPurchaseOrderDetailLogic
    {
        /// <summary>
        /// Find  DepartmentPurchaseOrderDetail object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of  DepartmentPurchaseOrderDetail</param>
        /// <returns></returns>
         DepartmentPurchaseOrderDetail FindById(object id);
        
        /// <summary>
        /// Add  DepartmentPurchaseOrderDetail to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
         DepartmentPurchaseOrderDetail Add( DepartmentPurchaseOrderDetail data);
        
        /// <summary>
        /// Update  DepartmentPurchaseOrderDetail to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update( DepartmentPurchaseOrderDetail data);
        
        /// <summary>
        /// Delete  DepartmentPurchaseOrderDetail from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete( DepartmentPurchaseOrderDetail data);
        
        /// <summary>
        /// Delete  DepartmentPurchaseOrderDetail from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all  DepartmentPurchaseOrderDetail from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList<DepartmentPurchaseOrderDetail> FindAll(ObjectCriteria<DepartmentPurchaseOrderDetail> criteria);
        
        /// <summary>
        /// Find all  DepartmentPurchaseOrderDetail from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria<DepartmentPurchaseOrderDetail> criteria);
    }
}