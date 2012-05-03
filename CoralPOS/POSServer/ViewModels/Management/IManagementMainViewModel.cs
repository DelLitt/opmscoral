
			 
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using AppFrame.CustomAttributes;
using AppFrame.CustomAttributes;

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