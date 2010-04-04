			 

			 

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
using Caliburn.PresentationFramework.Screens;
using CoralPOS.Models;
using POSServer.BusinessLogic.Common;


namespace POSServer.ViewModels.Stock.StockOut
{
    [PerRequest(typeof(IStockOutConfirmViewModel))]
    public class StockOutConfirmViewModel : PosViewModel,IStockOutConfirmViewModel  
    {

        private IShellViewModel _startViewModel;
        public StockOutConfirmViewModel(IShellViewModel startViewModel)
        {
            _startViewModel = startViewModel; 
        }
		
		#region Fields
		        
        private string _createDate;
        public string CreateDate
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
		        
        private string _department;
        public string Department
        {
            get
            {
                return _department;
            }
            set
            {
                _department = value;
                NotifyOfPropertyChange(() => Department);
            }
        }
				#endregion
		
		#region List use to fetch object for view
				#endregion
		
		#region List which just using in Data Grid
		        
        private IList _stockOutList;
        public IList StockOutList
        {
            get
            {
                return _stockOutList;
            }
            set
            {
                _stockOutList = value;
                NotifyOfPropertyChange(() => StockOutList);
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
            CoralPOS.Models.StockOut stockOut = Flow.Session.Get(FlowConstants.SAVE_STOCK_OUT) as CoralPOS.Models.StockOut;
            //Description = stockIn.Description;
            foreach (StockOutDetail outDetail in stockOut.StockOutDetails)
            {
                outDetail.StockOut = stockOut;
            }
            StockOutList = ObjectConverter.ConvertFrom(stockOut.StockOutDetails);
            CreateDate = stockOut.CreateDate.ToString();
        }
				#endregion
		
        
        
    }
}