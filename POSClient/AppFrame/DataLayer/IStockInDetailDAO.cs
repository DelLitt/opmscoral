using System;
using System.Collections;
using AppFrame.Model;
using NHibernate.Criterion;

namespace AppFrame.DataLayer
{
    public interface IStockInDetailDAO
    {
        /// <summary>
        /// Find StockInDetail object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of StockInDetail</param>
        /// <returns></returns>
        StockInDetail FindById(object id);
        
        /// <summary>
        /// Add StockInDetail to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        StockInDetail Add(StockInDetail data);
        
        /// <summary>
        /// Update StockInDetail to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update(StockInDetail data);
        
        /// <summary>
        /// Delete StockInDetail from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete(StockInDetail data);
        
        /// <summary>
        /// Delete StockInDetail from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all StockInDetail from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all StockInDetail from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
        
        /// <summary>
        /// Find min, max, count... StockInDetail from database.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        object SelectSpecificType(ObjectCriteria criteria, IProjection type);
    }
}