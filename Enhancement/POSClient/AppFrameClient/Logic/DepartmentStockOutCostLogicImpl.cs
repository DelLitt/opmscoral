using System.Collections;
using Spring.Transaction.Interceptor;
using AppFrame.Model;
using AppFrame.DataLayer;

namespace AppFrame.Logic
{
    public class DepartmentStockOutCostLogicImpl : IDepartmentStockOutCostLogic
    {
        private IDepartmentStockOutCostDAO _departmentStockOutCostDAO;

        public IDepartmentStockOutCostDAO DepartmentStockOutCostDAO
        {
            get 
            { 
                return _departmentStockOutCostDAO; 
            }
            set 
            { 
                _departmentStockOutCostDAO = value; 
            }
        }
        
        /// <summary>
        /// Find DepartmentStockOutCost object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of DepartmentStockOutCost</param>
        /// <returns></returns>
        public DepartmentStockOutCost FindById(object id)
        {
            return DepartmentStockOutCostDAO.FindById(id);
        }
        
        /// <summary>
        /// Add DepartmentStockOutCost to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public DepartmentStockOutCost Add(DepartmentStockOutCost data)
        {
            DepartmentStockOutCostDAO.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update DepartmentStockOutCost to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(DepartmentStockOutCost data)
        {
            DepartmentStockOutCostDAO.Update(data);
        }
        
        /// <summary>
        /// Delete DepartmentStockOutCost from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(DepartmentStockOutCost data)
        {
            DepartmentStockOutCostDAO.Delete(data);
        }
        
        /// <summary>
        /// Delete DepartmentStockOutCost from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            DepartmentStockOutCostDAO.DeleteById(id);
        }
        
        /// <summary>
        /// Find all DepartmentStockOutCost from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return DepartmentStockOutCostDAO.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all DepartmentStockOutCost from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return DepartmentStockOutCostDAO.FindPaging(criteria);
        }
    }
}