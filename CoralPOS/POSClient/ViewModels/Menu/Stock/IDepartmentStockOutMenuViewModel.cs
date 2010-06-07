
			 
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using Caliburn.PresentationFramework.ApplicationModel;
using Caliburn.PresentationFramework.Screens;

namespace POSClient.ViewModels.Menu.Stock
{
    public interface IDepartmentStockOutMenuViewModel : IScreenNode
    {
        #region Fields
			#endregion
		
		#region Methods
		        
        void StockOutToDepartment();
        
		        
        void StockOutToOther();
        
		        
        void StockOutList();
        
		        
        void StockOutByExcel();
        
			#endregion
    }
}