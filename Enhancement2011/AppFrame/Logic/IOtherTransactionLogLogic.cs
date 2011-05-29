using System;
using System.Collections;
using AppFrame.Model;

namespace AppFrame.Logic
{
    public interface IOtherTransactionLogLogic
    {
        /// <summary>
        /// Find OtherTransactionLog object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of OtherTransactionLog</param>
        /// <returns></returns>
        OtherTransactionLog FindById(object id);
        
        /// <summary>
        /// Add OtherTransactionLog to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        OtherTransactionLog Add(OtherTransactionLog data);
        
        /// <summary>
        /// Update OtherTransactionLog to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update(OtherTransactionLog data);
        
        /// <summary>
        /// Delete OtherTransactionLog from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete(OtherTransactionLog data);
        
        /// <summary>
        /// Delete OtherTransactionLog from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all OtherTransactionLog from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all OtherTransactionLog from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
    }
}