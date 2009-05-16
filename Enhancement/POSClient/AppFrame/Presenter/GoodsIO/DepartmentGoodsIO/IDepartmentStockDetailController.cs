using System;
using System.Collections.Generic;
using System.Text;
using AppFrame.Common;
using AppFrame.Logic;
using AppFrame.View.GoodsIO;
using AppFrame.View.GoodsIO.DepartmentGoodsIO;

namespace AppFrame.Presenter.GoodsIO.DepartmentGoodsIO
{
    public interface IDepartmentStockDetailController : IBaseController<DepartmentStockDetailEventArgs>
    {
        #region View use in IDepartmentStockDetailController
        IDepartmentStockDetailView DepartmentStockDetailView { get; set; }
        #endregion

        #region Logic use in IDepartmentStockSearchController
        #endregion
    }
}