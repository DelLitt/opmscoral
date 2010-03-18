using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using Caliburn.Core.IoC;
using Caliburn.PresentationFramework.ApplicationModel;
using Caliburn.PresentationFramework.Screens;
using POSServer.BusinessLogic.Implement;

namespace POSServer.ViewModels.ProductMaster
{
    public interface IExProductSizeViewModel : IScreenNode
    {
        #region Fields
        string Description
        {
            get;
            set;            
        }
		                
        string SizeName
        {
            get;
            set;            
        }
		                
        string SizeId
        {
            get;
            set;            
        }

        IExProductSizeLogic ProductSizeLogic { get; set; }
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