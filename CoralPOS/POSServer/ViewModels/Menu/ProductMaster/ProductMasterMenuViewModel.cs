			 

			 

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



namespace POSServer.ViewModels.Menu.ProductMaster
{
    [PerRequest(typeof(IProductMasterMenuViewModel))]
    public class ProductMasterMenuViewModel : PosViewModel,IProductMasterMenuViewModel  
    {

        private IShellViewModel _startViewModel;
        public ProductMasterMenuViewModel(IShellViewModel startViewModel)
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
		        
        public void BackToParent()
        {
            
        }
		        
        public void Back()
        {
            
        }
		        
        public void CreateProductMaster()
        {
            _startViewModel.EnterFlow("ProductMasterCreateFlow");
        }
		        
        public void CreateProductMasterByTemplate()
        {
            
        }
		        
        public void ProductMasterList()
        {
            
        }
		        
        public void StockInByExcel()
        {
            
        }
		        
        public void ExtendFunctions()
        {
            
        }
				#endregion
		
        
        
    }
}