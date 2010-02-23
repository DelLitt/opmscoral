			 


using System.Collections;
using Spring.Transaction.Interceptor;
using  CoralPOS.Models;
using  POSServer.DataLayer.Implement;

namespace POSServer.DataLayer.Implement
{
    public class EmployeeDayoffLogicImpl : IEmployeeDayoffLogic
    {
        private IEmployeeDayoffDao _innerDao;

        public IEmployeeDayoffDao EmployeeDayoffDao
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
        /// Find EmployeeDayoff object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of EmployeeDayoff</param>
        /// <returns></returns>
        public EmployeeDayoff FindById(object id)
        {
            return _innerDao.FindById(id);
        }
        
        /// <summary>
        /// Add EmployeeDayoff to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public EmployeeDayoff Add(EmployeeDayoff data)
        {
            _innerDao.Add(data);
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
            _innerDao.Update(data);
        }
        
        /// <summary>
        /// Delete EmployeeDayoff from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(EmployeeDayoff data)
        {
            _innerDao.Delete(data);
        }
        
        /// <summary>
        /// Delete EmployeeDayoff from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            _innerDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all EmployeeDayoff from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return _innerDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all EmployeeDayoff from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return _innerDao.FindPaging(criteria);
        }
    }
}