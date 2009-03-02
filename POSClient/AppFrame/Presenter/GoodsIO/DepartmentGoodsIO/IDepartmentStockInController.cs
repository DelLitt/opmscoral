using System;
using System.Collections.Generic;
using System.Text;
using AppFrame.Common;
using AppFrame.Logic;
using AppFrame.View.GoodsIO;
using AppFrame.View.GoodsIO.DepartmentGoodsIO;

namespace AppFrame.Presenter.GoodsIO.DepartmentGoodsIO
{
    public interface IDepartmentStockInController : IBaseController<DepartmentStockInEventArgs>
    {
        #region View use in IDepartmentStockInController
        IDepartmentStockInView DepartmentStockInView { get; set; }
        #endregion

        #region Logic use in IDepartmentStockInController
        IDepartmentStockInLogic DepartmentStockInLogic { get; set; }
        IProductMasterLogic ProductMasterLogic { get; set; }
        IDepartmentStockInDetailLogic DepartmentStockInDetailLogic { get; set; }
        IDepartmentStockLogic DepartmentStockLogic { get; set; }

        #endregion
    }
}