using System;
using System.Collections.Generic;
using System.Text;
using AppFrame.Common;
using AppFrame.Logic;
using AppFrame.Presenter.GoodsIO.DepartmentGoodsIO;
using AppFrame.View.GoodsIO;
using AppFrame.View.GoodsIO.DepartmentGoodsIO;

namespace AppFrame.Presenter.GoodsIO.MainStock
{
    public interface IMainStockSearchController : IBaseController<DepartmentStockSearchEventArgs>
    {
        #region View use in IDepartmentStockSearchController
        IDepartmentStockSearchView DepartmentStockSearchView { get; set; }
        #endregion

        #region Logic use in IDepartmentStockSearchController
        #endregion
    }
}