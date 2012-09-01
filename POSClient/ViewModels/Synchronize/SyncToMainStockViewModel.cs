			 

			 

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



namespace POSClient.ViewModels.Synchronize
{
    //[PerRequest(typeof(ISyncToMainStockViewModel))]
    public class SyncToMainStockViewModel : PosViewModel,ISyncToMainStockViewModel  
    {

        private IShellViewModel _startViewModel;
        public SyncToMainStockViewModel()
        {
            _startViewModel = ShellViewModel.Current;
        }
		
		#region Fields
				#endregion
		
		#region List use to fetch object for view
				#endregion
		
		#region List which just using in Data Grid
		        
        private IList _resultGrid;
        public IList ResultGrid
        {
            get
            {
                return _resultGrid;
            }
            set
            {
                _resultGrid = value;
                NotifyOfPropertyChange(() => ResultGrid);
            }
        }
				#endregion
		
		#region Methods
		        
        public void ToMainStock()
        {
            
        }
		        
        public void Quit()
        {
            
        }
				#endregion
		
        
        
    }
}