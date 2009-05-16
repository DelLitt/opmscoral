using System;
using System.Collections.Generic;
using System.Text;
using AppFrame.Common;
using AppFrame.Logic;
using AppFrame.Model;
using AppFrame.View.SalePoints;

namespace AppFrame.Presenter.SalePoints
{
    public interface ISalePointListController : IBaseController<SalePointListEventArgs>
    {
        #region Model use in Controller
        IList<Department> DepartmentList { get; set; }
        #endregion
        #region main view and event
        ISalePointListView SalePointListView { get; set; } 
        event EventHandler<SalePointListEventArgs> CompletedHelpEvent;
        event EventHandler<SalePointListEventArgs> CompletedCheckAllEvent;
        event EventHandler<SalePointListEventArgs> CompletedUncheckAllEvent;
        event EventHandler<SalePointListEventArgs> CompletedAddSalePointEvent;
        event EventHandler<SalePointListEventArgs> CompletedEditSalePointEvent;
        event EventHandler<SalePointListEventArgs> CompletedDeleteSalePointEvent;
        event EventHandler<SalePointListEventArgs> CompletedCloseSalePointListFormEvent;
        event EventHandler<SalePointListEventArgs> CompletedLoadDepartmentsEvent;
        #endregion

        #region logic use in controller
        IDepartmentLogic DepartmentLogic { get; set; }
        #endregion
        

    }
}
