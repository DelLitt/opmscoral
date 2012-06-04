			 

			 

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
using POSServer.Common;


namespace POSServer.ViewModels.Menu.Stock
{
    [PerRequest(typeof(IStockOutMenuViewModel))]
    public class StockOutMenuViewModel : PosViewModel,IStockOutMenuViewModel  
    {

        private IShellViewModel _startViewModel;
        public StockOutMenuViewModel()
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
            _startViewModel.EnterFlow(FlowDefinition.StockOutCreateFlow);
        }
		        
        public void StockOutToOther()
        {
            _startViewModel.EnterFlow(FlowDefinition.StockOutSpecificCreateFlow);
        }
		        
        public void StockOutList()
        {
            _startViewModel.EnterFlow(FlowDefinition.StockOutSearchFlow);
        }
		        
        public void StockOutByExcel()
        {
            
        }

        public void Back()
        {
            _startViewModel.OpenMainScreen();
        }
				#endregion
		
        
        
    }
}