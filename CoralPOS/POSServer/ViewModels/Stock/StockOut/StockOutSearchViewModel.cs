			 

			 

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
            
        }
		        
        public void Stop()
        {
           Flow.End(); 
        }
		        
        public void Search()
        {
            Execute.OnBackgroundThread(() => FindStockOuts(null), CompletedLoadProductMaster);

            
        }

        private void FindStockOuts(object criteria)
        {
            
            ServiceLocator.Current.GetInstance<ICircularLoadViewModel>().StartLoading();
            IList<CoralPOS.Models.StockOut> stockOuts = StockOutLogic.FindByCriteria(criteria);
            StockOutList = ObjectConverter.ConvertFrom(stockOuts);
        }
        void CompletedLoadProductMaster(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            ServiceLocator.Current.GetInstance<ICircularLoadViewModel>().StopLoading();
        }

				#endregion
		
        
        
    }
}