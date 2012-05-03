
			 
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using AppFrame.CustomAttributes;
using AppFrame.CustomAttributes;

namespace POSClient.ViewModels.Menu
{
    public interface IMainMenuViewModel : IScreenNode
    {
        #region Fields
			#endregion
		
		#region Methods
		        
        void Task();
        
		        
        void Sale();
        
		        
        void DepartmentStock();
        
		        
        void Report();
        
		        
        void Management();
        
		        
        void Utility();
        
		        
        void Synchronize();
        
			#endregion
    }
}