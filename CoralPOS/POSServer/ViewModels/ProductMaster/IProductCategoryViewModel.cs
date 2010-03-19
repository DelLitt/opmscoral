
			 
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;

using Caliburn.PresentationFramework.ApplicationModel;
using Caliburn.PresentationFramework.Screens;
using CoralPOS.Models;
using POSServer.BusinessLogic.Implement;

namespace POSServer.ViewModels.ProductMaster
{
    public interface IProductCategoryViewModel : IScreenNode
    {
        #region Fields
		                
        string Description
        {
            get;
            set;            
        }
		                
        string CategoryName
        {
            get;
            set;            
        }
		                
        string CategoryId
        {
            get;
            set;            
        }
        Category SelectedProductCategory { get; set; }

        ICategoryLogic CategoryLogic { get; set; }
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