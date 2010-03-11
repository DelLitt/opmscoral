
			 
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
    public interface IProductTypeViewModel : IScreenNode
    {
        #region Fields
		                
        public string Description
        {
            get;
            set;            
        }
		                
        public string TypeName
        {
            get;
            set;            
        }
		                
        public string TypeId
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