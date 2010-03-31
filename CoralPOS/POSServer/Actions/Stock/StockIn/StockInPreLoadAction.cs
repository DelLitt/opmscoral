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
using Microsoft.Practices.ServiceLocation;
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
            ServiceLocator.Current.GetInstance<ICircularLoadViewModel>().StartLoading();
            DoExecuteCompleted += StockInPreLoadAction_DoExecuteCompleted;
            DoExecuteAsync(() => DoWork(), null);
        }

        void StockInPreLoadAction_DoExecuteCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            ServiceLocator.Current.GetInstance<ICircularLoadViewModel>().StopLoading();
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