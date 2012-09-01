			 

			 

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using AppFrame.Base;
using AppFrame.CustomAttributes;
using Caliburn.Micro;

using AppFrame.CustomAttributes;
using AppFrame.CustomAttributes;
using POSClient.ViewModels.Menu;


namespace POSClient.ViewModels.Stock
{
    [PerRequest(typeof(IStockMainViewModel))]
    [AttachMenuAndMainScreen(typeof(IMainMenuViewModel), typeof(IMainViewModel))]
    public class StockMainViewModel : PosViewModel,IStockMainViewModel  
    {

        private IShellViewModel _startViewModel;
        public StockMainViewModel()
        {
            _startViewModel = ShellViewModel.Current;
        }
		
		#region Fields
				#endregion
		
		#region List use to fetch object for view
				#endregion
		
		#region List which just using in Data Grid
				#endregion
		
		#region Methods
		        
        public void StockInConfirm()
        {
            
        }
		        
        public void StockInList()
        {
            
        }
		        
        public void StockInBackList()
        {
            
        }
		        
        public void ReStockIn()
        {
            
        }
		        
        public void StockOutToDepartment()
        {
            
        }
		        
        public void StockOutToOther()
        {
            
        }
		        
        public void StockOutList()
        {
            
        }
		        
        public void TempStockOut()
        {
            
        }
		        
        public void InventoryCollector()
        {
            
        }
		        
        public void InventoryCollectorList()
        {
            
        }
		        
        public void StockSearch()
        {
            
        }
		        
        public void OtherStockSearch()
        {
            
        }
				#endregion
		
        
        
    }
}