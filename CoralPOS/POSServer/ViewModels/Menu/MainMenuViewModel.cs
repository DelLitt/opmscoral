			 

			 

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



namespace POSServer.ViewModels.Menu
{
    [PerRequest(typeof(IMainMenuViewModel))]
    public class MainMenuViewModel : PosViewModel,IMainMenuViewModel  
    {

        private IShellViewModel _startViewModel;
        public MainMenuViewModel(IShellViewModel startViewModel)
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
		        
        public void Task()
        {
            MessageBox.Show("Task Menu!");
        }
		        
        public void ProductMaster()
        {
            _startViewModel.EnterFlow("ProductMasterCreateFlow");
        }
		        
        public void Stock()
        {
            MessageBox.Show("Stock Menu!");
        }
		        
        public void Report()
        {
            MessageBox.Show("Report Menu!");
        }
		        
        public void Management()
        {
            MessageBox.Show("Management Menu!");
        }
		        
        public void Utility()
        {
            MessageBox.Show("Utility Menu!");
        }
		        
        public void Synchronize()
        {
            MessageBox.Show("Synchronize Menu!");
        }
				#endregion
		
        
        
    }
}