using System;
using System.Collections;
using AppFrame.Model;
using NHibernate.Criterion;

namespace AppFrame.DataLayer
{
    public interface IStockInDAO
    {
        /// <summary>
        /// Find StockIn object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of StockIn</param>
        /// <returns></returns>
        StockIn FindById(object id);
        
        /// <summary>
        /// Add StockIn to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        StockIn Add(StockIn data);
        
        /// <summary>
        /// Update StockIn to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update(StockIn data);
        
        /// <summary>
        /// Delete StockIn from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete(StockIn data);
        
        /// <summary>
        /// Delete StockIn from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all StockIn from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all StockIn from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
        
        /// <summary>
        /// Find min, max, count... StockIn from database.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        object SelectSpecificType(ObjectCriteria criteria, IProjection type);

        IList FindByProductMaster(DateTime date, DateTime toDate);
    }
}