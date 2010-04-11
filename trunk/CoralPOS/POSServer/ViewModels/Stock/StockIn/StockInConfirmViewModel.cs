			 

			 

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using AppFrame.Base;
using AppFrame.Utils;
using Caliburn.Core;
using Caliburn.Core.IoC;

using Caliburn.PresentationFramework.ApplicationModel;
using Caliburn.PresentationFramework.Filters;
using Caliburn.PresentationFramework.Screens;
using CoralPOS.Models;
using POSServer.BusinessLogic.Common;


namespace POSServer.ViewModels.Stock.StockIn
{
    
    public class StockInConfirmViewModel : PosViewModel,IStockInConfirmViewModel  
    {

        private IShellViewModel _startViewModel;
        public StockInConfirmViewModel(IShellViewModel startViewModel,bool _isViewOnly)
        {
            _startViewModel = startViewModel;
            IsViewOnly = _isViewOnly;
        }
		
		#region Fields

        private DateTime _createDate;
        public DateTime CreateDate
        {
            get
            {
                return _createDate;
            }
            set
            {
                _createDate = value;
                NotifyOfPropertyChange(() => CreateDate);
            }
        }
		        
        private string _description;
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                NotifyOfPropertyChange(() => Description);
            }
        }

        public bool IsViewOnly
        {
            get; set;
        }

        #endregion
		
		#region List use to fetch object for view
				#endregion
		
		#region List which just using in Data Grid
		        
        private IList _stockInDetailList;
        public IList StockInDetailList
        {
            get
            {
                return _stockInDetailList;
            }
            set
            {
                _stockInDetailList = value;
                NotifyOfPropertyChange(() => StockInDetailList);
            }
        }
				#endregion
		
		#region Methods
		        
        public void Help()
        {
            
        }
		        
        public void Back()
        {
            Flow.Back();
        }

        public bool CanSaveConfirm
        {
            get
            {
                return !IsViewOnly;
            }
        }

        [Preview("CanSaveConfirm")]
        public void SaveConfirm()
        {
            GoToNextNode();
        }
		        
        public void Stop()
        {
            Flow.End();
        }

        public override void Initialize()
        {
            base.Initialize();
            CoralPOS.Models.StockIn stockIn = Flow.Session.Get(FlowConstants.SAVE_STOCK_IN) as CoralPOS.Models.StockIn;
            Description = stockIn.Description;
            stockIn.TotalQuantity = 0;
            foreach (StockInDetail inDetail in stockIn.StockInDetails)
            {
                inDetail.StockIn = stockIn;
                stockIn.TotalQuantity += inDetail.Quantity;
            }
            StockInDetailList = ObjectConverter.ConvertFrom(stockIn.StockInDetails);
            CreateDate = stockIn.CreateDate;

        }

        #endregion
		
        
        
    }
}