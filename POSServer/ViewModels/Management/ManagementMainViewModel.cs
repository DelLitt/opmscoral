			 

			 

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
using POSServer.Common;
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

        /// <summary>
        /// Creates the department.
        /// </summary>
        public void CreateDepartment()
        {
            _startViewModel.EnterFlow(FlowDefinition.DepartmentsViewFlow);
        }

        /// <summary>
        /// Departments the list.
        /// </summary>
        public void DepartmentList()
        {
            
        }

        /// <summary>
        /// Creates the employee.
        /// </summary>
        public void CreateEmployee()
        {
            _startViewModel.EnterFlow(FlowDefinition.EmployeesViewFlow);
        }

        /// <summary>
        /// Employees the list.
        /// </summary>
        public void EmployeeList()
        {
            
        }

        /// <summary>
        /// Costs the management.
        /// </summary>
        public void CostManagement()
        {
            
        }

        /// <summary>
        /// Times the attendance.
        /// </summary>
        public void TimeAttendance()
        {
            
        }

        /// <summary>
        /// Calendars the present list.
        /// </summary>
        public void CalendarPresentList()
        {
            
        }

        /// <summary>
        /// Calendars the absent list.
        /// </summary>
        public void CalendarAbsentList()
        {
            
        }

        /// <summary>
        /// Accounts the management.
        /// </summary>
        public void AccountManagement()
        {
            _startViewModel.EnterFlow(FlowDefinition.UserInfoViewFlow);
        }

        /// <summary>
        /// Users the right.
        /// </summary>
        public void UserRight()
        {
            
        }

        /// <summary>
        /// Creates the calendar present.
        /// </summary>
        public void CreateCalendarPresent()
        {
            
        }
				#endregion
		
        
        
    }
}