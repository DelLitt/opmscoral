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
using AppFrameClient.Common;

namespace AppFrameClient.View.SalePoints
{
    public partial class SalePointForm : BaseForm, ISalePointView
    {
        public SalePointForm()
        {
            InitializeComponent();

            //GeneratePrimaryKey();

            bdsEmployeeSource.Filter = "DelFlg = 1";
            
        }
      

        private void GeneratePrimaryKey()
        {
            txtDepartmentId.Text = DbUtility.DepartmentRandomPKGenerator();
        }

        #region ISalePointView Members

        private ISalePointController salePointController;
        public ISalePointController SalePointController
        {
            set 
            { 
                salePointController = value;
                salePointController.SalePointView = this;

            }
            get
            {
                return salePointController;
            }
        }

        void salePointController_CompletedAddDepartmentEvent(object sender, SalePointEventArgs e)
        {
            
        }

        void salePointController_CompletedAddEmployeeEvent(object sender, SalePointEventArgs e)
        {
            this.Enabled = true;
            bdsEmployeeSource.Add(e.Employees[0]);
        }

        public event EventHandler<SalePointEventArgs> CheckAllGridEvent;

        public event EventHandler<SalePointEventArgs> UncheckAllGridEvent;

        public event EventHandler<EmployeeEventArgs> AddEmployeeEvent;

        public event EventHandler<EmployeeEventArgs> EditEmployeeEvent;

        public event EventHandler<SalePointEventArgs> DeleteEmployeeEvent;

        public event EventHandler<SalePointEventArgs> HelpEvent;

        #endregion

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormToModel();
            EmployeeEventArgs eventArgs = new EmployeeEventArgs();
            
            EmployeeInfo employeeInfo = new EmployeeInfo();
              
            Employee employee = new Employee();
            employee.Department = SalePointController.DepartmentModel;
            //employee.DepartmentId = SalePointController.DepartmentModel.DepartmentId;
            employee.EmployeeInfo = employeeInfo;
            
            employeeInfo.Employee = employee;
            //employeeInfo.DepartmentId = (int)SalePointController.DepartmentModel.DepartmentId;
            
            EmployeePK employeePK = new EmployeePK();
            employeePK.DepartmentId = SalePointController.DepartmentModel.DepartmentId;
            employeeInfo.EmployeePK = employeePK;
            employee.EmployeePK = employeePK;

            eventArgs.EmployeeInfo = employeeInfo;
            eventArgs.SelectedEmployee = -1;
            this.Enabled = false;
            
            EventUtility.fireEvent(AddEmployeeEvent,this,eventArgs);
            if(eventArgs.AddedEmployee!=null)
            {
                bdsEmployeeSource.Add(eventArgs.AddedEmployee);
                bdsEmployeeSource.EndEdit();
                dgvEmployees.Refresh();
                dgvEmployees.Invalidate();
            }
            this.Enabled = true;
            employeeController.EmployeeInfoModel = null;
        }

        #region ISalePointView Members

        private IEmployeeController employeeController;
        public IEmployeeController EmployeeController
        {
            set
            {
                employeeController = value;
                employeeController.SalePointView = this;
            }
        }

        void employeeController_CompletedEditEmployeeEvent(object sender, EmployeeEventArgs e)
        {
            this.Enabled = true;
            bdsEmployeeSource[e.SelectedEmployee] = e.EmployeeInfo;
            this.Focus();
            
        }

        void employeeController_CompletedAddEmployeeEvent(object sender, EmployeeEventArgs e)
        {
            this.Enabled = true;
            this.Focus();
            bdsEmployeeSource.Add(e.EmployeeInfo);    
            txtEmployeesNumber.Text = bdsEmployeeSource.List.Count.ToString();
            
        }

