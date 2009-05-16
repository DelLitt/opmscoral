using System.Collections;
using Spring.Transaction.Interceptor;
using AppFrame.Model;
using AppFrame.DataLayer;

namespace AppFrame.Logic
{
    public class DepartmentReturnCostLogicImpl : IDepartmentReturnCostLogic
    {
        private IDepartmentReturnCostDAO _departmentReturnCostDAO;

        public IDepartmentReturnCostDAO DepartmentReturnCostDAO
        {
            get 
            { 
                return _departmentReturnCostDAO; 
            }
            set 
            { 
                _departmentReturnCostDAO = value; 
            }
        }
        
        /// <summary>
        /// Find DepartmentReturnCost object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of DepartmentReturnCost</param>
        /// <returns></returns>
        public DepartmentReturnCost FindById(object id)
        {
            return DepartmentReturnCostDAO.FindById(id);
        }
        
        /// <summary>
        /// Add DepartmentReturnCost to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public DepartmentReturnCost Add(DepartmentReturnCost data)
        {
            DepartmentReturnCostDAO.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update DepartmentReturnCost to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(DepartmentReturnCost data)
        {
            DepartmentReturnCostDAO.Update(data);
        }
        
        /// <summary>
        /// Delete DepartmentReturnCost from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(DepartmentReturnCost data)
        {
            DepartmentReturnCostDAO.Delete(data);
        }
        
        /// <summary>
        /// Delete DepartmentReturnCost from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            DepartmentReturnCostDAO.DeleteById(id);
        }
        
        /// <summary>
        /// Find all DepartmentReturnCost from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return DepartmentReturnCostDAO.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all DepartmentReturnCost from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return DepartmentReturnCostDAO.FindPaging(criteria);
        }
    }
}