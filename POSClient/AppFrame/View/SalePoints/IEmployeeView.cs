using System;
using AppFrame.Common;
using AppFrame.Presenter.SalePoints;

namespace AppFrame.View.SalePoints
{
    public interface IEmployeeView : IView<EmployeeEventArgs>
    {
        #region main controller and event
        IEmployeeController EmployeeController { get; set; }
        event EventHandler<EmployeeEventArgs> SaveEmployeeEvent;
        event EventHandler<EmployeeEventArgs> ResetEmployeeEvent;
        event EventHandler<EmployeeEventArgs> CloseEmployeeFormEvent;
        event EventHandler<EmployeeEventArgs> HelpEvent;
        #endregion

        #region sub controller and event
        ISalePointController SalePointController { set; }
        #endregion
    }
}