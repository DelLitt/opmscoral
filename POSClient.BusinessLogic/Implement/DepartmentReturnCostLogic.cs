			 


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
    public class DepartmentReturnCostLogic : IDepartmentReturnCostLogic
    {
        private IDepartmentReturnCostDao _innerDao;
        public IDepartmentReturnCostDao DepartmentReturnCostDao
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
        /// Find DepartmentReturnCost object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of DepartmentReturnCost</param>
        /// <returns></returns>
        public DepartmentReturnCost FindById(object id)
        {
            return DepartmentReturnCostDao.FindById(id);
        }
        
        /// <summary>
        /// Add DepartmentReturnCost to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public DepartmentReturnCost Add(DepartmentReturnCost data)
        {
            DepartmentReturnCostDao.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update DepartmentReturnCost to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(DepartmentReturnCost data)
        {
            DepartmentReturnCostDao.Update(data);
        }
        
        /// <summary>
        /// Delete DepartmentReturnCost from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(DepartmentReturnCost data)
        {
            DepartmentReturnCostDao.Delete(data);
        }
        
        /// <summary>
        /// Delete DepartmentReturnCost from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            DepartmentReturnCostDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all DepartmentReturnCost from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<DepartmentReturnCost> FindAll(ObjectCriteria<DepartmentReturnCost> criteria)
        {
            return DepartmentReturnCostDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all DepartmentReturnCost from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria<DepartmentReturnCost> criteria)
        {
            return DepartmentReturnCostDao.FindPaging(criteria);
        }
    }
}