			 
			 

using System;
using System.Collections;
using System.Collections.Generic;
using CoralPOS.Models;
using POSServer.DataLayer.Implement;

namespace POSServer.BusinessLogic.Implement
{
    public interface IEmpLogic
    {
        /// <summary>
        /// Find  Emp object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of  Emp</param>
        /// <returns></returns>
         Emp FindById(object id);
        
        /// <summary>
        /// Add  Emp to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
         Emp Add( Emp data);
        
        /// <summary>
        /// Update  Emp to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update( Emp data);
        
        /// <summary>
        /// Delete  Emp from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete( Emp data);
        
        /// <summary>
        /// Delete  Emp from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all  Emp from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList<Emp> FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all  Emp from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
    }
}