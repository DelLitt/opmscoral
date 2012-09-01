
			 
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using AppFrame.CustomAttributes;
using AppFrame.CustomAttributes;

namespace POSClient.ViewModels.Menu.Stock
{
    public interface IDepartmentStockInMenuViewModel : IScreenNode
    {
        #region Fields
			#endregion
		
		#region Methods
		        
        void StockInConfirm();
        
		        
        void StockInList();
        
		        
        void StockInBackList();
        
		        
        void ReStockIn();
        
			#endregion
    }
}