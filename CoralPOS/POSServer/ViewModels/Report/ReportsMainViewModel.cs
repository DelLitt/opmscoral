			 

			 

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



namespace POSServer.ViewModels.Report
{
    [PerRequest(typeof(ReportsMainViewModel))]
    public class ReportsMainViewModel : PosViewModel
    {

        private IShellViewModel _startViewModel;
        public ReportsMainViewModel()
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
		        
        public void StockIn()
        {
            
        }
		        
        public void StockInList()
        {
            
        }
		        
        public void StockInBackList()
        {
            
        }
		        
        public void StockInByExcel()
        {
            
        }
		        
        public void button1()
        {
            
        }
				#endregion
		
        
        
    }
}