			 
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
    public interface IDepartmentStockInHistoryLogic
    {
        /// <summary>
        /// Find  DepartmentStockInHistory object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of  DepartmentStockInHistory</param>
        /// <returns></returns>
         DepartmentStockInHistory FindById(object id);
        
        /// <summary>
        /// Add  DepartmentStockInHistory to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
         DepartmentStockInHistory Add( DepartmentStockInHistory data);
        
        /// <summary>
        /// Update  DepartmentStockInHistory to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update( DepartmentStockInHistory data);
        
        /// <summary>
        /// Delete  DepartmentStockInHistory from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete( DepartmentStockInHistory data);
        
        /// <summary>
        /// Delete  DepartmentStockInHistory from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all  DepartmentStockInHistory from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList<DepartmentStockInHistory> FindAll(ObjectCriteria<DepartmentStockInHistory> criteria);
        
        /// <summary>
        /// Find all  DepartmentStockInHistory from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria<DepartmentStockInHistory> criteria);
    }
}