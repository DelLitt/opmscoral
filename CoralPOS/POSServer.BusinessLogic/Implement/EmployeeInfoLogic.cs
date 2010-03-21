			 


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
using  POSServer.DataLayer.Implement;

namespace POSServer.BusinessLogic.Implement
{
    public class EmployeeInfoLogic : IEmployeeInfoLogic
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
            return EmployeeInfoDao.FindById(id);
        }
        
        /// <summary>
        /// Add EmployeeInfo to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public EmployeeInfo Add(EmployeeInfo data)
        {
            EmployeeInfoDao.Add(data);
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
            EmployeeInfoDao.Update(data);
        }
        
        /// <summary>
        /// Delete EmployeeInfo from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(EmployeeInfo data)
        {
            EmployeeInfoDao.Delete(data);
        }
        
        /// <summary>
        /// Delete EmployeeInfo from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            EmployeeInfoDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all EmployeeInfo from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<EmployeeInfo> FindAll(ObjectCriteria<EmployeeInfo> criteria)
        {
            return EmployeeInfoDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all EmployeeInfo from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria<EmployeeInfo> criteria)
        {
            return EmployeeInfoDao.FindPaging(criteria);
        }
    }
}