using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using AppFrame.Base;
using AppFrame.CustomAttributes;
using AppFrame.Invocation;
using AppFrame.WPF.Screens;
using Caliburn.Micro;
using CoralPOS.Common;
using POSServer.Common;
using POSServer.Utils;
using POSServer.ViewModels.Menu;

namespace POSServer.ViewModels.Synchronize
{
    [AttachMenuAndMainScreen(typeof(IMainMenuViewModel), typeof(IMainViewModel))]
    public class CreateSyncUSBViewModel : PosViewModel, ICreateSyncUSBViewModel
    {

        private IList _usbList;
        public IList USBList
        {
            get { return _usbList; }
            set { 
                _usbList = value;
                NotifyOfPropertyChange(()=>USBList);
            }
        }

        private string _selectedUSB;
        public string SelectedUSB
        {
            get { return _selectedUSB; }
            set { _selectedUSB = value;
                NotifyOfPropertyChange(()=>SelectedUSB);
            }
        }

        public void CreateSyncUSB()
        {
            IoC.Get<INormalLoadViewModel>().StartLoading();
            BackgroundTask _backgroundTask = null;
            _backgroundTask = new BackgroundTask(() => CreateSyncUSB(SelectedUSB));
            _backgroundTask.Completed += (s, e) => CreateSyncUSBCompleted(s, e);
            _backgroundTask.Start(null);
        }

        private object CreateSyncUSB(string selectedUsb)
        {
            if (string.IsNullOrEmpty(selectedUsb)) return null;
            SystemConfig config = SystemConfig.Instance;

            ClientUtility.EnsureSyncPath(selectedUsb + config.SyncExportPath);
            ClientUtility.EnsureSyncPath(selectedUsb + config.SyncImportPath);
            ClientUtility.EnsureSyncPath(selectedUsb + config.SyncSuccessPath);
            ClientUtility.EnsureSyncPath(selectedUsb + config.SyncErrorPath);
            ClientUtility.EnsureSyncPath(selectedUsb + config.SyncBackupPath);
            return null;
        }

        private void CreateSyncUSBCompleted(object sender, RunWorkerCompletedEventArgs runWorkerCompletedEventArgs)
        {
            IoC.Get<INormalLoadViewModel>().StopLoading();
        }

        public void Quit()
        {
            Flow.End();
        }

        protected override void OnInitialize()
        {
            IList departmentUsbList = ClientUtility.GetUSBDrives();
            USBList = departmentUsbList;
        }
    }
}
