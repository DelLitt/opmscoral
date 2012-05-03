			 

			 

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



namespace POSServer.ViewModels.Synchronize
{
    [PerRequest(typeof(ISyncToMainViewModel))]
    public class SyncToMainViewModel : PosViewModel,ISyncToMainViewModel  
    {

        private IShellViewModel _startViewModel;
        public SyncToMainViewModel(IShellViewModel startViewModel)
        {
            _startViewModel = startViewModel; 
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
		        
        public void SyncToMain()
        {
            
        }
		        
        public void Quit()
        {
            
        }
				#endregion
		
        
        
    }
}