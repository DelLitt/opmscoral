			 


using System.Collections;
using System.Collections.Generic;
using Spring.Transaction.Interceptor;
using  CoralPOS.Models;
using  POSServer.DataLayer.Implement;

namespace POSServer.BusinessLogic.Implement
{
    public class DepartmentStockInLogic : IDepartmentStockInLogic
    {
        private IDepartmentStockInDao _innerDao;
        public IDepartmentStockInDao DepartmentStockInDao
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
        /// Find DepartmentStockIn object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of DepartmentStockIn</param>
        /// <returns></returns>
        public DepartmentStockIn FindById(object id)
        {
            return DepartmentStockInDao.FindById(id);
        }
        
        /// <summary>
        /// Add DepartmentStockIn to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public DepartmentStockIn Add(DepartmentStockIn data)
        {
            DepartmentStockInDao.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update DepartmentStockIn to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(DepartmentStockIn data)
        {
            DepartmentStockInDao.Update(data);
        }
        
        /// <summary>
        /// Delete DepartmentStockIn from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(DepartmentStockIn data)
        {
            DepartmentStockInDao.Delete(data);
        }
        
        /// <summary>
        /// Delete DepartmentStockIn from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            DepartmentStockInDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all DepartmentStockIn from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<DepartmentStockIn> FindAll(ObjectCriteria criteria)
        {
            return DepartmentStockInDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all DepartmentStockIn from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return DepartmentStockInDao.FindPaging(criteria);
        }
    }
}