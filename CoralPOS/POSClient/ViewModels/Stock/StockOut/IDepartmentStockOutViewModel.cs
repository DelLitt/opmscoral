
			 
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using Caliburn.PresentationFramework.ApplicationModel;
using Caliburn.PresentationFramework.Screens;

namespace POSClient.ViewModels.Stock.StockOut
{
    public interface IDepartmentStockOutViewModel : IScreenNode
    {
        #region Fields
		                
        string CreateDate
        {
            get;
            set;            
        }
		                
        string ProductMaster
        {
            get;
            set;            
        }
		                
        string Description
        {
            get;
            set;            
        }
			#endregion
		
		#region Methods
		        
        void Help();
        
		        
        void Recreate();
        
		        
        void Save();
        
		        
        void Stop();
        
		        
        void CreateByBlock();
        
		        
        void CreateByFile();
        
		        
        void FixQuantityByAvailable();
        
			#endregion
    }
}