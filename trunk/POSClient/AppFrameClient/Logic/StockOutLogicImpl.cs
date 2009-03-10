using System;
using System.Collections;
using AppFrame.Common;
using AppFrame.Exceptions;
using NHibernate.Criterion;
using Spring.Transaction.Interceptor;
using AppFrame.Model;
using AppFrame.DataLayer;

namespace AppFrame.Logic
{
    public class StockOutLogicImpl : IStockOutLogic
    {
        public IStockOutDAO StockOutDAO { get; set; }
        public IStockOutDetailDAO StockOutDetailDAO { get; set; }
        public IStockDefectDAO StockDefectDAO { get; set; }

        /// <summary>
        /// Find StockOut object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of StockOut</param>
        /// <returns></returns>
        public StockOut FindById(object id)
        {
            return StockOutDAO.FindById(id);
        }
        
        /// <summary>
        /// Add StockOut to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public StockOut Add(StockOut stockOut)
        {
            stockOut.CreateDate = DateTime.Now;
            stockOut.CreateId = ClientInfo.getInstance().LoggedUser.Name;
            stockOut.UpdateDate = DateTime.Now;
            stockOut.UpdateId = ClientInfo.getInstance().LoggedUser.Name;

            stockOut.DelFlg = 0;
            stockOut.StockOutDate = DateTime.Now;
            long maxStockOutId = this.FindMaxId();
            maxStockOutId = maxStockOutId + 1;

            stockOut.StockoutId = maxStockOutId;
            StockOutDAO.Add(stockOut);
            var maxStockOutDetailIdStr = StockOutDetailDAO.SelectSpecificType(null, Projections.Max("StockOutDetailId"));
            long maxStockOutDetailId = maxStockOutDetailIdStr != null ? Int64.Parse(maxStockOutDetailIdStr.ToString()) : 0;
            maxStockOutDetailId = maxStockOutDetailId + 1;
            IList productIds = new ArrayList();
            foreach (StockOutDetail stockOutDetail in stockOut.StockOutDetails)
            {
                productIds.Add(stockOutDetail.Product.ProductId);
            }
            var criteria = new ObjectCriteria();
            criteria.AddEqCriteria("DelFlg", CommonConstants.DEL_FLG_NO);
            criteria.AddSearchInCriteria("Product.ProductId", productIds);
            IList stockDefectList = StockDefectDAO.FindAll(criteria);
            foreach (StockOutDetail stockOutDetail in stockOut.StockOutDetails)
            {
                // check number
                var objectCriteria = new ObjectCriteria();
                objectCriteria.AddEqCriteria("DelFlg", CommonConstants.DEL_FLG_NO);
                objectCriteria.AddEqCriteria("Product.ProductId", stockOutDetail.Product.ProductId);
                IList stockedOutList = StockOutDetailDAO.FindAll(objectCriteria);
                long quantity = CalculateQuantitiesWhichStockedOut(stockedOutList);
                StockDefect def = GetErrorCount(stockOutDetail.Product.ProductId, stockDefectList);
                stockOutDetail.LostQuantity = 0;
                stockOutDetail.UnconfirmQuantity = 0;
                if (stockOutDetail.DefectStatus != null && stockOutDetail.DefectStatus.DefectStatusId == 7)
                {
                    stockOutDetail.ErrorQuantity = 0;
                    stockOutDetail.DamageQuantity = 0;
                }
                if (def != null)
                {
                    def.GoodCount -= stockOutDetail.GoodQuantity;
                    def.ErrorCount -= (int)stockOutDetail.ErrorQuantity;
                    def.DamageCount -= (int)stockOutDetail.DamageQuantity;
                    def.UpdateDate = DateTime.Now;
                    def.UpdateId = ClientInfo.getInstance().LoggedUser.Name;

                    StockDefectDAO.Update(def);
                    //long errorCount = GetErrorCount(stockOutDetail.Product.ProductId, stockDefectList);
                    //                if (stockOutDetail.Quantity > errorCount - quantity)
                    //                {
                    //                    throw new BusinessException("Số lượng hàng lỗi không đủ để xuất. Số lượng lỗi hiện có là " +
                    //                                    errorCount.ToString() + ", số lượng đã xuất là " + quantity.ToString());
                    //                }

                }
                stockOutDetail.StockOut = stockOut;
                stockOutDetail.StockOutDetailId = maxStockOutDetailId++;
                stockOutDetail.StockOutId = stockOut.StockoutId;
                StockOutDetailDAO.Add(stockOutDetail);
            }
            return stockOut;
        }

        private StockDefect GetErrorCount(string id, IList list)
        {
            foreach (StockDefect stockDefect in list)
            {
                if (stockDefect.Product.ProductId == id)
                {
                    return stockDefect;
                }
            }
            return null;
        }

        private long CalculateQuantitiesWhichStockedOut(IList list)
        {
            long result = 0;
            if (list == null)
            {
                return 0;
            }
            foreach (StockOutDetail detail in list)
            {
                result += detail.Quantity;
            }
            return result;
        }

        /// <summary>
        /// Update StockOut to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(StockOut data)
        {
            StockOutDAO.Update(data);
        }
        
        /// <summary>
        /// Delete StockOut from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(StockOut data)
        {
            StockOutDAO.Delete(data);
        }
        
        /// <summary>
        /// Delete StockOut from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            StockOutDAO.DeleteById(id);
        }
        
        /// <summary>
        /// Find all StockOut from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return StockOutDAO.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all StockOut from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return StockOutDAO.FindPaging(criteria);
        }

        #region IStockOutLogic Members


        public IList FindByProductMaster(System.DateTime date, System.DateTime toDate)
        {
            return null;//return StockOutDAO.FindByProductMaster(date, toDate);
        }

        #endregion

        #region IStockOutLogic Members


        public IList FindByProductMaster(long id, System.DateTime date, System.DateTime toDate)
        {
            return StockOutDAO.FindByProductMaster(id,date, toDate);
        }

        #endregion

        #region IStockOutLogic Members


        public long FindMaxId()
        {
            object maxId = StockOutDAO.SelectSpecificType(null, Projections.Max("StockoutId"));
            return maxId != null ? (long)maxId : 0;
        }

        #endregion

        #region IStockOutLogic Members


        public IList FindStockOut(System.DateTime date, System.DateTime toDate)
        {
            return StockOutDAO.FindStockOut(date, toDate);
        }

        #endregion
    }
}