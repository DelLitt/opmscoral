using System.Collections;
using Spring.Transaction.Interceptor;
using AppFrame.Model;
using AppFrame.DataLayer;

namespace AppFrame.Logic
{
    public class EmployeeLogicImpl : IEmployeeLogic
    {
        private IEmployeeDAO _employeeDAO;

        public IEmployeeDAO EmployeeDAO
        {
            get 
            { 
                return _employeeDAO; 
            }
            set 
            { 
                _employeeDAO = value; 
            }
        }
        
        /// <summary>
        /// Find Employee object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of Employee</param>
        /// <returns></returns>
        public Employee FindById(object id)
        {
            return EmployeeDAO.FindById(id);
        }
        
        /// <summary>
        /// Add Employee to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public Employee Add(Employee data)
        {
            EmployeeDAO.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update Employee to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(Employee data)
        {
            EmployeeDAO.Update(data);
        }
        
        /// <summary>
        /// Delete Employee from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(Employee data)
        {
            EmployeeDAO.Delete(data);
        }
        
        /// <summary>
        /// Delete Employee from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            EmployeeDAO.DeleteById(id);
        }
        
        /// <summary>
        /// Find all Employee from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return EmployeeDAO.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all Employee from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return EmployeeDAO.FindPaging(criteria);
        }
    }
}