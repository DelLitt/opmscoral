			 

			 

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using AppFrame.Base;
using AppFrame.CustomAttributes;
using Caliburn.Micro;

using AppFrame.CustomAttributes;
using AppFrame.CustomAttributes;
using POSClient.ViewModels.Menu;


namespace POSClient.ViewModels.Management
{
    [PerRequest(typeof(IManagementMainViewModel))]
    [AttachMenuAndMainScreen(typeof(IMainMenuViewModel), typeof(IMainViewModel))]
    public class ManagementMainViewModel : PosViewModel,IManagementMainViewModel  
    {

        private IShellViewModel _startViewModel;
        public ManagementMainViewModel()
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
		        
        public void ManageDepartment()
        {
            
        }
		        
        public void ManageEmployee()
        {
            
        }
		        
        public void EmployeeAbsentList()
        {
            
        }
		        
        public void InputCost()
        {
            
        }
		        
        public void OutputCost()
        {
            
        }
		        
        public void CostList()
        {
            
        }
		        
        public void WorkingUnit()
        {
            
        }
				#endregion
		
        
        
    }
}