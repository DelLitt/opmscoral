			 

			 

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
using POSServer.ViewModels.Menu;


namespace POSServer.ViewModels.ProductMaster
{
    [PerRequest(typeof(IProductMasterMainViewModel))]
    [AttachMenuAndMainScreen(typeof(IMainMenuViewModel))]
    public class ProductMasterMainViewModel : PosViewModel,IProductMasterMainViewModel  
    {

        private IShellViewModel _startViewModel;
        public ProductMasterMainViewModel()
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
		        
        public void StockInByExcel()
        {
            
        }
		        
        public void ExtendFunctions()
        {
            
        }
				#endregion
		
        
        
    }
}