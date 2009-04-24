using System;
using System.Collections;
using System.Text;
using AppFrame.Common;
using AppFrame.Exceptions;
using NHibernate.Criterion;
using Spring.Transaction.Interceptor;
using AppFrame.Model;
using AppFrame.DataLayer;

namespace AppFrame.Logic
{
    public class DepartmentStockTempLogicImpl : IDepartmentStockTempLogic
    {
        public IDepartmentStockTempDAO DepartmentStockTempDAO { get; set; }
        
        /// <summary>
        /// Find DepartmentStockTemp object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of DepartmentStockTemp</param>
        /// <returns></returns>
        public DepartmentStockTemp FindById(object id)
        {
            return DepartmentStockTempDAO.FindById(id);
        }
        
        /// <summary>
        /// Add DepartmentStockTemp to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public DepartmentStockTemp Add(DepartmentStockTemp data)
        {
            DepartmentStockTempDAO.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update DepartmentStockTemp to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(DepartmentStockTemp data)
        {
            DepartmentStockTempDAO.Update(data);
        }
        
        /// <summary>
        /// Delete DepartmentStockTemp from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(DepartmentStockTemp data)
        {
            DepartmentStockTempDAO.Delete(data);
        }
        
        /// <summary>
        /// Delete DepartmentStockTemp from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            DepartmentStockTempDAO.DeleteById(id);
        }
        
        /// <summary>
        /// Find all DepartmentStockTemp from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return DepartmentStockTempDAO.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all DepartmentStockTemp from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return DepartmentStockTempDAO.FindPaging(criteria);
        }
        
    }
}