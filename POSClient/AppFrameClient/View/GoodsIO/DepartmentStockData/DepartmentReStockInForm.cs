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
using AppFrame.Presenter.GoodsIO.MainStock;
using AppFrame.Utility;
using AppFrame.View.GoodsIO.DepartmentGoodsIO;
using AppFrameClient.Presenter.GoodsIO;

namespace AppFrameClient.View.GoodsIO.DepartmentStockData
{
    public partial class DepartmentReStockInForm : BaseForm,IDepartmentStockInView
    {

        private DepartmentStockInDetailCollection deptSIDetailList;
        
        public DepartmentStockIn deptSI { get; set; }
        

        public DepartmentReStockInForm()
        {
            InitializeComponent();
        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            //cboProductMasters.SelectedIndex;
            //            string productName = cboProductMasters.SelectedItem as string;
            //            BindingSource bindingSource = (BindingSource) cboProductMasters.DataSource;
            //            PopulateGridByProductMaster((ProductMaster) bindingSource[cboProductMasters.SelectedIndex]);
            if (string.IsNullOrEmpty(txtBarcode.Text))
            {
                MessageBox.Show("Hãy nhập mã vạch để tái nhập kho");
                return;
            }
            long outValue = 0;
            if (!NumberUtility.CheckLongNullIsZero(txtQty.Text, out outValue)
                || outValue < 0)
            {
                MessageBox.Show("Số lượng phải là số dương");
                return;
            }
            var eventArgs = new DepartmentStockInEventArgs();
            eventArgs.ProductId = txtBarcode.Text;
            EventUtility.fireEvent(FindByBarcodeEvent, this, eventArgs);
            if (eventArgs.EventResult != null)
            {
                if (eventArgs.DepartmentStockInDetail == null)
                {
                    MessageBox.Show("Không thể tìm thấy mã vạch " + txtBarcode.Text + " trong kho tạm xuất");
                    return;
                }
                else
                {
                    foreach (DepartmentStockInDetail detail in deptSIDetailList)
                    {
                        if (detail.Product.ProductId.Equals(eventArgs.DepartmentStockInDetail.Product.ProductId))
                        {
                            MessageBox.Show("Mã vạch " + txtBarcode.Text + " đã được nhập rồi");
                            return;
                        }
                    }
                }
                eventArgs.DepartmentStockInDetail.Quantity = outValue;
                deptSIDetailList.Add(eventArgs.DepartmentStockInDetail);
                deptSIDetailList.EndNew(deptSIDetailList.Count - 1);
                for (int i = 0; i < dgvDeptStockIn.ColumnCount; i++)
                {
                    if (i != 6)
                    {
                        dgvDeptStockIn[i, deptSIDetailList.Count - 1].Style.ForeColor = Color.Gray;
                    }
                }
            }
            CalculateTotalPrice();
        }

        private void CalculateTotalPrice()
        {
            
            long totalProduct = 0;
            foreach (DepartmentStockInDetail detail in deptSIDetailList)
            {
                if (detail.DelFlg == CommonConstants.DEL_FLG_NO)
                { 
                    totalProduct += detail.Quantity;
                }
            }
            txtSumProduct.Text = totalProduct.ToString();
        }

        #region IDepartmentStockInView Members

        private AppFrame.Presenter.GoodsIO.DepartmentGoodsIO.IDepartmentStockInController departmentStockInController;
        public AppFrame.Presenter.GoodsIO.DepartmentGoodsIO.IDepartmentStockInController DepartmentStockInController
        {
            set
            {
                departmentStockInController = value;
                departmentStockInController.DepartmentStockInView = this;
            }
        }

        public AppFrame.Presenter.GoodsIO.IProductMasterSearchOrCreateController productMasterSearchOrCreateController;
        public AppFrame.Presenter.GoodsIO.IProductMasterSearchOrCreateController ProductMasterSearchOrCreateController
        {
            set
            {
                productMasterSearchOrCreateController = value;
            }
        }

        public event EventHandler<AppFrame.Presenter.GoodsIO.DepartmentGoodsIO.DepartmentStockInEventArgs> InitDepartmentStockInEvent;

