using System.Collections;
using NHibernate.Criterion;
using Spring.Transaction.Interceptor;
using AppFrame.Model;
using AppFrame.DataLayer;

namespace AppFrame.Logic
{
    public class DepartmentStockOutDetailLogicImpl : IDepartmentStockOutDetailLogic
    {
        private IDepartmentStockOutDetailDAO _departmentStockOutDetailDAO;

        public IDepartmentStockOutDetailDAO DepartmentStockOutDetailDAO
        {
            get 
            { 
                return _departmentStockOutDetailDAO; 
            }
            set 
            { 
                _departmentStockOutDetailDAO = value; 
            }
        }
        
        /// <summary>
        /// Find DepartmentStockOutDetail object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of DepartmentStockOutDetail</param>
        /// <returns></returns>
        public DepartmentStockOutDetail FindById(object id)
        {
            return DepartmentStockOutDetailDAO.FindById(id);
        }
        
        /// <summary>
        /// Add DepartmentStockOutDetail to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public DepartmentStockOutDetail Add(DepartmentStockOutDetail data)
        {
            DepartmentStockOutDetailDAO.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update DepartmentStockOutDetail to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(DepartmentStockOutDetail data)
        {
            DepartmentStockOutDetailDAO.Update(data);
        }
        
        /// <summary>
        /// Delete DepartmentStockOutDetail from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(DepartmentStockOutDetail data)
        {
            DepartmentStockOutDetailDAO.Delete(data);
        }
        
        /// <summary>
        /// Delete DepartmentStockOutDetail from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            DepartmentStockOutDetailDAO.DeleteById(id);
        }
        
        /// <summary>
        /// Find all DepartmentStockOutDetail from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return DepartmentStockOutDetailDAO.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all DepartmentStockOutDetail from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return DepartmentStockOutDetailDAO.FindPaging(criteria);
        }

        #region IDepartmentStockOutDetailLogic Members


        public long FindMaxId()
        {
            object maxId = DepartmentStockOutDetailDAO.SelectSpecificType(null, Projections.Max("DepartmentStockOutDetailPK.StockOutId"));
            return maxId != null ? (long)maxId : 0;
        }

        #endregion
    }
}