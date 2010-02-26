			 


using System.Collections;
using System.Collections.Generic;
using Spring.Transaction.Interceptor;
using  CoralPOS.Models;
using  POSServer.DataLayer.Implement;

namespace POSServer.BusinessLogic.Implement
{
    public class EmployeeInfoLogicImpl : IEmployeeInfoLogic
    {
        private IEmployeeInfoDao _innerDao;

        public IEmployeeInfoDao EmployeeInfoDao
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
        /// Find EmployeeInfo object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of EmployeeInfo</param>
        /// <returns></returns>
        public EmployeeInfo FindById(object id)
        {
            return _innerDao.FindById(id);
        }
        
        /// <summary>
        /// Add EmployeeInfo to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public EmployeeInfo Add(EmployeeInfo data)
        {
            _innerDao.Add(data);
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
            _innerDao.Update(data);
        }
        
        /// <summary>
        /// Delete EmployeeInfo from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(EmployeeInfo data)
        {
            _innerDao.Delete(data);
        }
        
        /// <summary>
        /// Delete EmployeeInfo from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            _innerDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all EmployeeInfo from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<EmployeeInfo> FindAll(ObjectCriteria criteria)
        {
            return _innerDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all EmployeeInfo from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return _innerDao.FindPaging(criteria);
        }
    }
}