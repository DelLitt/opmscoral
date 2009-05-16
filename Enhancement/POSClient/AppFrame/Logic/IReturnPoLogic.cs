using System;
using System.Collections;
using AppFrame.Model;

namespace AppFrame.Logic
{
    public interface IReturnPoLogic
    {
        /// <summary>
        /// Find ReturnPo object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of ReturnPo</param>
        /// <returns></returns>
        ReturnPo FindById(object id);
        
        /// <summary>
        /// Add ReturnPo to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        ReturnPo Add(ReturnPo data);
        
        /// <summary>
        /// Update ReturnPo to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update(ReturnPo data);
        
        /// <summary>
        /// Delete ReturnPo from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete(ReturnPo data);
        
        /// <summary>
        /// Delete ReturnPo from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all ReturnPo from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all ReturnPo from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);

        object FindQuantityById(ReturnPoPK pk);
    }
}