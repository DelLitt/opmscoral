
			 
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using AppFrame.CustomAttributes;
using AppFrame.CustomAttributes;

namespace POSClient.ViewModels.Menu.Report
{
    public interface IReportsMenuViewModel : IScreenNode
    {
        #region Fields
			#endregion
		
		#region Methods
		        
        void StockInConfirm();
        
		        
        void StockOutConfirm();
        
		        
        void DepartmentStockOutConfirm();
        
			#endregion
    }
}