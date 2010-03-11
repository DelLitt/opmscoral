
			 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using Caliburn.Core.Metadata;
using Caliburn.PresentationFramework.ApplicationModel;
using Caliburn.PresentationFramework.Screens;

namespace POSServer.ViewModels.ProductMaster
{
    public interface IProductMasterSearchViewModel : IScreenNode
    {
        #region Fields
		                
        public string ProductName
        {
            get;
            set;            
        }
		                
        public string ProductMasterId
        {
            get;
            set;            
        }
			#endregion
		
		#region Methods
		        
        public void Help();
        
		        
        public void Save();
        
		        
        public void Edit();
        
		        
        public void Stop();
        
		        
        public void Cancel();
        
		        
        public void ProductMasterSearch();
        
			#endregion
    }
}