using System;
using System.Collections;
using AppFrame.Model;

namespace AppFrame.Logic
{
    public interface IStockOutDetailLogic
    {
        /// <summary>
        /// Find StockOutDetail object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of StockOutDetail</param>
        /// <returns></returns>
        StockOutDetail FindById(object id);
        
        /// <summary>
        /// Add StockOutDetail to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        StockOutDetail Add(StockOutDetail data);
        
        /// <summary>
        /// Update StockOutDetail to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update(StockOutDetail data);
        
        /// <summary>
        /// Delete StockOutDetail from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete(StockOutDetail data);
        
        /// <summary>
        /// Delete StockOutDetail from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all StockOutDetail from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all StockOutDetail from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);

        long FindMaxId();
    }
}