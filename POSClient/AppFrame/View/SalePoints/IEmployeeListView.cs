using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Presenter.SalePoints;

namespace AppFrame.View.SalePoints
{
    public interface IEmployeeListView
    {
        IEmployeeController EmployeeController { get;set;}
        event EventHandler<EmployeeEventArgs> LoadEmployeesEvent;
        event EventHandler<EmployeeEventArgs> EditEmployeeEvent;
        event EventHandler<EmployeeEventArgs> DeleteEmployeeEvent;
    }
}
