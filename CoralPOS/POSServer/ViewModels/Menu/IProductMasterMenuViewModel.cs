
			 
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using Caliburn.PresentationFramework.ApplicationModel;
using Caliburn.PresentationFramework.Screens;

namespace POSServer.ViewModels.Menu
{
    public interface IProductMasterMenuViewModel : IScreenNode
    {
        #region Fields
			#endregion
		
		#region Methods
		        
        void ProductMasterNew();
        
		        
        void ProductMasterSearch();
        
		        
        void BackToParent();
        
		        
        void Back();
        
		        
        void ProductMasterDetail();
        
			#endregion
    }
}