using System;
using System.Collections.Generic;
using System.Text;
using AppFrame.Common;
using AppFrame.Presenter.SalePoints;

namespace AppFrame.View.SalePoints
{
    public interface ISalePointView : IView<SalePointEventArgs>
    {

        #region main controller and event
        ISalePointController SalePointController { set; }
        event EventHandler<SalePointEventArgs> CheckAllGridEvent;
        event EventHandler<SalePointEventArgs> UncheckAllGridEvent;
        event EventHandler<SalePointEventArgs> DeleteEmployeeEvent;
        event EventHandler<SalePointEventArgs> HelpEvent;

        event EventHandler<SalePointEventArgs> SaveDepartmentEvent;
        event EventHandler<SalePointEventArgs> ResetDepartmentEvent;
        event EventHandler<SalePointEventArgs> CloseDepartmentFormEvent;
        #endregion

        #region sub controller and event
        IEmployeeController EmployeeController { set; }
        event EventHandler<EmployeeEventArgs> AddEmployeeEvent;
        event EventHandler<EmployeeEventArgs> EditEmployeeEvent;
        #endregion

    }
}
