using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using AppFrame.DataLayer;
using AppFrame.WPF;
using AppFrame.WPF.Screens;
using Caliburn.Core.Invocation;
using Caliburn.PresentationFramework.Actions;
using Caliburn.PresentationFramework.Filters;
using CoralPOS.Models;
using Microsoft.Practices.ServiceLocation;
using POSServer.BusinessLogic.Common;
using POSServer.BusinessLogic.Implement;
using POSServer.Utils;

namespace POSServer.Actions.Stock.StockOut
{
    public class StockOutPreLoadAction : PosAction,IStockOutPreLoadAction
    {
        public IProductMasterLogic ProductMasterLogic { get; set; }
        public IMainStockLogic MainStockLogic
        {
            get; set;
        }

        public IDepartmentLogic DepartmentLogic
        {
            get; set;
        }

        public override void DoExecute()
        {
            ServiceLocator.Current.GetInstance<ICircularLoadViewModel>().StartLoading();
            DoExecuteCompleted += StockOutPreLoadActionDoExecuteCompleted;
            DoExecuteAsync(() => DoWork(), null);
        }

        void StockOutPreLoadActionDoExecuteCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            ServiceLocator.Current.GetInstance<ICircularLoadViewModel>().StopLoading();
            GoToNextNode();
        }

        private object DoWork()
        {
            IList productMasters = MainStockLogic.FindProductMasterAvailInStock();
            Flow.Session.Put(FlowConstants.PRODUCT_NAMES_LIST, productMasters);
            IList<Department> departments = DepartmentLogic.FindAll(new ObjectCriteria<Department>());
            Flow.Session.Put(FlowConstants.DEPARTMENTS,departments);
            return null;
        }
    }
}