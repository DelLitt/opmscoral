			 
			 

using System;
using System.Collections;
using System.Collections.Generic;
using CoralPOS.Models;
using POSServer.DataLayer.Implement;

namespace POSServer.BusinessLogic.Implement
{
    public interface IReturnProductLogic
    {
        /// <summary>
        /// Find  ReturnProduct object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of  ReturnProduct</param>
        /// <returns></returns>
         ReturnProduct FindById(object id);
        
        /// <summary>
        /// Add  ReturnProduct to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
         ReturnProduct Add( ReturnProduct data);
        
        /// <summary>
        /// Update  ReturnProduct to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update( ReturnProduct data);
        
        /// <summary>
        /// Delete  ReturnProduct from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete( ReturnProduct data);
        
        /// <summary>
        /// Delete  ReturnProduct from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all  ReturnProduct from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList<ReturnProduct> FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all  ReturnProduct from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
    }
}