using System;
using System.Collections.Generic;
using System.Text;
using AppFrame.Common;
using AppFrame.Logic;
using AppFrame.View.GoodsIO;
using AppFrame.View.GoodsIO.DepartmentGoodsIO;

namespace AppFrame.Presenter.GoodsIO.DepartmentGoodsIO
{
    public interface IDepartmentStockInSearchController : IBaseController<DepartmentStockInSearchEventArgs>
    {
        #region View use in IDepartmentStockInSearchController
        IDepartmentStockInSearchView DepartmentStockInSearchView { get; set; }
        #endregion

        #region Logic use in IDepartmentStockInSearchController
        IDepartmentStockInLogic DepartmentStockInLogic { get; set; }
        #endregion
    }
}