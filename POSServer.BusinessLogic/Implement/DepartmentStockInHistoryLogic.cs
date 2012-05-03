			 


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
    public class DepartmentStockInHistoryLogic : IDepartmentStockInHistoryLogic
    {
        private IDepartmentStockInHistoryDao _innerDao;
        public IDepartmentStockInHistoryDao DepartmentStockInHistoryDao
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
        /// Find DepartmentStockInHistory object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of DepartmentStockInHistory</param>
        /// <returns></returns>
        public DepartmentStockInHistory FindById(object id)
        {
            return DepartmentStockInHistoryDao.FindById(id);
        }
        
        /// <summary>
        /// Add DepartmentStockInHistory to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public DepartmentStockInHistory Add(DepartmentStockInHistory data)
        {
            DepartmentStockInHistoryDao.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update DepartmentStockInHistory to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(DepartmentStockInHistory data)
        {
            DepartmentStockInHistoryDao.Update(data);
        }
        
        /// <summary>
        /// Delete DepartmentStockInHistory from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(DepartmentStockInHistory data)
        {
            DepartmentStockInHistoryDao.Delete(data);
        }
        
        /// <summary>
        /// Delete DepartmentStockInHistory from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            DepartmentStockInHistoryDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all DepartmentStockInHistory from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<DepartmentStockInHistory> FindAll(ObjectCriteria<DepartmentStockInHistory> criteria)
        {
            return DepartmentStockInHistoryDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all DepartmentStockInHistory from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria<DepartmentStockInHistory> criteria)
        {
            return DepartmentStockInHistoryDao.FindPaging(criteria);
        }
    }
}