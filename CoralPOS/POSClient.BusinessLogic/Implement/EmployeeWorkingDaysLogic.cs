			 


using System.Collections;
using System.Collections.Generic;
using Spring.Transaction.Interceptor;
using System.Linq.Expressions;
using AppFrame.DataLayer;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.LambdaExtensions;
using NHibernate.Linq.Expressions;
using Spring.Data.NHibernate;
using  CoralPOS.Models;
using  POSClient.DataLayer.Implement;

namespace POSClient.BusinessLogic.Implement
{
    public class EmployeeWorkingDaysLogic : IEmployeeWorkingDaysLogic
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
            return EmployeeWorkingDaysDao.FindById(id);
        }
        
        /// <summary>
        /// Add EmployeeWorkingDays to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public EmployeeWorkingDays Add(EmployeeWorkingDays data)
        {
            EmployeeWorkingDaysDao.Add(data);
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
            EmployeeWorkingDaysDao.Update(data);
        }
        
        /// <summary>
        /// Delete EmployeeWorkingDays from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(EmployeeWorkingDays data)
        {
            EmployeeWorkingDaysDao.Delete(data);
        }
        
        /// <summary>
        /// Delete EmployeeWorkingDays from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            EmployeeWorkingDaysDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all EmployeeWorkingDays from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<EmployeeWorkingDays> FindAll(ObjectCriteria<EmployeeWorkingDays> criteria)
        {
            return EmployeeWorkingDaysDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all EmployeeWorkingDays from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria<EmployeeWorkingDays> criteria)
        {
            return EmployeeWorkingDaysDao.FindPaging(criteria);
        }
    }
}