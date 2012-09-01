
			 
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using AppFrame.CustomAttributes;
using AppFrame.CustomAttributes;

namespace POSClient.ViewModels.Management
{
    public interface IManagementMainViewModel : IScreenNode
    {
        #region Fields
			#endregion
		
		#region Methods
		        
        void ManageDepartment();
        
		        
        void ManageEmployee();
        
		        
        void EmployeeAbsentList();
        
		        
        void InputCost();
        
		        
        void OutputCost();
        
		        
        void CostList();
        
		        
        void WorkingUnit();
        
			#endregion
    }
}