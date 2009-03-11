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
                    DepartmentStockDefect defect = checkingEventArgs.ScannedStockDefect;
                    stockDefectList[stockDefectList.Count - 1] = defect;
                    if (defect.ErrorCount != 0
                            || defect.DamageCount != 0
                            || defect.LostCount != 0
                            || defect.UnconfirmCount != 0)
                    {
                        stockDefectList[stockDefectList.Count - 1].Quantity = stock.Quantity + defect.ErrorCount +
                                                                              defect.DamageCount +
                                                                              defect.UnconfirmCount +
                                                                              defect.LostCount;
                    }
                    else
                    {
                        stockDefectList[stockDefectList.Count - 1].Quantity = stock.Quantity;
                    }
                    txtStockQuantity.Text = stockDefectList[stockDefectList.Count - 1].Quantity.ToString("##,##0");

                    stockDefectList[stockDefectList.Count - 1].DepartmentStock = stock;
                    stockDefectList[stockDefectList.Count - 1].GoodCount = 1;
                    stockDefectList[stockDefectList.Count - 1].OldErrorCount = stockDefectList[stockDefectList.Count - 1].ErrorCount = 0;
                    stockDefectList[stockDefectList.Count - 1].OldDamageCount = stockDefectList[stockDefectList.Count - 1].DamageCount = 0;
                    stockDefectList[stockDefectList.Count - 1].OldLostCount = stockDefectList[stockDefectList.Count - 1].LostCount = 0;
                    stockDefectList[stockDefectList.Count - 1].OldUnconfirmCount = stockDefectList[stockDefectList.Count - 1].UnconfirmCount = 0;

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
                    newStockDefect.GoodCount = 1;
                    
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
            if(!CheckDepartmentDataIntegrity())
                return;
            EventUtility.fireEvent(SaveInventoryCheckingEvent, this, checkingEventArgs);
            MessageBox.Show("Lưu kết quả thành công");
            ClearForm();
        }
        private bool CheckDepartmentDataIntegrity()
        {
            for (int i = 0; i < stockDefectList.Count; i++)
            {
                DepartmentStockDefect defect = stockDefectList[i];

                if (defect.ErrorCount < 0 || defect.GoodCount < 0 || defect.DamageCount < 0 || defect.LostCount < 0 || defect.UnconfirmCount < 0)
                {
                    MessageBox.Show("Lỗi ở dòng thứ " + (i + 1) + " : Có số lượng âm");
                    dgvStock.CurrentCell = dgvStock[5, i];
                    dgvStock.Focus();
                    return false;
                }

                long totalQuantity = defect.ErrorCount + defect.GoodCount + defect.DamageCount + defect.LostCount +
                                     defect.UnconfirmCount;
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

        private void dgvStock_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DepartmentStockDefect defect = stockDefectList[e.RowIndex];
            int currError = defect.ErrorCount - defect.OldErrorCount;
            int currDamage = defect.DamageCount - defect.OldDamageCount;
            int currLost = defect.LostCount - defect.OldLostCount;
            int currUnconfirm = defect.UnconfirmCount - defect.OldUnconfirmCount;

            defect.GoodCount = defect.GoodCount - currUnconfirm - currError - currLost - currDamage;

            defect.OldDamageCount = defect.DamageCount;
            defect.OldErrorCount = defect.ErrorCount;
            defect.OldLostCount = defect.LostCount;
            defect.OldUnconfirmCount = defect.UnconfirmCount;

            bdsStockDefect.EndEdit();
            dgvStock.Refresh();
            dgvStock.Invalidate();

        }
    }
}
