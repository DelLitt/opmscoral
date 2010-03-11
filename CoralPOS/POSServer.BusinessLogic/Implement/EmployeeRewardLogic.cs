			 


using System.Collections;
using System.Collections.Generic;
using Spring.Transaction.Interceptor;
using  CoralPOS.Models;
using  POSServer.DataLayer.Implement;

namespace POSServer.BusinessLogic.Implement
{
    public class EmployeeRewardLogic : IEmployeeRewardLogic
    {
        private IEmployeeRewardDao _innerDao;
        public IEmployeeRewardDao EmployeeRewardDao
        {
            get 
            { 
                return _innerDao; 
            }
            set 
            { 
                _innerDao = value; 
            }
        }
        
        /// <summary>
        /// Find EmployeeReward object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of EmployeeReward</param>
        /// <returns></returns>
        public EmployeeReward FindById(object id)
        {
            return EmployeeRewardDao.FindById(id);
        }
        
        /// <summary>
        /// Add EmployeeReward to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public EmployeeReward Add(EmployeeReward data)
        {
            EmployeeRewardDao.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update EmployeeReward to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(EmployeeReward data)
        {
            EmployeeRewardDao.Update(data);
        }
        
        /// <summary>
        /// Delete EmployeeReward from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(EmployeeReward data)
        {
            EmployeeRewardDao.Delete(data);
        }
        
        /// <summary>
        /// Delete EmployeeReward from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            EmployeeRewardDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all EmployeeReward from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<EmployeeReward> FindAll(ObjectCriteria criteria)
        {
            return EmployeeRewardDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all EmployeeReward from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return EmployeeRewardDao.FindPaging(criteria);
        }
    }
}