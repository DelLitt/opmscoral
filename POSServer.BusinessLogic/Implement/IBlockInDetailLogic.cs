			 
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
    public interface IBlockInDetailLogic
    {
        /// <summary>
        /// Find  BlockInDetail object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of  BlockInDetail</param>
        /// <returns></returns>
         BlockInDetail FindById(object id);
        
        /// <summary>
        /// Add  BlockInDetail to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
         BlockInDetail Add( BlockInDetail data);
        
        /// <summary>
        /// Update  BlockInDetail to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update( BlockInDetail data);
        
        /// <summary>
        /// Delete  BlockInDetail from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete( BlockInDetail data);
        
        /// <summary>
        /// Delete  BlockInDetail from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all  BlockInDetail from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList<BlockInDetail> FindAll(ObjectCriteria<BlockInDetail> criteria);
        
        /// <summary>
        /// Find all  BlockInDetail from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria<BlockInDetail> criteria);
    }
}