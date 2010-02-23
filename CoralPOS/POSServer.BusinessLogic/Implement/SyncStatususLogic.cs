			 


using System.Collections;
using Spring.Transaction.Interceptor;
using  CoralPOS.Models;
using  POSServer.DataLayer.Implement;

namespace POSServer.DataLayer.Implement
{
    public class SyncStatususLogicImpl : ISyncStatususLogic
    {
        private ISyncStatususDao _innerDao;

        public ISyncStatususDao SyncStatususDao
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
        /// Find SyncStatusus object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of SyncStatusus</param>
        /// <returns></returns>
        public SyncStatusus FindById(object id)
        {
            return _innerDao.FindById(id);
        }
        
        /// <summary>
        /// Add SyncStatusus to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public SyncStatusus Add(SyncStatusus data)
        {
            _innerDao.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update SyncStatusus to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(SyncStatusus data)
        {
            _innerDao.Update(data);
        }
        
        /// <summary>
        /// Delete SyncStatusus from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(SyncStatusus data)
        {
            _innerDao.Delete(data);
        }
        
        /// <summary>
        /// Delete SyncStatusus from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            _innerDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all SyncStatusus from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return _innerDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all SyncStatusus from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return _innerDao.FindPaging(criteria);
        }
    }
}