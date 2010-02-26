			 


using System.Collections;
using System.Collections.Generic;
using Spring.Transaction.Interceptor;
using  CoralPOS.Models;
using  POSServer.DataLayer.Implement;

namespace POSServer.BusinessLogic.Implement
{
    public class MainStockHistoryLogicImpl : IMainStockHistoryLogic
    {
        private IMainStockHistoryDao _innerDao;

        public IMainStockHistoryDao MainStockHistoryDao
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
        /// Find MainStockHistory object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of MainStockHistory</param>
        /// <returns></returns>
        public MainStockHistory FindById(object id)
        {
            return _innerDao.FindById(id);
        }
        
        /// <summary>
        /// Add MainStockHistory to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public MainStockHistory Add(MainStockHistory data)
        {
            _innerDao.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update MainStockHistory to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(MainStockHistory data)
        {
            _innerDao.Update(data);
        }
        
        /// <summary>
        /// Delete MainStockHistory from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(MainStockHistory data)
        {
            _innerDao.Delete(data);
        }
        
        /// <summary>
        /// Delete MainStockHistory from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            _innerDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all MainStockHistory from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<MainStockHistory> FindAll(ObjectCriteria criteria)
        {
            return _innerDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all MainStockHistory from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return _innerDao.FindPaging(criteria);
        }
    }
}