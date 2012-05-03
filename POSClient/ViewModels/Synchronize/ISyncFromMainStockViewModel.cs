
			 
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using Caliburn.PresentationFramework.ApplicationModel;
using Caliburn.PresentationFramework.Screens;
using POSClient.BusinessLogic.Implement;

namespace POSClient.ViewModels.Synchronize
{
    public interface ISyncFromMainStockViewModel : IScreenNode
    {
        #region Fields
			#endregion
        IDepartmentLogic DepartmentLogic { get; set; }
        ISyncLogic SyncLogic { get; set; }
		#region Methods
		        
        void SyncFromMainStock();
        
		        
        void Quit();
        
			#endregion
    }
}