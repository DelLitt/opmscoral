using System.Collections;
using System.Collections.Generic;
using System.Text;
using NHibernate.Criterion;
using Spring.Transaction.Interceptor;
using AppFrame.Model;
using AppFrame.DataLayer;

namespace AppFrame.Logic
{
    public class StockLogicImpl : IStockLogic
    {
        public IReturnProductDAO ReturnProductDAO { get; set; }

        public IStockDAO StockDAO { get; set; }

        public IStockInDetailDAO StockInDetailDAO { get; set; }

        /// <summary>
        /// Find Stock object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of Stock</param>
        /// <returns></returns>
        public Stock FindById(object id)
        {
            return StockDAO.FindById(id);
        }
        
        /// <summary>
        /// Add Stock to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public Stock Add(Stock data)
        {
            StockDAO.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update Stock to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(Stock data)
        {
            StockDAO.Update(data);
        }
        
        /// <summary>
        /// Delete Stock from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(Stock data)
        {
            StockDAO.Delete(data);
        }
        
        /// <summary>
        /// Delete Stock from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            StockDAO.DeleteById(id);
        }
        
        /// <summary>
        /// Find all Stock from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return StockDAO.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all Stock from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return StockDAO.FindPaging(criteria);
        }

        [Transaction(ReadOnly = false)]
        public void CreateOrUpdateStock(IList<Stock> stockList, IList<ReturnProduct> returnProductList, IList<StockInDetail> stockInDetailList)
        {
            var stockId = StockDAO.SelectSpecificType(null, Projections.Max("StockId"));
            long id = 0;
            if (stockId != null)
            {
                id = (long)stockId;
            }

            foreach (var stock in stockList)
            {
                if (stock.StockId == 0)
                {
                    stock.StockId = ++id;
                    StockDAO.Add(stock);
                }
                else
                {
                    StockDAO.Update(stock);
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
                StockInDetailDAO.Update(stockInDetail);
            }
        }

        public IList FindByQuery(ObjectCriteria criteria)
        {
            var sqlString = new StringBuilder("select stock, sum(stock.Quantity) FROM Stock stock, Product p, ProductMaster pm WHERE stock.Product.ProductId = p.ProductId AND p.ProductMaster.ProductMasterId = pm.ProductMasterId ");
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
            //var sqlString = "select * FROM Stock stock, Product p WHERE stock.Product_Id = p.Product_Id";
            return StockDAO.FindByQuery(sqlString.ToString(), criteria);
        }

        public IList FindByQueryForStockIn(ObjectCriteria criteria)
        {
            var sqlString = new StringBuilder("select stock, sum(stock.Quantity) FROM Stock stock, Product p, ProductMaster pm WHERE stock.Product.ProductId = p.ProductId AND p.ProductMaster.ProductMasterId = pm.ProductMasterId ");
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
            return StockDAO.FindByQuery(sqlString.ToString(), criteria);
        }

        #region IStockLogic Members


        public IList FindByProductMasterName()
        {
            return StockDAO.FindByProductMasterName();
        }

        #endregion

        #region IStockLogic Members


        public IList FindAllErrors()
        {
            return StockDAO.FindAllErrors();
        }

        #endregion

        #region IStockLogic Members


        public IList FindByProductMasterName(ProductMaster master)
        {
            return StockDAO.FindByProductMasterName(master);
        }

        #endregion

        #region IStockLogic Members


        public IList FindAllProductMasters()
        {
            return StockDAO.FindAllProductMasters();
        }

        #endregion
    }
}