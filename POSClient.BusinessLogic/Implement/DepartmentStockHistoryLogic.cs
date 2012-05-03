			 


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
    public class DepartmentStockHistoryLogic : IDepartmentStockHistoryLogic
    {
        private IDepartmentStockHistoryDao _innerDao;
        public IDepartmentStockHistoryDao DepartmentStockHistoryDao
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
        /// Find DepartmentStockHistory object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of DepartmentStockHistory</param>
        /// <returns></returns>
        public DepartmentStockHistory FindById(object id)
        {
            return DepartmentStockHistoryDao.FindById(id);
        }
        
        /// <summary>
        /// Add DepartmentStockHistory to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public DepartmentStockHistory Add(DepartmentStockHistory data)
        {
            DepartmentStockHistoryDao.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update DepartmentStockHistory to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(DepartmentStockHistory data)
        {
            DepartmentStockHistoryDao.Update(data);
        }
        
        /// <summary>
        /// Delete DepartmentStockHistory from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(DepartmentStockHistory data)
        {
            DepartmentStockHistoryDao.Delete(data);
        }
        
        /// <summary>
        /// Delete DepartmentStockHistory from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            DepartmentStockHistoryDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all DepartmentStockHistory from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<DepartmentStockHistory> FindAll(ObjectCriteria<DepartmentStockHistory> criteria)
        {
            return DepartmentStockHistoryDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all DepartmentStockHistory from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria<DepartmentStockHistory> criteria)
        {
            return DepartmentStockHistoryDao.FindPaging(criteria);
        }
    }
}