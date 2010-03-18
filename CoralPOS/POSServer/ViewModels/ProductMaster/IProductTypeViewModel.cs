
			 
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;

using Caliburn.PresentationFramework.ApplicationModel;
using Caliburn.PresentationFramework.Screens;
using POSServer.BusinessLogic.Implement;

namespace POSServer.ViewModels.ProductMaster
{
    public interface IProductTypeViewModel : IScreenNode
    {
        #region Fields
		                
        string Description
        {
            get;
            set;            
        }
		                
        string TypeName
        {
            get;
            set;            
        }
		                
        string TypeId
        {
            get;
            set;            
        }
        IProductTypeLogic ProductTypeLogic { get; set; }
			#endregion
		
		#region Methods
		        
        void Help();
        
		        
        void Delete();
        
		        
        void Edit();
        
		        
        void Stop();
        
		        
        void Create();
        
			#endregion
    }
}