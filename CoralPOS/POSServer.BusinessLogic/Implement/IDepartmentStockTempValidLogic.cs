			 
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
    public interface IDepartmentStockTempValidLogic
    {
        /// <summary>
        /// Find  DepartmentStockTemployeeValid object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of  DepartmentStockTemployeeValid</param>
        /// <returns></returns>
         DepartmentStockTempValid FindById(object id);
        
        /// <summary>
        /// Add  DepartmentStockTemployeeValid to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
         DepartmentStockTempValid Add( DepartmentStockTempValid data);
        
        /// <summary>
        /// Update  DepartmentStockTemployeeValid to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update( DepartmentStockTempValid data);
        
        /// <summary>
        /// Delete  DepartmentStockTemployeeValid from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete( DepartmentStockTempValid data);
        
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
        IList<DepartmentStockTempValid> FindAll(ObjectCriteria<DepartmentStockTempValid> criteria);
        
        /// <summary>
        /// Find all  DepartmentStockTemployeeValid from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria<DepartmentStockTempValid> criteria);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="selectedDepartment"></param>
        /// <returns></returns>
        IList<DepartmentStockTempValid> FindStockTempValidForDepartment(Department selectedDepartment);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        DepartmentStockTempValid CreateFromProductId(string productId,long departmentId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stockInventoryList"></param>
        void AddBatch(IList<DepartmentStockTempValid> stockInventoryList);
    }
}