using System;
using System.Collections.Generic;
using System.Text;
using AppFrame.Common;
using AppFrame.Presenter.SalePoints;

namespace AppFrame.View.SalePoints
{
    public interface ISalePointListView : IView<SalePointListEventArgs>
    {
        #region main controller and event
        ISalePointListController SalePointListController { get; set; }
        event EventHandler<SalePointListEventArgs> HelpEvent;
        event EventHandler<SalePointListEventArgs> CheckAllEvent;
        event EventHandler<SalePointListEventArgs> UncheckAllEvent;
        event EventHandler<SalePointListEventArgs> AddSalePointEvent;
        event EventHandler<SalePointListEventArgs> EditSalePointEvent;
        event EventHandler<SalePointListEventArgs> DeleteSalePointEvent;
        event EventHandler<SalePointListEventArgs> CloseSalePointListFormEvent;
        event EventHandler<SalePointListEventArgs> LoadDepartmentsEvent;
        #endregion

        #region other controllers and events
        ISalePointController SalePointController { get; set; }
        #endregion
    }
}
