using System;
using System.Collections.Generic;
using System.Text;
using AppFrame.Presenter.GoodsIO;
using AppFrame.Common;

namespace AppFrame.View.GoodsIO
{
    public interface IGoodsIOSearchView : IView<GoodsIOSearchEventArgs>
    {
        #region main controller and event
        IGoodsIOSearchController GoodsIOSearchController { set; }
        event EventHandler<GoodsIOSearchEventArgs> SearchBlockInDetailEvent;
        event EventHandler<GoodsIOSearchEventArgs> LoadBlockInDetailEvent;
        event EventHandler<GoodsIOSearchEventArgs> DeleteBlockInDetailEvent;
        #endregion
    }
}