        void employeeController_CompletedCloseEmployeeFormEvent(object sender, EmployeeEventArgs e)
        {
            this.Enabled = true;
            this.Focus();
        }

        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            FormToModel();
            Department dept = SalePointController.DepartmentModel;
            if(dept!= null && dept.Active == 1)
            {
                if(ClientSetting.IsServer())
                {
                    MessageBox.Show("Ở chế độ máy chủ, không thể active cửa hàng nào");
                    return;
                }
            }
            SalePointEventArgs eventArgs = new SalePointEventArgs();
            eventArgs.Department = SalePointController.DepartmentModel;
            EventUtility.fireEvent(SaveDepartmentEvent, this, eventArgs);
            if(!eventArgs.HasErrors)
            {
                MessageBox.Show("Lưu cửa hàng thành công !");    
            }
            else
            {
                MessageBox.Show("Có lỗi khi lưu cửa hàng.");
            }
            ClearForm();
            //ModelToForm();
            if(this.Status == ViewStatus.EDIT)
            {
                Close();                
            }
        }

        private void ClearForm()
        {
            //SalePointController.DepartmentModel = null;
            txtActiveDepartment.Text = "0";
            txtDeparmentCost.Text = "0";
            txtDepartmentId.Text = "";
            txtDepartmentName.Text = "";
            txtAddress.Text = "";
            txtEmployeesNumber.Text = "0";

        }

        #region ISalePointView Members


        public event EventHandler<SalePointEventArgs> SaveDepartmentEvent;

        public event EventHandler<SalePointEventArgs> ResetDepartmentEvent;

        public event EventHandler<SalePointEventArgs> CloseDepartmentFormEvent;

        #endregion

        private void btnEdit_Click(object sender, EventArgs e)
        {
            FormToModel();
            EmployeeEventArgs eventArgs = new EmployeeEventArgs();
            
            int selectedIndex = dgvEmployees.SelectedRows[0].Index;
            EmployeeInfo employeeInfo = bdsEmployeeSource[selectedIndex] as EmployeeInfo;
            

            eventArgs.EmployeeInfo = employeeInfo;
            eventArgs.SelectedEmployee = selectedIndex;
            this.Enabled = false;
            EventUtility.fireEvent(EditEmployeeEvent, this, eventArgs);
            if(eventArgs.EditedEmployee!=null)
            {
                bdsEmployeeSource[selectedIndex] = eventArgs.EditedEmployee;
                bdsEmployeeSource.EndEdit();
                dgvEmployees.Refresh();
                dgvEmployees.Invalidate();
            }
            this.Enabled = true;
            employeeController.EmployeeInfoModel = null;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCheckAll_Click(object sender, EventArgs e)
        {
            dgvEmployees.SelectAll();
        }

        private void btnUncheckAll_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow selectedRow in dgvEmployees.SelectedRows)
            {
                selectedRow.Selected = false;
            }
            dgvEmployees.Update();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selectedRows = dgvEmployees.SelectedRows;
            //IList sources = bdsEmployeeSource.List;
            int i = selectedRows.Count - 1;
            while(i>= 0)
            {
                DataGridViewRow selectedRow = selectedRows[i];
                int delIndex = selectedRow.Index;
                if (((EmployeeInfo)bdsEmployeeSource[delIndex]).ExclusiveKey == 0)
                {
                    bdsEmployeeSource.RemoveAt(delIndex);
                }
                i -= 1;
            }
            //bdsEmployeeSource.DataSource = sources;
            bdsEmployeeSource.Filter = "DelFlg = 0";
            
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtAddress.Text = "";
            txtDeparmentCost.Text = "0";
            txtDepartmentName.Text = "";
            txtEmployeesNumber.Text = "0";
            txtDeparmentCost.Text = "";
            bdsEmployeeSource.Clear();
            
            dtpCreateDate.Value = DateTime.Now;
        }

        private void mnuAdd_Click(object sender, EventArgs e)
        {
           btnAdd_Click(sender,e); 
        }

        private void mnuEdit_Click(object sender, EventArgs e)
        {
           btnEdit_Click(sender,e);
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            btnDelete_Click(sender,e);
        }

        public override void FormToModel()
        {

            Department department = SalePointController.DepartmentModel;
            if(department == null)
            {
                department = new Department();
            }

            department.DepartmentId = ObjectConverter.Convert<Int64>(txtDepartmentId.Text);
            department.DepartmentName = txtDepartmentName.Text;
            department.Address = txtAddress.Text;
            department.StartDate = dtpCreateDate.Value;
            department.Employees = bdsEmployeeSource.List as IList;
            department.Active = ObjectConverter.Convert<Int32>(txtActiveDepartment.Text);

            SalePointController.DepartmentModel = department;
        }
        public override void ModelToForm()
        {
            Department department = SalePointController.DepartmentModel;
            if (department == null)
                return;
            txtDepartmentName.Text = department.DepartmentName;
            txtDepartmentId.Text = department.DepartmentId.ToString();
            txtAddress.Text = department.Address;
            if (department.StartDate != null)
            {
                dtpCreateDate.Value = department.StartDate;
            }
            
            bdsEmployeeSource.DataSource = department.Employees;
            if (department.Employees != null)
            {
                txtEmployeesNumber.Text = department.Employees.Count.ToString();
            }
            else
            {
                txtEmployeesNumber.Text = "0";
            }
            txtActiveDepartment.Text = department.Active.ToString();
            CheckActive();
        }

        private void dgvEmployees_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
                
                EmployeeInfo employeeInfo = bdsEmployeeSource.List[e.RowIndex] as EmployeeInfo;
                DataGridViewRow row = dgvEmployees.Rows[e.RowIndex];
                if (employeeInfo != null && employeeInfo.DelFlg == 1 && row.Visible)
                {
                    // detach currency manager
                    CurrencyManager currencyManager1 = bdsEmployeeSource.CurrencyManager;
                    
                    
                    // set visible = false
                    
                        currencyManager1.SuspendBinding();
                    
                        dgvEmployees.CurrentCell = null;
                        row.Visible = false;

                        currencyManager1.ResumeBinding();     
                }
                
        
        }
        
        private void mnuSetMainSalePoint_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(txtActiveDepartment.Text) || !txtActiveDepartment.Text.Equals("1"))
            {
                txtActiveDepartment.Text = "1";
            }
            else
            {
                txtActiveDepartment.Text = "0";
            }
            CheckActive();
            
            
        }

        private void CheckActive()
        {
            if (txtActiveDepartment.Text.Equals("1"))
            {
                lblActiveDepartment.Text = "Cửa hàng này là cửa hàng ACTIVE";
                mnuSetMainSalePoint.Text = "Không thiết lập làm cửa hàng chính";
            }
            else
            {
                lblActiveDepartment.Text = "Cửa hàng này không phải là cửa hàng ACTIVE";
                mnuSetMainSalePoint.Text = "Thiết lập làm cửa hàng chính";
            }
        }

        private void btnActive_Click(object sender, EventArgs e)
        {
            mnuSetMainSalePoint_Click(sender, e);
        }

        private void txtDepartmentName_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void FormatDepartmentName()
        {
            txtDepartmentName.Text = txtDepartmentName.Text.ToUpper();
            txtDepartmentName.SelectionStart = txtDepartmentName.Text.Length;
        }

        private void SalePointForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*if (this.Status == ViewStatus.EDIT)
            {
                SalePointController.EndEditDepartment();
            }*/
        }

        private void SalePointForm_Load(object sender, EventArgs e)
        {
            if(this.Status == ViewStatus.EDIT)
            {

                btnReset.Enabled = false;
            }
        }
    }
    
}
