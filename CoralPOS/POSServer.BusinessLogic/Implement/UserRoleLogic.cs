			 


using System;
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
    public class UserRoleLogic : IUserRoleLogic
    {
        private IUserRoleDao _innerDao;
        public IUserRoleDao UserRoleDao
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
        /// Find UserRole object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of UserRole</param>
        /// <returns></returns>
        public UserRole FindById(object id)
        {
            return UserRoleDao.FindById(id);
        }
        
        /// <summary>
        /// Add UserRole to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public UserRole Add(UserRole data)
        {
            UserRoleDao.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update UserRole to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(UserRole data)
        {
            UserRoleDao.Update(data);
        }
        
        /// <summary>
        /// Delete UserRole from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(UserRole data)
        {
            UserRoleDao.Delete(data);
        }
        
        /// <summary>
        /// Delete UserRole from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            UserRoleDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all UserRole from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<UserRole> FindAll(ObjectCriteria<UserRole> criteria)
        {
            return UserRoleDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all UserRole from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria<UserRole> criteria)
        {
            return UserRoleDao.FindPaging(criteria);
        }

        public UserRole FindRole(string username)
        {
            LinqCriteria<UserRole> linqCriteria = new LinqCriteria<UserRole>();
            linqCriteria.AddCriteria(m => m.Userid.Equals(username));
            var result = UserRoleDao.FindAll(linqCriteria);
            return result.Count > 0 ? result[0] : null;
        }
    }
}