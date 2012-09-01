using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows;
using AppFrame.Base;
using AppFrame.Base.Synchronize;
using AppFrame.WPF.Screens;
using Caliburn.Micro;
using CoralPOS.Models;
using POSServer.BusinessLogic.Common;
using POSServer.BusinessLogic.Implement;
using POSServer.Common;
using POSServer.Utils;
using ClientUtility = POSServer.Utils.ClientUtility;

namespace POSServer.Actions.Synchronize
{
    public class SyncToDepartmentAction : PosAction, ISyncToDepartmentAction
    {
        public ISyncLogic SyncLogic { get; set; }
        private IList resultList = null;

        public override void DoExecute()
        {
            SyncToDepartmentObject toDepartmentObject = Flow.Session.Get(FlowConstants.SYNC_TO_DEPARTMENT) as SyncToDepartmentObject;

            IoC.Get<INormalLoadViewModel>().StartLoading();
            DoExecuteCompleted += SyncToDepartmentCompleted;
            DoExecuteAsync(() => SyncToDepartment(toDepartmentObject), toDepartmentObject);
            GoToNextNode();
        }
               
        
        public object SyncToDepartment(SyncToDepartmentObject toDepartmentObject)
        {
            IList departmentUsbList = ClientUtility.GetUSBDrives();
            foreach (var POSSyncDrive in departmentUsbList)
            {

                //var exportPath = (string)configurationAppSettings.GetValue("SyncExportPath", typeof(String));
                var configExportPath = POSSyncDrive + ClientSetting.SyncExportPath;
                if (string.IsNullOrEmpty(configExportPath) || !Directory.Exists(configExportPath))
                {
                    MessageBox.Show("Không thể tìm thấy đường dẫn đến thư mục " + configExportPath + "!Hãy kiễm tra file cấu hình phần SyncExportPath");
                    return -1;
                }
                resultList = new ArrayList();

                //toDepartmentObject = SyncLogic.SyncToDepartment(toDepartmentObject);
                Department department = toDepartmentObject.Department;
                    var exportPath = ClientUtility.EnsureSyncPath(configExportPath, department);
                    int countSyncFile = 1;

                SyncLogic.SyncToDepartment(exportPath, toDepartmentObject);
                
                MessageBox.Show("Đồng bộ hoàn tất !");
            }
            return 0;
        }

        private IList<UsbSyncDisc> GetUSBDrives()
        {
            return new List<UsbSyncDisc>();
        }

        private void SyncToDepartmentCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            IoC.Get<INormalLoadViewModel>().StopLoading();
            GoToNextNode();
        }
    }
}
