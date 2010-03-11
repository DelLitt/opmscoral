			 


using System.Collections;
using System.Collections.Generic;
using Spring.Transaction.Interceptor;
using  CoralPOS.Models;
using  POSServer.DataLayer.Implement;

namespace POSServer.BusinessLogic.Implement
{
    public class DepartmentPurchaseOrderDetailLogLogic : IDepartmentPurchaseOrderDetailLogLogic
    {
        private IDepartmentPurchaseOrderDetailLogDao _innerDao;
        public IDepartmentPurchaseOrderDetailLogDao DepartmentPurchaseOrderDetailLogDao
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
        /// Find DepartmentPurchaseOrderDetailLog object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of DepartmentPurchaseOrderDetailLog</param>
        /// <returns></returns>
        public DepartmentPurchaseOrderDetailLog FindById(object id)
        {
            return DepartmentPurchaseOrderDetailLogDao.FindById(id);
        }
        
        /// <summary>
        /// Add DepartmentPurchaseOrderDetailLog to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public DepartmentPurchaseOrderDetailLog Add(DepartmentPurchaseOrderDetailLog data)
        {
            DepartmentPurchaseOrderDetailLogDao.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update DepartmentPurchaseOrderDetailLog to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(DepartmentPurchaseOrderDetailLog data)
        {
            DepartmentPurchaseOrderDetailLogDao.Update(data);
        }
        
        /// <summary>
        /// Delete DepartmentPurchaseOrderDetailLog from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(DepartmentPurchaseOrderDetailLog data)
        {
            DepartmentPurchaseOrderDetailLogDao.Delete(data);
        }
        
        /// <summary>
        /// Delete DepartmentPurchaseOrderDetailLog from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            DepartmentPurchaseOrderDetailLogDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all DepartmentPurchaseOrderDetailLog from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<DepartmentPurchaseOrderDetailLog> FindAll(ObjectCriteria criteria)
        {
            return DepartmentPurchaseOrderDetailLogDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all DepartmentPurchaseOrderDetailLog from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return DepartmentPurchaseOrderDetailLogDao.FindPaging(criteria);
        }
    }
}