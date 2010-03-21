			 
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
    public interface IDepartmentStockTemployeeValidLogic
    {
        /// <summary>
        /// Find  DepartmentStockTemployeeValid object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of  DepartmentStockTemployeeValid</param>
        /// <returns></returns>
         DepartmentStockTemployeeValid FindById(object id);
        
        /// <summary>
        /// Add  DepartmentStockTemployeeValid to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
         DepartmentStockTemployeeValid Add( DepartmentStockTemployeeValid data);
        
        /// <summary>
        /// Update  DepartmentStockTemployeeValid to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update( DepartmentStockTemployeeValid data);
        
        /// <summary>
        /// Delete  DepartmentStockTemployeeValid from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete( DepartmentStockTemployeeValid data);
        
        /// <summary>
        /// Delete  DepartmentStockTemployeeValid from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all  DepartmentStockTemployeeValid from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList<DepartmentStockTemployeeValid> FindAll(ObjectCriteria<DepartmentStockTemployeeValid> criteria);
        
        /// <summary>
        /// Find all  DepartmentStockTemployeeValid from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria<DepartmentStockTemployeeValid> criteria);
    }
}