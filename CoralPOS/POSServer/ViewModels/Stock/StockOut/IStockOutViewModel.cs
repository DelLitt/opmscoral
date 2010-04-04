
			 
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;

using Caliburn.PresentationFramework.ApplicationModel;
using Caliburn.PresentationFramework.Screens;
using CoralPOS.Models;

namespace POSServer.ViewModels.Stock.StockOut
{
    public interface IStockOutViewModel : IScreenNode
    {
        #region Fields
		                
        DateTime CreateDate
        {
            get;
            set;            
        }

        CoralPOS.Models.ProductMaster ProductMaster
        {
            get;
            set;            
        }
        Department Department { get; set; }                
        string Description
        {
            get;
            set;            
        }
        string ProductNameText { get; set; }
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