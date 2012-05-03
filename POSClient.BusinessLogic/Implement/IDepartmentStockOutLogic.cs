			 
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
    public interface IDepartmentStockOutLogic
    {
        /// <summary>
        /// Find  DepartmentStockOut object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of  DepartmentStockOut</param>
        /// <returns></returns>
         DepartmentStockOut FindById(object id);
        
        /// <summary>
        /// Add  DepartmentStockOut to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
         DepartmentStockOut Add( DepartmentStockOut data);
        
        /// <summary>
        /// Update  DepartmentStockOut to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update( DepartmentStockOut data);
        
        /// <summary>
        /// Delete  DepartmentStockOut from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete( DepartmentStockOut data);
        
        /// <summary>
        /// Delete  DepartmentStockOut from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all  DepartmentStockOut from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList<DepartmentStockOut> FindAll(ObjectCriteria<DepartmentStockOut> criteria);
        
        /// <summary>
        /// Find all  DepartmentStockOut from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria<DepartmentStockOut> criteria);
    }
}