using System;
using System.Collections.Generic;
using System.Text;
using AppFrame.Common;
using AppFrame.Logic;
using AppFrame.View.GoodsIO;

namespace AppFrame.Presenter.GoodsIO
{
    public interface IGoodsIOSearchController : IBaseController<GoodsIOSearchEventArgs>
    {
        #region View use in IGoodsIOSearchController
        IGoodsIOSearchView GoodsIOSearchView { get; set; }
        #endregion

        #region Logic use in IGoodsIOSearchController
        IBlockInDetailLogic BlockInDetailLogic { get; set; }
        #endregion
    }
}
