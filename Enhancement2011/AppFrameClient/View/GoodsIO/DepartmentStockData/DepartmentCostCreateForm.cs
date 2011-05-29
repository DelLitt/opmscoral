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
using AppFrame.Presenter.GoodsIO.DepartmentGoodsIO;
using AppFrame.Utility;
using AppFrame.View.GoodsIO.DepartmentGoodsIO;

namespace AppFrameClient.View.GoodsIO.DepartmentStockData
{
    public partial class DepartmentCostCreateForm : BaseForm,IDepartmentCostCreateView,IDepartmentCostEditView,IDepartmentCostListView
    {
        private DepartmentCostCollection costList;
        private bool CreateFlag = false;
        private bool UpdateFlag = false;
        public DepartmentCostCreateForm()
        {
            InitializeComponent();
        }


        private IDepartmentCostController departmentCostController;            
        public IDepartmentCostController DepartmentCostController
        {
            get
            {
                return departmentCostController;
            }
            set
            {
                departmentCostController = value;
                departmentCostController.DepartmentCostCreateView = this;
                departmentCostController.DepartmentCostEditView = this;
                departmentCostController.DepartmentCostListView = this;
            }
        }

        public event EventHandler<DepartmentCostEventArgs> SearchDepartmentCostEvent;


        public event EventHandler<DepartmentCostEventArgs> EditDepartmentCostEvent;
        public event EventHandler<DepartmentCostEventArgs> CreateDepartmentCostEvent;

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (!CreateFlag)
            {
                CreateFlag = true;
                EnableCostControls();
                btnCreate.Text = "Lưu";

                btnEdit.Enabled = false;
                btnCancel.Enabled = true;
            }
            else
            {
                DepartmentCost cost = new DepartmentCost();
                cost.DepartmentCostPK = new DepartmentCostPK
                                            {
                                                DepartmentId = CurrentDepartment.Get().DepartmentId,
                                                CostDate = DateTime.Now
                                            };
                cost.CreateDate = DateTime.Now;
                cost.CreateId = ClientInfo.getInstance().LoggedUser.Name;
                cost.UpdateDate = DateTime.Now;
                cost.UpdateId = ClientInfo.getInstance().LoggedUser.Name;

                cost.Cost = Int64.Parse(txtCost.Text.Trim());
                cost.CostDescription = txtCostDescription.Text.Trim();
                cost.CostName = txtCostName.Text.Trim();
                cost.CostType = cboCostType.SelectedIndex;
                DepartmentCostEventArgs eventArgs = new DepartmentCostEventArgs();
                eventArgs.CreateCost = cost;

                EventUtility.fireEvent(CreateDepartmentCostEvent, this, eventArgs);
                if (!eventArgs.HasErrors)
                {
                    costList.Add(eventArgs.CreateCost);
                    bdsCost.ResetBindings(false);
                    dgvCost.Refresh();
                    dgvCost.Invalidate();
                    CreateFlag = false;
                    ClearCostControls();
                    DisableCostControls();
                    btnCreate.Text = "Tạo";
                    btnEdit.Enabled = true;
                    btnCancel.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Có lỗi khi thêm chi phí. Liên hệ người quản trị", "Lỗi", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
        }

        private void ClearCostControls()
        {
            txtCost.Text = "";
            txtCostName.Text = "";
            txtCostDescription.Text = "";
            cboCostType.Text = "";
        }

        private void EnableCostControls()
        {
            txtCost.Enabled = true;
            txtCostName.Enabled = true;
            txtCostDescription.Enabled = true;
            cboCostType.Enabled = true;
            
        }

        private void DisableCostControls()
        {
            txtCost.Enabled = false;
            txtCostName.Enabled = false;
            txtCostDescription.Enabled = false;
            cboCostType.Enabled = false; 
        }
        private void DepartmentCostCreateForm_Load(object sender, EventArgs e)
        {
            BindingSource bdsDepartment = new BindingSource();
            bdsDepartment.DataSource = CurrentDepartment.Get();
            cboDepartment.DataSource = bdsDepartment;
            cboDepartment.DisplayMember = "DepartmentName";
            costList = new DepartmentCostCollection(bdsCost);
            bdsCost.ResetBindings(true);
            dgvCost.Refresh();
            dgvCost.Invalidate();
            DisableCostControls();
            txtCostDate.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            timer1.Start();
            DepartmentCostEventArgs eventArgs = new DepartmentCostEventArgs();
            EventUtility.fireEvent(SearchDepartmentCostEvent,this,eventArgs);

            if(eventArgs.CostList != null && eventArgs.CostList.Count > 0)
            {
                foreach (DepartmentCost cost in eventArgs.CostList)
                {
                    costList.Add(cost);
                }
            }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txtCostDate.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(dgvCost.CurrentCell ==null)
            {
                return;
            }
            if (!UpdateFlag)
            {
                UpdateFlag = true;
                EnableCostControls();
                btnEdit.Text = "Lưu";
                DepartmentCost cost = costList[dgvCost.CurrentCell.RowIndex];
                txtCost.Text = cost.Cost.ToString();
                txtCostName.Text = cost.CostName;
                txtCostDescription.Text = cost.CostDescription;
                cboCostType.SelectedIndex = (int)cost.CostType;
                dgvCost.Enabled = false;

                btnCreate.Enabled = false;
                btnCancel.Enabled = true;

            }
            else
            {
                DepartmentCost cost = costList[dgvCost.CurrentCell.RowIndex];
                cost.UpdateDate = DateTime.Now;
                cost.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                cost.Cost = Int64.Parse(txtCost.Text.Trim());
                cost.CostDescription = txtCostDescription.Text.Trim();
                cost.CostName = txtCostName.Text.Trim();
                cost.CostType = cboCostType.SelectedIndex;
                DepartmentCostEventArgs eventArgs = new DepartmentCostEventArgs();
                eventArgs.UpdateCost = cost;

                EventUtility.fireEvent(EditDepartmentCostEvent, this, eventArgs);
                if (!eventArgs.HasErrors)
                {
                    costList.Add(eventArgs.CreateCost);
                    bdsCost.ResetBindings(false);
                    dgvCost.Refresh();
                    dgvCost.Invalidate();
                    CreateFlag = false;
                    ClearCostControls();
                    DisableCostControls();
                    btnEdit.Text = "Sửa";
                    dgvCost.Enabled = true;

                    btnCreate.Enabled = true;
                    btnCancel.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Có lỗi khi sửa chi phí. Liên hệ người quản trị", "Lỗi", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearCostControls();
            DisableCostControls();
            btnEdit.Enabled = true;
            btnCreate.Enabled = true;
            btnEdit.Text = "Sửa";
            btnCreate.Text = "Tạo";
            dgvCost.Enabled = true;
        }

        private void dgvCost_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {

        }
        
    }
}
