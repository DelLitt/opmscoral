using System;
using System.Collections;
using AppFrame.Model;

namespace AppFrame.Logic
{
    public interface ICustomerDetailLogic
    {
        /// <summary>
        /// Find CustomerDetail object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of CustomerDetail</param>
        /// <returns></returns>
        CustomerDetail FindById(object id);
        
        /// <summary>
        /// Add CustomerDetail to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        CustomerDetail Add(CustomerDetail data);
        
        /// <summary>
        /// Update CustomerDetail to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update(CustomerDetail data);
        
        /// <summary>
        /// Delete CustomerDetail from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete(CustomerDetail data);
        
        /// <summary>
        /// Delete CustomerDetail from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all CustomerDetail from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all CustomerDetail from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
    }
}