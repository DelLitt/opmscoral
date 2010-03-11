
			 
using System;
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
		        
        public void Task();
        
		        
        public void ProductMaster();
        
		        
        public void Stock();
        
		        
        public void Report();
        
		        
        public void Management();
        
		        
        public void Utility();
        
		        
        public void Synchronize();
        
			#endregion
    }
}