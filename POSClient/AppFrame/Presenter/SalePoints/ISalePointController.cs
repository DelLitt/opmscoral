
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using AppFrame.Common;
using AppFrame.Logic;
using AppFrame.Model;
using AppFrame.View.SalePoints;

namespace AppFrame.Presenter.SalePoints
{

    public interface ISalePointController : IBaseController<SalePointEventArgs>
    {
        #region View use in ISalePointController
        ISalePointView SalePointView { get; set; }
        #endregion

        #region Logic use in ISalePointController
        IEmployeeLogic EmployeeLogic { get; set; }
        IDepartmentLogic DepartmentLogic { get; set; }
        IEmployeeDetailLogic EmployeeDetailLogic { get; set; }
        #endregion

        #region Event use in ISalePointController
        event EventHandler<SalePointEventArgs> CompletedCheckAllGridEvent;
        event EventHandler<SalePointEventArgs> CompletedUncheckAllGridEvent;
        event EventHandler<SalePointEventArgs> CompletedEditEmployeeEvent;
        event EventHandler<SalePointEventArgs> CompletedDeleteEmployeeEvent;
        event EventHandler<SalePointEventArgs> CompletedHelpEvent;
        
        event EventHandler<SalePointEventArgs> CompletedAddDepartmentEvent;
        event EventHandler<SalePointEventArgs> CompletedEditDepartmentEvent;
        #endregion

        #region Model use in Controller
        Department DepartmentModel { get; set; }
        ISalePointSubStockView SalePointSubStockView { get; set; }

        #endregion

        #region methods in Controller

        void EndEditDepartment();
        #endregion

    }
}
