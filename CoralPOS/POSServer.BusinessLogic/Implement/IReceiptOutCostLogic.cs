			 
			 

using System;
using System.Collections;
using CoralPOS.Models;

namespace POSServer.DataLayer.Implement
{
    public interface IReceiptOutCostLogic
    {
        /// <summary>
        /// Find  ReceiptOutCost object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of  ReceiptOutCost</param>
        /// <returns></returns>
         ReceiptOutCost FindById(object id);
        
        /// <summary>
        /// Add  ReceiptOutCost to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
         ReceiptOutCost Add( ReceiptOutCost data);
        
        /// <summary>
        /// Update  ReceiptOutCost to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update( ReceiptOutCost data);
        
        /// <summary>
        /// Delete  ReceiptOutCost from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete( ReceiptOutCost data);
        
        /// <summary>
        /// Delete  ReceiptOutCost from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all  ReceiptOutCost from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all  ReceiptOutCost from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
    }
}