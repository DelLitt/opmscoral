			 

			 

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using AppFrame.Base;
using AppFrame.CustomAttributes;
using AppFrame.Utils;
using Caliburn.Core;
using Caliburn.Core.IoC;
using Caliburn.PresentationFramework.ApplicationModel;
using Caliburn.PresentationFramework.Screens;
using POSClient.BusinessLogic.Implement;
using POSClient.ViewModels.Menu;


namespace POSClient.ViewModels.Synchronize
{
    [AttachMenuAndMainScreen(typeof(IMainMenuViewModel), typeof(IMainViewModel))]
    public class SyncFromMainStockViewModel : PosViewModel,ISyncFromMainStockViewModel  
    {

        private IShellViewModel _startViewModel;
        public SyncFromMainStockViewModel(IShellViewModel startViewModel)
        {
            _startViewModel = startViewModel; 
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
            foreach (var POSSyncDrive in departmentUsbList)
            {
                var configExportPath = POSSyncDrive + @"\POS\KHO-CH" + @"\1";
                SyncLogic.SyncFromMain(configExportPath);
            }
        }
		        
        public void Quit()
        {
           Flow.End(); 
        }
				#endregion
		
        
        
    }
}