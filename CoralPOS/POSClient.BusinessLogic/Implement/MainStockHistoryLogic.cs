			 


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
using  POSClient.DataLayer.Implement;

namespace POSClient.BusinessLogic.Implement
{
    public class MainStockHistoryLogic : IMainStockHistoryLogic
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
            return MainStockHistoryDao.FindById(id);
        }
        
        /// <summary>
        /// Add MainStockHistory to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public MainStockHistory Add(MainStockHistory data)
        {
            MainStockHistoryDao.Add(data);
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
            MainStockHistoryDao.Update(data);
        }
        
        /// <summary>
        /// Delete MainStockHistory from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(MainStockHistory data)
        {
            MainStockHistoryDao.Delete(data);
        }
        
        /// <summary>
        /// Delete MainStockHistory from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            MainStockHistoryDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all MainStockHistory from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<MainStockHistory> FindAll(ObjectCriteria<MainStockHistory> criteria)
        {
            return MainStockHistoryDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all MainStockHistory from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria<MainStockHistory> criteria)
        {
            return MainStockHistoryDao.FindPaging(criteria);
        }
    }
}