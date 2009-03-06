using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame;
using AppFrame.Common;
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
           if(e.SaveStockDefectList!=null && e.SaveStockDefectList.Count > 0)
           {
               foreach (StockDefect stockDefect in e.SaveStockDefectList)
               {
                   StockOut stockOut = new StockOut();
                   stockOut.CreateDate = DateTime.Now;
                   stockOut.CreateId = ClientInfo.getInstance().LoggedUser.Name;
                   stockOut.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                   stockOut.UpdateDate = DateTime.Now;
                   stockOut.DelFlg = 0;
                   stockOut.StockOutDate = DateTime.Now;
                   IList stockOutDetails = new ArrayList();
                   if(stockDefect.ErrorCount > 0)
                   {
                       StockOutDetail stockOutDetail = new StockOutDetail();
                       //StockOutDetailPK stockOutDetailPK = new StockOutDetailPK{ ProductId = stockDefect.Product.ProductId};

                       //stockOutDetail.StockOutDetailPK = stockOutDetailPK;
                       stockOutDetail.CreateDate = DateTime.Now;
                       stockOutDetail.CreateId = ClientInfo.getInstance().LoggedUser.Name;
                       stockOutDetail.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                       stockOutDetail.UpdateDate = DateTime.Now;

                       stockOutDetail.DelFlg = 0;
                       stockOutDetail.Product = stockDefect.Product;
                       stockOutDetail.Quantity = stockDefect.ErrorCount;
                       stockOutDetail.ProductId = stockDefect.Product.ProductId;

                       stockOutDetails.Add(stockOutDetail);
                   }

                   if (stockDefect.DamageCount > 0)
                   {
                       StockOutDetail stockOutDetail = new StockOutDetail();
                       //StockOutDetailPK stockOutDetailPK = new StockOutDetailPK { ProductId = stockDefect.Product.ProductId };

                       //stockOutDetail.StockOutDetailPK = stockOutDetailPK;
                       stockOutDetail.CreateDate = DateTime.Now;
                       stockOutDetail.CreateId = ClientInfo.getInstance().LoggedUser.Name;
                       stockOutDetail.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                       stockOutDetail.UpdateDate = DateTime.Now;

                       stockOutDetail.DelFlg = 0;
                       stockOutDetail.Product = stockDefect.Product;
                       stockOutDetail.Quantity = stockDefect.DamageCount;
                       stockOutDetail.ProductId = stockDefect.Product.ProductId;
                       

                       stockOutDetails.Add(stockOutDetail);
                   }

                   if (stockDefect.LostCount > 0)
                   {
                       StockOutDetail stockOutDetail = new StockOutDetail();
                       //StockOutDetailPK stockOutDetailPK = new StockOutDetailPK { ProductId = stockDefect.Product.ProductId };

                       //stockOutDetail.StockOutDetailPK = stockOutDetailPK;
                       stockOutDetail.CreateDate = DateTime.Now;
                       stockOutDetail.CreateId = ClientInfo.getInstance().LoggedUser.Name;
                       stockOutDetail.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                       stockOutDetail.UpdateDate = DateTime.Now;

                       stockOutDetail.DelFlg = 0;
                       stockOutDetail.Product = stockDefect.Product;
                       stockOutDetail.Quantity = stockDefect.LostCount;
                       stockOutDetail.ProductId = stockDefect.Product.ProductId;

                       stockOutDetails.Add(stockOutDetail);
                   }
                   // TODO : Save to database
               }
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
    }
}
