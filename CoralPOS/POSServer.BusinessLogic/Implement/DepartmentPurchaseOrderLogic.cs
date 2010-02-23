			 


using System.Collections;
using Spring.Transaction.Interceptor;
using  CoralPOS.Models;
using  POSServer.DataLayer.Implement;

namespace POSServer.DataLayer.Implement
{
    public class DepartmentPurchaseOrderLogicImpl : IDepartmentPurchaseOrderLogic
    {
        private IDepartmentPurchaseOrderDao _innerDao;

        public IDepartmentPurchaseOrderDao DepartmentPurchaseOrderDao
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
        /// Find DepartmentPurchaseOrder object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of DepartmentPurchaseOrder</param>
        /// <returns></returns>
        public DepartmentPurchaseOrder FindById(object id)
        {
            return _innerDao.FindById(id);
        }
        
        /// <summary>
        /// Add DepartmentPurchaseOrder to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public DepartmentPurchaseOrder Add(DepartmentPurchaseOrder data)
        {
            _innerDao.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update DepartmentPurchaseOrder to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(DepartmentPurchaseOrder data)
        {
            _innerDao.Update(data);
        }
        
        /// <summary>
        /// Delete DepartmentPurchaseOrder from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(DepartmentPurchaseOrder data)
        {
            _innerDao.Delete(data);
        }
        
        /// <summary>
        /// Delete DepartmentPurchaseOrder from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            _innerDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all DepartmentPurchaseOrder from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return _innerDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all DepartmentPurchaseOrder from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return _innerDao.FindPaging(criteria);
        }
    }
}