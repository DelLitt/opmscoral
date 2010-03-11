			 

			 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using AppFrame.Base;
using Caliburn.Core;
using Caliburn.Core.IoC;
using Caliburn.Core.Metadata;
using Caliburn.PresentationFramework.ApplicationModel;
using Caliburn.PresentationFramework.Screens;



namespace POSServer.ViewModels.Menu
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
		        
        public void ProductMasterNew()
        {
            
        }
		        
        public void ProductMasterSearch()
        {
            
        }
		        
        public void BackToParent()
        {
            
        }
		        
        public void Back()
        {
            
        }
		        
        public void ProductMasterDetail()
        {
            
        }
				#endregion
		
        
        
    }
}