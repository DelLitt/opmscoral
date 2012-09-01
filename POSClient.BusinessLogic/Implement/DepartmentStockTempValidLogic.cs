			 


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
    public class DepartmentStockTempValidLogic : IDepartmentStockTempValidLogic
    {
        private IDepartmentStockTempValidDao _innerDao;
        public IDepartmentStockTempValidDao DepartmentStockTempValidDao
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
        /// Find DepartmentStockTemployeeValid object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of DepartmentStockTemployeeValid</param>
        /// <returns></returns>
        public DepartmentStockTempValid FindById(object id)
        {
            return DepartmentStockTempValidDao.FindById(id);
        }
        
        /// <summary>
        /// Add DepartmentStockTemployeeValid to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public DepartmentStockTempValid Add(DepartmentStockTempValid data)
        {
            DepartmentStockTempValidDao.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update DepartmentStockTemployeeValid to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(DepartmentStockTempValid data)
        {
            DepartmentStockTempValidDao.Update(data);
        }
        
        /// <summary>
        /// Delete DepartmentStockTemployeeValid from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(DepartmentStockTempValid data)
        {
            DepartmentStockTempValidDao.Delete(data);
        }
        
        /// <summary>
        /// Delete DepartmentStockTemployeeValid from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            DepartmentStockTempValidDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all DepartmentStockTemployeeValid from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<DepartmentStockTempValid> FindAll(ObjectCriteria<DepartmentStockTempValid> criteria)
        {
            return DepartmentStockTempValidDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all DepartmentStockTemployeeValid from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria<DepartmentStockTempValid> criteria)
        {
            return DepartmentStockTempValidDao.FindPaging(criteria);
        }
    }
}