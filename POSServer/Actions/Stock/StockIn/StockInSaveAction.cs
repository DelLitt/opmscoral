using System.Windows;
using AppFrame.Base;
using AppFrame.WPF.Screens;
using Caliburn.Micro;
using POSServer.BusinessLogic.Common;
using POSServer.BusinessLogic.Implement;
using POSServer.Utils;

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

        public override void DoExecute()
        {
            CoralPOS.Models.StockIn stockIn = (CoralPOS.Models.StockIn)Flow.Session.Get(FlowConstants.SAVE_STOCK_IN);
            IoC.Get<INormalLoadViewModel>().StartLoading();
            DoExecuteCompleted += StockInSaveActionDoExecuteCompleted;
            DoExecuteAsync(() => StockInLogic.Add(stockIn), stockIn);
        }

        void StockInSaveActionDoExecuteCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            IoC.Get<INormalLoadViewModel>().StopLoading();
            MessageBox.Show("Saved StockIn successfully !!");
            GoToNextNode();
        }
    }
}
