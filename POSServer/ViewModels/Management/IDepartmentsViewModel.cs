
			 
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using Caliburn.PresentationFramework.ApplicationModel;
using Caliburn.PresentationFramework.Screens;
using POSServer.BusinessLogic.Implement;

namespace POSServer.ViewModels.Management
{
    public interface IDepartmentsViewModel : IScreenNode
    {
        #region Fields
		                
        string Address
        {
            get;
            set;            
        }
		                
        string DepartmentName
        {
            get;
            set;            
        }
		                
        string DepartmentId
        {
            get;
            set;            
        }

        IDepartmentLogic DepartmentLogic { get; set; }
			#endregion
		
		#region Methods
		        
        void Help();
        
		        
        void Delete();
        
		        
        void Save();
        
		        
        void Stop();
        
		        
        void Create();
        
			#endregion
    }
}