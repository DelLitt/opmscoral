using System.Collections;
using Spring.Transaction.Interceptor;
using AppFrame.Model;
using AppFrame.DataLayer;

namespace AppFrame.Logic
{
    public class EmployeeDayoffLogicImpl : IEmployeeDayoffLogic
    {
        private IEmployeeDayoffDAO _employeeDayoffDAO;

        public IEmployeeDayoffDAO EmployeeDayoffDAO
        {
            get 
            { 
                return _employeeDayoffDAO; 
            }
            set 
            { 
                _employeeDayoffDAO = value; 
            }
        }
        
        /// <summary>
        /// Find EmployeeDayoff object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of EmployeeDayoff</param>
        /// <returns></returns>
        public EmployeeDayoff FindById(object id)
        {
            return EmployeeDayoffDAO.FindById(id);
        }
        
        /// <summary>
        /// Add EmployeeDayoff to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public EmployeeDayoff Add(EmployeeDayoff data)
        {
            EmployeeDayoffDAO.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update EmployeeDayoff to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(EmployeeDayoff data)
        {
            EmployeeDayoffDAO.Update(data);
        }
        
        /// <summary>
        /// Delete EmployeeDayoff from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(EmployeeDayoff data)
        {
            EmployeeDayoffDAO.Delete(data);
        }
        
        /// <summary>
        /// Delete EmployeeDayoff from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            EmployeeDayoffDAO.DeleteById(id);
        }
        
        /// <summary>
        /// Find all EmployeeDayoff from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return EmployeeDayoffDAO.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all EmployeeDayoff from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return EmployeeDayoffDAO.FindPaging(criteria);
        }
    }
}