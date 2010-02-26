			 


using System.Collections;
using System.Collections.Generic;
using Spring.Transaction.Interceptor;
using  CoralPOS.Models;
using  POSServer.DataLayer.Implement;

namespace POSServer.BusinessLogic.Implement
{
    public class UserInfoLogicImpl : IUserInfoLogic
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
            return _innerDao.FindById(id);
        }
        
        /// <summary>
        /// Add UserInfo to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public UserInfo Add(UserInfo data)
        {
            _innerDao.Add(data);
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
            _innerDao.Update(data);
        }
        
        /// <summary>
        /// Delete UserInfo from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(UserInfo data)
        {
            _innerDao.Delete(data);
        }
        
        /// <summary>
        /// Delete UserInfo from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            _innerDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all UserInfo from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<UserInfo> FindAll(ObjectCriteria criteria)
        {
            return _innerDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all UserInfo from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return _innerDao.FindPaging(criteria);
        }
    }
}