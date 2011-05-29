using System.Collections;
using Spring.Transaction.Interceptor;
using AppFrame.Model;
using AppFrame.DataLayer;

namespace AppFrame.Logic
{
    public class DepartmentCostLogicImpl : IDepartmentCostLogic
    {
        private IDepartmentCostDAO _departmentCostDAO;

        public IDepartmentCostDAO DepartmentCostDAO
        {
            get 
            { 
                return _departmentCostDAO; 
            }
            set 
            { 
                _departmentCostDAO = value; 
            }
        }
        
        /// <summary>
        /// Find DepartmentCost object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of DepartmentCost</param>
        /// <returns></returns>
        public DepartmentCost FindById(object id)
        {
            return DepartmentCostDAO.FindById(id);
        }
        
        /// <summary>
        /// Add DepartmentCost to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public DepartmentCost Add(DepartmentCost data)
        {
            DepartmentCostDAO.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update DepartmentCost to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(DepartmentCost data)
        {
            DepartmentCostDAO.Update(data);
        }
        
        /// <summary>
        /// Delete DepartmentCost from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(DepartmentCost data)
        {
            DepartmentCostDAO.Delete(data);
        }
        
        /// <summary>
        /// Delete DepartmentCost from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            DepartmentCostDAO.DeleteById(id);
        }
        
        /// <summary>
        /// Find all DepartmentCost from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return DepartmentCostDAO.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all DepartmentCost from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return DepartmentCostDAO.FindPaging(criteria);
        }
    }
}