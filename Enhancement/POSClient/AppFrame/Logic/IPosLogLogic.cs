using System;
using System.Collections;
using AppFrame.Model;

namespace AppFrame.Logic
{
    public interface IPosLogLogic
    {
        /// <summary>
        /// Find PosLog object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of PosLog</param>
        /// <returns></returns>
        PosLog FindById(object id);
        
        /// <summary>
        /// Add PosLog to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        PosLog Add(PosLog data);
        
        /// <summary>
        /// Update PosLog to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update(PosLog data);
        
        /// <summary>
        /// Delete PosLog from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete(PosLog data);
        
        /// <summary>
        /// Delete PosLog from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all PosLog from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all PosLog from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
    }
}