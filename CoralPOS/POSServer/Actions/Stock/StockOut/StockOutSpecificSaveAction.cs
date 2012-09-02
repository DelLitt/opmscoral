using System.Windows;
using AppFrame.Base;
using AppFrame.Common;
using AppFrame.WPF.Screens;
using Caliburn.Micro;
using CoralPOS.Common;
using POSServer.BusinessLogic.Common;
using POSServer.BusinessLogic.Implement;
using POSServer.Common;
using POSServer.Utils;

namespace POSServer.Actions.Stock.StockOut
{
    public class StockOutSpecificSaveAction : PosAction
    {
        public IProductMasterLogic ProductMasterLogic { get; set; }
        public IProductLogic ProductLogic { get; set; }
        public IExProductColorLogic ProductColorLogic { get; set; }
        public IExProductSizeLogic ProductSizeLogic { get; set; }
        public ICategoryLogic CategoryLogic { get; set; }
        public IProductTypeLogic ProductTypeLogic { get; set; }
        public IStockOutLogic StockOutLogic { get; set; }
        public IMainStockLogic MainStockLogic { get; set; }

        public override void DoExecute()
        {
            CoralPOS.Models.StockOut stockOut = Flow.Session.Get(FlowConstants.SAVE_STOCK_OUT) as CoralPOS.Models.StockOut;
            
            IoC.Get<INormalLoadViewModel>().StartLoading();
            DoExecuteCompleted += StockOutSaveActionDoExecuteCompleted;
            DoExecuteAsync(() => DoStockOut(stockOut), stockOut);
        }

        private object DoStockOut(CoralPOS.Models.StockOut stockOut)
        {
            StockOutLogic.Add(stockOut);
            if (stockOut.ConfirmFlg == 0 && !SystemConfig.Instance.StockOutConfirm)
            {
                MainStockLogic.Update(stockOut);
            }
            return stockOut;
        }

        void StockOutSaveActionDoExecuteCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            IoC.Get<INormalLoadViewModel>().StopLoading();
            MessageBox.Show("Saved StockOut successfully !!");
            GoToNextNode();
        }
    }
}
