			 

			 

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
using POSClient.ViewModels.Menu;


namespace POSClient.ViewModels.Sale
{
    [PerRequest(typeof(ISaleMainViewModel))]
    [AttachMenuAndMainScreen(typeof(IMainMenuViewModel),typeof(IMainViewModel))]
    public class SaleMainViewModel : PosViewModel,ISaleMainViewModel  
    {

        private IShellViewModel _startViewModel;
        public SaleMainViewModel(IShellViewModel startViewModel)
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
		        
        public void CreateProductMaster()
        {
            
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