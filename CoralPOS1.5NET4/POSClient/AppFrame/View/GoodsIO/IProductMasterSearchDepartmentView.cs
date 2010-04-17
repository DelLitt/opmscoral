using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Presenter.GoodsIO;

namespace AppFrame.View.GoodsIO
{
    public interface IProductMasterSearchDepartmentView
    {
        #region main controller and event
        IProductMasterSearchDepartmentController ProductMasterSearchDepartmentController { get; set; }
        event EventHandler<ProductMasterSearchDepartmentEventArgs> SaveProductMasterEvent;
        event EventHandler<ProductMasterSearchDepartmentEventArgs> SearchProductMasterEvent;
        event EventHandler<ProductMasterSearchDepartmentEventArgs> SelectProductMasterEvent;
        event EventHandler<ProductMasterSearchDepartmentEventArgs> SearchProductsEvent;
        event EventHandler<ProductMasterSearchDepartmentEventArgs> SelectProductEvent;
        event EventHandler<ProductMasterSearchDepartmentEventArgs> InitProductMasterSearchDepartmentEvent;
        event EventHandler<ProductMasterSearchDepartmentEventArgs> OpenProductMasterSearchDepartmentEvent;
        #endregion
    }
}
