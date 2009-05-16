using System.Collections;
using Spring.Transaction.Interceptor;
using AppFrame.Model;
using AppFrame.DataLayer;

namespace AppFrame.Logic
{
    public class SyncStatusLogicImpl : ISyncStatusLogic
    {
        private ISyncStatusDAO _syncStatusDAO;

        public ISyncStatusDAO SyncStatusDAO
        {
            get 
            { 
                return _syncStatusDAO; 
            }
            set 
            { 
                _syncStatusDAO = value; 
            }
        }
        
        /// <summary>
        /// Find SyncStatus object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of SyncStatus</param>
        /// <returns></returns>
        public SyncStatus FindById(object id)
        {
            return SyncStatusDAO.FindById(id);
        }
        
        /// <summary>
        /// Add SyncStatus to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public SyncStatus Add(SyncStatus data)
        {
            SyncStatusDAO.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update SyncStatus to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(SyncStatus data)
        {
            SyncStatusDAO.Update(data);
        }
        
        /// <summary>
        /// Delete SyncStatus from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(SyncStatus data)
        {
            SyncStatusDAO.Delete(data);
        }
        
        /// <summary>
        /// Delete SyncStatus from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            SyncStatusDAO.DeleteById(id);
        }
        
        /// <summary>
        /// Find all SyncStatus from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return SyncStatusDAO.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all SyncStatus from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return SyncStatusDAO.FindPaging(criteria);
        }
    }
}