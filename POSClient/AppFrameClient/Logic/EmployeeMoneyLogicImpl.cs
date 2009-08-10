using System.Collections;
using AppFrame;
using AppFrame.DataLayer;
using AppFrame.Logic;
using AppFrame.Model;
using Spring.Transaction.Interceptor;

namespace AppFrameClient.Logic
{
    public class EmployeeMoneyLogicImpl : IEmployeeMoneyLogic
    {
        private IEmployeeMoneyDAO _EmployeeMoneyDAO;

        public IEmployeeMoneyDAO EmployeeMoneyDAO
        {
            get 
            { 
                return _EmployeeMoneyDAO; 
            }
            set 
            { 
                _EmployeeMoneyDAO = value; 
            }
        }
        
        /// <summary>
        /// Find EmployeeMoney object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of EmployeeMoney</param>
        /// <returns></returns>
        public EmployeeMoney FindById(object id)
        {
            return EmployeeMoneyDAO.FindById(id);
        }
        
        /// <summary>
        /// Add EmployeeMoney to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public EmployeeMoney Add(EmployeeMoney data)
        {
            EmployeeMoneyDAO.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update EmployeeMoney to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(EmployeeMoney data)
        {
            EmployeeMoneyDAO.Update(data);
        }
        
        /// <summary>
        /// Delete EmployeeMoney from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(EmployeeMoney data)
        {
            EmployeeMoneyDAO.Delete(data);
        }
        
        /// <summary>
        /// Delete EmployeeMoney from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            EmployeeMoneyDAO.DeleteById(id);
        }
        
        /// <summary>
        /// Find all EmployeeMoney from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return EmployeeMoneyDAO.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all EmployeeMoney from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return EmployeeMoneyDAO.FindPaging(criteria);
        }
    }
}