			 


using System.Collections;
using System.Collections.Generic;
using Spring.Transaction.Interceptor;
using  CoralPOS.Models;
using  POSServer.DataLayer.Implement;

namespace POSServer.BusinessLogic.Implement
{
    public class RoleLogic : IRoleLogic
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
            return RoleDao.FindById(id);
        }
        
        /// <summary>
        /// Add Role to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public Role Add(Role data)
        {
            RoleDao.Add(data);
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
            RoleDao.Update(data);
        }
        
        /// <summary>
        /// Delete Role from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(Role data)
        {
            RoleDao.Delete(data);
        }
        
        /// <summary>
        /// Delete Role from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            RoleDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all Role from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<Role> FindAll(ObjectCriteria criteria)
        {
            return RoleDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all Role from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return RoleDao.FindPaging(criteria);
        }
    }
}