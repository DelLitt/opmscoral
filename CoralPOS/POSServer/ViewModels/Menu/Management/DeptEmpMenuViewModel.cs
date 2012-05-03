			 

			 

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



namespace POSServer.ViewModels.Menu.Management
{
    [PerRequest(typeof(IDeptEmpMenuViewModel))]
    public class DeptEmpMenuViewModel : PosViewModel,IDeptEmpMenuViewModel  
    {

        private IShellViewModel _startViewModel;
        public DeptEmpMenuViewModel()
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
		        
        public void CreateDepartment()
        {
            _startViewModel.EnterFlow("DepartmentsViewFlow"); 
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