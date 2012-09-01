			 


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
    public class ActiveDepartmentLogic : IActiveDepartmentLogic
    {
        private IActiveDepartmentDao _innerDao;
        public IActiveDepartmentDao ActiveDepartmentDao
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
        /// Find ActiveDepartment object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of ActiveDepartment</param>
        /// <returns></returns>
        public ActiveDepartment FindById(object id)
        {
            return ActiveDepartmentDao.FindById(id);
        }
        
        /// <summary>
        /// Add ActiveDepartment to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public ActiveDepartment Add(ActiveDepartment data)
        {
            ActiveDepartmentDao.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update ActiveDepartment to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(ActiveDepartment data)
        {
            ActiveDepartmentDao.Update(data);
        }
        
        /// <summary>
        /// Delete ActiveDepartment from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(ActiveDepartment data)
        {
            ActiveDepartmentDao.Delete(data);
        }
        
        /// <summary>
        /// Delete ActiveDepartment from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            ActiveDepartmentDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all ActiveDepartment from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<ActiveDepartment> FindAll(ObjectCriteria<ActiveDepartment> criteria)
        {
            return ActiveDepartmentDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all ActiveDepartment from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria<ActiveDepartment> criteria)
        {
            return ActiveDepartmentDao.FindPaging(criteria);
        }
    }
}