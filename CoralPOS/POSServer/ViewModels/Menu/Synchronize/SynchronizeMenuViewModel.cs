			 

			 

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



namespace POSServer.ViewModels.Menu.Synchronize
{
    [PerRequest]
    public class SynchronizeMenuViewModel : PosViewModel
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
		        
        public void ToDepartment()
        {
            
        }
		        
        public void FromDepartment()
        {
            
        }
		        
        public void FromMainStock()
        {
            
        }
		        
        public void ToMainStock()
        {
            
        }
				#endregion
		
        
        
    }
}