using System.Collections;
using System.Collections.Generic;
using AppFrame.Base;
using AppFrame.DataLayer;
using AppFrame.WPF.Screens;
using Caliburn.Micro;
using CoralPOS.Models;

using POSClient.BusinessLogic.Implement;
using POSClient.Common;

namespace POSClient.Actions.Stock.StockOut
{
    public class DepartmentStockOutPreLoadAction : PosAction,IDepartmentStockOutPreLoadAction
    {
        public IProductMasterLogic ProductMasterLogic { get; set; }
        public IDepartmentStockLogic DepartmentStockLogic
        {
            get; set;
        }

        public IDepartmentLogic DepartmentLogic
        {
            get; set;
        }

        public override void DoExecute()
        {
            IoC.Get<ICircularLoadViewModel>().StartLoading();
            DoExecuteCompleted += StockOutPreLoadActionDoExecuteCompleted;
            DoExecuteAsync(() => DoWork(), null);
        }

        void StockOutPreLoadActionDoExecuteCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            IoC.Get<ICircularLoadViewModel>().StopLoading();
            GoToNextNode();
        }

        private object DoWork()
        {
            IList productMasters = DepartmentStockLogic.FindProductMasterAvailInStock("");
            //IList productMasters = ProductMasterLogic.LoadAllProductMasterWithType("%%");
            Flow.Session.Put(FlowConstants.PRODUCT_NAMES_LIST, productMasters);
            IList<Department> departments = DepartmentLogic.FindAll(null);
            Flow.Session.Put(FlowConstants.DEPARTMENTS,departments);
            return null;
        }
    }
}