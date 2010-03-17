			 

			 

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



namespace POSServer.ViewModels.Dialogs
{
    [PerRequest(typeof(IProductPropertiesViewModel))]
    public class ProductPropertiesViewModel : PosViewModel,IProductPropertiesViewModel  
    {

        private IShellViewModel _startViewModel;
        public ProductPropertiesViewModel(IShellViewModel startViewModel)
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
		        
        public void button1()
        {
            
        }
		        
        public void button2()
        {
            
        }
				#endregion
		
        
        
    }
}