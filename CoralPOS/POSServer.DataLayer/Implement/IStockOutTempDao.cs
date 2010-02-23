
using System;

namespace POSServer.DataLayer.Implement
{
	
    public interface IStockOutTempDao
    {
        /// <summary>
        /// Find StockOutTemp object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of StockOutTemp</param>
        /// <returns></returns>
        StockOutTemp FindById(object id);
        
        /// <summary>
        /// Add StockOutTemp to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        StockOutTemp Add(StockOutTemp data);
        
        /// <summary>
        /// Update StockOutTemp to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Update(StockOutTemp data);
        
        /// <summary>
        /// Delete StockOutTemp from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Delete(StockOutTemp data);
        
        /// <summary>
        /// Delete StockOutTemp from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DeleteById(object id);
        
        /// <summary>
        /// Find all StockOutTemp from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList<StockOutTemp> FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all StockOutTemp from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
        
        /// <summary>
        /// Find min, max, count... StockOutTemp from database.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        object SelectSpecificType(ObjectCriteria criteria, IProjection type); 
    }
}
