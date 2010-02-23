
using System;

namespace POSServer.DataLayer.Implement
{
	
    public interface ISaleTransactionDao
    {
        /// <summary>
        /// Find SaleTransaction object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of SaleTransaction</param>
        /// <returns></returns>
        SaleTransaction FindById(object id);
        
        /// <summary>
        /// Add SaleTransaction to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        SaleTransaction Add(SaleTransaction data);
        
        /// <summary>
        /// Update SaleTransaction to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Update(SaleTransaction data);
        
        /// <summary>
        /// Delete SaleTransaction from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Delete(SaleTransaction data);
        
        /// <summary>
        /// Delete SaleTransaction from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DeleteById(object id);
        
        /// <summary>
        /// Find all SaleTransaction from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList<SaleTransaction> FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all SaleTransaction from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
        
        /// <summary>
        /// Find min, max, count... SaleTransaction from database.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        object SelectSpecificType(ObjectCriteria criteria, IProjection type); 
    }
}