        public event EventHandler<AppFrame.Presenter.GoodsIO.ProductMasterSearchOrCreateEventArgs> OpenProductMasterSearchEvent;

        public event EventHandler<AppFrame.Presenter.GoodsIO.DepartmentGoodsIO.DepartmentStockInEventArgs> SaveDepartmentStockInEvent;

        public event EventHandler<AppFrame.Presenter.GoodsIO.DepartmentGoodsIO.DepartmentStockInEventArgs> FindProductMasterEvent;

        public event EventHandler<AppFrame.Presenter.GoodsIO.DepartmentGoodsIO.DepartmentStockInEventArgs> SyncDepartmentStockInEvent;

        #endregion

        #region IDepartmentStockInView Members


        public event EventHandler<DepartmentStockInEventArgs> FindByBarcodeEvent;

        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            long cost = 0;
            if (!NumberUtility.CheckLongNullIsZero(txtCost.Text, out cost) || cost < 0)
            {
                MessageBox.Show("Chi phí phải là số dương");
                return;
            }
            if (deptSIDetailList.Count == 0)
            {
                MessageBox.Show("Không có sản phẩm nào để nhập kho!!!!");
                return;
            }

            // validate quantity
            StringBuilder errMsg = new StringBuilder();
            int line = 1;
            foreach (DepartmentStockInDetail detail in deptSIDetailList)
            {
                if (detail.Quantity <= 0)
                {
                    MessageBox.Show("Lỗi ở dòng " + line + " : Số lượng phải lớn hơn 0");
                    return;
                }
                long remainReStock = detail.StockOutQuantity - detail.ReStockQuantity;
                if (detail.Quantity > remainReStock)
                {
                    MessageBox.Show("Lỗi ở dòng " + errMsg.ToString() + " : Số lượng còn tái nhập được là " + remainReStock.ToString());
                    return;
                }
                line++;
            }

            if (deptSI == null)
            {
                deptSI = new DepartmentStockIn();
                deptSI.DepartmentStockInPK = new DepartmentStockInPK();
            }
            bool isNeedClearData = string.IsNullOrEmpty(deptSI.DepartmentStockInPK.StockInId);
            deptSI.DepartmentId = CurrentDepartment.Get().DepartmentId;
            deptSI.StockInDate = dtpImportDate.Value;
            deptSI.DepartmentStockInDetails = deptSIDetailList;
            deptSI.Description = txtDexcription.Text;
            deptSI.StockInCost = cost;
            var eventArgs = new DepartmentStockInEventArgs();
            eventArgs.DepartmentStockIn = deptSI;
            EventUtility.fireEvent(SaveReDepartmentStockInEvent, this, eventArgs);
            if (eventArgs.EventResult != null)
            {
                MessageBox.Show("Lưu thành công");
                if (isNeedClearData)
                {
                    deptSI = new DepartmentStockIn();
                    deptSIDetailList.Clear();
                    txtBarcode.Text = "";
                    txtQty.Text = "";
                    txtDexcription.Text = "";
                    txtSumProduct.Text = "";
                    txtSumValue.Text = "";
                    //CreateNewStockInDetail();
                }
            }
            else
            {
                //MessageBox.Show("Có lỗi khi lưu");
            }
        }

        #region IDepartmentStockInView Members


        public event EventHandler<DepartmentStockInEventArgs> SaveReDepartmentStockInEvent;

        #endregion

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(dgvDeptStockIn.CurrentCell==null)
            {
                return;
            }
            DataGridViewSelectedRowCollection collection = dgvDeptStockIn.SelectedRows;
            foreach (DataGridViewRow row in collection)
            {
                deptSIDetailList.RemoveAt(row.Index);
            }
        }

        private void DepartmentReStockInForm_Load(object sender, EventArgs e)
        {
            deptSIDetailList = new DepartmentStockInDetailCollection(bdsStockIn);
            bdsStockIn.ResetBindings(true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtBarcode_Enter(object sender, EventArgs e)
        {
            txtBarcode.BackColor = Color.Green;
        }

        private void txtBarcode_Leave(object sender, EventArgs e)
        {
            txtBarcode.BackColor = Color.FromKnownColor(KnownColor.Window);
        }
    }
}
