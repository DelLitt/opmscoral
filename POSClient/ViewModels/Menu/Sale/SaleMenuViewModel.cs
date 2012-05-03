			 

			 

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using AppFrame.Base;
using Caliburn.Core;
using Caliburn.Core.IoC;
using Caliburn.PresentationFramework.ApplicationModel;
using Caliburn.PresentationFramework.Screens;



namespace POSClient.ViewModels.Menu.Sale
{
    [PerRequest(typeof(ISaleMenuViewModel))]
    public class SaleMenuViewModel : PosViewModel,ISaleMenuViewModel  
    {

        private IShellViewModel _startViewModel;
        public SaleMenuViewModel(IShellViewModel startViewModel)
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
		        
        public void CreatePurchaseOrder()
        {
            
        }
		        
        public void PurchaseOrderList()
        {
            
        }
		        
        public void ProductMasterList()
        {
            
        }
		        
        public void PriceList()
        {
            
        }
				#endregion
		
        
        
    }
}