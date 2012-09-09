			 

			 

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using AppFrame.Base;
using AppFrame.DataLayer;
using AppFrame.Utils;
using AppFrame.WPF;
using AppFrame.WPF.Screens;
using Caliburn.Micro;
using CoralPOS.Models;
using POSServer.BusinessLogic.Implement;


namespace POSServer.ViewModels.Dialogs
{
	
	public class StockProductPropertiesViewModel : PosViewModel
	{

		private IShellViewModel _startViewModel;
		private IList _productColorList;
		private IList _stockList;

		private IList _productSizeList;

		private IList _extraProductColorList;

		private IList _extraProductSizeList;

		private IList _selectedProductColors;

		private IList _selectedProductSizes;

		private IList _extraSelectedProductColors;

		private IList _extraSelectedProductSizes;

		public StockProductPropertiesViewModel()
		{
			_startViewModel = ShellViewModel.Current;
		}
		
		#region Fields

		public IList ProductColorList
		{
			get { return _productColorList; }
			set
			{
				_productColorList = value;
				NotifyOfPropertyChange(() => ProductColorList);
			}
		}

		public IList ProductSizeList
		{
			get { return _productSizeList; }
			set
			{
				_productSizeList = value;
				NotifyOfPropertyChange(() => ProductSizeList);
			}
		}

		public IList ExtraProductColorList
		{
			get { return _extraProductColorList; }
			set
			{
				_extraProductColorList = value;
				NotifyOfPropertyChange(() => ExtraProductColorList);
			}
		}

		public IList ExtraProductSizeList
		{
			get { return _extraProductSizeList; }
			set
			{
				_extraProductSizeList = value;
				NotifyOfPropertyChange(() => ExtraProductSizeList);
			}
		}

		public IList SelectedProductColors
		{
			get { return _selectedProductColors; }
			set { _selectedProductColors = value; }
		}

		public IList SelectedProductSizes
		{
			get { return _selectedProductSizes; }
			set { _selectedProductSizes = value; }
		}

		public IList ExtraSelectedProductColors
		{
			get { return _extraSelectedProductColors; }
			set { _extraSelectedProductColors = value; }
		}

		public IList ExtraSelectedProductSizes
		{
			get { return _extraSelectedProductSizes; }
			set { _extraSelectedProductSizes = value; }
		}

		public string ProductName { get; set; }
		#endregion

        #region dependency object
        public IExProductColorLogic ProductColorLogic { get; set; }
        public IExProductSizeLogic ProductSizeLogic { get; set; }
        public IProductLogic ProductLogic { get; set; }
        public IMainStockLogic MainStockLogic { get; set; }
        public IProductMasterLogic ProductMasterLogic { get; set; }
        #endregion
        
        public event EventHandler<ProductEventArgs> ConfirmEvent;

        #region List use to fetch object for view
        #endregion

        #region List which just using in Data Grid
        #endregion

        #region Methods




        public IResult LoadData()
		{
			return new FlowBackgroundTaskResult<INormalLoadViewModel, FlowBackgroundTaskResultEventArgs>(Setup);
		}
		public void Setup()
		{
			
			string productName = ProductName;
			
			LinqCriteria<MainStock> crit = new LinqCriteria<MainStock>();
			crit.AddCriteria(stk => stk.ProductMaster.ProductName == productName);
			crit.AddCriteria(stk => stk.Quantity > 0);
			/*crit.Fetch(i => i.Product);
			crit.Fetch(i => i.ProductMaster);
			crit.Fetch(i => i.ProductMaster.ProductType);*/
			_stockList = (IList) MainStockLogic.FetchAll(crit);
			//IList colors = MainStockLogic.GetColorsFromAvailProductInStock(productName);
			//IList sizes = MainStockLogic.GetSizesFromAvailProductInStock(productName);
			IList<MainStock> _stocks = ObjectConverter.ConvertTo<MainStock>(_stockList);
			IList colors = _stocks.Select(s => s.Product.ProductColor).Distinct().ToList();
			IList sizes = _stocks.Select(s => s.Product.ProductSize).Distinct().ToList();
			ProductColorList = colors;
			ProductSizeList = sizes;
			SelectedProductColors = new ArrayList();
			SelectedProductSizes = new ArrayList();
			
		}
		
		public void Confirm()
		{
			ProductEventArgs eventArgs = new ProductEventArgs();
			eventArgs.ProductColorList = SelectedProductColors;
			eventArgs.ProductSizeList = SelectedProductSizes;
			eventArgs.StockList = _stockList as IList;
			if(ConfirmEvent!=null) ConfirmEvent(this, eventArgs);
			_startViewModel.HideDialog(this);
			//Shutdown();
		}

		public void Cancel()
		{
			_startViewModel.HideDialog(this);
			//Shutdown();
		}

		protected void OnShutdown()
		{
			//base.On//Shutdown();
			
		}

		public void ProgressKeyUp(object source,KeyEventArgs eventArgs)
		{
			DataGrid dataGrid = (DataGrid) source;
			if(eventArgs.Key == Key.D0 || eventArgs.Key == Key.NumPad0)
			{
				dataGrid.SelectAll();
			}
			if ((eventArgs.Key >= Key.NumPad1 && eventArgs.Key <= Key.NumPad9)
			   || (eventArgs.Key >= Key.D1 && eventArgs.Key <= Key.D9))
			{
				KeyConverter converter = new KeyConverter();

				try
				{
					int select = Int32.Parse(converter.ConvertToString(eventArgs.Key));
					DataGridRow row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromItem(dataGrid.Items[select - 1]);
					row.IsSelected = !row.IsSelected;
				}
				catch (Exception exception)
				{

				}
			}
			
		}

		public void AddToAvailList(int listType,KeyEventArgs eventArgs)
		{
			if(eventArgs.Key == Key.OemPlus || eventArgs.Key == Key.Add)
			{
				if(listType == 1)
				{
					IList addList = ExtraSelectedProductColors;
					IList list = new ArrayList(_productColorList);
					ObjectUtility.AddToList<ExProductColor>(list,addList,pm => pm.ColorName);
					ProductColorList = list;
				}
				else
				{
					IList addList = ExtraSelectedProductSizes;
					IList list = new ArrayList(_productSizeList);
					ObjectUtility.AddToList<ExProductSize>(list, addList, pm => pm.SizeName);
					ProductSizeList = list;
				}
			}
		}
		#endregion
		
		
		
	}
}