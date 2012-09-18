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
    public class StockInSaveAction : DefaultPosAction
    {
        [Autowired]
        public IStockInLogic StockInLogic { get; set; }

        public override void DoExecute()
        {
            StartAsyncWork();
        }

        public override object Working()
        {
            CoralPOS.Models.StockIn stockIn = (CoralPOS.Models.StockIn)Flow.Session.Get(FlowConstants.SAVE_STOCK_IN);
            return StockInLogic.Add(stockIn);
        }
        public override void AfterWorkCompleted()
        {
            GoToNextNode();
        }
    }
}
