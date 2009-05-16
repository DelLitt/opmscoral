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
using AppFrameClient.Utility;
using NHibernate.Criterion;

namespace AppFrameClient.Presenter.GoodsIO.DepartmentStockData
{
    public class DepartmentPriceUpdateController : IDepartmentPriceUpdateController
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #region View use in IDepartmentPriceUpdateController

        private IDepartmentPriceUpdateView _departmentPriceUpdateView;
        public IDepartmentPriceUpdateView DepartmentPriceUpdateView
        { 
            get
            {
                return _departmentPriceUpdateView;
            }
            set
            {
                _departmentPriceUpdateView = value;
                _departmentPriceUpdateView.SaveDepartmentPriceEvent += new System.EventHandler<DepartmentPriceUpdateEventArgs>(departmentStockDetailView_SaveDepartmentPriceEvent);
                _departmentPriceUpdateView.SearchDepartmentPriceEvent += new System.EventHandler<DepartmentPriceUpdateEventArgs>(departmentStockDetailView_SearchDepartmentPriceEvent);
                _departmentPriceUpdateView.InitDepartmentPriceEvent += new System.EventHandler<DepartmentPriceUpdateEventArgs>(departmentStockDetailView_InitDepartmentPriceUpdateEvent);
            }
        }

        #endregion

        public void departmentStockDetailView_InitDepartmentPriceUpdateEvent(object sender, DepartmentPriceUpdateEventArgs e)
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
            e.PackagerList = PackagerLogic.FindAll(criteria);
            e.PackagerList.Insert(0, new Packager());
            e.DistributorList = DistributorLogic.FindAll(criteria);
            e.DistributorList.Insert(0, new Distributor());
        }

        public void departmentStockDetailView_SearchDepartmentPriceEvent(object sender, DepartmentPriceUpdateEventArgs e)
        {
            var subCriteria = new SubObjectCriteria("ProductMaster");
            subCriteria.AddLikeCriteria("ProductMasterId", e.ProductMasterId + "%");
            subCriteria.AddLikeCriteria("ProductName", e.ProductMasterName + "%");
            subCriteria.AddEqCriteria("ProductType", e.ProductType);
            subCriteria.AddEqCriteria("ProductSize",  e.ProductSize);
            subCriteria.AddEqCriteria("ProductColor", e.ProductColor);
            subCriteria.AddEqCriteria("Country", e.Country);
            subCriteria.AddEqCriteria("Packager", e.Packager);
            subCriteria.AddEqCriteria("Manufacturer", e.Manufacturer);
            subCriteria.AddEqCriteria("Distributor", e.Distributor);

            var criteria = new ObjectCriteria();
            criteria.AddEqCriteria("DelFlg", CommonConstants.DEL_FLG_NO);
            criteria.AddSubCriteria("ProductMaster", subCriteria);
            criteria.AddEqCriteria("DepartmentPricePK.DepartmentId", CurrentDepartment.Get().DepartmentId);

            e.DepartmentPriceList = DepartmentPriceLogic.FindAll(criteria);
        }

        public void departmentStockDetailView_SaveDepartmentPriceEvent(object sender, DepartmentPriceUpdateEventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            foreach (DepartmentPrice price in e.DepartmentPriceList)
            {
                price.UpdateDate = DateTime.Now;
                price.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                DepartmentPriceLogic.Update(price);
                sb.Append(price.ToString()).Append("\r\n");
            }
            ClientUtility.Log(logger, sb.ToString(), CommonConstants.ACTION_UPDATE_PRICE);
        }

        #region Logic use in IDepartmentPriceUpdateController
        public IDepartmentPriceLogic DepartmentPriceLogic { get; set; }
        public ICountryLogic CountryLogic { get; set; }
        public IProductColorLogic ProductColorLogic { get; set; }
        public IProductTypeLogic ProductTypeLogic { get; set; }
        public IProductSizeLogic ProductSizeLogic { get; set; }
        public IManufacturerLogic ManufacturerLogic { get; set; }
        public IDistributorLogic DistributorLogic { get; set; }
        public IPackagerLogic PackagerLogic { get; set; }
        #endregion

        #region Implementation of IBaseController<DepartmentPriceUpdateEventArgs>

        public DepartmentPriceUpdateEventArgs ResultEventArgs
        {
            get; set;
        }

        #endregion

    }
}