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

                baseStockOutView.LoadDeptGoodsByNameEvent += new EventHandler<BaseStockOutEventArgs>(baseStockOutView_LoadDeptGoodsByNameEvent);
                baseStockOutView.FillDeptGoodsToCombo += new EventHandler<BaseStockOutEventArgs>(baseStockOutView_FillDeptGoodsToCombo);
                baseStockOutView.SaveDeptTempStockOut += new EventHandler<BaseStockOutEventArgs>(baseStockOutView_SaveDeptTempStockOut);
            }
        }

        void baseStockOutView_SaveDeptTempStockOut(object sender, BaseStockOutEventArgs e)
        {
            /*DepartmentStockOut stockOut = new DepartmentStockOut();
            stockOut.CreateDate = DateTime.Now;
            stockOut.CreateId = ClientInfo.getInstance().LoggedUser.Name;
            stockOut.UpdateDate = DateTime.Now;
            stockOut.UpdateId = ClientInfo.getInstance().LoggedUser.Name;

            stockOut.DelFlg = 0;
            stockOut.StockOutDate = DateTime.Now;
            stockOut.DepartmentStockOutDetails = e.SaveDeptStockOutList;
            stockOut.DefectStatus = new StockDefectStatus{DefectStatusId = 6};

            long maxStockOutId = DepartmentStockOutLogic.FindMaxId();
            maxStockOutId = maxStockOutId + 1;

            stockOut.DepartmentStockOutPK = new DepartmentStockOutPK
                                                {
                                                    DepartmentId = CurrentDepartment.Get().DepartmentId,
                                                    StockOutId = maxStockOutId
                                                };
            DepartmentStockOutLogic.Add(stockOut);

            //long maxStockOutDetailId = DepartmentStockOutDetailLogic.FindMaxId();
            //maxStockOutDetailId = maxStockOutDetailId + 1;
            foreach (DepartmentStockOutDetail stockOutDetail in e.SaveDeptStockOutList)
            {
                // check number
                ObjectCriteria objectCriteria = new ObjectCriteria();
                objectCriteria.AddEqCriteria("Product.ProductId", stockOutDetail.Product.ProductId)
                              .AddEqCriteria("DepartmentStockOutDetailPK.DepartmentId",
                                   stockOutDetail.DepartmentStockOutDetailPK.DepartmentId);                  
                IList stockedOutList = DepartmentStockOutDetailLogic.FindAll(objectCriteria);
                
                long quantity = CalculateDeptQuantitiesWhichStockedOut(stockedOutList);
                long errorCount = GetDeptErrorCount(stockOutDetail.Product.ProductId, e.SaveDeptStockDefectList);
                
                if (stockOutDetail.Quantity > errorCount - quantity)
                {
                    MessageBox.Show("Số lượng hàng lỗi không đủ để xuất. Số lượng lỗi hiện có là " +
                                    errorCount.ToString() + ", số lượng đã xuất là " + quantity.ToString());
                    return;
                }
                if (stockOutDetail.Description == null)
                    stockOutDetail.Description = "";
                stockOutDetail.DepartmentStockOut = stockOut;
                stockOutDetail.ProductMaster = stockOutDetail.Product.ProductMaster;
                stockOutDetail.ExclusiveKey = 1;
                stockOutDetail.StockOutId = stockOut.StockOutId;
                stockOutDetail.DepartmentStockOutDetailPK.StockOutId = stockOut.DepartmentStockOutPK.StockOutId;
                
                DepartmentStockOutDetailLogic.Add(stockOutDetail);
            }*/
        }

        private long GetDeptErrorCount(string id, IList list)
        {
            foreach (DepartmentStockHistory stockDefect in list)
            {
                if (stockDefect.Product.ProductId == id)
                {
                    return stockDefect.ErrorCount;
                }
            }
            return 0;
        }

        private long CalculateDeptQuantitiesWhichStockedOut(IList list)
        {
            long result = 0;
            if (list == null)
            {
                return 0;
            }
            foreach (DepartmentStockOutDetail detail in list)
            {
                result += detail.Quantity;
            }
            return result;
        }

        void baseStockOutView_FillDeptGoodsToCombo(object sender, BaseStockOutEventArgs e)
        {
            IList stockList = DepartmentStockDefectLogic.FindAllProductMasters();
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

        void baseStockOutView_LoadDeptGoodsByNameEvent(object sender, BaseStockOutEventArgs e)
        {
            IList stockDefectList = DepartmentStockDefectLogic.FindByProductMasterName(e.RequestProductMaster);
            e.ReturnDeptStockDefectList = stockDefectList;
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
            foreach (Stock stockDefect in list)
            {
                if(stockDefect.Product.ProductId == id)
                {
                    return stockDefect.ErrorQuantity;
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
             IList stockDefectList = StockLogic.FindByProductMasterName(e.RequestProductMaster);
            e.ReturnStockDefectList = stockDefectList;
        }

        void baseStockOutView_FillGoodsToCombo(object sender, BaseStockOutEventArgs e)
        {
            IList stockList = StockLogic.FindAllProductMasters();
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

        #region IBaseStockOutController Members


        public AppFrame.Logic.IDepartmentStockOutLogic DepartmentStockOutLogic
        {
            get;set;
        }

        public AppFrame.Logic.IDepartmentStockOutDetailLogic DepartmentStockOutDetailLogic
        {
            get;set;
        }

        #endregion
    }
}
