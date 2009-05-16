using System;
using System.Collections;
using AppFrame.Model;

namespace AppFrame.Logic
{
    public interface IReturnBlockInLogic
    {
        /// <summary>
        /// Find ReturnBlockIn object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of ReturnBlockIn</param>
        /// <returns></returns>
        ReturnBlockIn FindById(object id);
        
        /// <summary>
        /// Add ReturnBlockIn to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        ReturnBlockIn Add(ReturnBlockIn data);
        
        /// <summary>
        /// Update ReturnBlockIn to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update(ReturnBlockIn data);
        
        /// <summary>
        /// Delete ReturnBlockIn from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete(ReturnBlockIn data);
        
        /// <summary>
        /// Delete ReturnBlockIn from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all ReturnBlockIn from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all ReturnBlockIn from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
    }
}