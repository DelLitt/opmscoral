using System;
using AppFrame.Common;
using AppFrame.Presenter.GoodsIO;

namespace AppFrame.View.GoodsIO
{
    public interface IProductMasterView : IView<ProductMasterEventArgs>
    {
        #region main controller and event
        IProductMasterController ProductMasterController { set; }
        event EventHandler<ProductMasterEventArgs> SaveProductMasterEvent;
        event EventHandler<ProductMasterEventArgs> LoadProductMasterEvent;
        event EventHandler<ProductMasterEventArgs> InitProductMasterEvent;
        event EventHandler<ProductMasterEventArgs> DeleteProductMasterEvent;
        event EventHandler<ProductMasterEventArgs> CloseProductMasterEvent;
        #endregion
    }
}
