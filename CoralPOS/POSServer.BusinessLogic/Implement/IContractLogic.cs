			 
			 

using System;
using System.Collections;
using CoralPOS.Models;

namespace POSServer.DataLayer.Implement
{
    public interface IContractLogic
    {
        /// <summary>
        /// Find  Contract object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of  Contract</param>
        /// <returns></returns>
         Contract FindById(object id);
        
        /// <summary>
        /// Add  Contract to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
         Contract Add( Contract data);
        
        /// <summary>
        /// Update  Contract to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update( Contract data);
        
        /// <summary>
        /// Delete  Contract from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete( Contract data);
        
        /// <summary>
        /// Delete  Contract from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all  Contract from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all  Contract from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
    }
}