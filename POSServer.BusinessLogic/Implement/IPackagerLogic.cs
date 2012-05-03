			 
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
    public interface IPackagerLogic
    {
        /// <summary>
        /// Find  Packager object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of  Packager</param>
        /// <returns></returns>
         Packager FindById(object id);
        
        /// <summary>
        /// Add  Packager to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
         Packager Add( Packager data);
        
        /// <summary>
        /// Update  Packager to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update( Packager data);
        
        /// <summary>
        /// Delete  Packager from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete( Packager data);
        
        /// <summary>
        /// Delete  Packager from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all  Packager from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList<Packager> FindAll(ObjectCriteria<Packager> criteria);
        
        /// <summary>
        /// Find all  Packager from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria<Packager> criteria);
    }
}