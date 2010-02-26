			 


using System.Collections;
using System.Collections.Generic;
using Spring.Transaction.Interceptor;
using  CoralPOS.Models;
using  POSServer.DataLayer.Implement;

namespace POSServer.BusinessLogic.Implement
{
    public class EmployeeWorkingDaysLogicImpl : IEmployeeWorkingDaysLogic
    {
        private IEmployeeWorkingDaysDao _innerDao;

        public IEmployeeWorkingDaysDao EmployeeWorkingDaysDao
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
        /// Find EmployeeWorkingDays object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of EmployeeWorkingDays</param>
        /// <returns></returns>
        public EmployeeWorkingDays FindById(object id)
        {
            return _innerDao.FindById(id);
        }
        
        /// <summary>
        /// Add EmployeeWorkingDays to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public EmployeeWorkingDays Add(EmployeeWorkingDays data)
        {
            _innerDao.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update EmployeeWorkingDays to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(EmployeeWorkingDays data)
        {
            _innerDao.Update(data);
        }
        
        /// <summary>
        /// Delete EmployeeWorkingDays from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(EmployeeWorkingDays data)
        {
            _innerDao.Delete(data);
        }
        
        /// <summary>
        /// Delete EmployeeWorkingDays from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            _innerDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all EmployeeWorkingDays from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<EmployeeWorkingDays> FindAll(ObjectCriteria criteria)
        {
            return _innerDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all EmployeeWorkingDays from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return _innerDao.FindPaging(criteria);
        }
    }
}