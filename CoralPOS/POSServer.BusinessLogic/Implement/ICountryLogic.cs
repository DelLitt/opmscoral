			 
			 

using System;
using System.Collections;
using CoralPOS.Models;

namespace POSServer.DataLayer.Implement
{
    public interface ICountryLogic
    {
        /// <summary>
        /// Find  Country object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of  Country</param>
        /// <returns></returns>
         Country FindById(object id);
        
        /// <summary>
        /// Add  Country to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
         Country Add( Country data);
        
        /// <summary>
        /// Update  Country to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update( Country data);
        
        /// <summary>
        /// Delete  Country from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete( Country data);
        
        /// <summary>
        /// Delete  Country from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all  Country from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all  Country from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
    }
}