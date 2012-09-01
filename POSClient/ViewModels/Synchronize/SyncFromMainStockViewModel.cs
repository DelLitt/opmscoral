			 

			 

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using AppFrame.Base;
using AppFrame.CustomAttributes;
using AppFrame.Invocation;
using AppFrame.Utils;
using AppFrame.WPF.Screens;
using Caliburn.Micro;
using Caliburn.Micro;

using AppFrame.CustomAttributes;
using AppFrame.CustomAttributes;

using POSClient.BusinessLogic.Implement;
using POSClient.ViewModels.Menu;


namespace POSClient.ViewModels.Synchronize
{
	[AttachMenuAndMainScreen(typeof(IMainMenuViewModel), typeof(IMainViewModel))]
	public class SyncFromMainStockViewModel : PosViewModel,ISyncFromMainStockViewModel  
	{

		private IShellViewModel _startViewModel;
		public SyncFromMainStockViewModel()
		{
			_startViewModel = ShellViewModel.Current;
		}
		
		#region Fields
				#endregion
		
		#region List use to fetch object for view
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

		public IDepartmentLogic DepartmentLogic { get; set; }
		public ISyncLogic SyncLogic { get; set; }

		public void SyncFromMainStock()
		{
			IList departmentUsbList = ClientUtility.GetUSBDrives();

			IoC.Get<INormalLoadViewModel>().StartLoading();
			BackgroundTask _backgroundTask = null;
			_backgroundTask = new BackgroundTask(() => SyncFromMain(departmentUsbList));
			_backgroundTask.Completed += (s, e) => SyncToDepartmentCompleted(s, e);
			_backgroundTask.Start(departmentUsbList);

		}

		private void SyncToDepartmentCompleted(object sender, RunWorkerCompletedEventArgs runWorkerCompletedEventArgs)
		{
			IoC.Get<INormalLoadViewModel>().StopLoading();
		}

		private object SyncFromMain(IList departmentUsbList)
		{
			foreach (var POSSyncDrive in departmentUsbList)
			{
				var configExportPath = POSSyncDrive + @"\POS\KHO-CH" + @"\1";
				SyncLogic.SyncFromMain(configExportPath);
			}
			return null;
		}

		public void Quit()
		{
		   Flow.End(); 
		}
				#endregion
		
		
		
	}
}