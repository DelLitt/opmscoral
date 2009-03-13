using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AppFrame.Collection;
using AppFrame.Common;
using AppFrame.Model;
using AppFrame.Presenter.GoodsIO.DepartmentGoodsIO;
using AppFrame.Utility;
using AppFrame.View.GoodsIO.DepartmentGoodsIO;
using AppFrameClient.ViewModel;

namespace AppFrameClient.View.GoodsIO.DepartmentStockData
{
    public partial class DepartmentStockCheckingForm : AppFrame.Common.BaseForm, IDepartmentStockCheckingView
    {
        private DepartmentStockCollection stockList = null;
        public DepartmentStockCheckingForm()
        {
            InitializeComponent();
        }

        #region IDepartmentStockCheckingView Members

        public event EventHandler<AppFrame.Presenter.GoodsIO.DepartmentGoodsIO.DepartmentStockCheckingEventArgs> FillProductMasterToComboEvent;

        public event EventHandler<AppFrame.Presenter.GoodsIO.DepartmentGoodsIO.DepartmentStockCheckingEventArgs> LoadGoodsByProductIdEvent;

        public event EventHandler<AppFrame.Presenter.GoodsIO.DepartmentGoodsIO.DepartmentStockCheckingEventArgs> SaveInventoryCheckingEvent;

        private AppFrame.Presenter.GoodsIO.MainStock.IDepartmentStockCheckingController departmentStockCheckingController;        
        public AppFrame.Presenter.GoodsIO.MainStock.IDepartmentStockCheckingController DepartmentStockCheckingController
        {
            get
            {
                return departmentStockCheckingController;
            }
            set
            {
                departmentStockCheckingController = value;
                departmentStockCheckingController.DepartmentStockCheckingView = this;
            }
        }

        #endregion

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            LoadGoodsByProductId(txtBarcode.Text.Trim());
            txtBarcode.Focus();
        }

        private void LoadGoodsByProductId(string id)
        {
            DepartmentStockCheckingEventArgs checkingEventArgs = new DepartmentStockCheckingEventArgs();
            checkingEventArgs.InputBarcode = id;
            EventUtility.fireEvent(LoadGoodsByProductIdEvent, this, checkingEventArgs);
            DepartmentStock stock = checkingEventArgs.ScannedStock;
            if (stock == null)
            {
                MessageBox.Show("Không tìm thấy mã vạch trong kho", "Lỗi");
                return;
            }

            txtProductType.Text = stock.Product.ProductMaster.ProductType.TypeName;
            txtProductName.Text = stock.Product.ProductMaster.ProductName;
            txtStockQuantity.Text = stock.Quantity.ToString("##,##0");
            txtDescription.Text = stock.Product.ProductMaster.Description;
            pictureBox1.ImageLocation = stock.Product.ProductMaster.ImagePath;

            int stockDefIndex = -1;
            if (dgvStock.CurrentCell != null)
            {
                stockDefIndex = dgvStock.CurrentCell.RowIndex;
            }
            if (HasInStockDefectList(stock, stockList, out stockDefIndex))
            {
                if (stockDefIndex > -1 && stockDefIndex < stockList.Count)
                {
                    stockList[stockDefIndex].GoodQuantity += 1;
                    dgvStock.CurrentCell = dgvStock[5, stockDefIndex];
                }

            }
            else // create new stock defect row
            {
                    DepartmentStock defect = checkingEventArgs.ScannedStock;
                    stockList[stockList.Count - 1] = defect;
                    
                    stockList[stockList.Count - 1].GoodQuantity = 1;
                    stockList[stockList.Count - 1].OldErrorQuantity = stockList[stockList.Count - 1].ErrorQuantity = 0;
                    stockList[stockList.Count - 1].OldDamageQuantity = stockList[stockList.Count - 1].DamageQuantity = 0;
                    stockList[stockList.Count - 1].OldLostQuantity = stockList[stockList.Count - 1].LostQuantity = 0;
                    stockList[stockList.Count - 1].OldUnconfirmQuantity = stockList[stockList.Count - 1].UnconfirmQuantity = 0;

                    txtStockQuantity.Text = stockList[stockList.Count - 1].Quantity.ToString("##,##0");
                
                    
                
                dgvStock.CurrentCell = dgvStock[5, stockList.Count - 1];
            }
            bdsStockDefect.EndEdit();
            dgvStock.Refresh();
            dgvStock.Invalidate();
            txtBarcode.Text = "";
        }

