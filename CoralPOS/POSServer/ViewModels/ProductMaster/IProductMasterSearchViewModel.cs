
			 
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;

using AppFrame.CustomAttributes;
using AppFrame.CustomAttributes;

namespace POSServer.ViewModels.ProductMaster
{
    public interface IProductMasterSearchViewModel : IScreenNode
    {
        #region Fields
		                
        string ProductName
        {
            get;
            set;            
        }
		                
        string ProductMasterId
        {
            get;
            set;            
        }
			#endregion
		
		#region Methods
		        
        void Help();
        
		        
        void Save();
        
		        
        void Edit();
        
		        
        void Stop();
        
		        
        void Cancel();
        
		        
        void ProductMasterSearch();
        
			#endregion
    }
}