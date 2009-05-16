using System.Collections;
using Spring.Transaction.Interceptor;
using AppFrame.Model;
using AppFrame.DataLayer;

namespace AppFrame.Logic
{
    public class DepartmentManagementLogicImpl : IDepartmentManagementLogic
    {
        private IDepartmentManagementDAO _departmentCostDAO;

        public IDepartmentManagementDAO DepartmentManagementDAO
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
        /// Find DepartmentManagement object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of DepartmentManagement</param>
        /// <returns></returns>
        public DepartmentManagement FindById(object id)
        {
            return DepartmentManagementDAO.FindById(id);
        }
        
        /// <summary>
        /// Add DepartmentManagement to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public DepartmentManagement Add(DepartmentManagement data)
        {
            DepartmentManagementDAO.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update DepartmentManagement to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(DepartmentManagement data)
        {
            DepartmentManagementDAO.Update(data);
        }
        
        /// <summary>
        /// Delete DepartmentManagement from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(DepartmentManagement data)
        {
            DepartmentManagementDAO.Delete(data);
        }
        
        /// <summary>
        /// Delete DepartmentManagement from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            DepartmentManagementDAO.DeleteById(id);
        }
        
        /// <summary>
        /// Find all DepartmentManagement from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return DepartmentManagementDAO.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all DepartmentManagement from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return DepartmentManagementDAO.FindPaging(criteria);
        }


        #region IDepartmentManagementLogic Members


        public DepartmentManagement FindLastPeriod()
        {
            return DepartmentManagementDAO.FindLastPeriod();
        }

        #endregion
    }
}