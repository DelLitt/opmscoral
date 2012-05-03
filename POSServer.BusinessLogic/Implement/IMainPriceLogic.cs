			 
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
    public interface IMainPriceLogic
    {
        /// <summary>
        /// Find  MainPrice object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of  MainPrice</param>
        /// <returns></returns>
         MainPrice FindById(object id);
        
        /// <summary>
        /// Add  MainPrice to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
         MainPrice Add( MainPrice data);
        
        /// <summary>
        /// Update  MainPrice to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update( MainPrice data);
        
        /// <summary>
        /// Delete  MainPrice from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete( MainPrice data);
        
        /// <summary>
        /// Delete  MainPrice from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all  MainPrice from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList<MainPrice> FindAll(ObjectCriteria<MainPrice> criteria);
        
        /// <summary>
        /// Find all  MainPrice from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria<MainPrice> criteria);
    }
}