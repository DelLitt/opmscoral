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
        public IStockInDetailDAO StockInDetailDAO { get; set; }        
        public IStockDAO StockDAO { get; set; }

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
        /// <param name="stockOut"></param>
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
            
            IList stockList = StockDAO.FindAll(criteria);
            foreach (StockOutDetail stockOutDetail in stockOut.StockOutDetails)
            {
                // check number
                var objectCriteria = new ObjectCriteria();
                objectCriteria.AddEqCriteria("DelFlg", CommonConstants.DEL_FLG_NO);
                objectCriteria.AddEqCriteria("Product.ProductId", stockOutDetail.Product.ProductId);

                Stock stock = GetStock(stockOutDetail.Product.ProductId, stockList);
                if (stock == null)
                {
                    throw new BusinessException("Mặt hàng " + stockOutDetail.Product.ProductId + ", " + stockOutDetail.Product.ProductFullName + " không có trong kho");
                }
                stockOutDetail.LostQuantity = 0;
                stockOutDetail.UnconfirmQuantity = 0;
                // xuất ra cửa hàng khác
                if (stockOutDetail.DefectStatus != null && stockOutDetail.DefectStatus.DefectStatusId == 7)
                {
                    stockOutDetail.Quantity = stockOutDetail.GoodQuantity;
                    stock.Quantity -= stockOutDetail.Quantity;

                    stockOutDetail.ErrorQuantity = 0;
                    stockOutDetail.DamageQuantity = 0;
                    stockOutDetail.LostQuantity = 0;
                    stockOutDetail.UnconfirmQuantity = 0;

                }
                // xuất tạm
                else if (stockOutDetail.DefectStatus != null && stockOutDetail.DefectStatus.DefectStatusId == 4)
                {
                    // check whether it's has temp stockout enough ?
                    

                    long totaltempErrorStockOut = 0;
                    long totalReStockCount = 0;

                    ObjectCriteria crit = new ObjectCriteria();
                    crit.AddEqCriteria("Product.ProductId", stockOutDetail.Product.ProductId)
                        .AddEqCriteria("DefectStatus.DefectStatusId", (long)4)
                        .AddEqCriteria("DelFlg", (long)0);
                    IList tempStockedOutList = StockOutDetailDAO.FindAll(crit);
                    if(tempStockedOutList!=null)
                    {
                        
                        foreach (StockOutDetail outDetail in tempStockedOutList)
                        {
                            totaltempErrorStockOut += outDetail.Quantity;
                        }
                        
                    }

                    IList reStockList = StockInDetailDAO.FindReStock(stockOutDetail.Product.ProductId);
                    if (reStockList != null)
                    {
                        foreach (StockInDetail stockInDetail in reStockList)
                        {
                            totalReStockCount += stockInDetail.Quantity;
                        }
                    }
                    totaltempErrorStockOut = totaltempErrorStockOut - totalReStockCount;
                    if (stockOutDetail.ErrorQuantity > stock.ErrorQuantity - totaltempErrorStockOut)
                    {
                        throw new BusinessException("Lỗi: Mặt hàng " + stockOutDetail.Product.ProductFullName + ", mã vạch "
                                       + stockOutDetail.Product.ProductId + " có tồn " + stock.ErrorQuantity + ", đã xuất tạm " + totaltempErrorStockOut +
                                       ", và đang xuất " + stockOutDetail.ErrorQuantity);
                    }

                    // update quantity
                    stockOutDetail.Quantity = stockOutDetail.ErrorQuantity;
                    //stockOutDetail.ErrorQuantity = 0;
                    stockOutDetail.GoodQuantity = 0;
                    stockOutDetail.UnconfirmQuantity = 0;
                    stockOutDetail.LostQuantity = 0;
                    stockOutDetail.DamageQuantity = 0;
                }
                // xuất trả về cho nhà sản xuất
                else if (stockOutDetail.DefectStatus != null && stockOutDetail.DefectStatus.DefectStatusId == 5)
                {
                    stockOutDetail.Quantity = stockOutDetail.GoodQuantity + stockOutDetail.ErrorQuantity;
                    stock.Quantity -= stockOutDetail.Quantity;
                    stock.ErrorQuantity -= stockOutDetail.ErrorQuantity;
                    stockOutDetail.UnconfirmQuantity = 0;
                    stockOutDetail.LostQuantity = 0;
                }
                // if need to update main stock
                if (!stockOut.NotUpdateMainStock)
                {
                    stock.GoodQuantity -= stockOutDetail.GoodQuantity;
                    stock.UpdateDate = DateTime.Now;
                    stock.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                    StockDAO.Update(stock);
                }



                stockOutDetail.StockOut = stockOut;
                stockOutDetail.StockOutDetailId = maxStockOutDetailId++;
                stockOutDetail.StockOutId = stockOut.StockoutId;
                stockOutDetail.ProductMaster = stockOutDetail.Product.ProductMaster;
                StockOutDetailDAO.Add(stockOutDetail);
            }
            return stockOut;
        }

        private Stock GetErrorCount(string id, IList list)
        {
            foreach (Stock stockDefect in list)
            {
                if (stockDefect.Product.ProductId == id)
                {
                    return stockDefect;
                }
            }
            return null;
        }

        private Stock GetStock(string id, IList list)
        {
            foreach (Stock stockDefect in list)
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

        #region IStockOutLogic Members


        public void ProcessErrorGoods(IList stockList, IList returnGoodsList, IList tempStockOutList, IList destroyGoodsList)
        {
            long maxId = FindMaxId();
            maxId += 1;

            object maxDetailObj = StockOutDetailDAO.SelectSpecificType(null, Projections.Max("StockOutDetailId"));
            long maxDetailId = maxDetailObj != null ? (long)maxDetailObj : 0;
            maxDetailId += 1;

            StockOut destroytSO = new StockOut();
            destroytSO.CreateDate = DateTime.Now;
            destroytSO.CreateId = ClientInfo.getInstance().LoggedUser.Name;
            destroytSO.UpdateDate = DateTime.Now;
            destroytSO.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
            
            destroytSO.StockOutDate = DateTime.Now;
            destroytSO.DefectStatus = new StockDefectStatus { DefectStatusId = 8, DefectStatusName = " Huỷ hàng hư và mất" };

            destroytSO.StockoutId = maxId++;
            destroytSO.ExclusiveKey = 1;
            if (destroyGoodsList.Count > 0)
            {
                foreach (StockOutDetail stockOutDetail in destroyGoodsList)
                {
                    
                    stockOutDetail.GoodQuantity = 0;
                    stockOutDetail.ErrorQuantity = 0;
                    stockOutDetail.CreateDate = DateTime.Now;
                    stockOutDetail.CreateId = ClientInfo.getInstance().LoggedUser.Name;
                    stockOutDetail.UpdateDate = DateTime.Now;
                    stockOutDetail.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                    stockOutDetail.StockOut = destroytSO;
                    stockOutDetail.StockOutId = destroytSO.StockoutId;
                    stockOutDetail.DelFlg = 0;
                    stockOutDetail.ExclusiveKey = 1;
                    stockOutDetail.Description = " Huỷ hàng hư và mất";

                    // update defect
                    // update quantity of stock
                    Stock defect = GetDefectFromStockOut(stockOutDetail, stockList);
                    if (defect == null)
                    {
                        throw new BusinessException("Hàng xuất không tồn tại trong cơ sở dữ liệu, mục hàng lỗi");
                    }
                    defect.LostQuantity -= stockOutDetail.LostQuantity;
                    defect.DamageQuantity -= stockOutDetail.DamageQuantity;
                    defect.Quantity -= stockOutDetail.Quantity;
                    
                    StockDAO.Update(defect);
                }
                destroytSO.StockOutDetails = destroyGoodsList;
                StockOutDAO.Add(destroytSO);

                
                foreach (StockOutDetail detail in destroyGoodsList)
                {
                    detail.StockOutDetailId = maxDetailId++;
                    StockOutDetailDAO.Add(detail);
                }
            }
            // -------------- return to manufacturer ------------
            StockOut returnSO = new StockOut();
            returnSO.CreateDate = DateTime.Now;
            returnSO.CreateId = ClientInfo.getInstance().LoggedUser.Name;
            returnSO.UpdateDate = DateTime.Now;
            returnSO.UpdateId = ClientInfo.getInstance().LoggedUser.Name;

            returnSO.StockOutDate = DateTime.Now;
            returnSO.DefectStatus = new StockDefectStatus { DefectStatusId = 5 };
            returnSO.StockoutId = maxId++;
            returnSO.ExclusiveKey = 1;

            if (returnGoodsList.Count > 0)
            {
                foreach (StockOutDetail stockOutDetail in returnGoodsList)
                {
                    stockOutDetail.Quantity = stockOutDetail.ErrorQuantity;
                    stockOutDetail.GoodQuantity = 0;
                    stockOutDetail.LostQuantity = 0;
                    stockOutDetail.DamageQuantity = 0;
                    stockOutDetail.CreateDate = DateTime.Now;
                    stockOutDetail.CreateId = ClientInfo.getInstance().LoggedUser.Name;
                    stockOutDetail.UpdateDate = DateTime.Now;
                    stockOutDetail.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                    stockOutDetail.StockOut = returnSO;
                    stockOutDetail.StockOutId = returnSO.StockoutId;
                    stockOutDetail.DelFlg = 0;
                    stockOutDetail.ExclusiveKey = 1;
                    stockOutDetail.Description = " Trả hàng cho nhà sản xuất";

                    Stock defect = GetDefectFromStockOut(stockOutDetail, stockList);
                    if (defect == null)
                    {
                        throw new BusinessException("Hàng xuất không tồn tại trong cơ sở dữ liệu, mục hàng lỗi");
                    }
                    defect.ErrorQuantity -= stockOutDetail.ErrorQuantity;
                    defect.Quantity -= stockOutDetail.Quantity;
                    StockDAO.Update(defect);
                }
                returnSO.StockOutDetails = returnGoodsList;
                StockOutDAO.Add(returnSO);

                //maxDetailId += 1;
                foreach (StockOutDetail detail in returnGoodsList)
                {
                    detail.StockOutDetailId = maxDetailId++;
                    StockOutDetailDAO.Add(detail);
                }
            }
            // -------------- temporary stock out
            StockOut tempSO = new StockOut();
            tempSO.CreateDate = DateTime.Now;
            tempSO.CreateId = ClientInfo.getInstance().LoggedUser.Name;
            tempSO.UpdateDate = DateTime.Now;
            tempSO.UpdateId = ClientInfo.getInstance().LoggedUser.Name;

            tempSO.StockOutDate = DateTime.Now;
            tempSO.DefectStatus = new StockDefectStatus { DefectStatusId = 4 };
            tempSO.StockoutId = maxId++;
            tempSO.ExclusiveKey = 1;
            if (tempStockOutList.Count > 0)
            {
                foreach (StockOutDetail stockOutDetail in tempStockOutList)
                {
                    stockOutDetail.Quantity = stockOutDetail.ErrorQuantity;
                    stockOutDetail.GoodQuantity = 0;
                    stockOutDetail.LostQuantity = 0;
                    stockOutDetail.DamageQuantity = 0;
                    stockOutDetail.CreateDate = DateTime.Now;
                    stockOutDetail.CreateId = ClientInfo.getInstance().LoggedUser.Name;
                    stockOutDetail.UpdateDate = DateTime.Now;
                    stockOutDetail.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                    stockOutDetail.StockOut = tempSO;
                    stockOutDetail.StockOutId = tempSO.StockoutId;
                    stockOutDetail.DelFlg = 0;
                    stockOutDetail.ExclusiveKey = 1;
                    stockOutDetail.Description = " Trả hàng cho nhà sản xuất";

                    Stock defect = GetDefectFromStockOut(stockOutDetail, stockList);
                    if (defect == null)
                    {
                        throw new BusinessException("Hàng xuất không tồn tại trong cơ sở dữ liệu, mục hàng lỗi");
                    }
                    /*defect.ErrorQuantity -= stockOutDetail.ErrorQuantity;
                    defect.Quantity -= stockOutDetail.Quantity;
                    StockDAO.Update(defect);*/
                }
                tempSO.StockOutDetails = tempStockOutList;
                StockOutDAO.Add(tempSO);

                //maxDetailId += 1;
                foreach (StockOutDetail detail in tempStockOutList)
                {
                    detail.StockOutDetailId = maxDetailId++;
                    StockOutDetailDAO.Add(detail);
                }
            }
        }

        private Stock GetDefectFromStockOut(StockOutDetail detail, IList list)
        {
            foreach (Stock stockDefect in list)
            {
                if(stockDefect.Product.ProductId == detail.Product.ProductId)
                {
                    return stockDefect;
                }
            }
            return null;
        }

        #endregion
    }
}