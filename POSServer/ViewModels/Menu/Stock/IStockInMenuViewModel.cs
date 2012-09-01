
			 
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using AppFrame.CustomAttributes;
using AppFrame.CustomAttributes;

namespace POSServer.ViewModels.Menu.Stock
{
    public interface IStockInMenuViewModel : IScreenNode
    {
        #region Fields
			#endregion
		
		#region Methods
		        
        void StockIn();
        
		        
        void StockInList();
        
		        
        void StockInBackList();
        
		        
        void StockInByExcel();

        void Back();

        #endregion
    }
}