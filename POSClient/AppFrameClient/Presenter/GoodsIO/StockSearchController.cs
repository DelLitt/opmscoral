using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using AppFrame;
using AppFrame.Common;
using AppFrame.Logic;
using AppFrame.Model;
using AppFrame.Presenter.GoodsIO;
using AppFrame.Presenter.SalePoints;
using AppFrame.Utility;
using AppFrame.View.GoodsIO;
using NHibernate.Criterion;

namespace AppFrameClient.Presenter.GoodsIO
{
    public class StockSearchController : IStockSearchController
    {
        #region View use in IGoodsIOSearchController

        private IStockSearchView _stockSearchView;
        public IStockSearchView StockSearchView
        { 
            get
            {
                return _stockSearchView;
            }
            set
            {
                _stockSearchView = value;
                _stockSearchView.InitStockSearchEvent += new System.EventHandler<StockSearchEventArgs>(stockSearchView_InitStockSearchEvent);
                _stockSearchView.SearchStockEvent += new System.EventHandler<StockSearchEventArgs>(stockSearchView_SearchStockEvent);
                _stockSearchView.RemainSearchStockEvent += new System.EventHandler<StockSearchEventArgs>(stockSearchView_RemainSearchStockEvent);
            }
        }

        public void stockSearchView_RemainSearchStockEvent(object sender, StockSearchEventArgs e)
        {
            var criteria = new ObjectCriteria();
            criteria.AddEqCriteria("DelFlg", CommonConstants.DEL_FLG_NO);
            criteria.AddLikeCriteria("pm.ProductMasterId", e.ProductMasterId + "%");
            criteria.AddLikeCriteria("pm.ProductName", e.ProductMasterName + "%");
            criteria.AddEqCriteria("pm.ProductType", e.ProductType);
            criteria.AddEqCriteria("pm.ProductSize", e.ProductSize);
            criteria.AddEqCriteria("pm.ProductColor", e.ProductColor);
            criteria.AddEqCriteria("pm.Country", e.Country);
            criteria.AddEqCriteria("pm.Manufacturer", e.Manufacturer);
            criteria.AddEqCriteria("pm.Packager", e.Packager);
            criteria.AddEqCriteria("pm.Distributor", e.Distributor);
            criteria.AddGreaterOrEqualsCriteria("stockin.StockInDate", DateUtility.ZeroTime(e.FromDate));
            criteria.AddLesserOrEqualsCriteria("stockin.StockInDate", DateUtility.MaxTime(e.ToDate));

            IList minList = StockInDetailLogic.FindByQueryForRemainStock(criteria, true);
            IList maxList = StockInDetailLogic.FindByQueryForRemainStock(criteria, false);

        }

        #endregion

        public void stockSearchView_SearchStockEvent(object sender, StockSearchEventArgs e)
        {
            /*            var subCriteria1 = new SubObjectCriteria("Product");
                        var subCriteria2 = new SubObjectCriteria("ProductMaster");
                        subCriteria2.AddLikeCriteria("ProductMasterId", e.ProductMasterId);
                        subCriteria2.AddLikeCriteria("ProductName", e.ProductMasterName);*/

            var criteria = new ObjectCriteria(true);
            criteria.AddEqCriteria("stock.DelFlg", CommonConstants.DEL_FLG_NO);
            criteria.AddLikeCriteria("pm.ProductMasterId", e.ProductMasterId + "%");
            criteria.AddLikeCriteria("pm.ProductName", e.ProductMasterName + "%");
            criteria.AddEqCriteria("pm.ProductType", e.ProductType);
            criteria.AddEqCriteria("pm.ProductSize", e.ProductSize);
            criteria.AddEqCriteria("pm.ProductColor", e.ProductColor);
            criteria.AddEqCriteria("pm.Country", e.Country);
            criteria.AddEqCriteria("pm.Manufacturer", e.Manufacturer);
            criteria.AddEqCriteria("pm.Packager", e.Packager);
            criteria.AddEqCriteria("pm.Distributor", e.Distributor);
            IList list = StockLogic.FindByQuery(criteria);
            e.StockList = list;
        }

        public void stockSearchView_InitStockSearchEvent(object sender, StockSearchEventArgs e)
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

        #region Logic use in IStockCreateController
        public ICountryLogic CountryLogic { get; set; }
        public IProductColorLogic ProductColorLogic { get; set; }
        public IProductTypeLogic ProductTypeLogic { get; set; }
        public IProductSizeLogic ProductSizeLogic { get; set; }
        public IManufacturerLogic ManufacturerLogic { get; set; }
        public IDistributorLogic DistributorLogic { get; set; }
        public IPackagerLogic PackagerLogic { get; set; }
        public IStockLogic StockLogic { get; set; }
        public IStockInDetailLogic StockInDetailLogic { get; set; }
        #endregion

        #region Implementation of IBaseController<StockCreateEventArgs>

        public StockSearchEventArgs ResultEventArgs
        {
            get; set;
        }

        #endregion
    }
}
