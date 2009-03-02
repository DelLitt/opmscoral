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
            }
        }

        #endregion

        public void stockSearchView_SearchStockEvent(object sender, StockSearchEventArgs e)
        {
/*            var subCriteria1 = new SubObjectCriteria("Product");
            var subCriteria2 = new SubObjectCriteria("ProductMaster");
            subCriteria2.AddLikeCriteria("ProductMasterId", e.ProductMasterId);
            subCriteria2.AddLikeCriteria("ProductName", e.ProductMasterName);

            var criteria = new ObjectCriteria();
            criteria.AddSubCriteria("Product", subCriteria1);
            criteria.AddSubCriteria("ProductMaster", subCriteria2);*/
            IList list = StockLogic.FindByQuery(new ObjectCriteria());
            e.StockList = list;
        }

        public void stockSearchView_InitStockSearchEvent(object sender, StockSearchEventArgs e)
        {
            var criteria = new ObjectCriteria();
            criteria.AddEqCriteria("DelFlg", (long)0);
            e.ProductTypeList = ProductTypeLogic.FindAll(criteria);
            e.ProductSizeList = ProductSizeLogic.FindAll(criteria);
            e.ProductColorList = ProductColorLogic.FindAll(criteria);
            e.CountryList = CountryLogic.FindAll(criteria);
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
        #endregion

        #region Implementation of IBaseController<StockCreateEventArgs>

        public StockSearchEventArgs ResultEventArgs
        {
            get; set;
        }

        #endregion
    }
}
