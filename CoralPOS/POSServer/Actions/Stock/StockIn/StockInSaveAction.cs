using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using AppFrame.Base;
using AppFrame.Utils;
using AppFrame.WPF.Screens;
using Caliburn.PresentationFramework.Actions;
using POSServer.BusinessLogic.Common;
using POSServer.BusinessLogic.Implement;

namespace POSServer.Actions.Stock.StockIn
{
    public class StockInSaveAction : PosAction,IStockInSaveAction
    {
        public IProductMasterLogic ProductMasterLogic { get; set; }
        public IProductLogic ProductLogic { get; set; }
        public IExProductColorLogic ProductColorLogic { get; set; }
        public IExProductSizeLogic ProductSizeLogic { get; set; }
        public ICategoryLogic CategoryLogic { get; set; }
        public IProductTypeLogic ProductTypeLogic { get; set; }
        public IStockInLogic StockInLogic { get; set; }

        private ILoadViewModel _loadViewModel;

        [AsyncAction(BlockInteraction = false)]
        public override void DoExecute()
        {
            _loadViewModel = Flow.Navigator.ServiceLocator.GetInstance<ILoadViewModel>("ILoadViewModel");
            _loadViewModel.StartLoading();
            CoralPOS.Models.StockIn stockIn = Flow.Session.Get(FlowConstants.SAVE_STOCK_IN) as CoralPOS.Models.StockIn;
            stockIn = StockInLogic.Add(stockIn);
            if(!string.IsNullOrEmpty(stockIn.StockInId))
            {
                if (_loadViewModel != null) _loadViewModel.StopLoading();
                MessageBox.Show("Saved StockIn with id = " + stockIn.StockInId); 
            }
            GoToNextNode();
        }
    }
}
