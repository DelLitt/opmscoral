
			 
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using AppFrame.CustomAttributes;
using AppFrame.CustomAttributes;

namespace POSServer.ViewModels.Security
{
    public interface IUserInfoViewModel : IScreenNode
    {
        #region Fields
		                
        string Username
        {
            get;
            set;            
        }
		                
        string Password
        {
            get;
            set;            
        }
			#endregion
		
		#region Methods
		        
        void Help();
        
		        
        void Save();
        
		        
        void Stop();
        
		        
        void Cancel();
        
		        
        void CreateEmployeeAccount();
        
		        
        void CreateNormalAccount();
        
			#endregion
    }
}