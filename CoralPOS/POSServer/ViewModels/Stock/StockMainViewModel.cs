			 

			 

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using AppFrame.Base;
using AppFrame.CustomAttributes;
using Caliburn.Core;
using Caliburn.Core.IoC;
using Caliburn.PresentationFramework.ApplicationModel;
using Caliburn.PresentationFramework.Screens;
using POSServer.Common;
using POSServer.ViewModels.Menu;


namespace POSServer.ViewModels.Stock
{
    [PerRequest(typeof(IStockMainViewModel))]
    [AttachMenuAndMainScreen(typeof(IMainMenuViewModel),typeof(IMainView))]
    public class StockMainViewModel : PosViewModel,IStockMainViewModel  
    {

        private IShellViewModel _startViewModel;
        public StockMainViewModel(IShellViewModel startViewModel)
        {
            _startViewModel = startViewModel; 
        }
		
		#region Fields
				#endregion
		
		#region List use to fetch object for view
				#endregion
		
		#region List which just using in Data Grid
				#endregion
		
		#region Methods
		        
        public void StockIn()
        {
            _startViewModel.EnterFlow(FlowDefinition.StockInCreateFlow); 
        }
		        
        public void StockInList()
        {
            _startViewModel.EnterFlow(FlowDefinition.StockInSearchFlow); 
        }
		        
        public void StockInBackList()
        {
            
        }
		        
        public void StockInByExcel()
        {
            
        }
		        
        public void StockOutToDepartment()
        {
            _startViewModel.EnterFlow(FlowDefinition.StockOutCreateFlow); 
        }
		        
        public void StockOutToOther()
        {
            
        }
		        
        public void StockOutList()
        {
            _startViewModel.EnterFlow(FlowDefinition.StockOutSearchFlow);  
        }
		        
        public void StockOutByExcel()
        {
            
        }
		        
        public void InventoryCollector()
        {
            
        }
		        
        public void AfterInventoryCollectorProcessing()
        {
            
        }
		        
        public void StockSearch()
        {
            
        }
		        
        public void StockCategorySearch()
        {
            
        }
		        
        public void StockInConfirm()
        {
            
        }
		        
        public void StockOutConfirm()
        {
            
        }
		        
        public void DepartmentStockOutConfirm()
        {
            
        }
				#endregion
		
        
        
    }
}