using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using AppFrame.Base;
using AppFrame.CustomAttributes;
using AppFrame.DataLayer;
using AppFrame.Invocation;
using AppFrame.Utils;
using AppFrame.WPF.Screens;
using Caliburn.Micro;
using CoralPOS.Common;
using CoralPOS.Models;
using POSServer.BusinessLogic.Implement;
using POSServer.Common;
using POSServer.ViewModels.Menu;
using ClientUtility = POSServer.Utils.ClientUtility;

namespace POSServer.ViewModels.Synchronize
{
    //[AttachMenuAndMainScreen(typeof(MainMenuViewModel), typeof(MainViewModel))]
    [PerRequest]
    public class CreateSyncUSBViewModel : PosViewModel
    {

        private IList _departments;
        private Department _selectedDepartment;
        [Autowired]
        public IDepartmentLogic DepartmentLogic { get; set; }
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

        public IList Departments
        {
            get { return _departments; }
            set { _departments = value; 
                NotifyOfPropertyChange(()=>Departments);
            }
        }

        public Department SelectedDepartment
        {
            get { return _selectedDepartment; }
            set { _selectedDepartment = value; 
                NotifyOfPropertyChange(()=>SelectedDepartment);
            }
        }

        protected override void OnActivate()
        {
            SelectedDepartment = new Department();
            Departments = new ArrayList();
            ObjectCriteria<Department> criteria = new ObjectCriteria<Department>();
            criteria.Add(t => t.DepartmentId > 0);
            IList<CoralPOS.Models.Department> departments = DepartmentLogic.FindAll(criteria);
            Departments = ObjectConverter.ConvertFrom(departments);
        }

        public void CreateSyncUSB()
        {
            if (SelectedDepartment.DepartmentId <=0) return;
            IoC.Get<INormalLoadViewModel>().StartLoading();
            BackgroundTask backgroundTask = null;
            backgroundTask = new BackgroundTask(() => CreateSyncUSB(SelectedUSB,SelectedDepartment.DepartmentId));
            backgroundTask.Completed += (s, e) => CreateSyncUSBCompleted(s, e);
            backgroundTask.Start(null);
        }

        private object CreateSyncUSB(string selectedUsb,long departmentId)
        {
            if (string.IsNullOrEmpty(selectedUsb)) return null;
            SystemConfig config = SystemConfig.Instance;

            ClientUtility.EnsureSyncPath(selectedUsb + config.SyncExportPath);
            ClientUtility.EnsureSyncPath(selectedUsb + config.SyncImportPath);
            ClientUtility.EnsureSyncPath(selectedUsb + config.SyncSuccessPath);
            ClientUtility.EnsureSyncPath(selectedUsb + config.SyncErrorPath);
            ClientUtility.EnsureSyncPath(selectedUsb + config.SyncBackupPath);
            ClientUtility.CreateDepartmentNotif(selectedUsb,departmentId);
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
