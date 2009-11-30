using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame;
using AppFrame.Common;
using AppFrame.Exceptions;
using AppFrame.Logic;
using AppFrame.Model;
using AppFrame.Presenter;
using AppFrame.View.GoodsIO;

namespace AppFrameClient.Presenter
{
    public class StockInConfirmController : IStockInConfirmController
    {
        #region Implementation of IStockInConfirmController

        private IStockInConfirmView stockInConfirmView; 
        public IStockInConfirmView StockInConfirmView 
        { 
            get
            {
                return stockInConfirmView; 
            }
            set
            {
                stockInConfirmView = value;
                stockInConfirmView.ConfirmStockInEvent += new EventHandler<StockInConfirmEventArgs>(stockInConfirmView_ConfirmStockInEvent);
                stockInConfirmView.LoadStockInEvent += new EventHandler<StockInConfirmEventArgs>(stockInConfirmView_LoadStockInEvent);
                stockInConfirmView.DenyStockInEvent += new EventHandler<StockInConfirmEventArgs>(stockInConfirmView_DenyStockInEvent);
            }
        }

        void stockInConfirmView_DenyStockInEvent(object sender, StockInConfirmEventArgs e)
        {
            try
            {
                ObjectCriteria objectCriteria = new ObjectCriteria();
                objectCriteria.AddSearchInCriteria("StockInId", e.ConfirmStockInList);
                objectCriteria.AddEqCriteria("DelFlg", CommonConstants.DEL_FLG_NO);
                IList stockInList = StockInLogic.FindAll(objectCriteria);

                if (stockInList != null && stockInList.Count > 0)
                {
                    foreach (StockIn stockIn in stockInList)
                    {
                        if (stockIn.ConfirmFlg == 1)
                        {
                            stockIn.ConfirmFlg = 0;
                            stockIn.DelFlg = 1;
                            stockIn.NotUpdateMainStock = true;
                            foreach (StockInDetail inDetail in stockIn.StockInDetails)
                            {
                                inDetail.DelFlg = 1;
                            }
                            StockInLogic.Update(stockIn);
                        }
                    }
                }
                else
                {
                    throw new BusinessException("Khong co gi de luu");
                }
            }
            catch (Exception exception)
            {
                e.EventResult = " Error !";
                e.HasErrors = true;
            }
        }

        void stockInConfirmView_LoadStockInEvent(object sender, StockInConfirmEventArgs e)
        {
            StockIn stockIn = StockInLogic.FindById(e.StockInId);
            if (stockIn != null)
            {
                foreach (StockInDetail inDetail in stockIn.StockInDetails)
                {
                    inDetail.OldQuantity = inDetail.Quantity;
                }
                e.StockIn = stockIn;
            }
        }

        void stockInConfirmView_ConfirmStockInEvent(object sender, StockInConfirmEventArgs e)
        {
            try
            {
                ObjectCriteria objectCriteria = new ObjectCriteria();
                objectCriteria.AddSearchInCriteria("StockInId", e.ConfirmStockInList);
                objectCriteria.AddEqCriteria("DelFlg", CommonConstants.DEL_FLG_NO);
                IList stockInList = StockInLogic.FindAll(objectCriteria);

                if (stockInList != null && stockInList.Count > 0)
                {
                    foreach (StockIn stockIn in stockInList)
                    {
                        if (stockIn.ConfirmFlg == 1)
                        {
                            stockIn.ConfirmFlg = 0;
                            StockInLogic.Update(stockIn);
                        }
                    }
                }
                else
                {
                    throw new BusinessException("Khong co gi de luu");
                }
            }
            catch (Exception exception)
            {
                e.EventResult = " Error !";
                e.HasErrors = true;
            }
        }
        public IStockInLogic StockInLogic { get; set; }
        public IStockInDetailLogic StockInDetailLogic { get; set; }
        public IDepartmentLogic DepartmentLogic { get; set; }
        public IDepartmentPriceLogic DepartmentPriceLogic { get; set; }
        public IStockLogic StockLogic { get; set; }

        #endregion
    }
}
