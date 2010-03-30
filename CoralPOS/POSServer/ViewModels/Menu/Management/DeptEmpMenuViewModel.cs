			 

			 

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



namespace POSServer.ViewModels.Menu.Management
{
    [PerRequest(typeof(IDeptEmpMenuViewModel))]
    public class DeptEmpMenuViewModel : PosViewModel,IDeptEmpMenuViewModel  
    {

        private IShellViewModel _startViewModel;
        public DeptEmpMenuViewModel(IShellViewModel startViewModel)
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
		        
        public void CreateDepartment()
        {
            
        }
		        
        public void DepartmentList()
        {
            
        }
		        
        public void CreateEmployee()
        {
            
        }
		        
        public void EmployeeList()
        {
            
        }
		        
        public void AccountManagement()
        {
            
        }
		        
        public void UserRight()
        {
            
        }
				#endregion
		
        
        
    }
}