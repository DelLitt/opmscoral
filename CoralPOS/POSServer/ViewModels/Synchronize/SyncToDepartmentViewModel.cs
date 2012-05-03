using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows;
using AppFrame.Base;
using AppFrame.Base.Synchronize;
using AppFrame.CustomAttributes;
using AppFrame.DataLayer;
using AppFrame.Invocation;
using AppFrame.WPF.Screens;
using Caliburn.Micro;
using CoralPOS.Common;
using CoralPOS.Models;
using POSServer.BusinessLogic.Implement;
using POSServer.Common;
using POSServer.Utils;
using POSServer.ViewModels.Menu;


namespace POSServer.ViewModels.Synchronize
{
	[AttachMenuAndMainScreen(typeof(IMainMenuViewModel), typeof(IMainViewModel))]
	public class SyncToDepartmentViewModel : PosViewModel,ISyncToDepartmentViewModel  
	{

		private IShellViewModel _startViewModel;
		private IList<Department> _departments;

		private Department _selectedDepartment;

		private bool _departmentInfo;

		private bool _productMasterInfo;

		private bool _priceInfo;

		private IList _resultInfoList;

		public SyncToDepartmentViewModel()
		{
			_startViewModel = ShellViewModel.Current;
		}
		
		#region Fields
				#endregion
		
		#region List use to fetch object for view
				
		private IList _comboBox1;
		public IList comboBox1
		{
			get
			{
				return _comboBox1;
			}
			set
			{
				_comboBox1 = value;
				NotifyOfPropertyChange(() => comboBox1);
			}
		}
				#endregion
		
		#region List which just using in Data Grid
				
		private IList _resultGrid;
		public IList ResultGrid
		{
			get
			{
				return _resultGrid;
			}
			set
			{
				_resultGrid = value;
				NotifyOfPropertyChange(() => ResultGrid);
			}
		}
				#endregion
		
		#region Methods

		public IList<Department> Departments
		{
			get { return _departments; }
			set { _departments = value; NotifyOfPropertyChange(()=>Departments);}
		}

		public Department SelectedDepartment
		{
			get { return _selectedDepartment; }
			set { _selectedDepartment = value; NotifyOfPropertyChange(() => SelectedDepartment); }
		}

		public bool DepartmentInfo
		{
			get { return _departmentInfo; }
			set { _departmentInfo = value; NotifyOfPropertyChange(() => DepartmentInfo); }
		}

		public bool ProductMasterInfo
		{
			get { return _productMasterInfo; }
			set { _productMasterInfo = value; NotifyOfPropertyChange(() => ProductMasterInfo); }
		}

		public bool PriceInfo
		{
			get { return _priceInfo; }
			set { _priceInfo = value; NotifyOfPropertyChange(() => PriceInfo); }
		}

		public IList ResultInfoList
		{
			get { return _resultInfoList; }
			set { _resultInfoList = value; NotifyOfPropertyChange(() => ResultInfoList); }
		}

		public IDepartmentLogic DepartmentLogic
		{
			get; set;
		}

		public SyncLogic SyncLogic
		{
			get; set;
		}

		public void SyncToDepartment()
		{
		   SyncToDepartmentObject obj = new SyncToDepartmentObject();
			obj.Department = SelectedDepartment;
			obj.DepartmentInfo = DepartmentInfo;
			obj.ProductMasterInfo = ProductMasterInfo;
			obj.PriceInfo = PriceInfo;
			IoC.Get<INormalLoadViewModel>().StartLoading();
			BackgroundTask _backgroundTask = null;
			_backgroundTask = new BackgroundTask(()=>SyncToDepartment(obj));
			_backgroundTask.Completed += (s, e) => SyncToDepartmentCompleted(s, e);
			_backgroundTask.Start(obj);
		}
				
		public void Quit()
		{
			Flow.End();
		}

		protected override void OnInitialize()
		{
			IList<Department> list = DepartmentLogic.FindAll(new ObjectCriteria<Department>());
			Departments = list;
		}

		private IList resultList = null;
		public object SyncToDepartment(SyncToDepartmentObject toDepartmentObject)
		{
			SystemConfig config = SystemConfig.Instance;
			IList departmentUsbList = ClientUtility.GetUSBDrives();
			foreach (var POSSyncDrive in departmentUsbList)
			{

				//var exportPath = (string)configurationAppSettings.GetValue("SyncExportPath", typeof(String));
				var configExportPath = POSSyncDrive + config.SyncExportPath;
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
		}

		#endregion
		
		
		
	}
}