using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AppFrame.Common;
using AppFrame.Model;
using AppFrame.Presenter.SalePoints;
using AppFrame.Utility;
using AppFrame.Utility.Mapper;
using AppFrame.View.SalePoints;
using AppFrame.Presenter.SalePoints;

namespace AppFrameClient.View.SalePoints
{
    public partial class EmployeeForm : BaseForm, IEmployeeView
    {
        public EmployeeForm()
        {
            InitializeComponent();
        }



        #region IEmployeeView Members

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
                employeeController.EmployeeView = this;
            }
        }

        public event EventHandler<EmployeeEventArgs> SaveEmployeeEvent;

        public event EventHandler<EmployeeEventArgs> ResetEmployeeEvent;

        public event EventHandler<EmployeeEventArgs> CloseEmployeeFormEvent;

        public event EventHandler<EmployeeEventArgs> HelpEvent;

        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        #region IEmployeeView Members

        private ISalePointController salePointController;
        public ISalePointController SalePointController
        {
            set
            {
                salePointController = value;
            }
        }

        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            FormToModel();
            EmployeeEventArgs eventArgs = new EmployeeEventArgs();
            eventArgs.EmployeeInfo = EmployeeController.EmployeeInfoModel;
            eventArgs.SelectedEmployee = ObjectConverter.Convert<Int32>(txtHiddenSelectedEmployeeId.Text);
            EventUtility.fireEvent(SaveEmployeeEvent,this,eventArgs);
            if(!eventArgs.HasErrors)
            {
                
            }
            if(Status == ViewStatus.OPENDIALOG)
            {
                Close();
            }
            btnReset_Click(null,null);
        }

        public override void FormToModel()
        {

            EmployeeInfo employeeInfo = EmployeeController.EmployeeInfoModel;
            if (employeeInfo == null)
            {
                employeeInfo = new EmployeeInfo();
            }
            
            employeeInfo.EmployeeName = txtEmployeeName.Text.Trim();
            employeeInfo.Address = txtAddress.Text.Trim();
            employeeInfo.StartDate = dtpCreateDate.Value;
            employeeInfo.Salary = ObjectConverter.Convert<Int32>(txtSalary.Text);
            //employeeInfo.Employee.EmployeeId = employeeInfo.EmployeeId;
            EmployeeController.EmployeeInfoModel = employeeInfo;

            
        }
        public override void ModelToForm()
        {
            EmployeeInfo employeeInfo = EmployeeController.EmployeeInfoModel;
            if (employeeInfo == null)
                return;
            //txtDepartmentName.Text = employeeInfo.Employee.Department.DepartmentName;
            //txtDepartmentId.Text = employeeInfo.DepartmentId.ToString();
            if (   employeeInfo.EmployeePK != null 
                && employeeInfo.EmployeePK.EmployeeId != null)
            {
                txtEmployeeId.Text = employeeInfo.EmployeePK.EmployeeId.ToString();
            }
            txtEmployeeName.Text = employeeInfo.EmployeeName;
            txtAddress.Text = employeeInfo.Address;
            txtSalary.Text = employeeInfo.Salary.ToString();
            dtpCreateDate.Value = employeeInfo.StartDate;
            
        }

        private void txtEmployeeName_TextChanged(object sender, EventArgs e)
        {
            FormatEmployeeName();
        }

        private void FormatEmployeeName()
        {
            txtEmployeeName.Text = txtEmployeeName.Text.ToUpper();
            txtEmployeeName.SelectionStart = txtEmployeeName.Text.Length;
        }

        private void GenerateEmployeeID()
        {
            string empName = txtEmployeeName.Text;
            
        }
        Hashtable stringTable = new Hashtable();
        private void initializeStringTable()
        {
            stringTable.Add("a", "áàãảạăắằẳẵặâấầẩẫậ");
            stringTable.Add("i","í");
            stringTable.Add("u","ú");
            stringTable.Add("e","é");
            stringTable.Add("o","ó");
            stringTable.Add("y","ý");
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private string ConvertEmployeeNameToId(string name)
        {
            string[] nameparts = name.Split(' ');
            string retName = nameparts[nameparts.Length - 1];
            foreach (string namepart in nameparts)
            {
                retName += namepart[0];
            }
            return retName;
        }

        private void EmployeeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void EmployeeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            EmployeeEventArgs eventArgs = new EmployeeEventArgs();
            EventUtility.fireEvent(CloseEmployeeFormEvent, this, eventArgs);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtEmployeeName.Text = "";
            txtAddress.Text = "";
            txtSalary.Text = "";
            EmployeeController.EmployeeInfoModel = null;
        }
    }
}
