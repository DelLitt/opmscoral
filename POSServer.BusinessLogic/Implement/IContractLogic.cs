			 
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
    public interface IContractLogic
    {
        /// <summary>
        /// Find  Contract object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of  Contract</param>
        /// <returns></returns>
         Contract FindById(object id);
        
        /// <summary>
        /// Add  Contract to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
         Contract Add( Contract data);
        
        /// <summary>
        /// Update  Contract to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update( Contract data);
        
        /// <summary>
        /// Delete  Contract from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete( Contract data);
        
        /// <summary>
        /// Delete  Contract from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all  Contract from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList<Contract> FindAll(ObjectCriteria<Contract> criteria);
        
        /// <summary>
        /// Find all  Contract from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria<Contract> criteria);
    }
}