			 


using System.Collections;
using System.Collections.Generic;
using Spring.Transaction.Interceptor;
using  CoralPOS.Models;
using  POSServer.DataLayer.Implement;

namespace POSServer.BusinessLogic.Implement
{
    public class ReturnBlockInLogicImpl : IReturnBlockInLogic
    {
        private IReturnBlockInDao _innerDao;

        public IReturnBlockInDao ReturnBlockInDao
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
        /// Find ReturnBlockIn object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of ReturnBlockIn</param>
        /// <returns></returns>
        public ReturnBlockIn FindById(object id)
        {
            return _innerDao.FindById(id);
        }
        
        /// <summary>
        /// Add ReturnBlockIn to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public ReturnBlockIn Add(ReturnBlockIn data)
        {
            _innerDao.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update ReturnBlockIn to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(ReturnBlockIn data)
        {
            _innerDao.Update(data);
        }
        
        /// <summary>
        /// Delete ReturnBlockIn from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(ReturnBlockIn data)
        {
            _innerDao.Delete(data);
        }
        
        /// <summary>
        /// Delete ReturnBlockIn from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            _innerDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all ReturnBlockIn from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<ReturnBlockIn> FindAll(ObjectCriteria criteria)
        {
            return _innerDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all ReturnBlockIn from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return _innerDao.FindPaging(criteria);
        }
    }
}