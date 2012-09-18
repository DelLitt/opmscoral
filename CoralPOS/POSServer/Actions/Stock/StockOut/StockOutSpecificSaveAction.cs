using System.Windows;
using AppFrame.Base;
using AppFrame.Common;
using AppFrame.CustomAttributes;
using AppFrame.WPF.Screens;
using Caliburn.Micro;
using CoralPOS.Common;
using POSServer.BusinessLogic.Common;
using POSServer.BusinessLogic.Implement;
using POSServer.Common;
using POSServer.Utils;

namespace POSServer.Actions.Stock.StockOut
{
    [PerRequest]
    public class StockOutSpecificSaveAction : DefaultPosAction
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
            StartAsyncWork();
        }

        public override object Working()
        {
            CoralPOS.Models.StockOut stockOut = Flow.Session.Get(FlowConstants.SAVE_STOCK_OUT) as CoralPOS.Models.StockOut;
            StockOutLogic.Add(stockOut);
            if (stockOut.ConfirmFlg == 0 && !SystemConfig.Instance.StockOutConfirm)
            {
                MainStockLogic.Update(stockOut);
            }
            return stockOut;
        }

        public override void AfterWorkCompleted()
        {
            MessageBox.Show("Saved StockOut successfully !!");
            GoToNextNode();
        }
    }
}
