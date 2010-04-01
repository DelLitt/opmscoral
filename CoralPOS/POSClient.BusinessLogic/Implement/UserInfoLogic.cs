			 


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
    public class UserInfoLogic : IUserInfoLogic
    {
        private IUserInfoDao _innerDao;
        public IUserInfoDao UserInfoDao
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
        /// Find UserInfo object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of UserInfo</param>
        /// <returns></returns>
        public UserInfo FindById(object id)
        {
            return UserInfoDao.FindById(id);
        }
        
        /// <summary>
        /// Add UserInfo to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public UserInfo Add(UserInfo data)
        {
            UserInfoDao.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update UserInfo to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(UserInfo data)
        {
            UserInfoDao.Update(data);
        }
        
        /// <summary>
        /// Delete UserInfo from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(UserInfo data)
        {
            UserInfoDao.Delete(data);
        }
        
        /// <summary>
        /// Delete UserInfo from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            UserInfoDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all UserInfo from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<UserInfo> FindAll(ObjectCriteria<UserInfo> criteria)
        {
            return UserInfoDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all UserInfo from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria<UserInfo> criteria)
        {
            return UserInfoDao.FindPaging(criteria);
        }
    }
}