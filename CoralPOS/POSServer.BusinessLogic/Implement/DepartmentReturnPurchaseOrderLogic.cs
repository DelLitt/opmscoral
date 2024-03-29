			 


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
    public class DepartmentReturnPurchaseOrderLogic : IDepartmentReturnPurchaseOrderLogic
    {
        private IDepartmentReturnPurchaseOrderDao _innerDao;
        public IDepartmentReturnPurchaseOrderDao DepartmentReturnPurchaseOrderDao
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
        /// Find DepartmentReturnPurchaseOrder object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of DepartmentReturnPurchaseOrder</param>
        /// <returns></returns>
        public DepartmentReturnPurchaseOrder FindById(object id)
        {
            return DepartmentReturnPurchaseOrderDao.FindById(id);
        }
        
        /// <summary>
        /// Add DepartmentReturnPurchaseOrder to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public DepartmentReturnPurchaseOrder Add(DepartmentReturnPurchaseOrder data)
        {
            DepartmentReturnPurchaseOrderDao.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update DepartmentReturnPurchaseOrder to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(DepartmentReturnPurchaseOrder data)
        {
            DepartmentReturnPurchaseOrderDao.Update(data);
        }
        
        /// <summary>
        /// Delete DepartmentReturnPurchaseOrder from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(DepartmentReturnPurchaseOrder data)
        {
            DepartmentReturnPurchaseOrderDao.Delete(data);
        }
        
        /// <summary>
        /// Delete DepartmentReturnPurchaseOrder from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            DepartmentReturnPurchaseOrderDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all DepartmentReturnPurchaseOrder from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<DepartmentReturnPurchaseOrder> FindAll(ObjectCriteria<DepartmentReturnPurchaseOrder> criteria)
        {
            return DepartmentReturnPurchaseOrderDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all DepartmentReturnPurchaseOrder from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria<DepartmentReturnPurchaseOrder> criteria)
        {
            return DepartmentReturnPurchaseOrderDao.FindPaging(criteria);
        }
    }
}