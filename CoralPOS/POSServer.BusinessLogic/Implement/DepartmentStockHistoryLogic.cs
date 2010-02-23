			 


using System.Collections;
using Spring.Transaction.Interceptor;
using  CoralPOS.Models;
using  POSServer.DataLayer.Implement;

namespace POSServer.DataLayer.Implement
{
    public class DepartmentStockHistoryLogicImpl : IDepartmentStockHistoryLogic
    {
        private IDepartmentStockHistoryDao _innerDao;

        public IDepartmentStockHistoryDao DepartmentStockHistoryDao
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
        /// Find DepartmentStockHistory object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of DepartmentStockHistory</param>
        /// <returns></returns>
        public DepartmentStockHistory FindById(object id)
        {
            return _innerDao.FindById(id);
        }
        
        /// <summary>
        /// Add DepartmentStockHistory to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public DepartmentStockHistory Add(DepartmentStockHistory data)
        {
            _innerDao.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update DepartmentStockHistory to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(DepartmentStockHistory data)
        {
            _innerDao.Update(data);
        }
        
        /// <summary>
        /// Delete DepartmentStockHistory from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(DepartmentStockHistory data)
        {
            _innerDao.Delete(data);
        }
        
        /// <summary>
        /// Delete DepartmentStockHistory from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            _innerDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all DepartmentStockHistory from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return _innerDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all DepartmentStockHistory from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return _innerDao.FindPaging(criteria);
        }
    }
}