using System.Collections;
using System.Text;
using Spring.Transaction.Interceptor;
using AppFrame.Model;
using AppFrame.DataLayer;

namespace AppFrame.Logic
{
    public class DepartmentStockInDetailLogicImpl : IDepartmentStockInDetailLogic
    {
        private IDepartmentStockInDetailDAO _departmentStockInDetailDAO;

        public IDepartmentStockInDetailDAO DepartmentStockInDetailDAO
        {
            get 
            { 
                return _departmentStockInDetailDAO; 
            }
            set 
            { 
                _departmentStockInDetailDAO = value; 
            }
        }
        
        /// <summary>
        /// Find DepartmentStockInDetail object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of DepartmentStockInDetail</param>
        /// <returns></returns>
        public DepartmentStockInDetail FindById(object id)
        {
            return DepartmentStockInDetailDAO.FindById(id);
        }
        
        /// <summary>
        /// Add DepartmentStockInDetail to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public DepartmentStockInDetail Add(DepartmentStockInDetail data)
        {
            DepartmentStockInDetailDAO.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update DepartmentStockInDetail to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(DepartmentStockInDetail data)
        {
            DepartmentStockInDetailDAO.Update(data);
        }
        
        /// <summary>
        /// Delete DepartmentStockInDetail from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(DepartmentStockInDetail data)
        {
            DepartmentStockInDetailDAO.Delete(data);
        }
        
        /// <summary>
        /// Delete DepartmentStockInDetail from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            DepartmentStockInDetailDAO.DeleteById(id);
        }
        
        /// <summary>
        /// Find all DepartmentStockInDetail from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return DepartmentStockInDetailDAO.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all DepartmentStockInDetail from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return DepartmentStockInDetailDAO.FindPaging(criteria);
        }

        public IList FindByQuery(ObjectCriteria criteria)
        {
            var sql = new StringBuilder("SELECT s FROM DepartmentStockInDetail s, DepartmentStockIn deptStockIn, Product p, ProductMaster pm, DepartmentPrice price ");
            sql.Append("WHERE s.DepartmentStockInDetailPK.ProductId = p.ProductId AND p.ProductMaster.ProductMasterId = pm.ProductMasterId ");
            sql.Append(" AND pm.ProductMasterId = price.DepartmentPricePK.ProductMasterId ");
            sql.Append(" AND s.DepartmentStockInDetailPK.DepartmentId = price.DepartmentPricePK.DepartmentId ");
            sql.Append(" AND s.DepartmentStockInDetailPK.DepartmentId = deptStockIn.DepartmentStockInPK.DepartmentId ");
            sql.Append(" AND s.DepartmentStockInDetailPK.StockInId = deptStockIn.DepartmentStockInPK.StockInId");
            int i = 0;
            foreach (SQLQueryCriteria crit in criteria.GetQueryCriteria())
            {
                sql.Append(" AND ")
                   .Append(crit.PropertyName)
                   .Append(" ")
                   .Append(crit.SQLString)
                   .Append(" :")
                   .Append(crit.PropertyName)
                   .Append(i++)
                   .Append(" ");
            }
            return DepartmentStockInDetailDAO.FindByQuery(sql.ToString(), criteria);
        }

        #region IDepartmentStockInDetailLogic Members


        public IList FindAllProductMaster(ProductMaster searchProductMaster)
        {
            return DepartmentStockInDetailDAO.FindAllProductMaster(searchProductMaster);
        }

        #endregion
    }
}