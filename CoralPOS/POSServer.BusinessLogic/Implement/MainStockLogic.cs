			 


using System.Collections;
using System.Collections.Generic;
using Spring.Transaction.Interceptor;
using  CoralPOS.Models;
using  POSServer.DataLayer.Implement;

namespace POSServer.BusinessLogic.Implement
{
    public class MainStockLogic : IMainStockLogic
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
            return MainStockDao.FindById(id);
        }
        
        /// <summary>
        /// Add MainStock to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public MainStock Add(MainStock data)
        {
            MainStockDao.Add(data);
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
            MainStockDao.Update(data);
        }
        
        /// <summary>
        /// Delete MainStock from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(MainStock data)
        {
            MainStockDao.Delete(data);
        }
        
        /// <summary>
        /// Delete MainStock from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            MainStockDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all MainStock from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<MainStock> FindAll(ObjectCriteria criteria)
        {
            return MainStockDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all MainStock from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return MainStockDao.FindPaging(criteria);
        }
    }
}