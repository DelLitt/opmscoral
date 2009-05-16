using System;
using AppFrame.Common;
using AppFrame.Presenter.GoodsIO;

namespace AppFrame.View.GoodsIO
{
    public interface IProductMasterSearchOrCreateView : IView<ProductMasterSearchOrCreateEventArgs>
    {
        #region main controller and event
        IProductMasterSearchOrCreateController ProductMasterSearchOrCreateController { set; }
        event EventHandler<ProductMasterSearchOrCreateEventArgs> SaveProductMasterEvent;
        event EventHandler<ProductMasterSearchOrCreateEventArgs> SearchProductMasterEvent;
        event EventHandler<ProductMasterSearchOrCreateEventArgs> SelectProductMasterEvent;
        event EventHandler<ProductMasterSearchOrCreateEventArgs> InitProductMasterSearchOrCreateEvent;
        event EventHandler<ProductMasterSearchOrCreateEventArgs> OpenProductMasterSearchOrCreateEvent;
        #endregion
    }
}
