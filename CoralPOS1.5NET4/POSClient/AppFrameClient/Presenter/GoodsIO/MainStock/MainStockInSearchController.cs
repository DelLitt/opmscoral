using System;
using System.Collections.Generic;
using System.Text;
using AppFrame;
using AppFrame.Common;
using AppFrame.Logic;
using AppFrame.Presenter.GoodsIO.DepartmentGoodsIO;
using AppFrame.Presenter.GoodsIO.MainStock;
using AppFrame.Utility;
using AppFrame.View.GoodsIO.DepartmentGoodsIO;
using AppFrame.View.GoodsIO.MainStock;

namespace AppFrameClient.Presenter.GoodsIO.MainStock
{
    public class MainStockInSearchController : IMainStockInSearchController
    {
        private IMainStockInSearchView _stockInSearchView;
        public IMainStockInSearchView StockInSearchView
        {
            get
            {
                return _stockInSearchView;
            }
            set
            {
                _stockInSearchView = value;
                _stockInSearchView.SearchStockInEvent += new System.EventHandler<MainStockInSearchEventArgs>(departmentStockInSearchView_SearchMainStockInEvent);
                _stockInSearchView.SearchSingleStockInEvent += new EventHandler<MainStockInSearchEventArgs>(_stockInSearchView_SearchSingleStockInEvent);
            }
        }

        void _stockInSearchView_SearchSingleStockInEvent(object sender, MainStockInSearchEventArgs e)
        {
            e.StockIn = StockInLogic.FindById(e.StockInId);
        }

        public void departmentStockInSearchView_SearchMainStockInEvent(object sender, MainStockInSearchEventArgs e)
        {
            var criteria = new ObjectCriteria();
            criteria.AddGreaterOrEqualsCriteria("StockInDate", e.StockInDateFrom);
            criteria.AddLesserOrEqualsCriteria("StockInDate", e.StockInDateTo);
            criteria.AddLikeCriteria("StockInId", e.StockInId + "%");
            criteria.AddEqCriteria("DelFlg", (long)0);
            e.StockInList = StockInLogic.FindAll(criteria);
            EventUtility.fireEvent(CompletedMainStockInSearchEvent,this,e);
        }

        public IStockInLogic StockInLogic { get; set; }
        public event EventHandler<MainStockInSearchEventArgs> CompletedMainStockInSearchEvent;

        #region Implementation of IBaseController<StockCreateEventArgs>

        public MainStockInSearchEventArgs ResultEventArgs
        {
            get;
            set;
        }

        #endregion
    }
}
