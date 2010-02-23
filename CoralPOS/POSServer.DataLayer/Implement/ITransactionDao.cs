
using System;

namespace POSServer.DataLayer.Implement
{
	
    public interface ITransactionDao
    {
        /// <summary>
        /// Find Transaction object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of Transaction</param>
        /// <returns></returns>
        Transaction FindById(object id);
        
        /// <summary>
        /// Add Transaction to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Transaction Add(Transaction data);
        
        /// <summary>
        /// Update Transaction to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Update(Transaction data);
        
        /// <summary>
        /// Delete Transaction from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Delete(Transaction data);
        
        /// <summary>
        /// Delete Transaction from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DeleteById(object id);
        
        /// <summary>
        /// Find all Transaction from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList<Transaction> FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all Transaction from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
        
        /// <summary>
        /// Find min, max, count... Transaction from database.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        object SelectSpecificType(ObjectCriteria criteria, IProjection type); 
    }
}
