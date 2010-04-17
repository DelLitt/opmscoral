using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using AppFrame;
using AppFrame.Common;
using AppFrame.Logic;
using AppFrame.Model;
using AppFrame.Presenter.GoodsIO;
using AppFrame.Presenter.GoodsIO.DepartmentGoodsIO;
using AppFrame.Presenter.SalePoints;
using AppFrame.Utility;
using AppFrame.View.GoodsIO;
using AppFrame.View.GoodsIO.DepartmentGoodsIO;
using NHibernate.Criterion;

namespace AppFrameClient.Presenter.GoodsIO.DepartmentStockData
{
    public class DepartmentStockSearchController : IDepartmentStockSearchController
    {
        #region View use in IGoodsIOSearchController

        private IDepartmentStockSearchView _departmentStockSearchView;
        public IDepartmentStockSearchView DepartmentStockSearchView
        { 
            get
            {
                return _departmentStockSearchView;
            }
            set
            {
                _departmentStockSearchView = value;
                _departmentStockSearchView.InitDepartmentStockSearchEvent += new System.EventHandler<DepartmentStockSearchEventArgs>(stockSearchView_InitStockSearchEvent);
                _departmentStockSearchView.SearchDepartmentStockEvent += new System.EventHandler<DepartmentStockSearchEventArgs>(stockSearchView_SearchStockEvent);
            }
        }

        #endregion

        public void stockSearchView_SearchStockEvent(object sender, DepartmentStockSearchEventArgs e)
        {
            var criteria = new SubObjectCriteria("ProductMaster");
            if (!string.IsNullOrEmpty(e.ProductMasterId))
            {
                criteria.AddLikeCriteria("ProductMasterId", "%" + e.ProductMasterId + "%");
            }
            criteria.AddEqCriteria("DelFlg", CommonConstants.DEL_FLG_NO);
            criteria.AddLikeCriteria("ProductName", "%" +e.ProductMasterName + "%");
            if (e.ProductType != null && e.ProductType.TypeId > 0)
            {
                criteria.AddEqCriteria("ProductType.TypeId", e.ProductType.TypeId);
            }
            if (e.ProductSize != null && e.ProductSize.SizeId > 0)
            {
                criteria.AddEqCriteria("ProductSize.SizeId", e.ProductSize.SizeId);
            }
            if (e.ProductColor != null && e.ProductColor.ColorId > 0)
            {
                criteria.AddEqCriteria("ProductColor.ColorId", e.ProductColor.ColorId);
            }
            if (e.Country != null && e.Country.CountryId > 0)
            {
                criteria.AddEqCriteria("Country.CountryId", e.Country.CountryId);
            }
            if (!string.IsNullOrEmpty(e.Description))
            {
                criteria.AddLikeCriteria("Description", "%" + e.Description +"%");
            }
            criteria.AddOrder("ProductName",true);

            var objectCriteria = new ObjectCriteria(true);
            objectCriteria.AddEqCriteria("DelFlg", (long)0);
            if (!string.IsNullOrEmpty(e.ProductId))
            {
                objectCriteria.AddLikeCriteria("DepartmentStockPK.ProductId", "%" + e.ProductMasterId + "%");   
            }
            objectCriteria.AddEqCriteria("DepartmentStockPK.DepartmentId", CurrentDepartment.Get().DepartmentId);
            objectCriteria.AddSubCriteria("ProductMaster",criteria);

            IList departmentStocks = DepartmentStockLogic.FindAll(objectCriteria);
            IList stockViewList = new ArrayList();
            // create stock view
            if (departmentStocks != null && departmentStocks.Count > 0)
            {
                DepartmentStockView stockView = null;
                foreach (DepartmentStock departmentStock in departmentStocks)
                {
                    if (stockView!=null)
                    {
                       if(!stockView.ProductMaster.ProductName.Equals(
                           departmentStock.Product.ProductMaster.ProductName))
                       {
                           stockViewList.Add(stockView);
                           stockView = null;
                       }
                    }
                    if(stockView == null)
                    {
                        stockView = new DepartmentStockView();
                        stockView.ProductMaster = departmentStock.Product.ProductMaster;
                        stockView.DepartmentStocks = new ArrayList();
                    }

                    stockView.DepartmentStocks.Add(departmentStock);
                    stockView.Quantity += departmentStock.Quantity;
                    stockView.GoodQuantity += departmentStock.GoodQuantity;
                    
                }
                // add last item
                if(stockView!=null)
                {
                    stockViewList.Add(stockView);
                    stockView = null;
                }
                e.DepartmentStockList = stockViewList;
            }

        }

        public void stockSearchView_InitStockSearchEvent(object sender, DepartmentStockSearchEventArgs e)
        {
            var criteria = new ObjectCriteria();
            criteria.AddEqCriteria("DelFlg", (long)0);
            e.ProductTypeList = ProductTypeLogic.FindAll(criteria);
            e.ProductTypeList.Insert(0, new ProductType());
            e.ProductSizeList = ProductSizeLogic.FindAll(criteria);
            e.ProductSizeList.Insert(0, new ProductSize());
            e.ProductColorList = ProductColorLogic.FindAll(criteria);
            e.ProductColorList.Insert(0, new ProductColor());
            e.ManufacturerList = ManufacturerLogic.FindAll(criteria);
            e.ManufacturerList.Insert(0, new Manufacturer());
            e.CountryList = CountryLogic.FindAll(criteria);
            e.CountryList.Insert(0, new Country());
        }

        #region Logic use in IStockCreateController
        public ICountryLogic CountryLogic { get; set; }
        public IProductColorLogic ProductColorLogic { get; set; }
        public IProductTypeLogic ProductTypeLogic { get; set; }
        public IProductSizeLogic ProductSizeLogic { get; set; }
        public IManufacturerLogic ManufacturerLogic { get; set; }
        public IDistributorLogic DistributorLogic { get; set; }
        public IPackagerLogic PackagerLogic { get; set; }
        public IDepartmentStockLogic DepartmentStockLogic { get; set; }
        #endregion

        #region Implementation of IBaseController<StockCreateEventArgs>

        public DepartmentStockSearchEventArgs ResultEventArgs
        {
            get; set;
        }

        #endregion
    }
}