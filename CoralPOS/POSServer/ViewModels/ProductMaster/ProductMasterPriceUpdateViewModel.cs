using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using AppFrame.Base;
using AppFrame.CustomAttributes;
using AppFrame.Extensions;
using AppFrame.Invocation;
using AppFrame.Utils;
using AppFrame.Validation;
using AppFrame.WPF.Screens;
using AppFrame.WPF.ValidationAttributes;
using Caliburn.Micro;
using CoralPOS.Models;
using POSServer.BusinessLogic.Common;
using POSServer.BusinessLogic.Implement;
using POSServer.ViewModels.Menu.ProductMaster;

namespace POSServer.ViewModels.ProductMaster
{
	[AttachMenuAndMainScreen(typeof(ProductMasterMenuViewModel), typeof(ProductMasterMainViewModel))]
    [PerRequest]
	public class ProductMasterPriceUpdateViewModel : PosViewModel
	{

		private IShellViewModel _startViewModel;
		private IList<MainPrice> _allMainPriceList = new List<MainPrice>();
		public ProductMasterPriceUpdateViewModel()
		{
			_startViewModel = ShellViewModel.Current;
		}

		#region Fields

		private string _productName;
        
        [Autowired]
		public IMainPriceLogic MainPriceLogic
		{
            
			get;
			set;
		}

		public string ProductName
		{
			get
			{
				return _productName;
			}
			set
			{
				_productName = value;
				NotifyOfPropertyChange(() => ProductName);
			}
		}

		private string _productMasterId;
		public string ProductMasterId
		{
			get
			{
				return _productMasterId;
			}
			set
			{
				_productMasterId = value;
				NotifyOfPropertyChange(() => ProductMasterId);
			}
		}

		private string _WholeSalePrice;
		public string WholeSalePrice
		{
			get
			{
				return _WholeSalePrice;
			}
			set
			{
				_WholeSalePrice = value;
				NotifyOfPropertyChange(() => WholeSalePrice);
			}
		}

		private string _price;
		public string Price
		{
			get
			{
				return _price;
			}
			set
			{
				_price = value;
				NotifyOfPropertyChange(() => Price);
			}
		}
		#endregion

		#region List use to fetch object for view

		private IList _productTypeList;
		public IList ProductTypeList
		{
			get
			{
				return _productTypeList;
			}
			set
			{
				_productTypeList = value;
				NotifyOfPropertyChange(() => ProductTypeList);
			}
		}

		private IList _categoryList;
		public IList CategoryList
		{
			get
			{
				return _categoryList;
			}
			set
			{
				_categoryList = value;
				NotifyOfPropertyChange(() => CategoryList);
			}
		}

		private ProductType _selectedProductType;
		public ProductType SelectedProductType
		{
			get { return _selectedProductType; }
			set { _selectedProductType = value; NotifyOfPropertyChange(()=>SelectedProductType);}
		}
		private Category _selectedCategory;
		public Category SelectedCategory
		{
			get { return _selectedCategory; }
			set { _selectedCategory = value; NotifyOfPropertyChange(()=>SelectedCategory);}
		}

		#endregion

		#region List which just using in Data Grid

		private IList<MainPrice> _productMasterPriceList;
		public IList<MainPrice> ProductMasterPriceList
		{
			get
			{
				return _productMasterPriceList;
			}
			set
			{
				_productMasterPriceList = value;
				NotifyOfPropertyChange(() => ProductMasterPriceList);
			}
		}


		#endregion

		#region Methods

		protected override void OnInitialize()
		{
			ProductTypeList = new ArrayList();
			CategoryList = new ArrayList();
			ProductMasterPriceList = new List<MainPrice>();
			IList typeList = (IList)Flow.Session.Get(FlowConstants.PRODUCT_TYPE_LIST);
			IList catList = (IList)Flow.Session.Get(FlowConstants.CATEGORY_LIST);
			ProductType allProductType = new ProductType
											 {
												 TypeId = 0,
												 TypeName = "---- TẤT CẢ CHỦNG LOẠI ----"
											 };
			Category allCategory = new Category
									   {
										   CategoryId = 0,
										   CategoryName = "---- TẤT CẢ NHÓM ----"
									   };
			
			if (typeList.Count > 0)
			{
				IList preparedTypeList = new ArrayList();
				preparedTypeList.Add(allProductType);
				foreach (var type in typeList)
				{
					preparedTypeList.Add(type);
				}
				ProductTypeList = preparedTypeList;
			}
			if (catList.Count > 0)
			{
				IList preparedCatList = new ArrayList();
				preparedCatList.Add(allCategory);
				foreach (var type in catList)
				{
					preparedCatList.Add(type);
				}
				CategoryList = preparedCatList;
			}

			_allMainPriceList = (IList<MainPrice>)Flow.Session.Get(FlowConstants.MAINPRICE_LIST);
		}

		public void Help()
		{

		}

		public void Save()
		{
            IList<MainPrice> prices = ProductMasterPriceList;
		    ExecuteHelper.OnBackgroundThread(() => SavePrices(prices),CompleteSavePrices);
		}

	    private bool savedOk = false;
        void CompleteSavePrices(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            IoC.Get<INormalLoadViewModel>().StopLoading();
            if (savedOk) MessageBox.Show("Đã cập nhật giá thành công !!");
        }
	    private object SavePrices(IList<MainPrice> prices)
	    {
	        savedOk = false;
            IoC.Get<INormalLoadViewModel>().StartLoading();
            try
            {
                foreach (var price in prices)
                {
                    MainPriceLogic.Update(price);
                }
                savedOk = true;
            }
            catch (Exception)
            {
             
            }
	        return null;
	    }

	    public void Edit()
		{

		}

		public void Stop()
		{
			Flow.End();
		}

		public void Cancel()
		{

		}

		public void ProductMasterSearch()
		{

			IList<MainPrice> result = _allMainPriceList;
			if(!string.IsNullOrEmpty(ProductName))  result = _allMainPriceList.Where(price => price.ProductMaster.ProductName.IndexOf(ProductName) >=0).ToList<MainPrice>();
			if (SelectedCategory!= null && SelectedCategory.CategoryId > 0)
			{
				result = result.Where(price => price.ProductMaster.Category.CategoryId == SelectedCategory.CategoryId).ToList();
			}
			if (SelectedProductType != null && SelectedProductType.TypeId > 0)
			{
				result = result.Where(price => price.ProductMaster.ProductType.TypeId == SelectedProductType.TypeId).ToList();
			}
			ProductMasterPriceList =result;
		}

		public void button1()
		{

		}
		#endregion



	}
}