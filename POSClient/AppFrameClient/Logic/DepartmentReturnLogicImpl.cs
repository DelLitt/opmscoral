using System.Collections;
using Spring.Transaction.Interceptor;
using AppFrame.Model;
using AppFrame.DataLayer;

namespace AppFrame.Logic
{
    public class DepartmentReturnLogicImpl : IDepartmentReturnLogic
    {
        private IDepartmentReturnDAO _departmentReturnDAO;

        public IDepartmentReturnDAO DepartmentReturnDAO
        {
            get 
            { 
                return _departmentReturnDAO; 
            }
            set 
            { 
                _departmentReturnDAO = value; 
            }
        }
        
        /// <summary>
        /// Find DepartmentReturn object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of DepartmentReturn</param>
        /// <returns></returns>
        public DepartmentReturn FindById(object id)
        {
            return DepartmentReturnDAO.FindById(id);
        }
        
        /// <summary>
        /// Add DepartmentReturn to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public DepartmentReturn Add(DepartmentReturn data)
        {
            DepartmentReturnDAO.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update DepartmentReturn to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(DepartmentReturn data)
        {
            DepartmentReturnDAO.Update(data);
        }
        
        /// <summary>
        /// Delete DepartmentReturn from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(DepartmentReturn data)
        {
            DepartmentReturnDAO.Delete(data);
        }
        
        /// <summary>
        /// Delete DepartmentReturn from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            DepartmentReturnDAO.DeleteById(id);
        }
        
        /// <summary>
        /// Find all DepartmentReturn from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return DepartmentReturnDAO.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all DepartmentReturn from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return DepartmentReturnDAO.FindPaging(criteria);
        }
    }
}