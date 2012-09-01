			 
using System;
using System.Collections;
using System.Collections.Generic;
using AppFrame.DataLayer;
using NHibernate;
using NHibernate.Criterion;
using Spring.Data.NHibernate;
using CoralPOS.Models;
using POSClient.DataLayer.Implement;

namespace POSClient.BusinessLogic.Implement
{
    public interface IMainStockHistoryLogic
    {
        /// <summary>
        /// Find  MainStockHistory object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of  MainStockHistory</param>
        /// <returns></returns>
         MainStockHistory FindById(object id);
        
        /// <summary>
        /// Add  MainStockHistory to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
         MainStockHistory Add( MainStockHistory data);
        
        /// <summary>
        /// Update  MainStockHistory to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update( MainStockHistory data);
        
        /// <summary>
        /// Delete  MainStockHistory from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete( MainStockHistory data);
        
        /// <summary>
        /// Delete  MainStockHistory from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all  MainStockHistory from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList<MainStockHistory> FindAll(ObjectCriteria<MainStockHistory> criteria);
        
        /// <summary>
        /// Find all  MainStockHistory from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria<MainStockHistory> criteria);
    }
}