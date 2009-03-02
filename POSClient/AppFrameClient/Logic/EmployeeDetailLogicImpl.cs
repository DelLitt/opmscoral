using System.Collections;
using Spring.Transaction.Interceptor;
using AppFrame.Model;
using AppFrame.DataLayer;

namespace AppFrame.Logic
{
    public class EmployeeDetailLogicImpl : IEmployeeDetailLogic
    {
        private IEmployeeDetailDAO _employeeDetailDAO;

        public IEmployeeDetailDAO EmployeeDetailDAO
        {
            get 
            { 
                return _employeeDetailDAO; 
            }
            set 
            { 
                _employeeDetailDAO = value; 
            }
        }
        
        /// <summary>
        /// Find EmployeeInfo object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of EmployeeInfo</param>
        /// <returns></returns>
        public EmployeeInfo FindById(object id)
        {
            return EmployeeDetailDAO.FindById(id);
        }
        
        /// <summary>
        /// Add EmployeeInfo to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public EmployeeInfo Add(EmployeeInfo data)
        {
            EmployeeDetailDAO.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update EmployeeInfo to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(EmployeeInfo data)
        {
            EmployeeDetailDAO.Update(data);
        }
        
        /// <summary>
        /// Delete EmployeeInfo from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(EmployeeInfo data)
        {
            EmployeeDetailDAO.Delete(data);
        }
        
        /// <summary>
        /// Delete EmployeeInfo from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            EmployeeDetailDAO.DeleteById(id);
        }
        
        /// <summary>
        /// Find all EmployeeInfo from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return EmployeeDetailDAO.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all EmployeeInfo from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return EmployeeDetailDAO.FindPaging(criteria);
        }
    }
}