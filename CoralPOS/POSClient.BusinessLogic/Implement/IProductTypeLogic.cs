			 
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
    public interface IProductTypeLogic
    {
        /// <summary>
        /// Find  ProductType object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of  ProductType</param>
        /// <returns></returns>
         ProductType FindById(object id);
        
        /// <summary>
        /// Add  ProductType to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
         ProductType Add( ProductType data);
        
        /// <summary>
        /// Update  ProductType to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update( ProductType data);
        
        /// <summary>
        /// Delete  ProductType from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete( ProductType data);
        
        /// <summary>
        /// Delete  ProductType from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all  ProductType from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList<ProductType> FindAll(ObjectCriteria<ProductType> criteria);
        
        /// <summary>
        /// Find all  ProductType from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria<ProductType> criteria);
    }
}