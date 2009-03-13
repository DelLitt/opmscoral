using System;
using System.Collections;
using AppFrame.Model;

namespace AppFrame.Logic
{
    public interface IStockHistoryLogic
    {
        /// <summary>
        /// Find StockHistory object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of StockHistory</param>
        /// <returns></returns>
        StockHistory FindById(object id);

        /// <summary>
        /// Add StockHistory to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        StockHistory Add(StockHistory data);

        /// <summary>
        /// Update StockHistory to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update(StockHistory data);

        /// <summary>
        /// Delete StockHistory from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete(StockHistory data);

        /// <summary>
        /// Delete StockHistory from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);

        /// <summary>
        /// Find all StockHistory from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList FindAll(ObjectCriteria criteria);

        /// <summary>
        /// Find all StockHistory from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);

        void Process(StockHistory defect);
        long FindMaxStockHistoryId();
        IList FindAllProductMasters();
        IList FindByProductMasterName(ProductMaster master);
    }
}