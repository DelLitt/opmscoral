using System;
using System.Collections;
using AppFrame.Model;

namespace AppFrame.Logic
{
    public interface IDepartmentStockOutLogic
    {
        /// <summary>
        /// Find DepartmentStockOut object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of DepartmentStockOut</param>
        /// <returns></returns>
        DepartmentStockOut FindById(object id);
        
        /// <summary>
        /// Add DepartmentStockOut to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        DepartmentStockOut Add(DepartmentStockOut data);
        
        /// <summary>
        /// Update DepartmentStockOut to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update(DepartmentStockOut data);
        
        /// <summary>
        /// Delete DepartmentStockOut from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete(DepartmentStockOut data);
        
        /// <summary>
        /// Delete DepartmentStockOut from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all DepartmentStockOut from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all DepartmentStockOut from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);

        long FindMaxId();
        IList FindStockOut(DateTime date, DateTime toDate);
        void ProcessErrorGoods(IList list, IList outList, IList stockOutList, IList goodsList);
        SyncFromDepartmentToMain GetSyncData(bool IsSubmitPeriod,DateTime lastSyncTime);
        void SyncToMain(SyncFromDepartmentToMain sync);
    }
}