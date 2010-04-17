using System.Collections;
using Spring.Transaction.Interceptor;
using AppFrame.Model;
using AppFrame.DataLayer;

namespace AppFrame.Logic
{
    public class EmployeeWorkingDayLogicImpl : IEmployeeWorkingDayLogic
    {
        private IEmployeeWorkingDayDAO _employeeWorkingDayDAO;

        public IEmployeeWorkingDayDAO EmployeeWorkingDayDAO
        {
            get 
            { 
                return _employeeWorkingDayDAO; 
            }
            set 
            { 
                _employeeWorkingDayDAO = value; 
            }
        }
        
        /// <summary>
        /// Find EmployeeWorkingDay object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of EmployeeWorkingDay</param>
        /// <returns></returns>
        public EmployeeWorkingDay FindById(object id)
        {
            return EmployeeWorkingDayDAO.FindById(id);
        }
        
        /// <summary>
        /// Add EmployeeWorkingDay to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public EmployeeWorkingDay Add(EmployeeWorkingDay data)
        {
            EmployeeWorkingDayDAO.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update EmployeeWorkingDay to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(EmployeeWorkingDay data)
        {
            EmployeeWorkingDayDAO.Update(data);
        }
        
        /// <summary>
        /// Delete EmployeeWorkingDay from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(EmployeeWorkingDay data)
        {
            EmployeeWorkingDayDAO.Delete(data);
        }
        
        /// <summary>
        /// Delete EmployeeWorkingDay from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            EmployeeWorkingDayDAO.DeleteById(id);
        }
        
        /// <summary>
        /// Find all EmployeeWorkingDay from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return EmployeeWorkingDayDAO.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all EmployeeWorkingDay from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return EmployeeWorkingDayDAO.FindPaging(criteria);
        }
    }
}