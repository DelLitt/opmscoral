using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Logic;
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
                
            }
        }
        public IStockInLogic StockInLogic { get; set; }
        public IStockInDetailLogic StockInDetailLogic { get; set; }
        public IDepartmentLogic DepartmentLogic { get; set; }
        public IDepartmentPriceLogic DepartmentPriceLogic { get; set; }
        public IStockOutLogic StockOutLogic { get; set; }
        public IStockOutDetailLogic StockOutDetailLogic { get; set; }
        public IStockLogic StockLogic { get; set; }

        #endregion
    }
}
