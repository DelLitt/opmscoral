
			 
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using Caliburn.PresentationFramework.ApplicationModel;
using Caliburn.PresentationFramework.Screens;

namespace POSClient.ViewModels.Tool
{
    public interface ISetDepartmentViewModel : IScreenNode
    {
        #region Fields
		                
        string CreateDate
        {
            get;
            set;            
        }
		                
        string Description
        {
            get;
            set;            
        }
		                
        string DepartmentName
        {
            get;
            set;            
        }
			#endregion
		
		#region Methods
		        
        void Help();
        
		        
        void SetDepartment();
        
		        
        void Stop();
        
			#endregion
    }
}