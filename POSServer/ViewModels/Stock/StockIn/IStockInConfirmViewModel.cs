
			 
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;

using Caliburn.PresentationFramework.ApplicationModel;
using Caliburn.PresentationFramework.Screens;
using POSServer.BusinessLogic.Implement;

namespace POSServer.ViewModels.Stock.StockIn
{
    public interface IStockInConfirmViewModel : IScreenNode
    {
        #region Fields

        DateTime CreateDate
        {
            get;
            set;            
        }
		                
        string Description
        {
            get;
            set;            
        }
        
        bool IsViewOnly { get; set; }

        bool ContinousPrint { get; set; }
        bool PricePrint { get; set; }
        bool FollowQuantityPrint { get; set; }
        int BarcodeNumbers { get; set; }
        string Barcode { get; set; }
        string BarcodeText { get; set; }
        IList StockInDetailList { get; set; }
        IList SelectedStockInDetails { get; set; }
        IMainPriceLogic MainPriceLogic { get; set; }

        #endregion
		
		#region Methods
		        
        void Help();
        
		        
        void Back();
        
		        
        void SaveConfirm();
        
		        
        void Stop();

        void PrintBarcode();
        
			#endregion
    }
}