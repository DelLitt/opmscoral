using System.Collections;
using System.Windows.Forms;
using AppFrame.Common;
using AppFrame.Model;

namespace AppFrame.Presenter.SalePoints
{
    public class EmployeeEventArgs : BaseEventArgs
    {
        private Form parentForm;
        private string departmentName;
        private string departmentId;
        private Employee employee;
        private EmployeeInfo employeeInfo;
        private int selectedEmployeeId = -1;

        public Employee Employee
        {
            get { return employee; }
            set { employee = value; }
        }

        public EmployeeInfo EmployeeInfo
        {
            get { return employeeInfo; }
            set { employeeInfo = value; }
        }

        public string DepartmentName
        {
            get { return departmentName; }
            set { departmentName = value; }
        }

        public Form ParentForm
        {
            get { return parentForm; }
            set { parentForm = value; }
        }

        public string DepartmentId
        {
            get { return departmentId; }
            set { departmentId = value; }
        }

        public int SelectedEmployee
        {
            get { return selectedEmployeeId; }
            set { selectedEmployeeId = value; }
        }
        public EmployeeInfo EditedEmployee { get; set; }
        public EmployeeInfo AddedEmployee { get; set; }

        public IList EmployeeList { get; set; }
    }
}