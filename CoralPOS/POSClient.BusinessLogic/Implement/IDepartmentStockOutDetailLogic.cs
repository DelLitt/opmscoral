			 
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
    public interface IDepartmentStockOutDetailLogic
    {
        /// <summary>
        /// Find  DepartmentStockOutDetail object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of  DepartmentStockOutDetail</param>
        /// <returns></returns>
         DepartmentStockOutDetail FindById(object id);
        
        /// <summary>
        /// Add  DepartmentStockOutDetail to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
         DepartmentStockOutDetail Add( DepartmentStockOutDetail data);
        
        /// <summary>
        /// Update  DepartmentStockOutDetail to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update( DepartmentStockOutDetail data);
        
        /// <summary>
        /// Delete  DepartmentStockOutDetail from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete( DepartmentStockOutDetail data);
        
        /// <summary>
        /// Delete  DepartmentStockOutDetail from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all  DepartmentStockOutDetail from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList<DepartmentStockOutDetail> FindAll(ObjectCriteria<DepartmentStockOutDetail> criteria);
        
        /// <summary>
        /// Find all  DepartmentStockOutDetail from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria<DepartmentStockOutDetail> criteria);
    }
}