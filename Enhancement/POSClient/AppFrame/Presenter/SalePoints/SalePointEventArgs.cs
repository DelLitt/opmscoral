using System;
using System.Collections.Generic;
using System.Text;
using AppFrame.Common;
using AppFrame.Model;

namespace AppFrame.Presenter.SalePoints
{
    public class SalePointEventArgs : BaseEventArgs
    {
        public Department department;
        public IList<EmployeeInfo> employees;

        public Department Department
        {
            get { return department; }
            set { department = value; }
        }

        public IList<EmployeeInfo> Employees
        {
            get { return employees; }
            set { employees = value; }
        }
    }
}
