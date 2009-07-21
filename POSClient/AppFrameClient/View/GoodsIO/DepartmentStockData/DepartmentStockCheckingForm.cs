using System;
using System.Collections;
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
        public event EventHandler RestrictDepartmentStocksChecked;
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

        public event EventHandler<DepartmentStockCheckingEventArgs> SaveTempInventoryCheckingEvent;
        public event EventHandler<DepartmentStockCheckingEventArgs> LoadTempInventoryCheckingEvent;

        #endregion

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            LoadGoodsByProductId(txtBarcode.Text.Trim());
            txtBarcode.Focus();
        }

        private void LoadGoodsByProductId(string id)
        {
            if(this.Status == ViewStatus.OPENDIALOG)
            {
                bool checkInList = false;
                if(RestrictDepartmentStocks!=null)
                {
                    foreach (DepartmentStock departmentStock in RestrictDepartmentStocks)
                    {
                        if(departmentStock.Product.ProductId.Equals(id))
                        {
                            checkInList = true;                            
                        }
                    }
                }
                if(!checkInList)
                {
                    string productName = "";
                    if(RestrictProductMaster!=null)
                    {
                        productName = RestrictProductMaster.ProductName;    
                    }
                    MessageBox.Show("Mã vạch không phải của mặt hàng " + productName + " cần kiểm tra", "Lỗi");
                    return;
                }
            }
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
            if(!CheckUtility.IsNullOrEmpty(pictureBox1.ImageLocation))
            {
                pictureBox1.Load();
            }

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
                    stockList.AddNew();
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
            txtBarcode.Focus();
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
            bdsStockDefect.ResetBindings(true);
            if(Status == ViewStatus.OPENDIALOG)
            {
                button4.Enabled = false;
                if(RestrictDepartmentStocks!=null && RestrictDepartmentStocks.Count > 0)
                {
                    foreach (DepartmentStock departmentStock in RestrictDepartmentStocks)
                    {
                        stockList.Add(departmentStock);                        
                    }                        
                    bdsStockDefect.EndEdit();
                    dgvStock.Refresh();
                    dgvStock.Invalidate();
                }
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (stockList.Count < 1)
            {
                MessageBox.Show("Không có gì để lưu");
            }
            DepartmentStockCheckingEventArgs checkingEventArgs = new DepartmentStockCheckingEventArgs();
            checkingEventArgs.SaveStockList = ObjectConverter.ConvertToNonGenericList(stockList);
            
            if(Status == ViewStatus.OPENDIALOG )
            {
                if(!CheckDepartmentDataIntegrity())
                {
                    DialogResult result =MessageBox.Show(
                        "Số liệu trong chương trình không khớp với số liệu kiểm kê thực tế. Bạn vẫn muốn chấp nhận kết quả kiểm kê này ?",
                        "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                    if(result == DialogResult.No)
                    {
                        return;
                    }
                }
                this.RestrictDepartmentStocks = checkingEventArgs.SaveStockList;
                if(this.RestrictDepartmentStocksChecked!=null)
                {
                    RestrictDepartmentStocksChecked(this, null);    
                }
                Close();
                return;
            }
            if (!CheckDepartmentDataIntegrity())
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
            if(Status == ViewStatus.OPENDIALOG)
            {
                foreach (DepartmentStock departmentStock in RestrictDepartmentStocks)
                {
                     departmentStock.GoodQuantity = departmentStock.OldGoodQuantity ;
                     departmentStock.ErrorQuantity = departmentStock.OldErrorQuantity ;
                     departmentStock.UnconfirmQuantity = departmentStock.OldUnconfirmQuantity ;
                     departmentStock.DamageQuantity = departmentStock.OldDamageQuantity ;
                     departmentStock.LostQuantity = departmentStock.OldLostQuantity ;
                }
            }
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

        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBarcode.Text) && txtBarcode.Text.Length == CommonConstants.PRODUCT_ID_LENGTH)
            {
                btnConfirm_Click(this, null);
            }
        }

        private void txtBarcode_Enter(object sender, EventArgs e)
        {
            txtBarcode.BackColor = Color.LightGreen;
        }

        private void txtBarcode_Leave(object sender, EventArgs e)
        {
            txtBarcode.BackColor = Color.White;
        }

        private void systemHotkey1_Pressed(object sender, EventArgs e)
        {
            txtBarcode.Focus();
        }

        public IList RestrictDepartmentStocks { get; set; }
        public ProductMaster RestrictProductMaster { get; set; }

        private void ctxShortcuts_Opening(object sender, CancelEventArgs e)
        {

        }
    }
}
