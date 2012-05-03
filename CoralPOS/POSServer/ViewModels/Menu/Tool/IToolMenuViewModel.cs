
			 
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using AppFrame.CustomAttributes;
using AppFrame.CustomAttributes;

namespace POSServer.ViewModels.Menu.Tool
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
        
		        
        void ExportStockCollectorData();
        
			#endregion
    }
}