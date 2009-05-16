using System.Collections;
using Spring.Transaction.Interceptor;
using AppFrame.Model;
using AppFrame.DataLayer;

namespace AppFrame.Logic
{
    public class DepartmentReturnDetailLogicImpl : IDepartmentReturnDetailLogic
    {
        private IDepartmentReturnDetailDAO _departmentReturnDetailDAO;

        public IDepartmentReturnDetailDAO DepartmentReturnDetailDAO
        {
            get 
            { 
                return _departmentReturnDetailDAO; 
            }
            set 
            { 
                _departmentReturnDetailDAO = value; 
            }
        }
        
        /// <summary>
        /// Find DepartmentReturnDetail object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of DepartmentReturnDetail</param>
        /// <returns></returns>
        public DepartmentReturnDetail FindById(object id)
        {
            return DepartmentReturnDetailDAO.FindById(id);
        }
        
        /// <summary>
        /// Add DepartmentReturnDetail to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public DepartmentReturnDetail Add(DepartmentReturnDetail data)
        {
            DepartmentReturnDetailDAO.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update DepartmentReturnDetail to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(DepartmentReturnDetail data)
        {
            DepartmentReturnDetailDAO.Update(data);
        }
        
        /// <summary>
        /// Delete DepartmentReturnDetail from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(DepartmentReturnDetail data)
        {
            DepartmentReturnDetailDAO.Delete(data);
        }
        
        /// <summary>
        /// Delete DepartmentReturnDetail from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            DepartmentReturnDetailDAO.DeleteById(id);
        }
        
        /// <summary>
        /// Find all DepartmentReturnDetail from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return DepartmentReturnDetailDAO.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all DepartmentReturnDetail from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return DepartmentReturnDetailDAO.FindPaging(criteria);
        }
    }
}