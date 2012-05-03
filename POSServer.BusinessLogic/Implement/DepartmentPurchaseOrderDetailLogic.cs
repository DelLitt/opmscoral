			 


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
    public class DepartmentPurchaseOrderDetailLogic : IDepartmentPurchaseOrderDetailLogic
    {
        private IDepartmentPurchaseOrderDetailDao _innerDao;
        public IDepartmentPurchaseOrderDetailDao DepartmentPurchaseOrderDetailDao
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
        /// Find DepartmentPurchaseOrderDetail object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of DepartmentPurchaseOrderDetail</param>
        /// <returns></returns>
        public DepartmentPurchaseOrderDetail FindById(object id)
        {
            return DepartmentPurchaseOrderDetailDao.FindById(id);
        }
        
        /// <summary>
        /// Add DepartmentPurchaseOrderDetail to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public DepartmentPurchaseOrderDetail Add(DepartmentPurchaseOrderDetail data)
        {
            DepartmentPurchaseOrderDetailDao.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update DepartmentPurchaseOrderDetail to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(DepartmentPurchaseOrderDetail data)
        {
            DepartmentPurchaseOrderDetailDao.Update(data);
        }
        
        /// <summary>
        /// Delete DepartmentPurchaseOrderDetail from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(DepartmentPurchaseOrderDetail data)
        {
            DepartmentPurchaseOrderDetailDao.Delete(data);
        }
        
        /// <summary>
        /// Delete DepartmentPurchaseOrderDetail from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            DepartmentPurchaseOrderDetailDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all DepartmentPurchaseOrderDetail from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<DepartmentPurchaseOrderDetail> FindAll(ObjectCriteria<DepartmentPurchaseOrderDetail> criteria)
        {
            return DepartmentPurchaseOrderDetailDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all DepartmentPurchaseOrderDetail from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria<DepartmentPurchaseOrderDetail> criteria)
        {
            return DepartmentPurchaseOrderDetailDao.FindPaging(criteria);
        }
    }
}