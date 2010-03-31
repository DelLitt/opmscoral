using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using AppFrame.Base;
using AppFrame.Utils;
using AppFrame.WPF.Screens;
using Caliburn.PresentationFramework.Actions;
using Caliburn.PresentationFramework.Invocation;
using Microsoft.Practices.ServiceLocation;
using POSServer.BusinessLogic.Common;
using POSServer.BusinessLogic.Implement;
using POSServer.Utils;

namespace POSServer.Actions.Stock.StockOut
{
    public class StockOutSaveAction : PosAction,IStockOutSaveAction
    {
        public IProductMasterLogic ProductMasterLogic { get; set; }
        public IProductLogic ProductLogic { get; set; }
        public IExProductColorLogic ProductColorLogic { get; set; }
        public IExProductSizeLogic ProductSizeLogic { get; set; }
        public ICategoryLogic CategoryLogic { get; set; }
        public IProductTypeLogic ProductTypeLogic { get; set; }
        public IStockOutLogic StockOutLogic { get; set; }

        public override void DoExecute()
        {
            CoralPOS.Models.StockOut stockIn = Flow.Session.Get(FlowConstants.SAVE_STOCK_OUT) as CoralPOS.Models.StockOut;
            ServiceLocator.Current.GetInstance<INormalLoadViewModel>().StartLoading();
            DoExecuteCompleted += StockOutSaveActionDoExecuteCompleted;
            DoExecuteAsync(() => StockOutLogic.Add(stockIn), stockIn);
        }

        void StockOutSaveActionDoExecuteCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            ServiceLocator.Current.GetInstance<INormalLoadViewModel>().StopLoading();
            MessageBox.Show("Saved StockOut successfully !!");
            GoToNextNode();
        }
    }
}
