
			 
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using Caliburn.PresentationFramework.ApplicationModel;
using Caliburn.PresentationFramework.Screens;

namespace POSServer.ViewModels.Synchronize
{
    public interface ISyncToMainViewModel : IScreenNode
    {
        #region Fields
			#endregion
		
		#region Methods
		        
        void SyncToMain();
        
		        
        void Quit();
        
			#endregion
    }
}