        private bool HasInStockDefectList(DepartmentStock stock, DepartmentStockCollection list, out int stockDefIndex)
        {
            int count = 0;
            foreach (DepartmentStock stockDefect in list)
            {
                if (stockDefect.DepartmentStockPK.DepartmentId == stock.DepartmentStockPK.DepartmentId
                    && stockDefect.Product.ProductId.Equals(stock.DepartmentStockPK.ProductId))
                {
                    stockDefIndex = count;
                    return true;
                }
                count += 1;
            }
            stockDefIndex = count;
            return false;
        }

        private void DepartmentStockCheckingForm_Load(object sender, EventArgs e)
        {
            stockList = new DepartmentStockCollection(bdsStockDefect);
            bdsStockDefect.DataSource = stockList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (stockList.Count < 1)
            {
                MessageBox.Show("Không có gì để lưu");
            }
            DepartmentStockCheckingEventArgs checkingEventArgs = new DepartmentStockCheckingEventArgs();
            checkingEventArgs.SaveStockList = ObjectConverter.ConvertToNonGenericList(stockList);
            if(!CheckDepartmentDataIntegrity())
                return;
            EventUtility.fireEvent(SaveInventoryCheckingEvent, this, checkingEventArgs);
            MessageBox.Show("Lưu kết quả thành công");
            ClearForm();
        }
        private bool CheckDepartmentDataIntegrity()
        {
            for (int i = 0; i < stockList.Count; i++)
            {
                DepartmentStock defect = stockList[i];

                if (defect.ErrorQuantity < 0 || defect.GoodQuantity < 0 || defect.DamageQuantity < 0 || defect.LostQuantity < 0 || defect.UnconfirmQuantity < 0)
                {
                    MessageBox.Show("Lỗi ở dòng thứ " + (i + 1) + " : Có số lượng âm");
                    dgvStock.CurrentCell = dgvStock[5, i];
                    dgvStock.Focus();
                    return false;
                }

                long totalQuantity = defect.ErrorQuantity + defect.GoodQuantity + defect.DamageQuantity + defect.LostQuantity +
                                     defect.UnconfirmQuantity;
                if (defect.Quantity != totalQuantity)
                {
                    MessageBox.Show("Lỗi ở dòng thứ " + (i + 1) + " : Số lượng tồn không khớp với số lượng kiểm kê");
                    dgvStock.CurrentCell = dgvStock[5, i];
                    dgvStock.Focus();
                    return false;
                }
            }
            return true;
        }


        private void ClearForm()
        {
            stockList.Clear();
            txtBarcode.Text = "";
            txtDescription.Text = "";
            txtProductName.Text = "";
            txtProductType.Text = "";
            txtStockQuantity.Text = "0";
            pictureBox1.ImageLocation = "";
            txtBarcode.Focus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvStock_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DepartmentStock defect = stockList[e.RowIndex];
            long currError = defect.ErrorQuantity - defect.OldErrorQuantity;
            long currDamage = defect.DamageQuantity - defect.OldDamageQuantity;
            long currLost = defect.LostQuantity - defect.OldLostQuantity;
            long currUnconfirm = defect.UnconfirmQuantity - defect.OldUnconfirmQuantity;

            defect.GoodQuantity = defect.GoodQuantity - currUnconfirm - currError - currLost - currDamage;

            defect.OldDamageQuantity = defect.DamageQuantity;
            defect.OldErrorQuantity = defect.ErrorQuantity;
            defect.OldLostQuantity = defect.LostQuantity;
            defect.OldUnconfirmQuantity = defect.UnconfirmQuantity;

            bdsStockDefect.EndEdit();
            dgvStock.Refresh();
            dgvStock.Invalidate();

        }
    }
}
