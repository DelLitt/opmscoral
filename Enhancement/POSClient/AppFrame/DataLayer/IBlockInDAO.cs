using System;
using System.Collections;
using AppFrame.Model;
using NHibernate.Criterion;

namespace AppFrame.DataLayer
{
    public interface IBlockInDAO
    {
        /// <summary>
        /// Find BlockIn object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of BlockIn</param>
        /// <returns></returns>
        BlockIn FindById(object id);
        
        /// <summary>
        /// Add BlockIn to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        BlockIn Add(BlockIn data);
        
        /// <summary>
        /// Update BlockIn to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update(BlockIn data);
        
        /// <summary>
        /// Delete BlockIn from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete(BlockIn data);
        
        /// <summary>
        /// Delete BlockIn from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all BlockIn from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all BlockIn from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
        
        /// <summary>
        /// Find min, max, count... BlockIn from database.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        object SelectSpecificType(ObjectCriteria criteria, IProjection type);
    }
}