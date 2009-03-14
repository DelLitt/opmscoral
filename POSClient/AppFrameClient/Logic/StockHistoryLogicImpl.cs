using System.Collections;
using System.Text;
using NHibernate.Criterion;
using Spring.Transaction.Interceptor;
using AppFrame.Model;
using AppFrame.DataLayer;

namespace AppFrame.Logic
{
    public class StockHistoryLogicImpl : IStockHistoryLogic
    {
        private IStockHistoryDAO _StockHistoryDAO;

        public IStockHistoryDAO StockHistoryDAO
        {
            get
            {
                return _StockHistoryDAO;
            }
            set
            {
                _StockHistoryDAO = value;
            }
        }

        /// <summary>
        /// Find StockHistory object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of StockHistory</param>
        /// <returns></returns>
        public StockHistory FindById(object id)
        {
            return StockHistoryDAO.FindById(id);
        }

        /// <summary>
        /// Add StockHistory to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly = false)]
        public StockHistory Add(StockHistory data)
        {
            StockHistoryDAO.Add(data);
            return data;
        }

        /// <summary>
        /// Update StockHistory to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly = false)]
        public void Update(StockHistory data)
        {
            StockHistoryDAO.Update(data);
        }

        /// <summary>
        /// Delete StockHistory from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly = false)]
        public void Delete(StockHistory data)
        {
            StockHistoryDAO.Delete(data);
        }

        /// <summary>
        /// Delete StockHistory from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly = false)]
        public void DeleteById(object id)
        {
            StockHistoryDAO.DeleteById(id);
        }

        /// <summary>
        /// Find all StockHistory from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return StockHistoryDAO.FindAll(criteria);
        }

        /// <summary>
        /// Find all StockHistory from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return StockHistoryDAO.FindPaging(criteria);
        }

        #region IStockHistoryLogic Members


        public void Process(StockHistory defect)
        {
            // find exist stock base on productid
            ObjectCriteria objectCriteria = new ObjectCriteria();
            objectCriteria.AddEqCriteria("Product.ProductId", defect.Product.ProductId);
            IList existList = StockHistoryDAO.FindAll(objectCriteria);

            if (existList.Count > 0) // exist stock ?
            {
                StockHistory existDefect = (StockHistory)existList[0];
                existDefect.DamageCount = defect.DamageCount;
                existDefect.Description = defect.Description;
                existDefect.ErrorCount = defect.ErrorCount;
                existDefect.LostCount = defect.LostCount;
                existDefect.GoodCount = defect.GoodCount;
                existDefect.Product = defect.Product;
                existDefect.ProductMaster = defect.ProductMaster;
                existDefect.Quantity = defect.Quantity;
                existDefect.Stock = defect.Stock;
                existDefect.UnconfirmCount = defect.UnconfirmCount;
                existDefect.UpdateDate = defect.UpdateDate;
                existDefect.UpdateId = defect.UpdateId;

                existDefect.ExclusiveKey = existDefect.ExclusiveKey + 1;
                defect.StockHistoryId = existDefect.StockHistoryId;

                StockHistoryDAO.Update(existDefect);
            }
            else
            {
                StockHistoryDAO.Add(defect);
            }
        }

        #endregion

        #region IStockHistoryLogic Members


        public long FindMaxStockHistoryId()
        {
            object maxId = StockHistoryDAO.SelectSpecificType(null, Projections.Max("StockHistoryId"));
            if (maxId != null)
            {
                return (long) maxId;
            }
            else
            {
                return 0;
            }
        }

        #endregion

        #region IStockHistoryLogic Members


        public IList FindAllProductMasters()
        {
            return StockHistoryDAO.FindByProductMasters();
        }

        #endregion

        #region IStockHistoryLogic Members


        public IList FindByProductMasterName(ProductMaster master)
        {
            return StockHistoryDAO.FindByProductMasterName(master);
        }

        #endregion

        public IList FindByMaxDate(ObjectCriteria criteria)
        {
            var sqlString = new StringBuilder("select stock, max(stock.CreateDate) FROM StockHistory stock, Product p WHERE stock.Product.ProductId = p.ProductId ");
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
            return StockHistoryDAO.FindByMaxDate(sqlString.ToString(), criteria);
        }
    }
}