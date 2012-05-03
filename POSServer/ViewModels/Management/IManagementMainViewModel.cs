
			 
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using Caliburn.PresentationFramework.ApplicationModel;
using Caliburn.PresentationFramework.Screens;

namespace POSServer.ViewModels.Management
{
    public interface IManagementMainViewModel : IScreenNode
    {
        #region Fields
			#endregion
		
		#region Methods
		        
        void CreateDepartment();
        
		        
        void DepartmentList();
        
		        
        void CreateEmployee();
        
		        
        void EmployeeList();
        
		        
        void CostManagement();
        
		        
        void TimeAttendance();
        
		        
        void CalendarPresentList();
        
		        
        void CalendarAbsentList();
        
		        
        void AccountManagement();
        
		        
        void UserRight();
        
		        
        void CreateCalendarPresent();
        
			#endregion
    }
}