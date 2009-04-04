using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppFrame.Collection;
using AppFrame.Common;
using AppFrame.Model;
using AppFrame.Presenter.SalePoints;
using AppFrame.Utility;
using AppFrame.View.SalePoints;

namespace AppFrameClient.View.SalePoints
{
    public partial class EmployeeListForm : BaseForm,IEmployeeListView
    {
        private EmployeeInfoCollection empInfoList = null;
        private IEmployeeController employeeController;
        public IEmployeeController EmployeeController
        {
            get
            {
                return employeeController;
            }
            set
            {
                employeeController = value;
                employeeController.EmployeeListView = this;
            }
        }
        

        public EmployeeListForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        #region IEmployeeListView Members


        public event EventHandler<EmployeeEventArgs> LoadEmployeesEvent;

        public event EventHandler<EmployeeEventArgs> EditEmployeeEvent;

        public event EventHandler<EmployeeEventArgs> DeleteEmployeeEvent;

        #endregion

        private void EmployeeListForm_Load(object sender, EventArgs e)
        {
            empInfoList = new EmployeeInfoCollection(bdsEmployee);
            EmployeeEventArgs eventArgs = new EmployeeEventArgs();
            EventUtility.fireEvent(LoadEmployeesEvent,this,eventArgs);

            if(eventArgs.EmployeeList!= null && eventArgs.EmployeeList.Count > 0)
            {
                foreach (EmployeeInfo employeeInfo in eventArgs.EmployeeList)
                {
                    empInfoList.Add(employeeInfo);
                }
                bdsEmployee.EndEdit();
                dgvEmployee.Refresh();
                dgvEmployee.Invalidate();
            }
        }
    }
}
