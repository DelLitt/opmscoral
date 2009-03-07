using System.Collections;
using NHibernate.Criterion;
using Spring.Transaction.Interceptor;
using AppFrame.Model;
using AppFrame.DataLayer;

namespace AppFrame.Logic
{
    public class DepartmentStockOutLogicImpl : IDepartmentStockOutLogic
    {
        private IDepartmentStockOutDAO _departmentStockOutDAO;

        public IDepartmentStockOutDAO DepartmentStockOutDAO
        {
            get 
            { 
                return _departmentStockOutDAO; 
            }
            set 
            { 
                _departmentStockOutDAO = value; 
            }
        }
        
        /// <summary>
        /// Find DepartmentStockOut object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of DepartmentStockOut</param>
        /// <returns></returns>
        public DepartmentStockOut FindById(object id)
        {
            return DepartmentStockOutDAO.FindById(id);
        }
        
        /// <summary>
        /// Add DepartmentStockOut to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public DepartmentStockOut Add(DepartmentStockOut data)
        {
            DepartmentStockOutDAO.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update DepartmentStockOut to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(DepartmentStockOut data)
        {
            DepartmentStockOutDAO.Update(data);
        }
        
        /// <summary>
        /// Delete DepartmentStockOut from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(DepartmentStockOut data)
        {
            DepartmentStockOutDAO.Delete(data);
        }
        
        /// <summary>
        /// Delete DepartmentStockOut from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            DepartmentStockOutDAO.DeleteById(id);
        }
        
        /// <summary>
        /// Find all DepartmentStockOut from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return DepartmentStockOutDAO.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all DepartmentStockOut from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return DepartmentStockOutDAO.FindPaging(criteria);
        }

        #region IDepartmentStockOutLogic Members


        public long FindMaxId()
        {
            object maxId = DepartmentStockOutDAO.SelectSpecificType(null, Projections.Max("DepartmentStockOutPK.StockOutId"));
            return maxId != null ? (long)maxId : 0;
        }

        #endregion
    }
}