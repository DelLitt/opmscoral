
			 
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using Caliburn.PresentationFramework.ApplicationModel;
using Caliburn.PresentationFramework.Screens;

namespace POSServer.ViewModels.Menu.Management
{
    public interface IDeptEmpMenuViewModel : IScreenNode
    {
        #region Fields
			#endregion
		
		#region Methods
		        
        void CreateDepartment();
        
		        
        void DepartmentList();
        
		        
        void CreateEmployee();
        
		        
        void EmployeeList();
        
		        
        void AccountManagement();
        
		        
        void UserRight();
        
			#endregion
    }
}