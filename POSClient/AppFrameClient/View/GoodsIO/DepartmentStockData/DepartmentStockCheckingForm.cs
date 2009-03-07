using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
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
        private DepartmentStockDefectCollection stockDefectList = null;
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
            if (HasInStockDefectList(stock, stockDefectList, out stockDefIndex))
            {
                if (stockDefIndex > -1 && stockDefIndex < stockDefectList.Count)
                {
                    stockDefectList[stockDefIndex].GoodCount += 1;
                    dgvStock.CurrentCell = dgvStock[5, stockDefIndex];
                }

            }
            else // create new stock defect row
            {
                DepartmentStockDefect newStockDefect = stockDefectList.AddNew();

                if (checkingEventArgs.ScannedStockDefect != null)
                {
                    stockDefectList[stockDefectList.Count - 1] = checkingEventArgs.ScannedStockDefect;
                    stockDefectList[stockDefectList.Count - 1].GoodCount = 1;
                    stockDefectList[stockDefectList.Count - 1].Quantity = stock.Quantity;
                    stockDefectList[stockDefectList.Count - 1].DepartmentStock = stock;

                    stockDefectList[stockDefectList.Count - 1].OldErrorCount = stockDefectList[stockDefectList.Count - 1].ErrorCount;
                    stockDefectList[stockDefectList.Count - 1].OldDamageCount = stockDefectList[stockDefectList.Count - 1].DamageCount;
                    stockDefectList[stockDefectList.Count - 1].OldLostCount = stockDefectList[stockDefectList.Count - 1].LostCount;
                    stockDefectList[stockDefectList.Count - 1].OldUnconfirmCount = stockDefectList[stockDefectList.Count - 1].UnconfirmCount;

                }
                else
                {
                    newStockDefect.Product = stock.Product;
                    newStockDefect.ProductMaster = stock.Product.ProductMaster;
                    newStockDefect.DepartmentStock = stock;
                    newStockDefect.Quantity = stock.Quantity;
                    DepartmentStockDefectPK defectPK = new DepartmentStockDefectPK();
                    defectPK.DepartmentId = CurrentDepartment.Get().DepartmentId;
                    newStockDefect.DepartmentStockDefectPK = defectPK;
                    newStockDefect.GoodCount += 1;
                    
                    newStockDefect.OldDamageCount = newStockDefect.DamageCount;
                    newStockDefect.OldErrorCount = newStockDefect.ErrorCount;
                    newStockDefect.OldUnconfirmCount = newStockDefect.UnconfirmCount;
                    newStockDefect.OldLostCount = newStockDefect.LostCount;
                    
                }
                dgvStock.CurrentCell = dgvStock[5, stockDefectList.Count - 1];
            }
            bdsStockDefect.EndEdit();
            dgvStock.Refresh();
            dgvStock.Invalidate();
            txtBarcode.Text = "";
        }

        private bool HasInStockDefectList(DepartmentStock stock, DepartmentStockDefectCollection list, out int stockDefIndex)
        {
            int count = 0;
            foreach (DepartmentStockDefect stockDefect in list)
            {
                if (stockDefect.DepartmentStockDefectPK.DepartmentId == stock.DepartmentStockPK.DepartmentId
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
            stockDefectList = new DepartmentStockDefectCollection(bdsStockDefect);
            bdsStockDefect.DataSource = stockDefectList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (stockDefectList.Count < 1)
            {
                MessageBox.Show("Không có gì để lưu");
            }
            DepartmentStockCheckingEventArgs checkingEventArgs = new DepartmentStockCheckingEventArgs();
            checkingEventArgs.SaveStockDefectList = ObjectConverter.ConvertToNonGenericList(stockDefectList);

            EventUtility.fireEvent(SaveInventoryCheckingEvent, this, checkingEventArgs);
            MessageBox.Show("Lưu kết quả thành công");
            ClearForm();
        }

        private void ClearForm()
        {
            stockDefectList.Clear();
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
    }
}
