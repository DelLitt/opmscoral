			 

			 

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
using POSServer.Common;


namespace POSServer.ViewModels.Menu.ProductMaster
{
    [PerRequest]
    public class ProductMasterMenuViewModel : PosViewModel
    {

        private IShellViewModel _startViewModel;
        public ProductMasterMenuViewModel()
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
		        
        public void BackToParent()
        {
            
        }
		        
        public void Back()
        {
            _startViewModel.OpenMainScreen();
        }
		        
        public void CreateProductMaster()
        {
            _startViewModel.EnterFlow(FlowDefinition.ProductMasterCreateFlow);
        }
		        
        public void CreateProductMasterByTemplate()
        {
            
        }
		        
        public void ProductMasterList()
        {
            
        }

        public void UpdateProductMasterPrice()
        {
            _startViewModel.EnterFlow(FlowDefinition.ProductMasterPriceUpdateFlow);
        }
		        
        public void ExtendFunctions()
        {
            
        }
				#endregion
		
        
        
    }
}