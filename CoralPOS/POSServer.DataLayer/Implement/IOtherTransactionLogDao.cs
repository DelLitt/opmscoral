			 
using System;
using System.Collections;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;
using Spring.Data.NHibernate;
using CoralPOS.Models;

namespace POSServer.DataLayer.Implement
{
	
    public interface IOtherTransactionLogDao
    {
        /// <summary>
        /// Find OtherTransactionLog object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of OtherTransactionLog</param>
        /// <returns></returns>
        OtherTransactionLog FindById(object id);
        
        /// <summary>
        /// Add OtherTransactionLog to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        OtherTransactionLog Add(OtherTransactionLog data);
        
        /// <summary>
        /// Update OtherTransactionLog to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Update(OtherTransactionLog data);
        
        /// <summary>
        /// Delete OtherTransactionLog from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Delete(OtherTransactionLog data);
        
        /// <summary>
        /// Delete OtherTransactionLog from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DeleteById(object id);
        
        /// <summary>
        /// Find all OtherTransactionLog from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList<OtherTransactionLog> FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all OtherTransactionLog from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
        
        /// <summary>
        /// Find min, max, count... OtherTransactionLog from database.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        object SelectSpecificType(ObjectCriteria criteria, IProjection type); 
    }
}
