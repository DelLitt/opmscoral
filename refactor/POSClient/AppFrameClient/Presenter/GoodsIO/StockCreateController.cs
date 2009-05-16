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
    public class StockCreateController : IStockCreateController
    {
        #region View use in IGoodsIOSearchController

        private IStockCreateView _stockCreateView;
        public IStockCreateView StockCreateView
        { 
            get
            {
                return _stockCreateView;
            }
            set
            {
                _stockCreateView = value;
                _stockCreateView.CreateStockEvent += new System.EventHandler<StockCreateEventArgs>(stockCreateView_CreateStockEvent);
                _stockCreateView.SearchStockInDetailEvent += new System.EventHandler<StockCreateEventArgs>(stockCreateView_SearchStockInDetailEvent);
            }
        }

        #endregion

        public void stockCreateView_SearchStockInDetailEvent(object sender, StockCreateEventArgs e)
        {
            // Search StockInDetail
            var subCriteria = new SubObjectCriteria("StockIn");
            subCriteria.AddGreaterOrEqualsCriteria("StockInDate", DateUtility.ZeroTime(e.ImportDateFrom));
            subCriteria.AddLesserOrEqualsCriteria("StockInDate", DateUtility.MaxTime(e.ImportDateTo));
            subCriteria.AddEqCriteria("DelFlg", (long)0);

            var criteria = new ObjectCriteria();
            criteria.AddEqCriteria("DelFlg", (long)0);
            criteria.AddEqCriteria("StockInType", (Int64)e.StockInStatus);
            criteria.AddSubCriteria("StockIn", subCriteria);
            IList stockInDetailList = StockInDetailLogic.FindAll(criteria);
            e.StockInDetailList = stockInDetailList;

            // Search Stock
            if (stockInDetailList.Count > 0)
            {
                // build the Product id list
                IList productIdList = new ArrayList();
                foreach (StockInDetail stockInDetail in stockInDetailList)
                {
                    productIdList.Add(stockInDetail.Product.ProductId);
                }
                criteria = new ObjectCriteria();
                criteria.AddSearchInCriteria("Product.ProductId", productIdList);
                e.StockList = StockLogic.FindAll(criteria);

                criteria = new ObjectCriteria();
                criteria.AddSearchInCriteria("ProductId", productIdList);
                e.ReturnProductList = ReturnProductLogic.FindAll(criteria);
            }
        }

        public void stockCreateView_CreateStockEvent(object sender, StockCreateEventArgs e)
        {
            StockLogic.CreateOrUpdateStock(e.CreateStockList, e.CreateReturnProductList, e.UpdateStockInDetailList);
        }

        #region Logic use in IStockCreateController
        public IStockLogic StockLogic { get; set; }
        public IStockInDetailLogic StockInDetailLogic { get; set; }
        public IStockInLogic StockInLogic { get; set; }
        public IReturnProductLogic ReturnProductLogic { get; set; }
        #endregion

        #region Implementation of IBaseController<StockCreateEventArgs>

        public StockCreateEventArgs ResultEventArgs
        {
            get; set;
        }

        #endregion
    }
}
