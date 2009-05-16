using System.Collections;
using Spring.Transaction.Interceptor;
using AppFrame.Model;
using AppFrame.DataLayer;

namespace AppFrame.Logic
{
    public class EmployeeRewardLogicImpl : IEmployeeRewardLogic
    {
        private IEmployeeRewardDAO _employeeRewardDAO;

        public IEmployeeRewardDAO EmployeeRewardDAO
        {
            get 
            { 
                return _employeeRewardDAO; 
            }
            set 
            { 
                _employeeRewardDAO = value; 
            }
        }
        
        /// <summary>
        /// Find EmployeeReward object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of EmployeeReward</param>
        /// <returns></returns>
        public EmployeeReward FindById(object id)
        {
            return EmployeeRewardDAO.FindById(id);
        }
        
        /// <summary>
        /// Add EmployeeReward to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public EmployeeReward Add(EmployeeReward data)
        {
            EmployeeRewardDAO.Add(data);
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
            EmployeeRewardDAO.Update(data);
        }
        
        /// <summary>
        /// Delete EmployeeReward from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(EmployeeReward data)
        {
            EmployeeRewardDAO.Delete(data);
        }
        
        /// <summary>
        /// Delete EmployeeReward from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            EmployeeRewardDAO.DeleteById(id);
        }
        
        /// <summary>
        /// Find all EmployeeReward from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return EmployeeRewardDAO.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all EmployeeReward from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return EmployeeRewardDAO.FindPaging(criteria);
        }
    }
}