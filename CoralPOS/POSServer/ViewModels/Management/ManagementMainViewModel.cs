			 

			 

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using AppFrame.Base;
using AppFrame.CustomAttributes;
using Caliburn.Core;
using Caliburn.Core.IoC;
using Caliburn.PresentationFramework.ApplicationModel;
using Caliburn.PresentationFramework.Screens;
using POSServer.ViewModels.Menu;


namespace POSServer.ViewModels.Management
{
    [PerRequest(typeof(IManagementMainViewModel))]
    [AttachMenuAndMainScreen(typeof(IMainMenuViewModel),typeof(IMainView))]
    public class ManagementMainViewModel : PosViewModel,IManagementMainViewModel  
    {

        private IShellViewModel _startViewModel;
        public ManagementMainViewModel(IShellViewModel startViewModel)
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
		        
        public void CostManagement()
        {
            
        }
		        
        public void TimeAttendance()
        {
            
        }
		        
        public void CalendarPresentList()
        {
            
        }
		        
        public void CalendarAbsentList()
        {
            
        }
		        
        public void AccountManagement()
        {
            
        }
		        
        public void UserRight()
        {
            
        }
		        
        public void CreateCalendarPresent()
        {
            
        }
				#endregion
		
        
        
    }
}