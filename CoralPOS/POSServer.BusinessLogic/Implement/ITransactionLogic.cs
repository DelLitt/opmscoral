			 
			 

using System;
using System.Collections;
using System.Collections.Generic;
using CoralPOS.Models;
using POSServer.DataLayer.Implement;

namespace POSServer.BusinessLogic.Implement
{
    public interface ITransactionLogic
    {
        /// <summary>
        /// Find  Transaction object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of  Transaction</param>
        /// <returns></returns>
         Transaction FindById(object id);
        
        /// <summary>
        /// Add  Transaction to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
         Transaction Add( Transaction data);
        
        /// <summary>
        /// Update  Transaction to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update( Transaction data);
        
        /// <summary>
        /// Delete  Transaction from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete( Transaction data);
        
        /// <summary>
        /// Delete  Transaction from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all  Transaction from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList<Transaction> FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all  Transaction from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
    }
}