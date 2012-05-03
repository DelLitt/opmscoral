
			 
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using Caliburn.PresentationFramework.ApplicationModel;
using Caliburn.PresentationFramework.Screens;

namespace POSClient.ViewModels.Menu.Tool
{
    public interface IToolMenuViewModel : IScreenNode
    {
        #region Fields
			#endregion
		
		#region Methods
		        
        void LogViewer();
        
		        
        void BackupDatabase();
        
		        
        void CleanDatabase();
        
		        
        void RestoreDatabase();
        
		        
        void Configuration();
        
			#endregion
    }
}