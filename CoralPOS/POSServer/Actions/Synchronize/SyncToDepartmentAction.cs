using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using AppFrame.Base;
using AppFrame.Base.Synchronize;
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
            SyncToDepartmentObject toDepartmentObject = Flow.Session.Get(FlowConstants.SYNC_TO_DEPARTMENT) as SyncToDepartmentObject;
            ServiceLocator.Current.GetInstance<INormalLoadViewModel>().StartLoading();
            DoExecuteCompleted += SyncToDepartmentCompleted;
            DoExecuteAsync(() => DoSyncToDepartment(toDepartmentObject), toDepartmentObject);
        }

        private object DoSyncToDepartment(SyncToDepartmentObject toDepartmentObject)
        {
            IList<UsbSyncDisc> departmentUsbList = GetUSBDrives();
            foreach (var departmentUsb in departmentUsbList)
            {

                toDepartmentObject = SyncLogic.SyncToDepartment(toDepartmentObject);    
            }
            return 0;
        }

        private IList<UsbSyncDisc> GetUSBDrives()
        {
            return new List<UsbSyncDisc>();
        }

        private void SyncToDepartmentCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ServiceLocator.Current.GetInstance<INormalLoadViewModel>().StopLoading();
            GoToNextNode();
        }
    }
}
