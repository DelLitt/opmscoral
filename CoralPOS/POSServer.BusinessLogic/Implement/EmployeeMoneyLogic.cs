			 


using System.Collections;
using Spring.Transaction.Interceptor;
using  CoralPOS.Models;
using  POSServer.DataLayer.Implement;

namespace POSServer.DataLayer.Implement
{
    public class EmployeeMoneyLogicImpl : IEmployeeMoneyLogic
    {
        private IEmployeeMoneyDao _innerDao;

        public IEmployeeMoneyDao EmployeeMoneyDao
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
        /// Find EmployeeMoney object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of EmployeeMoney</param>
        /// <returns></returns>
        public EmployeeMoney FindById(object id)
        {
            return _innerDao.FindById(id);
        }
        
        /// <summary>
        /// Add EmployeeMoney to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public EmployeeMoney Add(EmployeeMoney data)
        {
            _innerDao.Add(data);
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
            _innerDao.Update(data);
        }
        
        /// <summary>
        /// Delete EmployeeMoney from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(EmployeeMoney data)
        {
            _innerDao.Delete(data);
        }
        
        /// <summary>
        /// Delete EmployeeMoney from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            _innerDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all EmployeeMoney from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return _innerDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all EmployeeMoney from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return _innerDao.FindPaging(criteria);
        }
    }
}