using System;
using System.Collections.Generic;
using System.Text;
using AppFrame;
using AppFrame.Common;
using AppFrame.Logic;
using AppFrame.Presenter.GoodsIO.DepartmentGoodsIO;
using AppFrame.Utility;
using AppFrame.View.GoodsIO.DepartmentGoodsIO;

namespace AppFrameClient.Presenter.GoodsIO.DepartmentStockData
{
    public class DepartmentStockInSearchController : IDepartmentStockInSearchController
    {
        private IDepartmentStockInSearchView _departmentStockInSearchView;
        public IDepartmentStockInSearchView DepartmentStockInSearchView
        {
            get
            {
                return _departmentStockInSearchView;
            }
            set
            {
                _departmentStockInSearchView = value;
                _departmentStockInSearchView.SearchDepartmentStockInEvent += new System.EventHandler<DepartmentStockInSearchEventArgs>(departmentStockInSearchView_SearchDepartmentStockInEvent);
            }
        }

        public void departmentStockInSearchView_SearchDepartmentStockInEvent(object sender, DepartmentStockInSearchEventArgs e)
        {
            var criteria = new ObjectCriteria();
            criteria.AddEqCriteria("DepartmentStockInPK.DepartmentId", CurrentDepartment.Get().DepartmentId);
            criteria.AddGreaterOrEqualsCriteria("StockInDate", e.StockInDateFrom);
            criteria.AddLesserOrEqualsCriteria("StockInDate", e.StockInDateTo);
            criteria.AddLikeCriteria("DepartmentStockInPK.StockInId", e.StockInId + "%");
            criteria.AddEqCriteria("DelFlg", (long)0);
            e.DepartmeneStockInList = DepartmentStockInLogic.FindAll(criteria);
            EventUtility.fireEvent(CompletedSearchDepartmentStockInEvent,this,e);
        }

        public IDepartmentStockInLogic DepartmentStockInLogic { get; set; }
        public event EventHandler<DepartmentStockInSearchEventArgs> CompletedSearchDepartmentStockInEvent;

        #region Implementation of IBaseController<StockCreateEventArgs>

        public DepartmentStockInSearchEventArgs ResultEventArgs
        {
            get;
            set;
        }

        #endregion
    }
}
