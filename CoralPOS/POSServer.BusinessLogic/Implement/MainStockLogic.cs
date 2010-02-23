			 


using System.Collections;
using Spring.Transaction.Interceptor;
using  CoralPOS.Models;
using  POSServer.DataLayer.Implement;

namespace POSServer.DataLayer.Implement
{
    public class MainStockLogicImpl : IMainStockLogic
    {
        private IMainStockDao _innerDao;

        public IMainStockDao MainStockDao
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
        /// Find MainStock object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of MainStock</param>
        /// <returns></returns>
        public MainStock FindById(object id)
        {
            return _innerDao.FindById(id);
        }
        
        /// <summary>
        /// Add MainStock to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public MainStock Add(MainStock data)
        {
            _innerDao.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update MainStock to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(MainStock data)
        {
            _innerDao.Update(data);
        }
        
        /// <summary>
        /// Delete MainStock from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(MainStock data)
        {
            _innerDao.Delete(data);
        }
        
        /// <summary>
        /// Delete MainStock from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            _innerDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all MainStock from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return _innerDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all MainStock from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return _innerDao.FindPaging(criteria);
        }
    }
}