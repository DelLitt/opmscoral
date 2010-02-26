			 


using System.Collections;
using System.Collections.Generic;
using Spring.Transaction.Interceptor;
using  CoralPOS.Models;
using  POSServer.DataLayer.Implement;

namespace POSServer.BusinessLogic.Implement
{
    public class DepartmentStockTemployeeValidSaveLogicImpl : IDepartmentStockTemployeeValidSaveLogic
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
            return _innerDao.FindById(id);
        }
        
        /// <summary>
        /// Add DepartmentStockTemployeeValidSave to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public DepartmentStockTemployeeValidSave Add(DepartmentStockTemployeeValidSave data)
        {
            _innerDao.Add(data);
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
            _innerDao.Update(data);
        }
        
        /// <summary>
        /// Delete DepartmentStockTemployeeValidSave from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(DepartmentStockTemployeeValidSave data)
        {
            _innerDao.Delete(data);
        }
        
        /// <summary>
        /// Delete DepartmentStockTemployeeValidSave from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            _innerDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all DepartmentStockTemployeeValidSave from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<DepartmentStockTemployeeValidSave> FindAll(ObjectCriteria criteria)
        {
            return _innerDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all DepartmentStockTemployeeValidSave from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return _innerDao.FindPaging(criteria);
        }
    }
}