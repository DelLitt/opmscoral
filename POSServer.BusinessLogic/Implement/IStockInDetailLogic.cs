			 
using System;
using System.Collections;
using System.Collections.Generic;
using AppFrame.DataLayer;
using NHibernate;
using NHibernate.Criterion;
using Spring.Data.NHibernate;
using CoralPOS.Models;
using POSServer.DataLayer.Implement;

namespace POSServer.BusinessLogic.Implement
{
    public interface IStockInDetailLogic
    {
        /// <summary>
        /// Find  StockInDetail object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of  StockInDetail</param>
        /// <returns></returns>
         StockInDetail FindById(object id);
        
        /// <summary>
        /// Add  StockInDetail to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
         StockInDetail Add( StockInDetail data);
        
        /// <summary>
        /// Update  StockInDetail to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update( StockInDetail data);
        
        /// <summary>
        /// Delete  StockInDetail from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete( StockInDetail data);
        
        /// <summary>
        /// Delete  StockInDetail from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all  StockInDetail from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList<StockInDetail> FindAll(ObjectCriteria<StockInDetail> criteria);
        
        /// <summary>
        /// Find all  StockInDetail from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria<StockInDetail> criteria);
    }
}