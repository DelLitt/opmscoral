			 


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
    public class DepartmentPurchaseOrderLogLogic : IDepartmentPurchaseOrderLogLogic
    {
        private IDepartmentPurchaseOrderLogDao _innerDao;
        public IDepartmentPurchaseOrderLogDao DepartmentPurchaseOrderLogDao
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
        /// Find DepartmentPurchaseOrderLog object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of DepartmentPurchaseOrderLog</param>
        /// <returns></returns>
        public DepartmentPurchaseOrderLog FindById(object id)
        {
            return DepartmentPurchaseOrderLogDao.FindById(id);
        }
        
        /// <summary>
        /// Add DepartmentPurchaseOrderLog to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public DepartmentPurchaseOrderLog Add(DepartmentPurchaseOrderLog data)
        {
            DepartmentPurchaseOrderLogDao.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update DepartmentPurchaseOrderLog to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(DepartmentPurchaseOrderLog data)
        {
            DepartmentPurchaseOrderLogDao.Update(data);
        }
        
        /// <summary>
        /// Delete DepartmentPurchaseOrderLog from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(DepartmentPurchaseOrderLog data)
        {
            DepartmentPurchaseOrderLogDao.Delete(data);
        }
        
        /// <summary>
        /// Delete DepartmentPurchaseOrderLog from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            DepartmentPurchaseOrderLogDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all DepartmentPurchaseOrderLog from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<DepartmentPurchaseOrderLog> FindAll(ObjectCriteria<DepartmentPurchaseOrderLog> criteria)
        {
            return DepartmentPurchaseOrderLogDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all DepartmentPurchaseOrderLog from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria<DepartmentPurchaseOrderLog> criteria)
        {
            return DepartmentPurchaseOrderLogDao.FindPaging(criteria);
        }
    }
}