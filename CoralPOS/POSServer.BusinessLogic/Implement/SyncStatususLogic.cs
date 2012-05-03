			 


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
    public class SyncStatususLogic : ISyncStatususLogic
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
            return SyncStatususDao.FindById(id);
        }
        
        /// <summary>
        /// Add SyncStatusus to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public SyncStatusus Add(SyncStatusus data)
        {

            SyncStatususDao.Add(data);
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
            SyncStatususDao.Update(data);
        }
        
        /// <summary>
        /// Delete SyncStatusus from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(SyncStatusus data)
        {
            SyncStatususDao.Delete(data);
        }
        
        /// <summary>
        /// Delete SyncStatusus from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            SyncStatususDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all SyncStatusus from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<SyncStatusus> FindAll(ObjectCriteria<SyncStatusus> criteria)
        {
            return SyncStatususDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all SyncStatusus from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria<SyncStatusus> criteria)
        {
            return SyncStatususDao.FindPaging(criteria);
        }
    }
}