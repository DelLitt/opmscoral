
			 
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using AppFrame.CustomAttributes;
using AppFrame.CustomAttributes;

namespace POSClient.ViewModels.Menu.Management
{
    public interface IDeptEmpMenuViewModel : IScreenNode
    {
        #region Fields
			#endregion
		
		#region Methods
		        
        void DepartmentManagement();
        
		        
        void EmployeeManagement();
        
		        
        void EmpInHolidaysList();
        
		        
        void AccountManagement();
        
			#endregion
    }
}