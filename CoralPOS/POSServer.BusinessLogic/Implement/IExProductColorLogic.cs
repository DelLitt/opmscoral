			 
			 

using System;
using System.Collections;
using System.Collections.Generic;
using AppFrame.Base;
using CoralPOS.Models;
using POSServer.DataLayer.Implement;

namespace POSServer.BusinessLogic.Implement
{
    public interface IExProductColorLogic
    {
        /// <summary>
        /// Find  ExProductColor object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of  ExProductColor</param>
        /// <returns></returns>
         ExProductColor FindById(object id);
        
        /// <summary>
        /// Add  ExProductColor to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
         ExProductColor Add( ExProductColor data);
        
        /// <summary>
        /// Update  ExProductColor to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update( ExProductColor data);
        
        /// <summary>
        /// Delete  ExProductColor from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete( ExProductColor data);
        
        /// <summary>
        /// Delete  ExProductColor from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all  ExProductColor from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList<ExProductColor> FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all  ExProductColor from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="flowSession"></param>
        void LoadProductColorDefinition(IFlowSession flowSession);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        void Process(IFlowSession session);
    }
}