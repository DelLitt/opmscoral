using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using AppFrame.Common;
using NHibernate.Criterion;
using Spring.Transaction.Interceptor;
using AppFrame.Model;
using AppFrame.DataLayer;

namespace AppFrame.Logic
{
    public class SubStockLogicImpl : ISubStockLogic
    {
        public IReturnProductDAO ReturnProductDAO { get; set; }

        public ISubStockDAO SubStockDAO { get; set; }

        public IStockInDetailDAO SubStockInDetailDAO { get; set; }

        /// <summary>
        /// Find SubStock object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of SubStock</param>
        /// <returns></returns>
        public SubStock FindById(object id)
        {
            return SubStockDAO.FindById(id);
        }
        
        /// <summary>
        /// Add SubStock to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public SubStock Add(SubStock data)
        {
            SubStockDAO.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update SubStock to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(SubStock data)
        {
            SubStockDAO.Update(data);
        }
        
        /// <summary>
        /// Delete SubStock from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(SubStock data)
        {
            SubStockDAO.Delete(data);
        }
        
        /// <summary>
        /// Delete SubStock from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            SubStockDAO.DeleteById(id);
        }
        
        /// <summary>
        /// Find all SubStock from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return SubStockDAO.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all SubStock from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return SubStockDAO.FindPaging(criteria);
        }

        [Transaction(ReadOnly = false)]
        public void CreateOrUpdateSubStock(IList<SubStock> stockList, IList<ReturnProduct> returnProductList, IList<StockInDetail> stockInDetailList)
        {
            var stockId = SubStockDAO.SelectSpecificType(null, Projections.Max("SubStockId"));
            long id = 0;
            if (stockId != null)
            {
                id = (long)stockId;
            }

            foreach (var stock in stockList)
            {
                if (stock.SubStockId == 0)
                {
                    stock.SubStockId = ++id;
                    SubStockDAO.Add(stock);
                }
                else
                {
                    SubStockDAO.Update(stock);
                }
            }

            var returnProductId = ReturnProductDAO.SelectSpecificType(null, Projections.Max("ReturnProductId"));
            id = 1;
            if (returnProductId != null)
            {
                id = (long)returnProductId;
            }
            foreach (var returnProduct in returnProductList)
            {
               returnProduct.ReturnProductId = ++id;
               ReturnProductDAO.Add(returnProduct);
            }

            foreach (var stockInDetail in stockInDetailList)
            {
                SubStockInDetailDAO.Update(stockInDetail);
            }
        }

        public IList FindByQuery(ObjectCriteria criteria)
        {
            var stockCount = SubStockDAO.SelectSpecificType(null, Projections.Count("SubStockId"));
            if (100 < (int)stockCount)
            {
                GlobalCache.Instance().WarningText = " Số lượng tìm thấy quá nhiều. Chỉ hiển thị 100 kết quả đầu.";
                criteria.MaxResult = 100;
            }

            var sqlString = new StringBuilder("select stock, sum(stock.Quantity) FROM SubStock stock, Product p, ProductMaster pm WHERE stock.Product.ProductId = p.ProductId AND p.ProductMaster.ProductMasterId = pm.ProductMasterId ");
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
            sqlString.Append(" Group BY pm.ProductMasterId");
            //criteria.AddQueryCriteria("productName", "Ao%");
            //var sqlString = "select * FROM SubStock stock, Product p WHERE stock.Product_Id = p.Product_Id";
            return SubStockDAO.FindByQuery(sqlString.ToString(), criteria);
        }

        public IList FindByQueryForSubStockIn(ObjectCriteria criteria)
        {

            var stockCount = SubStockDAO.SelectSpecificType(null, Projections.Count("SubStockId"));
            if(50 < (int)stockCount)
            {
                GlobalCache.Instance().WarningText = " Số lượng tìm thấy quá nhiều. Chỉ hiển thị 50 kết quả đầu.";
                criteria.MaxResult = 50;
            }

            var sqlString = new StringBuilder("select stock, sum(stock.Quantity) FROM SubStock stock, Product p, ProductMaster pm WHERE stock.Product.ProductId = p.ProductId AND p.ProductMaster.ProductMasterId = pm.ProductMasterId ");
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
            //var sqlString = "select * FROM SubStock stock, Product p WHERE stock.Product_Id = p.Product_Id";
            return SubStockDAO.FindByQuery(sqlString.ToString(), criteria);
        }

        #region ISubStockLogic Members


        public IList FindByProductMasterName()
        {
            return SubStockDAO.FindByProductMasterName();
        }

        #endregion

        #region ISubStockLogic Members


        public IList FindAllErrors()
        {
            return SubStockDAO.FindAllErrors();
        }

        #endregion

        #region ISubStockLogic Members


        public IList FindByProductMasterName(ProductMaster master)
        {
            return SubStockDAO.FindByProductMasterName(master);
        }

        #endregion

        #region ISubStockLogic Members


        public IList FindAllProductMasters()
        {
            return SubStockDAO.FindAllProductMasters();
        }

        #endregion
    }
}