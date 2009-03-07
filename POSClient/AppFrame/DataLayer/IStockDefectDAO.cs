using System;
using System.Collections;
using AppFrame.Model;
using NHibernate.Criterion;

namespace AppFrame.DataLayer
{
    public interface IStockDefectDAO
    {
        /// <summary>
        /// Find StockDefect object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of StockDefect</param>
        /// <returns></returns>
        StockDefect FindById(object id);

        /// <summary>
        /// Add StockDefect to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        StockDefect Add(StockDefect data);

        /// <summary>
        /// Update StockDefect to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update(StockDefect data);

        /// <summary>
        /// Delete StockDefect from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete(StockDefect data);

        /// <summary>
        /// Delete StockDefect from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);

        /// <summary>
        /// Find all StockDefect from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList FindAll(ObjectCriteria criteria);

        /// <summary>
        /// Find all StockDefect from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);

        /// <summary>
        /// Find min, max, count... StockDefect from database.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        object SelectSpecificType(ObjectCriteria criteria, IProjection type);
    }
}