			 
			 

using System;
using System.Collections;
using CoralPOS.Models;

namespace POSServer.DataLayer.Implement
{
    public interface ICashIoTransactionLogic
    {
        /// <summary>
        /// Find  CashIoTransaction object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of  CashIoTransaction</param>
        /// <returns></returns>
         CashIoTransaction FindById(object id);
        
        /// <summary>
        /// Add  CashIoTransaction to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
         CashIoTransaction Add( CashIoTransaction data);
        
        /// <summary>
        /// Update  CashIoTransaction to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update( CashIoTransaction data);
        
        /// <summary>
        /// Delete  CashIoTransaction from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete( CashIoTransaction data);
        
        /// <summary>
        /// Delete  CashIoTransaction from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all  CashIoTransaction from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all  CashIoTransaction from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
    }
}