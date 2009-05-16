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
    public class DepartmentStockDetailController : IDepartmentStockDetailController
    {
        #region View use in IGoodsIOSearchController

        private IDepartmentStockDetailView _departmentStockDetailView;
        public IDepartmentStockDetailView DepartmentStockDetailView
        { 
            get
            {
                return _departmentStockDetailView;
            }
            set
            {
                _departmentStockDetailView = value;
                _departmentStockDetailView.SaveDepartmentPriceEvent += new System.EventHandler<DepartmentStockDetailEventArgs>(departmentStockDetailView_SaveDepartmentPriceEvent);
                _departmentStockDetailView.SearchDepartmentStockInDetailEvent += new System.EventHandler<DepartmentStockDetailEventArgs>(departmentStockDetailView_SearchDepartmentStockInDetailEvent);
            }
        }

        #endregion

        public void departmentStockDetailView_SearchDepartmentStockInDetailEvent(object sender, DepartmentStockDetailEventArgs e)
        {
            long deptId = CurrentDepartment.Get().DepartmentId;
            var objectCriteria = new ObjectCriteria(true);
            objectCriteria.AddEqCriteria("s.DelFlg", CommonConstants.DEL_FLG_NO);
            objectCriteria.AddEqCriteria("pm.ProductMasterId", e.ProductMasterId);
            objectCriteria.AddEqCriteria("s.DepartmentStockInDetailPK.DepartmentId", deptId);
            objectCriteria.AddGreaterOrEqualsCriteria("deptStockIn.StockInDate", e.StockInDateFrom);
            objectCriteria.AddLesserOrEqualsCriteria("deptStockIn.StockInDate", e.StockInDateTo);
            e.DepartmentStockInDetailList = DepartmentStockInDetailLogic.FindByQuery(objectCriteria);
            e.ProductPrice = DepartmentPriceLogic.FindById(new DepartmentPricePK { ProductMasterId = e.ProductMasterId, DepartmentId = deptId });
        }

        public void departmentStockDetailView_SaveDepartmentPriceEvent(object sender, DepartmentStockDetailEventArgs e)
        {
            if (e.IsNewPrice)
            {
                DepartmentPriceLogic.Add(e.ProductPrice);
            } 
            else
            {
                DepartmentPriceLogic.Update(e.ProductPrice);
            }
        }

        #region Logic use in IStockCreateController
        public IDepartmentStockInDetailLogic DepartmentStockInDetailLogic { get; set; }
        public IDepartmentPriceLogic DepartmentPriceLogic { get; set; }
        #endregion

        #region Implementation of IBaseController<DepartmentStockDetailEventArgs>

        public DepartmentStockDetailEventArgs ResultEventArgs
        {
            get; set;
        }

        #endregion

    }
}