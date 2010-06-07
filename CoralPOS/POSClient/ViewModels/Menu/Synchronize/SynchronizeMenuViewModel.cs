			 

			 

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



namespace POSClient.ViewModels.Menu.Synchronize
{
    [PerRequest(typeof(ISynchronizeMenuViewModel))]
    public class SynchronizeMenuViewModel : PosViewModel,ISynchronizeMenuViewModel  
    {

        private IShellViewModel _startViewModel;
        public SynchronizeMenuViewModel(IShellViewModel startViewModel)
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
		        
        public void FromMainStock()
        {
            
        }
		        
        public void ToMainStock()
        {
            
        }
		        
        public void FromInternetMainStock()
        {
            
        }
		        
        public void ToInternetMainStock()
        {
            
        }
				#endregion
		
        
        
    }
}