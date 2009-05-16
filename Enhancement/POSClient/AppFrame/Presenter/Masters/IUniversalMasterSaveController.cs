using System;
using System.Collections.Generic;
using System.Text;
using AppFrame.Common;
using AppFrame.Logic;
using AppFrame.Presenter.Masters;
using AppFrame.View.GoodsIO;
using AppFrame.View.Masters;

namespace AppFrame.Presenter.Masters
{
    public interface IUniversalMasterSaveController : IBaseController<UniversalMasterSaveEventArgs>
    {
        #region View use in IUniversalMasterSaveController
        IUniversalMasterSaveView UniversalMasterSaveView { get; set; }
        #endregion

        #region Logic use in IGoodsIOSearchController
        ICountryLogic CountryLogic { get; set; }
        IProductColorLogic ProductColorLogic { get; set; }
        IProductTypeLogic ProductTypeLogic { get; set; }
        IProductSizeLogic ProductSizeLogic { get; set; }
        IManufacturerLogic ManufacturerLogic { get; set; }
        IDistributorLogic DistributorLogic { get; set; }
        IPackagerLogic PackagerLogic { get; set; }
        #endregion
    }
}