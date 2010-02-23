			 
			 

using System;
using System.Collections;
using CoralPOS.Models;

namespace POSServer.DataLayer.Implement
{
    public interface IMainftrLogic
    {
        /// <summary>
        /// Find  Mainftr object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of  Mainftr</param>
        /// <returns></returns>
         Mainftr FindById(object id);
        
        /// <summary>
        /// Add  Mainftr to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
         Mainftr Add( Mainftr data);
        
        /// <summary>
        /// Update  Mainftr to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update( Mainftr data);
        
        /// <summary>
        /// Delete  Mainftr from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete( Mainftr data);
        
        /// <summary>
        /// Delete  Mainftr from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all  Mainftr from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all  Mainftr from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
    }
}