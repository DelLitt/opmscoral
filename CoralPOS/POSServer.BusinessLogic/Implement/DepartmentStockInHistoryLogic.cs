			 


using System.Collections;
using Spring.Transaction.Interceptor;
using  CoralPOS.Models;
using  POSServer.DataLayer.Implement;

namespace POSServer.DataLayer.Implement
{
    public class DepartmentStockInHistoryLogicImpl : IDepartmentStockInHistoryLogic
    {
        private IDepartmentStockInHistoryDao _innerDao;

        public IDepartmentStockInHistoryDao DepartmentStockInHistoryDao
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
        /// Find DepartmentStockInHistory object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of DepartmentStockInHistory</param>
        /// <returns></returns>
        public DepartmentStockInHistory FindById(object id)
        {
            return _innerDao.FindById(id);
        }
        
        /// <summary>
        /// Add DepartmentStockInHistory to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public DepartmentStockInHistory Add(DepartmentStockInHistory data)
        {
            _innerDao.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update DepartmentStockInHistory to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(DepartmentStockInHistory data)
        {
            _innerDao.Update(data);
        }
        
        /// <summary>
        /// Delete DepartmentStockInHistory from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(DepartmentStockInHistory data)
        {
            _innerDao.Delete(data);
        }
        
        /// <summary>
        /// Delete DepartmentStockInHistory from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            _innerDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all DepartmentStockInHistory from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return _innerDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all DepartmentStockInHistory from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return _innerDao.FindPaging(criteria);
        }
    }
}