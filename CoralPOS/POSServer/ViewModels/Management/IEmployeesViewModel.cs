
			 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using Caliburn.Core.Metadata;
using Caliburn.PresentationFramework.ApplicationModel;
using Caliburn.PresentationFramework.Screens;

namespace POSServer.ViewModels.Management
{
    public interface IEmployeesViewModel : IScreenNode
    {
        #region Fields
		                
        public string Address
        {
            get;
            set;            
        }
		                
        public string DepartmentName
        {
            get;
            set;            
        }
		                
        public string DepartmentId
        {
            get;
            set;            
        }
		                
        public string CardId
        {
            get;
            set;            
        }
			#endregion
		
		#region Methods
		        
        public void Help();
        
		        
        public void Delete();
        
		        
        public void Edit();
        
		        
        public void Stop();
        
		        
        public void Create();
        
			#endregion
    }
}