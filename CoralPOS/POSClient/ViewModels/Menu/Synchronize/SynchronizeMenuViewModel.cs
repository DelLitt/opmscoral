			 

			 

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using AppFrame.Base;
using Caliburn.Micro;

using AppFrame.CustomAttributes;
using AppFrame.CustomAttributes;



namespace POSClient.ViewModels.Menu.Synchronize
{
    [PerRequest(typeof(ISynchronizeMenuViewModel))]
    public class SynchronizeMenuViewModel : PosViewModel,ISynchronizeMenuViewModel  
    {

        private IShellViewModel _startViewModel;
        public SynchronizeMenuViewModel()
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