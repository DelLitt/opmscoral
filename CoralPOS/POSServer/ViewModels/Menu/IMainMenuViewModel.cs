
			 
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using Caliburn.Core.Metadata;
using Caliburn.PresentationFramework.ApplicationModel;
using Caliburn.PresentationFramework.Screens;

namespace POSServer.ViewModels.Menu
{
    public interface IMainMenuViewModel : IScreenNode
    {
        #region Fields
			#endregion
		
		#region Methods
		        
        void Task();
        
		        
        void ProductMaster();
        
		        
        void Stock();
        
		        
        void Report();
        
		        
        void Management();
        
		        
        void Utility();
        
		        
        void Synchronize();
        
			#endregion
    }
}