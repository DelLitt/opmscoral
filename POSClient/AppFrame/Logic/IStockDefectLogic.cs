using System;
using System.Collections;
using AppFrame.Model;

namespace AppFrame.Logic
{
    public interface IStockDefectLogic
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

        void Process(StockDefect defect);
        long FindMaxStockDefectId();
        IList FindAllProductMasters();
        IList FindByProductMasterName(ProductMaster master);
    }
}