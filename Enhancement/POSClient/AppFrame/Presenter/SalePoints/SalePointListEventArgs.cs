using System;
using System.Collections.Generic;
using System.Text;
using AppFrame.Common;
using AppFrame.Model;

namespace AppFrame.Presenter.SalePoints
{
    public class SalePointListEventArgs : BaseEventArgs
    {
        private List<Department> departmentList;
        private Department selectedDepartment;

        public List<Department> DepartmentList
        {
            get { return departmentList; }
            set { departmentList = value; }
        }

        public Department SelectedDepartment
        {
            get { return selectedDepartment; }
            set { selectedDepartment = value; }
        }

        public Department EditedDepartment { get; set; }
    }
}
