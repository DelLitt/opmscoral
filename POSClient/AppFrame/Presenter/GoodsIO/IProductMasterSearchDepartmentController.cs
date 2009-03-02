using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Logic;
using AppFrame.View.GoodsIO;

namespace AppFrame.Presenter.GoodsIO
{
    public interface IProductMasterSearchDepartmentController
    {
        #region View use in IProductMasterSearchCreateController
        IProductMasterSearchDepartmentView ProductMasterSearchDepartmentView { get; set; }
        #endregion

        #region Logic
        IProductMasterLogic ProductMasterLogic { get; set; }
        ICountryLogic CountryLogic { get; set; }
        IProductColorLogic ProductColorLogic { get; set; }
        IProductTypeLogic ProductTypeLogic { get; set; }
        IProductSizeLogic ProductSizeLogic { get; set; }
        IManufacturerLogic ManufacturerLogic { get; set; }
        IDistributorLogic DistributorLogic { get; set; }
        IPackagerLogic PackagerLogic { get; set; }
        IDepartmentStockInDetailLogic DepartmentStockInDetailLogic { get; set; }

        #endregion
    }
}
