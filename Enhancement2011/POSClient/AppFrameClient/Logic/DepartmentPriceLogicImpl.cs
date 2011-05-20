using System.Collections;
using Spring.Transaction.Interceptor;
using AppFrame.Model;
using AppFrame.DataLayer;

namespace AppFrame.Logic
{
    public class DepartmentPriceLogicImpl : IDepartmentPriceLogic
    {
        private IDepartmentPriceDAO _DepartmentPriceDAO;

        public IDepartmentPriceDAO DepartmentPriceDAO
        {
            get 
            { 
                return _DepartmentPriceDAO; 
            }
            set 
            { 
                _DepartmentPriceDAO = value; 
            }
        }
        
        /// <summary>
        /// Find DepartmentPrice object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of DepartmentPrice</param>
        /// <returns></returns>
        public DepartmentPrice FindById(object id)
        {
            return DepartmentPriceDAO.FindById(id);
        }
        
        /// <summary>
        /// Add DepartmentPrice to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public DepartmentPrice Add(DepartmentPrice data)
        {
            DepartmentPriceDAO.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update DepartmentPrice to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(DepartmentPrice data)
        {
            DepartmentPriceDAO.Update(data);
        }
        
        /// <summary>
        /// Delete DepartmentPrice from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(DepartmentPrice data)
        {
            DepartmentPriceDAO.Delete(data);
        }
        
        /// <summary>
        /// Delete DepartmentPrice from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            DepartmentPriceDAO.DeleteById(id);
        }
        
        /// <summary>
        /// Find all DepartmentPrice from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return DepartmentPriceDAO.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all DepartmentPrice from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return DepartmentPriceDAO.FindPaging(criteria);
        }
    }
}