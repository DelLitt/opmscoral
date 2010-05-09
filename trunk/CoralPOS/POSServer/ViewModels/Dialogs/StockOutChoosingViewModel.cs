			 

			 

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using AppFrame.Base;
using AppFrame.DataLayer;
using AppFrame.Utils;
using System.Linq;
using System.Linq.Expressions;
using Caliburn.Core;
using Caliburn.Core.IoC;
using Caliburn.PresentationFramework.ApplicationModel;
using Caliburn.PresentationFramework.Screens;
using CoralPOS.Models;
using POSServer.BusinessLogic.Implement;


namespace POSServer.ViewModels.Dialogs
{
    public class StockOutChoosingViewModel : PosViewModel,IStockOutChoosingViewModel  
    {
        
        private IShellViewModel _startViewModel;
        public StockOutChoosingViewModel(IShellViewModel startViewModel)
        {
            _startViewModel = startViewModel; 
        }
		
		#region Fields

        
        IStockInLogic StockInLogic { get; set; }
				#endregion
		
		#region List use to fetch object for view
				#endregion
		
		#region List which just using in Data Grid
		        
        private IList _stockInList;
        public IList StockInList
        {
            get
            {
                return _stockInList;
            }
            set
            {
                _stockInList = value;
                NotifyOfPropertyChange(() => StockInList);
            }
        }
				#endregion
		
		#region Methods

        public StockIn SelectedStockIn
        {
            get; set;
        }

        public void Close()
        {
            Shutdown();
        }
		        
        public void Search()
        {
            StockInCriteria criteria = new StockInCriteria
                                           {
                                               FromDate = FromDate,
                                               ToDate = ToDate
                                           };
            IList<StockIn> list = StockInLogic.FindByMultiCriteria(criteria);
            StockInList = ObjectConverter.ConvertFrom(list);
        }

        public DateTime ToDate { get; set; }
        public DateTime FromDate { get; set; }
        public event EventHandler<StockInChoosingArg> ConfirmEvent;
        public void Choose()
        {
            StockIn stockIn = StockInLogic.Fetch(SelectedStockIn);
            StockInLogic.FetchMainStock(stockIn);
                                     
            StockInChoosingArg eventArgs = new StockInChoosingArg();
            eventArgs.SelectedStockIn = stockIn;
            if (ConfirmEvent != null) ConfirmEvent(this, eventArgs);
            Shutdown();
        }

        public override void Initialize()
        {
            FromDate = DateTime.Now;
            ToDate = DateTime.Now;
        }

        #endregion
		
        
        
    }

    public class StockInChoosingArg : EventArgs
    {
        public StockIn SelectedStockIn { get; set; }
    }
}