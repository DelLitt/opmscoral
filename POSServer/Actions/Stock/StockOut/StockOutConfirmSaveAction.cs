using System.Collections;
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
    public class StockOutConfirmSaveAction : PosAction,IStockOutConfirmSaveAction
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
            IList stockOuts = Flow.Session.Get(FlowConstants.SAVE_STOCK_OUT) as IList;
            bool confirmFlag = (bool)Flow.Session.Get(FlowConstants.STOCK_OUT_CONFIRM_FLAG);
            IoC.Get<INormalLoadViewModel>().StartLoading();
            DoExecuteCompleted += StockOutSaveActionDoExecuteCompleted;
            DoExecuteAsync(()=>ProcessStockOut(stockOuts,confirmFlag), stockOuts);
        }

        [Transaction]
        object ProcessStockOut(IList stockOuts,bool confirmFlag)
        {
            foreach (CoralPOS.Models.StockOut stockOut in stockOuts)
            {
                if (confirmFlag)
                {
                    MainStockLogic.Update(stockOut);
                    stockOut.ConfirmFlg = 2;
                    StockOutLogic.Update(stockOut);
                }
                else
                    StockOutLogic.Delete(stockOut);
            }
            return null;
        }
        void StockOutSaveActionDoExecuteCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            IoC.Get<INormalLoadViewModel>().StopLoading();
            MessageBox.Show("Processed Stock Out Confirmation  !!");
            GoToNextNode();
        }
    }
}
