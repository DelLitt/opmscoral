
			 
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using AppFrame.CustomAttributes;
using AppFrame.CustomAttributes;

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