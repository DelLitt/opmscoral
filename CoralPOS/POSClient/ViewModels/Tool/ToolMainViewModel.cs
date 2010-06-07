			 

			 

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using AppFrame.Base;
using AppFrame.CustomAttributes;
using Caliburn.Core;
using Caliburn.Core.IoC;
using Caliburn.PresentationFramework.ApplicationModel;
using Caliburn.PresentationFramework.Screens;
using POSClient.ViewModels.Menu;


namespace POSClient.ViewModels.Tool
{
    [PerRequest(typeof(IToolMainViewModel))]
    [AttachMenuAndMainScreen(typeof(IMainMenuViewModel), typeof(IMainViewModel))]
    public class ToolMainViewModel : PosViewModel,IToolMainViewModel  
    {

        private IShellViewModel _startViewModel;
        public ToolMainViewModel(IShellViewModel startViewModel)
        {
            _startViewModel = startViewModel; 
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
            
        }
				#endregion
		
        
        
    }
}