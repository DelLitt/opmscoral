using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame;
using AppFrame.Common;
using AppFrame.Exceptions;
using AppFrame.Model;
using AppFrame.Presenter.GoodsIO.MainStock;
using AppFrameClient.ViewModel;

namespace AppFrameClient.Presenter.GoodsIO.MainStock
{
    public class InventoryCheckingController : IInventoryCheckingController
    {
        #region IInventoryCheckingController Members
        
        AppFrame.View.GoodsIO.MainStock.IInventoryCheckingView inventoryCheckingView;    
        public AppFrame.View.GoodsIO.MainStock.IInventoryCheckingView InventoryCheckingView
        {
            get
            {
                return inventoryCheckingView;
            }
            set
            {
                inventoryCheckingView = value;
                inventoryCheckingView.FillProductMasterToComboEvent += new EventHandler<InventoryCheckingEventArgs>(inventoryCheckingView_FillProductMasterToComboEvent);
                inventoryCheckingView.LoadGoodsByProductIdEvent += new EventHandler<InventoryCheckingEventArgs>(inventoryCheckingView_LoadGoodsByProductIdEvent);
                inventoryCheckingView.SaveInventoryCheckingEvent += new EventHandler<InventoryCheckingEventArgs>(inventoryCheckingView_SaveInventoryCheckingEvent);
            }
        }

        void inventoryCheckingView_SaveInventoryCheckingEvent(object sender, InventoryCheckingEventArgs e)
        {
           if(e.SaveStockList!=null && e.SaveStockList.Count > 0)
           {
               /*foreach (Stock stock in e.SaveStockList)
               {
                   stock.CreateDate = DateTime.Now;
                   stock.CreateId = ClientInfo.getInstance().LoggedUser.Name;
                   stock.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                   stock.UpdateDate = DateTime.Now;
                   stock.DelFlg = 0;
                   
                   // calculate business
                   StockLogic.Update(stock);

                   e.HasErrors = false;
                   
               }*/
               // ++ AMEND FOR SHOES STOCK CHECKING 19/10/2009
               StockIn stockIn = new StockIn();
               stockIn.NotUpdateMainStock = false;
               stockIn.CreateDate = DateTime.Now;
               stockIn.UpdateDate = DateTime.Now;
               stockIn.StockInDate = DateTime.Now;
               stockIn.CreateId = ClientInfo.getInstance().LoggedUser.Name;
               stockIn.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
               stockIn.DelFlg = 0;
               stockIn.Description = " NHẬP TỪ SỐ LƯỢNG KIỂM KÊ";

               IList stockInDetailList = new ArrayList();
               foreach (Stock stock in e.SaveStockList)
               {
                   StockInDetail inDetail = new StockInDetail();
                   inDetail.CreateDate = DateTime.Now;
                   inDetail.CreateId = ClientInfo.getInstance().LoggedUser.Name;
                   inDetail.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                   inDetail.UpdateDate = DateTime.Now;
                   inDetail.DelFlg = 0;
                   inDetail.Product = stock.Product;
                   inDetail.Quantity = stock.GoodQuantity;
                   inDetail.DelFlg = 0;
                   inDetail.StockIn = stockIn;
                   // calculate business
                   inDetail.StockInDetailPK = new StockInDetailPK
                                                  { 
                                                      ProductId = stock.Product.ProductId
                                                  };
                   stockInDetailList.Add(inDetail);
               }
               stockIn.StockInDetails = stockInDetailList;
               StockInLogic.AddForStockOutToProducer(stockIn);
               e.HasErrors = false;
               // ++ AMEND FOR SHOES STOCK CHECKING 19/10/2009
           }
        }

        void inventoryCheckingView_LoadGoodsByProductIdEvent(object sender, InventoryCheckingEventArgs e)
        {
            ObjectCriteria objectCriteria  = new ObjectCriteria();
            objectCriteria.AddEqCriteria("Product.ProductId", e.InputBarcode);
            objectCriteria.AddEqCriteria("DelFlg", (long)0);
            IList stockList = StockLogic.FindAll(objectCriteria);
            if(stockList != null && stockList.Count > 0)
            {
                e.ScannedStock = (Stock)stockList[0];    
            }
            else
            {
                e.ScannedStock = null;
            }
            IList stockDefectList = StockLogic.FindAll(objectCriteria);
            if(stockDefectList!=null && stockDefectList.Count > 0)
            {
                e.ScannedStock = (Stock)stockDefectList[0];
            }
            else
            {
                e.ScannedStock = null;
            }
        }

        void inventoryCheckingView_FillProductMasterToComboEvent(object sender, InventoryCheckingEventArgs e)
        {
            IList stockList = StockLogic.FindByProductMasterName();
            IList stockViewList = new ArrayList();
            if(stockList!=null)
            {
                foreach (IList list in stockList)
                {
                    StockView stockView = new StockView();
                    stockView.ProductMaster = (ProductMaster) list[0];
                    stockView.StockQuantity = (long) list[1];
                    stockViewList.Add(stockView);
                }
                
            }
            e.ReturnStockViewList = stockViewList;
        }

        public AppFrame.Logic.IStockLogic StockLogic
        {
            get;set;
        }

        public AppFrame.Logic.IProductLogic ProductLogic
        {
            get;set;
        }

        public AppFrame.Logic.IProductMasterLogic ProductMasterLogic
        {
            get;set;
            
        }

        public AppFrame.Logic.IStockInLogic StockInLogic
        {
            get;set;
            
        }

        public AppFrame.Logic.IStockInDetailLogic StockInDetailLogic
        {
            get;set;
            
        }

        #endregion

        #region IInventoryCheckingController Members


        public AppFrame.Logic.IStockOutLogic StockOutLogic
        {
            get;set;
            
        }

        public AppFrame.Logic.IStockOutDetailLogic StockOutDetailLogic
        {
            get;set;
        }

        #endregion

        #region IInventoryCheckingController Members
        

        #endregion
    }
}
