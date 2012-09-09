using System.Windows;
using AppFrame.Base;
using AppFrame.CustomAttributes;
using AppFrame.WPF.Screens;
using Caliburn.Micro;
using CoralPOS.Common;
using POSServer.BusinessLogic.Common;
using POSServer.BusinessLogic.Implement;
using POSServer.Utils;
using Spring.Transaction.Interceptor;

namespace POSServer.Actions.Stock.StockOut
{
    [PerRequest]
    public class StockOutSaveAction : PosAction
    {
        [Autowired]
        public IProductMasterLogic ProductMasterLogic { get; set; }
        [Autowired]
        public IProductLogic ProductLogic { get; set; }
        [Autowired]
        public IExProductColorLogic ProductColorLogic { get; set; }
        [Autowired]
        public IExProductSizeLogic ProductSizeLogic { get; set; }
        [Autowired]
        public ICategoryLogic CategoryLogic { get; set; }
        [Autowired]
        public IProductTypeLogic ProductTypeLogic { get; set; }
        [Autowired]
        public IStockOutLogic StockOutLogic { get; set; }
        [Autowired]
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
