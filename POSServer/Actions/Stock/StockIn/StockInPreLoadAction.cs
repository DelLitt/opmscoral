using System.Collections;
using AppFrame.Base;
using AppFrame.WPF.Screens;
using Caliburn.Micro;
using POSServer.BusinessLogic.Common;
using POSServer.BusinessLogic.Implement;
using POSServer.Utils;


namespace POSServer.Actions.Stock.StockIn
{
    public class StockInPreLoadAction : PosAction,IStockInPreLoadAction
    {
        public IProductMasterLogic ProductMasterLogic { get; set; }
        
        public override void DoExecute()
        {
            IoC.Get<ICircularLoadViewModel>().StartLoading();
            DoExecuteCompleted += StockInPreLoadAction_DoExecuteCompleted;
            DoExecuteAsync(DoWork, null);
        }

        void StockInPreLoadAction_DoExecuteCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            IoC.Get<ICircularLoadViewModel>().StopLoading();
            GoToNextNode();
        }

        private object DoWork()
        {
            IList productMasters = ProductMasterLogic.LoadAllProductMasterWithType("%%");
            Flow.Session.Put(FlowConstants.PRODUCT_NAMES_LIST, productMasters);
            return null;
        }
    }
}