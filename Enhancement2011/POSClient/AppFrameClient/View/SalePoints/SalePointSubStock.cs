using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppFrame.Common;
using AppFrame.Model;
using AppFrame.Presenter.SalePoints;
using AppFrame.Utility;
using AppFrame.View.SalePoints;

namespace AppFrameClient.View.SalePoints
{
    public partial class SalePointSubStock : BaseForm, ISalePointSubStockView
    {
        public SalePointSubStock()
        {
            InitializeComponent();
        }

        public event EventHandler<SalePointEventArgs> LoadDepartmentsEvent;
        public event EventHandler<SalePointEventArgs> SaveDepartmentSubStockEvent;

        private ISalePointController salePointController;
        public ISalePointController SalePointController
        {
            set
            {
                salePointController = value;
                salePointController.SalePointSubStockView = this;
            }
        }

        private void SalePointSubStock_Load(object sender, EventArgs e)
        {
            SalePointEventArgs ea = new SalePointEventArgs();
            EventUtility.fireEvent(LoadDepartmentsEvent,this,ea);
            if(ea.DepartmentList!= null && ea.DepartmentList.Count > 0 )
            {
                cboDepartments.Items.Clear();
                BindingSource bdsDepartment = new BindingSource();
                bdsDepartment.DataSource = typeof(Department);
                foreach (Department department in ea.DepartmentList)
                {
                    bdsDepartment.Add(department);
                }
                cboDepartments.DataSource = bdsDepartment;
                cboDepartments.DisplayMember = "DepartmentName";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Department department = new Department();
            department.DepartmentId = ((Department) cboDepartments.SelectedItem).DepartmentId;
            department.DepartmentName = txtDepartmentName.Text.Trim();
            department.Address = txtAddress.Text.Trim();
            department.CreateDate = DateTime.Now;
            department.UpdateDate = DateTime.Now;
            department.CreateId = ClientInfo.getInstance().LoggedUser.Name;
            department.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
            department.StartDate = dtpCreateDate.Value;
            SalePointEventArgs ea = new SalePointEventArgs();
            ea.SavingSubStock = department;
            EventUtility.fireEvent(SaveDepartmentSubStockEvent,this,ea);
            if(!ea.HasErrors)
            {
                MessageBox.Show("Tạo kho phụ thành công !");                
            }
            else
            {
                MessageBox.Show("Có lỗi khi tạo kho phụ. Liên hệ người quản trị");
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearInput();
        }

        private void ClearInput()
        {
            txtAddress.Text = "";
            txtDeparmentCost.Text = "";
            txtDepartmentId.Text = "";
            txtDepartmentName.Text = "";
            txtDepartmentName.Focus();
        }
    }
}
