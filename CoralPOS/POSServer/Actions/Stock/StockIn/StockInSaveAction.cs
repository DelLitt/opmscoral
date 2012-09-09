using System.Windows;
using AppFrame.Base;
using AppFrame.CustomAttributes;
using AppFrame.WPF.Screens;
using Caliburn.Micro;
using POSServer.BusinessLogic.Common;
using POSServer.BusinessLogic.Implement;
using POSServer.Utils;

namespace POSServer.Actions.Stock.StockIn
{
    [PerRequest]
    public class StockInSaveAction : PosAction
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
