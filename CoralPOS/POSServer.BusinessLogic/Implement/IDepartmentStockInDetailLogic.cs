			 
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
    public interface IDepartmentStockInDetailLogic
    {
        /// <summary>
        /// Find  DepartmentStockInDetail object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of  DepartmentStockInDetail</param>
        /// <returns></returns>
         DepartmentStockInDetail FindById(object id);
        
        /// <summary>
        /// Add  DepartmentStockInDetail to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
         DepartmentStockInDetail Add( DepartmentStockInDetail data);
        
        /// <summary>
        /// Update  DepartmentStockInDetail to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update( DepartmentStockInDetail data);
        
        /// <summary>
        /// Delete  DepartmentStockInDetail from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete( DepartmentStockInDetail data);
        
        /// <summary>
        /// Delete  DepartmentStockInDetail from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all  DepartmentStockInDetail from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList<DepartmentStockInDetail> FindAll(ObjectCriteria<DepartmentStockInDetail> criteria);
        
        /// <summary>
        /// Find all  DepartmentStockInDetail from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria<DepartmentStockInDetail> criteria);
    }
}