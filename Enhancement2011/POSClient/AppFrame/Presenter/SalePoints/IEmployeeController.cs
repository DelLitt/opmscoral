using System;
using AppFrame.Common;
using AppFrame.Logic;
using AppFrame.Model;
using AppFrame.View.SalePoints;

namespace AppFrame.Presenter.SalePoints
{
    public interface IEmployeeController : IBaseController<EmployeeEventArgs>
    {
        #region View use in ISalePointController
        IEmployeeView EmployeeView { get; set; }
        ISalePointView SalePointView { get; set; }
        #endregion

        #region Logic use in ISalePointController
        IEmployeeLogic EmployeeLogic { get; set; }
        IEmployeeDetailLogic EmployeeDetailLogic { get; set; }
        #endregion

        #region Event use in ISalePointController
        event EventHandler<EmployeeEventArgs> CompletedSaveEmployeeEvent;
        event EventHandler<EmployeeEventArgs> CompletedResetEmployeeEvent;
        event EventHandler<EmployeeEventArgs> CompletedCloseEmployeeFormEvent;
        event EventHandler<EmployeeEventArgs> CompletedHelpEvent;
        event EventHandler<EmployeeEventArgs> CompletedAddEmployeeEvent;
        event EventHandler<EmployeeEventArgs> CompletedEditEmployeeEvent;
        #endregion

        #region Model use in Controller
        EmployeeInfo EmployeeInfoModel { get; set; }
        IEmployeeListView EmployeeListView { get; set; }

        #endregion
    }
}