
			 
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
    public interface IProductMasterMenuViewModel : IScreenNode
    {
        #region Fields
			#endregion
		
		#region Methods
		        
        public void ProductMasterNew();
        
		        
        public void ProductMasterSearch();
        
		        
        public void BackToParent();
        
		        
        public void Back();
        
		        
        public void ProductMasterDetail();
        
			#endregion
    }
}