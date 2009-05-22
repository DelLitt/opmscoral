using System;
using System.Collections;
using AppFrame;
using CoralPOS.Interfaces.Model;

namespace CoralPOS.Interfaces.Logic
{
    public interface IBlockInCostLogic
    {
        /// <summary>
        /// Find BlockInCost object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of BlockInCost</param>
        /// <returns></returns>
        BlockInCost FindById(object id);
        
        /// <summary>
        /// Add BlockInCost to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        BlockInCost Add(BlockInCost data);
        
        /// <summary>
        /// Update BlockInCost to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update(BlockInCost data);
        
        /// <summary>
        /// Delete BlockInCost from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete(BlockInCost data);
        
        /// <summary>
        /// Delete BlockInCost from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all BlockInCost from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all BlockInCost from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
    }
}