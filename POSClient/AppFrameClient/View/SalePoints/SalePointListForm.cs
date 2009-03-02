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
using AppFrame.View.SalePoints;

namespace AppFrameClient.View.SalePoints
{
    public partial class SalePointListForm : BaseForm,ISalePointListView
    {
        public SalePointListForm()
        {
            InitializeComponent();
            
        }

        private void LoadDepartments()
        {
            EventUtility.fireAsyncEvent(LoadDepartmentsEvent, this, new SalePointListEventArgs(), new AsyncCallback(EndEvent));
        }

        #region ISalePointListView Members

        private ISalePointListController salePointListController;
        public AppFrame.Presenter.SalePoints.ISalePointListController SalePointListController
        {
            get
            {
                return salePointListController;
            }
            set
            {
                salePointListController = value;
                salePointListController.SalePointListView = this;
                salePointListController.CompletedLoadDepartmentsEvent += new EventHandler<SalePointListEventArgs>(salePointListController_CompletedLoadDepartmentsEvent);
                salePointListController.CompletedDeleteSalePointEvent += new EventHandler<SalePointListEventArgs>(salePointListController_CompletedDeleteSalePointEvent);
            }
        }

        void salePointListController_CompletedDeleteSalePointEvent(object sender, SalePointListEventArgs e)
        {
            // detach currency manager
            //CurrencyManager currencyManager1 = bdsSalePointList.CurrencyManager;
            //bdsSalePointList.SuspendBinding();
            // set visible = false
            // update list
            IList<Department> departments = SalePointListController.DepartmentList;
            int i = departments.Count - 1;
            while (i >= 0)
            {
                if (departments[i].DelFlg == 1)
                {
                    departments.RemoveAt(i);
                }

                i -= 1;
            }
            //bdsSalePointList.ResumeBinding();
            ModelToForm();
            bdsSalePointList.ResetBindings(true);
            
            dgvDepartments.Invalidate();
            MessageBox.Show("Departments have been deleted !");
            
        }

        void salePointListController_CompletedLoadDepartmentsEvent(object sender, SalePointListEventArgs e)
        {
            bdsSalePointList.DataSource = e.DepartmentList;
        }

        public event EventHandler<AppFrame.Presenter.SalePoints.SalePointListEventArgs> HelpEvent;

        public event EventHandler<AppFrame.Presenter.SalePoints.SalePointListEventArgs> CheckAllEvent;

        public event EventHandler<AppFrame.Presenter.SalePoints.SalePointListEventArgs> UncheckAllEvent;

        public event EventHandler<AppFrame.Presenter.SalePoints.SalePointListEventArgs> AddSalePointEvent;

        public event EventHandler<AppFrame.Presenter.SalePoints.SalePointListEventArgs> EditSalePointEvent;

        public event EventHandler<AppFrame.Presenter.SalePoints.SalePointListEventArgs> DeleteSalePointEvent;

        public event EventHandler<AppFrame.Presenter.SalePoints.SalePointListEventArgs> CloseSalePointListFormEvent;
        public event EventHandler<AppFrame.Presenter.SalePoints.SalePointListEventArgs> LoadDepartmentsEvent;

        #endregion

        private void btnCheckAll_Click(object sender, EventArgs e)
        {
            dgvDepartments.SelectAll();
        }

        private void btnUncheckAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow selectedRow in dgvDepartments.SelectedRows)
            {
                selectedRow.Selected = false;
            }
            dgvDepartments.Update();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            EventUtility.fireAsyncEvent(AddSalePointEvent,this,new SalePointListEventArgs(), new AsyncCallback(EndEvent));
        }
        public override void FormToModel()
        {
            List<Department> departmentList = new List<Department>();
            System.Collections.IList origSPList = bdsSalePointList.DataSource as IList;
            foreach (Department obj in origSPList)
            {
                departmentList.Add(obj);                
            }
            SalePointListController.DepartmentList = departmentList;
        }

        public override void ModelToForm()
        {
            
            IList<Department> departments = SalePointListController.DepartmentList;
            bdsSalePointList.DataSource = departments;
            bdsSalePointList.EndEdit();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            DataGridViewSelectedRowCollection selectedList = dgvDepartments.SelectedRows;
            if(selectedList.Count <= 0)
            {
                return;
            }
            DataGridViewRow selectedRow = selectedList[0];
            SalePointListEventArgs salePointListEventArgs = new SalePointListEventArgs();
            salePointListEventArgs.SelectedDepartment = bdsSalePointList[selectedRow.Index] as Department;
            EventUtility.fireAsyncEvent(EditSalePointEvent,this,salePointListEventArgs,new AsyncCallback(EndEvent));
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
            salePointListController.CompletedLoadDepartmentsEvent -= new EventHandler<SalePointListEventArgs>(salePointListController_CompletedLoadDepartmentsEvent);
            salePointListController.CompletedDeleteSalePointEvent -= new EventHandler<SalePointListEventArgs>(salePointListController_CompletedDeleteSalePointEvent);
            salePointController.CompletedEditDepartmentEvent -= new EventHandler<SalePointEventArgs>(salePointController_CompletedEditDepartmentEvent);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc bạn muốn xoá cửa hàng này ?", "Xác nhận",
                                                  MessageBoxButtons.YesNo);
            if(result == DialogResult.No)
            {
                return;
            }
            DataGridViewSelectedRowCollection selectedList = dgvDepartments.SelectedRows;
            if (selectedList.Count <= 0)
            {
                return;
            }

            // delete department
            foreach (DataGridViewRow o in selectedList)
            {
                int delIndex = o.Index;
                ((Department) bdsSalePointList[delIndex]).DelFlg = 1;
            }
            SalePointListEventArgs salePointListEventArgs = new SalePointListEventArgs();
            SalePointListController.DepartmentList = bdsSalePointList.DataSource as IList<Department>;
            EventUtility.fireAsyncEvent(DeleteSalePointEvent,this,salePointListEventArgs,new AsyncCallback(EndEvent));
            
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadDepartments();
        }
       

        private void dgvDepartment_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            Department department = bdsSalePointList[e.RowIndex] as Department;
            if(department.Active == 1)
            {
                dgvDepartments.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.YellowGreen;
            }
            else
            {
                dgvDepartments.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.Window);
            }
        }


        #region ISalePointListView Members

        private ISalePointController salePointController;
        public ISalePointController SalePointController
        {
            get
            {
                return salePointController;         
            }
            set
            {
                salePointController = value;
                salePointController.CompletedEditDepartmentEvent += new EventHandler<SalePointEventArgs>(salePointController_CompletedEditDepartmentEvent);
            }
        }

        void salePointController_CompletedEditDepartmentEvent(object sender, SalePointEventArgs e)
        {
            this.Enabled = true;
        }

        #endregion

        private void mnuSetActiveDepartment_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selectedRows = dgvDepartments.SelectedRows;
            if(selectedRows.Count > 0 )
            {
                IList<Department> departments = bdsSalePointList.DataSource as IList<Department>;
                foreach (Department department in departments)
                {
                    department.Active = 0;                    
                }
                Department activeDepartment = bdsSalePointList[selectedRows[0].Index] as Department;
                activeDepartment.Active = 1;
            }
            dgvDepartments.Refresh();
            dgvDepartments.Invalidate();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
