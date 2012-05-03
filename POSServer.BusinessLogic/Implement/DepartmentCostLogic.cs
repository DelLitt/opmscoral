			 


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
    public class DepartmentCostLogic : IDepartmentCostLogic
    {
        private IDepartmentCostDao _innerDao;
        public IDepartmentCostDao DepartmentCostDao
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
        /// Find DepartmentCost object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of DepartmentCost</param>
        /// <returns></returns>
        public DepartmentCost FindById(object id)
        {
            return DepartmentCostDao.FindById(id);
        }
        
        /// <summary>
        /// Add DepartmentCost to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public DepartmentCost Add(DepartmentCost data)
        {
            DepartmentCostDao.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update DepartmentCost to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(DepartmentCost data)
        {
            DepartmentCostDao.Update(data);
        }
        
        /// <summary>
        /// Delete DepartmentCost from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(DepartmentCost data)
        {
            DepartmentCostDao.Delete(data);
        }
        
        /// <summary>
        /// Delete DepartmentCost from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            DepartmentCostDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all DepartmentCost from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<DepartmentCost> FindAll(ObjectCriteria<DepartmentCost> criteria)
        {
            return DepartmentCostDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all DepartmentCost from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria<DepartmentCost> criteria)
        {
            return DepartmentCostDao.FindPaging(criteria);
        }
    }
}