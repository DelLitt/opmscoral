			 

			 

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



namespace POSClient.ViewModels.Menu.Stock
{
    [PerRequest(typeof(IDepartmentStockOutMenuViewModel))]
    public class DepartmentStockOutMenuViewModel : PosViewModel,IDepartmentStockOutMenuViewModel  
    {

        private IShellViewModel _startViewModel;
        public DepartmentStockOutMenuViewModel()
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
		        
        public void StockOutToDepartment()
        {
            
        }
		        
        public void StockOutToOther()
        {
            
        }
		        
        public void StockOutList()
        {
            
        }
		        
        public void StockOutByExcel()
        {
            
        }
				#endregion
		
        
        
    }
}