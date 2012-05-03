
			 
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using AppFrame.CustomAttributes;
using AppFrame.CustomAttributes;

namespace POSServer.ViewModels.Synchronize
{
    public interface ISynchronizeMainViewModel : IScreenNode
    {
        #region Fields
			#endregion
		
		#region Methods
		        
        void ToDepartment();
        
		        
        void FromDepartment();
        
		        
        void FromMainStock();
        
		        
        void ToMainStock();
        
			#endregion
    }
}