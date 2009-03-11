using System.Collections;
using System.Text;
using Spring.Transaction.Interceptor;
using AppFrame.Model;
using AppFrame.DataLayer;

namespace AppFrame.Logic
{
    public class DepartmentStockLogicImpl : IDepartmentStockLogic
    {
        public IDepartmentStockDAO DepartmentStockDAO { get; set; }

        /// <summary>
        /// Find DepartmentStock object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of DepartmentStock</param>
        /// <returns></returns>
        public DepartmentStock FindById(object id)
        {
            return DepartmentStockDAO.FindById(id);
        }
        
        /// <summary>
        /// Add DepartmentStock to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public DepartmentStock Add(DepartmentStock data)
        {
            DepartmentStockDAO.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update DepartmentStock to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(DepartmentStock data)
        {
            DepartmentStockDAO.Update(data);
        }
        
        /// <summary>
        /// Delete DepartmentStock from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(DepartmentStock data)
        {
            DepartmentStockDAO.Delete(data);
        }
        
        /// <summary>
        /// Delete DepartmentStock from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            DepartmentStockDAO.DeleteById(id);
        }
        
        /// <summary>
        /// Find all DepartmentStock from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return DepartmentStockDAO.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all DepartmentStock from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return DepartmentStockDAO.FindPaging(criteria);
        }

        public IList FindByQuery(ObjectCriteria criteria)
        {
            var sql = new StringBuilder("SELECT s, SUM(s.Quantity), SUM(s.Quantity * sdetail.Price), price FROM DepartmentStock s, Product p, ProductMaster pm, DepartmentStockInDetail sdetail, DepartmentPrice price WHERE s.DepartmentStockPK.ProductId = p.ProductId AND p.ProductMaster.ProductMasterId = pm.ProductMasterId AND s.Product.ProductId = sdetail.Product.ProductId AND pm.ProductMasterId = price.DepartmentPricePK.ProductMasterId ");
            foreach (SQLQueryCriteria crit in criteria.GetQueryCriteria())
            {
                sql.Append(" AND ")
                   .Append(crit.PropertyName)
                   .Append(" ")
                   .Append(crit.SQLString)
                   .Append(" :")
                   .Append(crit.PropertyName)
                   .Append(" ");
            }
            sql.Append(" GROUP BY pm.ProductMasterId");

            //var sqltemp = new StringBuilder("SELECT s from DepartmentStockProductMasterView s");
            //DepartmentStockDAO.FindByQuery(sqltemp.ToString(), new ObjectCriteria());
            return DepartmentStockDAO.FindByQuery(sql.ToString(), criteria);
        }

        public IList FindByQueryForDeptStock(ObjectCriteria criteria)
        {
            var sqlString = new StringBuilder("select stock, sum(stock.Quantity) FROM DepartmentStock stock, Product p, ProductMaster pm WHERE stock.Product.ProductId = p.ProductId AND p.ProductMaster.ProductMasterId = pm.ProductMasterId ");
            foreach (SQLQueryCriteria crit in criteria.GetQueryCriteria())
            {
                sqlString.Append(" AND ")
                       .Append(crit.PropertyName)
                       .Append(" ")
                       .Append(crit.SQLString)
                       .Append(" :")
                       .Append(crit.PropertyName)
                       .Append(" ");
            }
            sqlString.Append(" Having sum(stock.Quantity) > 0 ");
            sqlString.Append(" Group BY pm.ProductMasterId");
            //criteria.AddQueryCriteria("productName", "Ao%");
            //var sqlString = "select * FROM Stock stock, Product p WHERE stock.Product_Id = p.Product_Id";
            return DepartmentStockDAO.FindByQueryForDeptStock(sqlString.ToString(), criteria);
        }

        #region IDepartmentStockLogic Members


        public void Process(IList list)
        {
            
        }

        #endregion
    }
}