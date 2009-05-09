using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Presenter.GoodsIO;

namespace AppFrame.View.GoodsIO
{
    public interface IProductMasterEditView
    {
        IProductMasterController ProductMasterController { get;set;}
        event EventHandler<ProductMasterEventArgs> LoadProductMasters;
        event EventHandler<ProductMasterEventArgs> SaveProductMasters;
    }
}
