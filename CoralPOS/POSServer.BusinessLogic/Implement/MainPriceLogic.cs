			 


using System.Collections;
using System.Collections.Generic;
using Spring.Transaction.Interceptor;
using  CoralPOS.Models;
using  POSServer.DataLayer.Implement;

namespace POSServer.BusinessLogic.Implement
{
    public class MainPriceLogicImpl : IMainPriceLogic
    {
        private IMainPriceDao _innerDao;

        public IMainPriceDao MainPriceDao
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
        /// Find MainPrice object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of MainPrice</param>
        /// <returns></returns>
        public MainPrice FindById(object id)
        {
            return _innerDao.FindById(id);
        }
        
        /// <summary>
        /// Add MainPrice to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public MainPrice Add(MainPrice data)
        {
            _innerDao.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update MainPrice to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(MainPrice data)
        {
            _innerDao.Update(data);
        }
        
        /// <summary>
        /// Delete MainPrice from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(MainPrice data)
        {
            _innerDao.Delete(data);
        }
        
        /// <summary>
        /// Delete MainPrice from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            _innerDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all MainPrice from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<MainPrice> FindAll(ObjectCriteria criteria)
        {
            return _innerDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all MainPrice from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return _innerDao.FindPaging(criteria);
        }
    }
}