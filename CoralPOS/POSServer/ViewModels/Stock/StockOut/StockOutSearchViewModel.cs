			 

			 

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using AppFrame.Base;
using AppFrame.Utils;
using AppFrame.WPF.Screens;
using Caliburn.Core;
using Caliburn.Core.IoC;

using Caliburn.PresentationFramework.ApplicationModel;
using Caliburn.PresentationFramework.Invocation;
using Caliburn.PresentationFramework.Screens;
using Microsoft.Practices.ServiceLocation;
using POSServer.BusinessLogic.Common;
using POSServer.BusinessLogic.Implement;


namespace POSServer.ViewModels.Stock.StockOut
{
    
    public class StockOutSearchViewModel : PosViewModel,IStockOutSearchViewModel  
    {

        private IShellViewModel _startViewModel;
        public StockOutSearchViewModel(IShellViewModel startViewModel)
        {
            _startViewModel = startViewModel; 
        }
		
		#region Fields
		        
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
		        
        private string _textBox2;
        public string textBox2
        {
            get
            {
                return _textBox2;
            }
            set
            {
                _textBox2 = value;
                NotifyOfPropertyChange(() => textBox2);
            }
        }

        private CoralPOS.Models.StockOut _selectedStockOut;
        public CoralPOS.Models.StockOut SelectedStockOut
        {
            get
            {
                return _selectedStockOut;
            }
            set
            {
                _selectedStockOut = value;
                NotifyOfPropertyChange(() => SelectedStockOut);
            }
        }

        public IStockOutLogic StockOutLogic
        {
            get; set;
        }

        #endregion
		
		#region List use to fetch object for view
		        
        private IList _category;
        public IList Category
        {
            get
            {
                return _category;
            }
            set
            {
                _category = value;
                NotifyOfPropertyChange(() => Category);
            }
        }
		        
        private IList _department;
        public IList Department
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
		        
        public void ViewDetail()
        {
            if (_selectedStockOut != null && _selectedStockOut.StockOutId > 0 )
            {
                CoralPOS.Models.StockOut stockOut = SelectedStockOut;
                Flow.Session.Put(FlowConstants.STOCK_OUT_SEARCH_RESULT, StockOutList);
                stockOut = StockOutLogic.Fetch(stockOut);
                Flow.Session.Put(FlowConstants.SAVE_STOCK_OUT, stockOut);
                GoToNextNode();
            }
        }
		        
        public void Stop()
        {
           Flow.End(); 
        }
		        
        public void Search()
        {
            Execute.OnBackgroundThread(() => FindStockOuts(null), CompletedLoadStockOuts);
        }

        private void FindStockOuts(object criteria)
        {
            
            ServiceLocator.Current.GetInstance<ICircularLoadViewModel>().StartLoading();
            IList<CoralPOS.Models.StockOut> stockOuts = StockOutLogic.FindByMultiCriteria(null);
            StockOutList = ObjectConverter.ConvertFrom(stockOuts);
        }
        void CompletedLoadStockOuts(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            ServiceLocator.Current.GetInstance<ICircularLoadViewModel>().StopLoading();
        }

        public override void Initialize()
        {
            IList searchedStockOut = Flow.Session.Get(FlowConstants.STOCK_OUT_SEARCH_RESULT) as IList;
            CoralPOS.Models.StockOut selectedStockOut = Flow.Session.Get(FlowConstants.SAVE_STOCK_OUT) as CoralPOS.Models.StockOut;
            if (searchedStockOut == null)
            {
                SelectedStockOut = new CoralPOS.Models.StockOut();
            }
            else
            {
                if(selectedStockOut!=null) SelectedStockOut = selectedStockOut;
                else
                {
                    SelectedStockOut = new CoralPOS.Models.StockOut();
                }
            }
        }

        #endregion
		
        
        
    }
}