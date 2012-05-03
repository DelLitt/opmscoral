			 
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
    public interface IProductUnitLogic
    {
        /// <summary>
        /// Find  ProductUnit object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of  ProductUnit</param>
        /// <returns></returns>
         ProductUnit FindById(object id);
        
        /// <summary>
        /// Add  ProductUnit to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
         ProductUnit Add( ProductUnit data);
        
        /// <summary>
        /// Update  ProductUnit to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update( ProductUnit data);
        
        /// <summary>
        /// Delete  ProductUnit from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete( ProductUnit data);
        
        /// <summary>
        /// Delete  ProductUnit from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all  ProductUnit from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList<ProductUnit> FindAll(ObjectCriteria<ProductUnit> criteria);
        
        /// <summary>
        /// Find all  ProductUnit from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria<ProductUnit> criteria);
    }
}