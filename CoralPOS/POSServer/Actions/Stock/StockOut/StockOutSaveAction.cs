using System.Windows;
using AppFrame.Base;
using AppFrame.WPF.Screens;
using Caliburn.Micro;
using CoralPOS.Common;
using POSServer.BusinessLogic.Common;
using POSServer.BusinessLogic.Implement;
using POSServer.Utils;
using Spring.Transaction.Interceptor;

namespace POSServer.Actions.Stock.StockOut
{
    public class StockOutSaveAction : PosAction
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
            DoExecuteAsync(()=>ProcessStockOut(stockOut), stockOut);
        }

        [Transaction]
        object ProcessStockOut(CoralPOS.Models.StockOut stockOut)
        {
            StockOutLogic.Add(stockOut);
            // if does not confirm when stock out so we update main stock immediately
            if(stockOut.ConfirmFlg == 0 && !SystemConfig.Instance.StockOutConfirm)
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
