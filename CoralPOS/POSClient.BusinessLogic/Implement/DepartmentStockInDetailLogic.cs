			 


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
    public class DepartmentStockInDetailLogic : IDepartmentStockInDetailLogic
    {
        private IDepartmentStockInDetailDao _innerDao;
        public IDepartmentStockInDetailDao DepartmentStockInDetailDao
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
        /// Find DepartmentStockInDetail object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of DepartmentStockInDetail</param>
        /// <returns></returns>
        public DepartmentStockInDetail FindById(object id)
        {
            return DepartmentStockInDetailDao.FindById(id);
        }
        
        /// <summary>
        /// Add DepartmentStockInDetail to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public DepartmentStockInDetail Add(DepartmentStockInDetail data)
        {
            DepartmentStockInDetailDao.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update DepartmentStockInDetail to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(DepartmentStockInDetail data)
        {
            DepartmentStockInDetailDao.Update(data);
        }
        
        /// <summary>
        /// Delete DepartmentStockInDetail from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(DepartmentStockInDetail data)
        {
            DepartmentStockInDetailDao.Delete(data);
        }
        
        /// <summary>
        /// Delete DepartmentStockInDetail from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            DepartmentStockInDetailDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all DepartmentStockInDetail from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<DepartmentStockInDetail> FindAll(ObjectCriteria<DepartmentStockInDetail> criteria)
        {
            return DepartmentStockInDetailDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all DepartmentStockInDetail from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria<DepartmentStockInDetail> criteria)
        {
            return DepartmentStockInDetailDao.FindPaging(criteria);
        }
    }
}