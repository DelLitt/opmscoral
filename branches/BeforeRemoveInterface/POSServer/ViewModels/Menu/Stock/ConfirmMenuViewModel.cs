			 

			 

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



namespace POSServer.ViewModels.Menu.Stock
{
    [PerRequest(typeof(IConfirmMenuViewModel))]
    public class ConfirmMenuViewModel : PosViewModel,IConfirmMenuViewModel  
    {

        private IShellViewModel _startViewModel;
        public ConfirmMenuViewModel()
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
		        
        public void StockInConfirm()
        {
            
        }
		        
        public void StockOutConfirm()
        {
            
        }
		        
        public void DepartmentStockOutConfirm()
        {
            
        }

        public void Back()
        {
            _startViewModel.OpenMainScreen();
        }

        #endregion
		
        
        
    }
}