			 
			 

using System;
using System.Collections;
using System.Collections.Generic;
using CoralPOS.Models;
using POSServer.DataLayer.Implement;

namespace POSServer.BusinessLogic.Implement
{
    public interface IProductLogic
    {
        /// <summary>
        /// Find  Product object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of  Product</param>
        /// <returns></returns>
         Product FindById(object id);
        
        /// <summary>
        /// Add  Product to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
         Product Add( Product data);
        
        /// <summary>
        /// Update  Product to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update( Product data);
        
        /// <summary>
        /// Delete  Product from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete( Product data);
        
        /// <summary>
        /// Delete  Product from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all  Product from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList<Product> FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all  Product from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
    }
}