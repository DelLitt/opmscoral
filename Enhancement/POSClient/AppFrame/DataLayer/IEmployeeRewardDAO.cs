using System;
using System.Collections;
using AppFrame.Model;
using NHibernate.Criterion;

namespace AppFrame.DataLayer
{
    public interface IEmployeeRewardDAO
    {
        /// <summary>
        /// Find EmployeeReward object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of EmployeeReward</param>
        /// <returns></returns>
        EmployeeReward FindById(object id);
        
        /// <summary>
        /// Add EmployeeReward to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        EmployeeReward Add(EmployeeReward data);
        
        /// <summary>
        /// Update EmployeeReward to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update(EmployeeReward data);
        
        /// <summary>
        /// Delete EmployeeReward from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete(EmployeeReward data);
        
        /// <summary>
        /// Delete EmployeeReward from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all EmployeeReward from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all EmployeeReward from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);
        
        /// <summary>
        /// Find min, max, count... EmployeeReward from database.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        object SelectSpecificType(ObjectCriteria criteria, IProjection type);
    }
}