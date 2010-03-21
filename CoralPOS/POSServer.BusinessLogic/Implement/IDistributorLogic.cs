			 
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
    public interface IDistributorLogic
    {
        /// <summary>
        /// Find  Distributor object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of  Distributor</param>
        /// <returns></returns>
         Distributor FindById(object id);
        
        /// <summary>
        /// Add  Distributor to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
         Distributor Add( Distributor data);
        
        /// <summary>
        /// Update  Distributor to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update( Distributor data);
        
        /// <summary>
        /// Delete  Distributor from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete( Distributor data);
        
        /// <summary>
        /// Delete  Distributor from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all  Distributor from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList<Distributor> FindAll(ObjectCriteria<Distributor> criteria);
        
        /// <summary>
        /// Find all  Distributor from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria<Distributor> criteria);
    }
}