			 
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
    public interface IDepartmentStockInCostLogic
    {
        /// <summary>
        /// Find  DepartmentStockInCost object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of  DepartmentStockInCost</param>
        /// <returns></returns>
         DepartmentStockInCost FindById(object id);
        
        /// <summary>
        /// Add  DepartmentStockInCost to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
         DepartmentStockInCost Add( DepartmentStockInCost data);
        
        /// <summary>
        /// Update  DepartmentStockInCost to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update( DepartmentStockInCost data);
        
        /// <summary>
        /// Delete  DepartmentStockInCost from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete( DepartmentStockInCost data);
        
        /// <summary>
        /// Delete  DepartmentStockInCost from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all  DepartmentStockInCost from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList<DepartmentStockInCost> FindAll(ObjectCriteria<DepartmentStockInCost> criteria);
        
        /// <summary>
        /// Find all  DepartmentStockInCost from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria<DepartmentStockInCost> criteria);
    }
}