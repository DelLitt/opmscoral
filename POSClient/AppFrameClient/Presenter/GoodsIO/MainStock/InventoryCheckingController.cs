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
           if(e.SaveStockDefectList!=null && e.SaveStockDefectList.Count > 0)
           {
               long maxId = StockDefectLogic.FindMaxStockDefectId();
               maxId = maxId + 1;
               foreach (StockDefect stockDefect in e.SaveStockDefectList)
               {

                   if (stockDefect.DamageCount == 0 && stockDefect.OldDamageCount == 0
                        && stockDefect.ErrorCount == 0 && stockDefect.OldErrorCount == 0
                        && stockDefect.LostCount == 0 && stockDefect.OldLostCount == 0
                        && stockDefect.UnconfirmCount == 0 && stockDefect.OldUnconfirmCount == 0)
                   {
                       continue;
                   }
                   
                   stockDefect.CreateDate = DateTime.Now;
                   stockDefect.CreateId = ClientInfo.getInstance().LoggedUser.Name;
                   stockDefect.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                   stockDefect.UpdateDate = DateTime.Now;
                   stockDefect.DelFlg = 0;
                   // get stock quantity
                   stockDefect.Quantity = stockDefect.Stock.Quantity;
                   // calculate business

                   // calculate business
                   /*int currDamageCount = stockDefect.DamageCount - stockDefect.OldDamageCount;
                   int currErrorCount = stockDefect.ErrorCount - stockDefect.OldErrorCount;
                   int currUnconfirmCount = stockDefect.UnconfirmCount - stockDefect.OldUnconfirmCount;
                   int currLostCount = stockDefect.LostCount - stockDefect.OldLostCount;*/
                   int currDamageCount = stockDefect.DamageCount ;
                   int currErrorCount = stockDefect.ErrorCount ;
                   int currUnconfirmCount = stockDefect.UnconfirmCount ;
                   int currLostCount = stockDefect.LostCount ;

                   long totalDefects = currDamageCount + currErrorCount + currLostCount + currUnconfirmCount;
                   /*if(stockDefect.Quantity < totalDefects)
                   {
                       throw new BusinessException("Số lượng hàng lỗi,hư,mất... lớn hơn số tồn thực");                       
                   }*/

                   stockDefect.GoodCount = stockDefect.Quantity - totalDefects;
                   
                   // update the stock remains equal good count
                   stockDefect.Stock.Quantity = stockDefect.GoodCount;
                   stockDefect.Quantity = stockDefect.Stock.Quantity;
                   stockDefect.StockDefectId = maxId++;

                   StockDefectLogic.Process(stockDefect);
                   StockLogic.Update(stockDefect.Stock);

                   e.HasErrors = false;
                   
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
            IList stockDefectList = StockDefectLogic.FindAll(objectCriteria);
            if(stockDefectList!=null && stockDefectList.Count > 0)
            {
                e.ScannedStockDefect = (StockDefect)stockDefectList[0];
            }
            else
            {
                e.ScannedStockDefect = null;
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


        public AppFrame.Logic.IStockDefectLogic StockDefectLogic
        {
            get;set;
        }

        #endregion
    }
}
