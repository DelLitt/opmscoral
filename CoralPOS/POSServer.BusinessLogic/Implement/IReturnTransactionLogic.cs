			 
			 

using System;
using System.Collections;
using System.Collections.Generic;
using CoralPOS.Models;
using POSServer.DataLayer.Implement;

namespace POSServer.BusinessLogic.Implement
{
    public interface IReturnTransactionLogic
    {
        /// <summary>
        /// Find  ReturnTransaction object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of  ReturnTransaction</param>
        /// <returns></returns>
         ReturnTransaction FindById(object id);
        
        /// <summary>
        /// Add  ReturnTransaction to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
         ReturnTransaction Add( ReturnTransaction data);
        
        /// <summary>
        /// Update  ReturnTransaction to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update( ReturnTransaction data);
        
        /// <summary>
        /// Delete  ReturnTransaction from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete( ReturnTransaction data);
        
        /// <summary>
        /// Delete  ReturnTransaction from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all  ReturnTransaction from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList<ReturnTransaction> FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all  ReturnTransaction from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
    }
}