			 


using System.Collections;
using System.Collections.Generic;
using Spring.Transaction.Interceptor;
using  CoralPOS.Models;
using  POSServer.DataLayer.Implement;

namespace POSServer.BusinessLogic.Implement
{
    public class DepartmentStockInCostLogic : IDepartmentStockInCostLogic
    {
        private IDepartmentStockInCostDao _innerDao;
        public IDepartmentStockInCostDao DepartmentStockInCostDao
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
        /// Find DepartmentStockInCost object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of DepartmentStockInCost</param>
        /// <returns></returns>
        public DepartmentStockInCost FindById(object id)
        {
            return DepartmentStockInCostDao.FindById(id);
        }
        
        /// <summary>
        /// Add DepartmentStockInCost to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public DepartmentStockInCost Add(DepartmentStockInCost data)
        {
            DepartmentStockInCostDao.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update DepartmentStockInCost to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(DepartmentStockInCost data)
        {
            DepartmentStockInCostDao.Update(data);
        }
        
        /// <summary>
        /// Delete DepartmentStockInCost from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(DepartmentStockInCost data)
        {
            DepartmentStockInCostDao.Delete(data);
        }
        
        /// <summary>
        /// Delete DepartmentStockInCost from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            DepartmentStockInCostDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all DepartmentStockInCost from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<DepartmentStockInCost> FindAll(ObjectCriteria criteria)
        {
            return DepartmentStockInCostDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all DepartmentStockInCost from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return DepartmentStockInCostDao.FindPaging(criteria);
        }
    }
}