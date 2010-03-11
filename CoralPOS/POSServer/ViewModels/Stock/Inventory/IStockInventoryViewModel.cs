
			 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using Caliburn.Core.Metadata;
using Caliburn.PresentationFramework.ApplicationModel;
using Caliburn.PresentationFramework.Screens;

namespace POSServer.ViewModels.Stock.Inventory
{
    public interface IStockInventoryViewModel : IScreenNode
    {
        #region Fields
		                
        public string CreateDate
        {
            get;
            set;            
        }
		                
        public string Barcode
        {
            get;
            set;            
        }
		                
        public string Description
        {
            get;
            set;            
        }
			#endregion
		
		#region Methods
		        
        public void Help();
        
		        
        public void TempLoad();
        
		        
        public void TempSave();
        
		        
        public void Stop();
        
		        
        public void button1();
        
		        
        public void SaveResult();
        
		        
        public void Delete();
        
		        
        public void Reset();
        
		        
        public void InputByFile();
        
			#endregion
    }
}