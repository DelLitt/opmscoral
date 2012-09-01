			 

			 

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using AppFrame.Base;
using AppFrame.CustomAttributes;
using Caliburn.Micro;

using AppFrame.CustomAttributes;
using AppFrame.CustomAttributes;
using POSServer.Common;


namespace POSServer.ViewModels.Tool
{
    [PerRequest(typeof(IToolMainViewModel))]
    public class ToolMainViewModel : PosViewModel,IToolMainViewModel  
    {

        private IShellViewModel _startViewModel;
        public ToolMainViewModel()
        {
            _startViewModel = ShellViewModel.Current;
        }
		
		#region Fields
				#endregion
		
		#region List use to fetch object for view
				#endregion
		
		#region List which just using in Data Grid
				#endregion
		
		#region Methods
		        
        public void LogViewer()
        {
            
        }
		        
        public void BackupDatabase()
        {
            
        }
		        
        public void CleanDatabase()
        {
            
        }
		        
        public void RestoreDatabase()
        {
            
        }
		        
        public void Configuration()
        {
            _startViewModel.EnterFlow(FlowDefinition.SystemConfigFlow);
        }
		        
        public void ExportStockCollectorData()
        {
            
        }
				#endregion
		
        
        
    }
}