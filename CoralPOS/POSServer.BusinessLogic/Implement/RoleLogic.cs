			 


using System.Collections;
using Spring.Transaction.Interceptor;
using  CoralPOS.Models;
using  POSServer.DataLayer.Implement;

namespace POSServer.DataLayer.Implement
{
    public class RoleLogicImpl : IRoleLogic
    {
        private IRoleDao _innerDao;

        public IRoleDao RoleDao
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
        /// Find Role object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of Role</param>
        /// <returns></returns>
        public Role FindById(object id)
        {
            return _innerDao.FindById(id);
        }
        
        /// <summary>
        /// Add Role to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public Role Add(Role data)
        {
            _innerDao.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update Role to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(Role data)
        {
            _innerDao.Update(data);
        }
        
        /// <summary>
        /// Delete Role from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(Role data)
        {
            _innerDao.Delete(data);
        }
        
        /// <summary>
        /// Delete Role from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            _innerDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all Role from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return _innerDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all Role from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return _innerDao.FindPaging(criteria);
        }
    }
}