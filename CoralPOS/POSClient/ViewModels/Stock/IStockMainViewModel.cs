
			 
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using Caliburn.PresentationFramework.ApplicationModel;
using Caliburn.PresentationFramework.Screens;

namespace POSClient.ViewModels.Stock
{
    public interface IStockMainViewModel : IScreenNode
    {
        #region Fields
			#endregion
		
		#region Methods
		        
        void StockInConfirm();
        
		        
        void StockInList();
        
		        
        void StockInBackList();
        
		        
        void ReStockIn();
        
		        
        void StockOutToDepartment();
        
		        
        void StockOutToOther();
        
		        
        void StockOutList();
        
		        
        void TempStockOut();
        
		        
        void InventoryCollector();
        
		        
        void InventoryCollectorList();
        
		        
        void StockSearch();
        
		        
        void OtherStockSearch();
        
			#endregion
    }
}