
			 
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using Caliburn.PresentationFramework.ApplicationModel;
using Caliburn.PresentationFramework.Screens;

namespace POSServer.ViewModels.Stock
{
    public interface IStockMainViewModel : IScreenNode
    {
        #region Fields
			#endregion
		
		#region Methods
		        
        void StockIn();
        
		        
        void StockInList();
        
		        
        void StockInBackList();
        
		        
        void StockInByExcel();
        
		        
        void StockOutToDepartment();
        
		        
        void StockOutToOther();
        
		        
        void StockOutList();
        
		        
        void StockOutByExcel();
        
		        
        void InventoryCollector();
        
		        
        void AfterInventoryCollectorProcessing();
        
		        
        void StockSearch();
        
		        
        void StockCategorySearch();
        
		        
        void StockInConfirm();
        
		        
        void StockOutConfirm();
        
		        
        void DepartmentStockOutConfirm();
        
			#endregion
    }
}