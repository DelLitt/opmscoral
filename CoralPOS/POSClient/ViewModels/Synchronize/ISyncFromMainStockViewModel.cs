
			 
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using AppFrame.CustomAttributes;
using AppFrame.CustomAttributes;
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