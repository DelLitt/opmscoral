			 


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
    public class DepartmentStockTemployeeValidSaveLogic : IDepartmentStockTemployeeValidSaveLogic
    {
        private IDepartmentStockTemployeeValidSaveDao _innerDao;
        public IDepartmentStockTemployeeValidSaveDao DepartmentStockTemployeeValidSaveDao
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
        /// Find DepartmentStockTemployeeValidSave object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of DepartmentStockTemployeeValidSave</param>
        /// <returns></returns>
        public DepartmentStockTemployeeValidSave FindById(object id)
        {
            return DepartmentStockTemployeeValidSaveDao.FindById(id);
        }
        
        /// <summary>
        /// Add DepartmentStockTemployeeValidSave to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public DepartmentStockTemployeeValidSave Add(DepartmentStockTemployeeValidSave data)
        {
            DepartmentStockTemployeeValidSaveDao.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update DepartmentStockTemployeeValidSave to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(DepartmentStockTemployeeValidSave data)
        {
            DepartmentStockTemployeeValidSaveDao.Update(data);
        }
        
        /// <summary>
        /// Delete DepartmentStockTemployeeValidSave from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(DepartmentStockTemployeeValidSave data)
        {
            DepartmentStockTemployeeValidSaveDao.Delete(data);
        }
        
        /// <summary>
        /// Delete DepartmentStockTemployeeValidSave from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            DepartmentStockTemployeeValidSaveDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all DepartmentStockTemployeeValidSave from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<DepartmentStockTemployeeValidSave> FindAll(ObjectCriteria<DepartmentStockTemployeeValidSave> criteria)
        {
            return DepartmentStockTemployeeValidSaveDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all DepartmentStockTemployeeValidSave from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria<DepartmentStockTemployeeValidSave> criteria)
        {
            return DepartmentStockTemployeeValidSaveDao.FindPaging(criteria);
        }
    }
}