﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using AppFrame.Common;
using CoralPOS.Interfaces.Common;
using CoralPOS.Interfaces.Logic;
using CoralPOS.Interfaces.Presenter.GoodsIO;
using CoralPOS.Interfaces.Presenter.SalePoints;
using AppFrame.Utility;
using CoralPOS.Interfaces.View.GoodsIO;
using AppFrame;
using CoralPOS.Interfaces.Model;
using CoralPOS.Common;
using CoralPOSClient.View.GoodsIO;

namespace CoralPOSClient.Presenter.GoodsIO
{
    public class ProductMasterSearchOrCreateController : IProductMasterSearchOrCreateController
    {
        #region View use in IProductMasterController

        private IProductMasterSearchOrCreateView _productMasterSearchOrCreateView;
        public IProductMasterSearchOrCreateView ProductMasterSearchOrCreateView
        { 
            get
            {
                return _productMasterSearchOrCreateView;
            }
            set
            {
                _productMasterSearchOrCreateView = value;
                _productMasterSearchOrCreateView.SaveProductMasterEvent += new System.EventHandler<ProductMasterSearchOrCreateEventArgs>(productMasterView_SaveProductMasterEvent);
                _productMasterSearchOrCreateView.InitProductMasterSearchOrCreateEvent += new System.EventHandler<ProductMasterSearchOrCreateEventArgs>(productMasterView_InitProductMasterSearchOrCreateEvent);
                _productMasterSearchOrCreateView.SearchProductMasterEvent += new System.EventHandler<ProductMasterSearchOrCreateEventArgs>(productMasterView_SearchProductMasterEvent);
                _productMasterSearchOrCreateView.SelectProductMasterEvent += new System.EventHandler<ProductMasterSearchOrCreateEventArgs>(productMasterView_SelectProductMasterEvent);
                _productMasterSearchOrCreateView.OpenProductMasterSearchOrCreateEvent += new System.EventHandler<ProductMasterSearchOrCreateEventArgs>(productMasterView_OpenProductMasterSearchOrCreateEvent);
            }
        }

        public void productMasterView_OpenProductMasterSearchOrCreateEvent(object sender, ProductMasterSearchOrCreateEventArgs e)
        {
            var productMasterForm = GlobalUtility.GetOnlyChildFormObject<ProductMasterSearchOrCreateForm>(e.ParentForm, FormConstants.PRODUCT_MASTER_SEARCH_OR_CREATE_FORM);
            productMasterForm.ShowDialog();
            e.ProductMaster = productMasterForm.SelectedProductMaster;
        }

        private void productMasterView_SelectProductMasterEvent(object sender, ProductMasterSearchOrCreateEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void productMasterView_SearchProductMasterEvent(object sender, ProductMasterSearchOrCreateEventArgs e)
        {
            var criteria = new ObjectCriteria();
            if (!string.IsNullOrEmpty(e.ProductMasterId)) 
            {
                /*long value = 0;
                Int64.TryParse(e.ProductMasterId, out value);*/
                criteria.AddEqCriteria("ProductMasterId", e.ProductMasterId); 
            }
            criteria.AddEqCriteria("DelFlg", CommonConstants.DEL_FLG_NO);
            criteria.AddLikeCriteria("ProductName", e.ProductMasterName + "%");
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
            
            e.ProductMasterList = ProductMasterLogic.FindAll(criteria);
        }

        private void productMasterView_InitProductMasterSearchOrCreateEvent(object sender, ProductMasterSearchOrCreateEventArgs e)
        {
            var criteria = new ObjectCriteria();
            criteria.AddEqCriteria("DelFlg", (long)0);
            e.ProductTypeList = ProductTypeLogic.FindAll(criteria);
            e.ProductTypeList.Insert(0, new ProductType());
            e.ProductSizeList = ProductSizeLogic.FindAll(criteria);
            e.ProductSizeList.Insert(0, new ProductSize());
            e.ProductColorList = ProductColorLogic.FindAll(criteria);
            e.ProductColorList.Insert(0, new ProductColor());
            e.CountryList = CountryLogic.FindAll(criteria);
            e.CountryList.Insert(0, new Country());
            e.ManufacturerList = ManufacturerLogic.FindAll(criteria);
            e.ManufacturerList.Insert(0, new Manufacturer());
            e.PackagerList = PackagerLogic.FindAll(criteria);
            e.PackagerList.Insert(0, new Packager());
            e.DistributorList = DistributorLogic.FindAll(criteria);
            e.DistributorList.Insert(0, new Distributor());
        }

        private void productMasterView_SaveProductMasterEvent(object sender, ProductMasterSearchOrCreateEventArgs e)
        {
            e.ProductMaster.CreateDate = DateTime.Now;
            e.ProductMaster.UpdateDate = DateTime.Now;
            e.ProductMaster = ProductMasterLogic.Add(e.ProductMaster);
        }

        #endregion

        #region Implementation of IBaseController<ProductMasterEventArgs>

        public ProductMasterEventArgs ResultEventArgs
        {
            get ;
            set ;
        }

        #endregion

        #region Implementation of IProductMasterSearchOrCreateController

        public IProductMasterLogic ProductMasterLogic
        {
            get;
            set;
        }

        public ICountryLogic CountryLogic
        {
            get ;
            set ;
        }

        public IProductColorLogic ProductColorLogic
        {
            get ;
            set ;
        }

        public IProductTypeLogic ProductTypeLogic
        {
            get ;
            set ;
        }

        public IProductSizeLogic ProductSizeLogic
        {
            get ;
            set ;
        }

        public IManufacturerLogic ManufacturerLogic
        {
            get ;
            set ;
        }

        public IDistributorLogic DistributorLogic
        {
            get ;
            set ;
        }

        public IPackagerLogic PackagerLogic
        {
            get ;
            set ;
        }

        #endregion
    }
}