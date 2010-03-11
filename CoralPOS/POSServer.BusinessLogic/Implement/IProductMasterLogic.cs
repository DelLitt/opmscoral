			 
			 

using System;
using System.Collections;
using System.Collections.Generic;
using CoralPOS.Models;
using POSServer.DataLayer.Implement;

namespace POSServer.BusinessLogic.Implement
{
    public interface IProductMasterLogic
    {
        /// <summary>
        /// Find  ProductMaster object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of  ProductMaster</param>
        /// <returns></returns>
         ProductMaster FindById(object id);
        
        /// <summary>
        /// Add  ProductMaster to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
         ProductMaster Add( ProductMaster data);
        
        /// <summary>
        /// Update  ProductMaster to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update( ProductMaster data);
        
        /// <summary>
        /// Delete  ProductMaster from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete( ProductMaster data);
        
        /// <summary>
        /// Delete  ProductMaster from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all  ProductMaster from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList<ProductMaster> FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all  ProductMaster from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
    }
}