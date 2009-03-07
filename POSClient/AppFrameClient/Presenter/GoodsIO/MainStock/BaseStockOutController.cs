using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppFrame;
using AppFrame.Common;
using AppFrame.Model;
using AppFrame.Presenter.GoodsIO.MainStock;
using AppFrameClient.ViewModel;

namespace AppFrameClient.Presenter.GoodsIO.MainStock
{
    public class BaseStockOutController : IBaseStockOutController
    {
        #region IBaseStockOutController Members

        private AppFrame.View.GoodsIO.MainStock.IBaseStockOutView baseStockOutView;
        public AppFrame.View.GoodsIO.MainStock.IBaseStockOutView BaseStockOutView
        {
            get
            {
                return baseStockOutView;
            }
            set
            {
                baseStockOutView = value;
                baseStockOutView.FillGoodsToCombo += new EventHandler<BaseStockOutEventArgs>(baseStockOutView_FillGoodsToCombo);
                baseStockOutView.LoadGoodsByNameEvent += new EventHandler<BaseStockOutEventArgs>(baseStockOutView_LoadGoodsByNameEvent);
                baseStockOutView.SaveTempStockOut += new EventHandler<BaseStockOutEventArgs>(baseStockOutView_SaveTempStockOut);
            }
        }

        void baseStockOutView_SaveTempStockOut(object sender, BaseStockOutEventArgs e)
        {
            StockOut stockOut = new StockOut();
            stockOut.CreateDate = DateTime.Now;
            stockOut.CreateId = ClientInfo.getInstance().LoggedUser.Name;
            stockOut.UpdateDate = DateTime.Now;
            stockOut.UpdateId = ClientInfo.getInstance().LoggedUser.Name;

            stockOut.DelFlg = 0;
            stockOut.StockOutDate = DateTime.Now;
            stockOut.StockOutDetails = e.SaveStockOutList;
            long maxStockOutId = StockOutLogic.FindMaxId();
            maxStockOutId = maxStockOutId + 1;
            
            stockOut.StockoutId = maxStockOutId;
            StockOutLogic.Add(stockOut);

            long maxStockOutDetailId = StockOutDetailLogic.FindMaxId();
            maxStockOutDetailId  = maxStockOutDetailId +1;
            foreach (StockOutDetail stockOutDetail in e.SaveStockOutList)
            {
                // check number
                ObjectCriteria objectCriteria = new ObjectCriteria();
                objectCriteria.AddEqCriteria("Product.ProductId", stockOutDetail.Product.ProductId);
                IList stockedOutList = StockOutDetailLogic.FindAll(objectCriteria);
                long quantity = CalculateQuantitiesWhichStockedOut(stockedOutList);
                long errorCount = GetErrorCount(stockOutDetail.Product.ProductId, e.SaveStockDefectList);
                if(stockOutDetail.Quantity > errorCount - quantity)
                {
                    MessageBox.Show("Số lượng hàng lỗi không đủ để xuất. Số lượng lỗi hiện có là " +
                                    errorCount.ToString() + ", số lượng đã xuất là " + quantity.ToString());
                    return;
                }

                stockOutDetail.StockOut = stockOut;
                stockOutDetail.StockOutDetailId = maxStockOutDetailId++;
                stockOutDetail.StockOutId = stockOut.StockoutId;
                StockOutDetailLogic.Add(stockOutDetail);
            }
        }

        private long GetErrorCount(string id, IList list)
        {
            foreach (StockDefect stockDefect in list)
            {
                if(stockDefect.Product.ProductId == id)
                {
                    return stockDefect.ErrorCount;
                }
            }
            return 0;
        }

        private long CalculateQuantitiesWhichStockedOut(IList list)
        {
            long result = 0;
            if(list ==null)
            {
                return 0;
            }
            foreach (StockOutDetail detail in list)
            {
                result += detail.Quantity;
            }
            return result;
        }

        void baseStockOutView_LoadGoodsByNameEvent(object sender, BaseStockOutEventArgs e)
        {
             IList stockDefectList = StockDefectLogic.FindByProductMasterName(e.RequestProductMaster);
            e.ReturnStockDefectList = stockDefectList;
        }

        void baseStockOutView_FillGoodsToCombo(object sender, BaseStockOutEventArgs e)
        {
            IList stockList = StockDefectLogic.FindAllProductMasters();
            IList stockViewList = new ArrayList();
            if (stockList != null)
            {
                foreach (IList list in stockList)
                {
                    StockView stockView = new StockView();
                    stockView.ProductMaster = (ProductMaster)list[0];
                    stockView.StockQuantity = (long)list[1];
                    stockViewList.Add(stockView);
                }

            }
            e.ReturnStockViewList = stockViewList;
        }

        public AppFrame.Logic.IStockDefectLogic StockDefectLogic
        {
            get;set;
            
        }

        public AppFrame.Logic.IProductLogic ProductLogic
        {
            get;set;
            
        }

        public AppFrame.Logic.IStockLogic StockLogic
        {
            get;set;
            
        }

        public AppFrame.Logic.IStockOutLogic StockOutLogic
        {
            get;set;
            
        }

        public AppFrame.Logic.IStockOutDetailLogic StockOutDetailLogic
        {
            get;set;
            
        }

        public AppFrame.Logic.IProductMasterLogic ProductMasterLogic
        {
            get;set;
        }

        #endregion

        #region IBaseStockOutController Members


        public AppFrame.Logic.IDepartmentStockDefectLogic DepartmentStockDefectLogic
        {
            get;set;
        }

        #endregion
    }
}
