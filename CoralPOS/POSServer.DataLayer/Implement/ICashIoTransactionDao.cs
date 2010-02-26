			 
using System;
using System.Collections;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;
using Spring.Data.NHibernate;
using CoralPOS.Models;

namespace POSServer.DataLayer.Implement
{
	
    public interface ICashIoTransactionDao
    {
        /// <summary>
        /// Find CashIoTransaction object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of CashIoTransaction</param>
        /// <returns></returns>
        CashIoTransaction FindById(object id);
        
        /// <summary>
        /// Add CashIoTransaction to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        CashIoTransaction Add(CashIoTransaction data);
        
        /// <summary>
        /// Update CashIoTransaction to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Update(CashIoTransaction data);
        
        /// <summary>
        /// Delete CashIoTransaction from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Delete(CashIoTransaction data);
        
        /// <summary>
        /// Delete CashIoTransaction from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DeleteById(object id);
        
        /// <summary>
        /// Find all CashIoTransaction from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList<CashIoTransaction> FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all CashIoTransaction from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
        
        /// <summary>
        /// Find min, max, count... CashIoTransaction from database.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        object SelectSpecificType(ObjectCriteria criteria, IProjection type); 
    }
}
