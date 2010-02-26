			 
			 

using System;
using System.Collections;
using System.Collections.Generic;
using CoralPOS.Models;
using POSServer.DataLayer.Implement;

namespace POSServer.BusinessLogic.Implement
{
    public interface ISimilarProductLogic
    {
        /// <summary>
        /// Find  SimilarProduct object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of  SimilarProduct</param>
        /// <returns></returns>
         SimilarProduct FindById(object id);
        
        /// <summary>
        /// Add  SimilarProduct to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
         SimilarProduct Add( SimilarProduct data);
        
        /// <summary>
        /// Update  SimilarProduct to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update( SimilarProduct data);
        
        /// <summary>
        /// Delete  SimilarProduct from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete( SimilarProduct data);
        
        /// <summary>
        /// Delete  SimilarProduct from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all  SimilarProduct from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList<SimilarProduct> FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all  SimilarProduct from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
    }
}