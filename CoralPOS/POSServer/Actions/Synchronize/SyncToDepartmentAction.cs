using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using AppFrame.Base;
using AppFrame.WPF.Screens;
using Microsoft.Practices.ServiceLocation;
using POSServer.Actions.Stock.StockOut;
using POSServer.BusinessLogic.Common;
using POSServer.BusinessLogic.Implement;

namespace POSServer.Actions.Synchronize
{
    public class SyncToDepartmentAction : PosAction, ISyncToDepartmentAction
    {
        public ISyncLogic SyncLogic { get; set; }
        public void SyncToDepartment(SyncToDepartmentObject syncToDepartmentObject)
        {
            SyncToDepartmentObject stockOut = Flow.Session.Get(FlowConstants.SYNC_TO_DEPARTMENT) as SyncToDepartmentObject;
            ServiceLocator.Current.GetInstance<INormalLoadViewModel>().StartLoading();
            DoExecuteCompleted += SyncToDepartmentCompleted;
            DoExecuteAsync(() => SyncLogic.SyncToDepartment(stockOut), stockOut);
        }

        private void SyncToDepartmentCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ServiceLocator.Current.GetInstance<INormalLoadViewModel>().StopLoading();
            GoToNextNode();
        }
    }
}
