using System.Windows;
using AppFrame.Base;
using AppFrame.WPF.Screens;
using Caliburn.Micro;
using POSClient.BusinessLogic.Implement;
using POSClient.Common;

namespace POSClient.Actions.Stock.StockOut
{
    public class DepartmentStockOutSaveAction : PosAction,IDepartmentStockOutSaveAction
    {
        public IProductMasterLogic ProductMasterLogic { get; set; }
        public IProductLogic ProductLogic { get; set; }
        public IExProductColorLogic ProductColorLogic { get; set; }
        public IExProductSizeLogic ProductSizeLogic { get; set; }
        public ICategoryLogic CategoryLogic { get; set; }
        public IProductTypeLogic ProductTypeLogic { get; set; }
        public IDepartmentStockOutLogic DepartmentStockOutLogic { get; set; }

        public override void DoExecute()
        {
            CoralPOS.Models.DepartmentStockOut stockOut = Flow.Session.Get(FlowConstants.SAVE_DEPT_STOCK_OUT) as CoralPOS.Models.DepartmentStockOut;
            IoC.Get<INormalLoadViewModel>().StartLoading();
            DoExecuteCompleted += StockOutSaveActionDoExecuteCompleted;
            DoExecuteAsync(() => DepartmentStockOutLogic.Add(stockOut), stockOut);
        }

        void StockOutSaveActionDoExecuteCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            IoC.Get<INormalLoadViewModel>().StopLoading();
            MessageBox.Show("Saved StockOut successfully !!");
            GoToNextNode();
        }
    }
}
