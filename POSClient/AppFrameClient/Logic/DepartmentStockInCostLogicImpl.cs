using System.Collections;
using Spring.Transaction.Interceptor;
using AppFrame.Model;
using AppFrame.DataLayer;

namespace AppFrame.Logic
{
    public class DepartmentStockInCostLogicImpl : IDepartmentStockInCostLogic
    {
        private IDepartmentStockInCostDAO _departmentStockInCostDAO;

        public IDepartmentStockInCostDAO DepartmentStockInCostDAO
        {
            get 
            { 
                return _departmentStockInCostDAO; 
            }
            set 
            { 
                _departmentStockInCostDAO = value; 
            }
        }
        
        /// <summary>
        /// Find DepartmentStockInCost object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of DepartmentStockInCost</param>
        /// <returns></returns>
        public DepartmentStockInCost FindById(object id)
        {
            return DepartmentStockInCostDAO.FindById(id);
        }
        
        /// <summary>
        /// Add DepartmentStockInCost to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public DepartmentStockInCost Add(DepartmentStockInCost data)
        {
            DepartmentStockInCostDAO.Add(data);
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
            DepartmentStockInCostDAO.Update(data);
        }
        
        /// <summary>
        /// Delete DepartmentStockInCost from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(DepartmentStockInCost data)
        {
            DepartmentStockInCostDAO.Delete(data);
        }
        
        /// <summary>
        /// Delete DepartmentStockInCost from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            DepartmentStockInCostDAO.DeleteById(id);
        }
        
        /// <summary>
        /// Find all DepartmentStockInCost from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return DepartmentStockInCostDAO.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all DepartmentStockInCost from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return DepartmentStockInCostDAO.FindPaging(criteria);
        }
    }
}