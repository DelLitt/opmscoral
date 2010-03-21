			 


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
    public class DepartmentStockOutCostLogic : IDepartmentStockOutCostLogic
    {
        private IDepartmentStockOutCostDao _innerDao;
        public IDepartmentStockOutCostDao DepartmentStockOutCostDao
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
        /// Find DepartmentStockOutCost object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of DepartmentStockOutCost</param>
        /// <returns></returns>
        public DepartmentStockOutCost FindById(object id)
        {
            return DepartmentStockOutCostDao.FindById(id);
        }
        
        /// <summary>
        /// Add DepartmentStockOutCost to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public DepartmentStockOutCost Add(DepartmentStockOutCost data)
        {
            DepartmentStockOutCostDao.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update DepartmentStockOutCost to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(DepartmentStockOutCost data)
        {
            DepartmentStockOutCostDao.Update(data);
        }
        
        /// <summary>
        /// Delete DepartmentStockOutCost from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(DepartmentStockOutCost data)
        {
            DepartmentStockOutCostDao.Delete(data);
        }
        
        /// <summary>
        /// Delete DepartmentStockOutCost from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            DepartmentStockOutCostDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all DepartmentStockOutCost from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<DepartmentStockOutCost> FindAll(ObjectCriteria<DepartmentStockOutCost> criteria)
        {
            return DepartmentStockOutCostDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all DepartmentStockOutCost from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria<DepartmentStockOutCost> criteria)
        {
            return DepartmentStockOutCostDao.FindPaging(criteria);
        }
    }
}