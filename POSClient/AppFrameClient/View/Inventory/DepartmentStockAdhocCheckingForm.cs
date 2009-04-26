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
using AppFrame.Presenter.Inventory;
using AppFrame.Utility;
using AppFrame.View.GoodsIO.DepartmentGoodsIO;
using AppFrame.View.Inventory;
using AppFrameClient.Common;
using AppFrameClient.View.GoodsIO.DepartmentStockData;
using AppFrameClient.ViewModel;

namespace AppFrameClient.View.Inventory
{
    public partial class DepartmentStockAdhocCheckingForm : BaseForm, IDepartmentStockAdhocProcessingView
    {
        private DepartmentStockTempViewCollection stockList = null;
        public DepartmentStockAdhocCheckingForm()
        {
            InitializeComponent();
        }

        #region IDepartmentStockCheckingView Members

        
        #endregion

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            
        }

        private void LoadGoods()
        {
            /*DepartmentStockCheckingEventArgs checkingEventArgs = new DepartmentStockCheckingEventArgs();
            checkingEventArgs.InputBarcode = id;
            EventUtility.fireEvent(LoadGoodsByProductIdEvent, this, checkingEventArgs);
            DepartmentStockView stock = checkingEventArgs.ScannedStockView;
            if (stock == null)
            {
                if(!checkingEventArgs.UnconfirmTempBarcode)
                    MessageBox.Show("Không tìm thấy mã vạch trong kho", "Lỗi");
                return;
            }

            txtProductType.Text = stock.ProductMaster.ProductType.TypeName;
            txtProductName.Text = stock.ProductMaster.ProductName;
            txtStockQuantity.Text = stock.Quantity.ToString("##,##0");
            txtDescription.Text = stock.ProductMaster.Description;
            pictureBox1.ImageLocation = stock.ProductMaster.ImagePath;
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
                DepartmentStockView defect = checkingEventArgs.ScannedStockView;
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
            dgvStock.Invalidate();*/
            
        }

        private bool HasInStockDefectList(DepartmentStockView stock, DepartmentStockViewCollection list, out int stockDefIndex)
        {
            int count = 0;
            foreach (DepartmentStockView stockDefect in list)
            {
                if (stockDefect.ProductMaster.ProductMasterId.Equals(stock.ProductMaster.ProductMasterId))
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
            stockList = new DepartmentStockTempViewCollection(bdsStockDefect);
            bdsStockDefect.DataSource = stockList;
            bdsStockDefect.EndEdit();
            bdsStockDefect.ResetBindings(true);
            dgvStock.Refresh();
            dgvStock.Invalidate();

            stockList.Clear();
            DepartmentStockAdhocProcessingEventArgs eventArgs = new DepartmentStockAdhocProcessingEventArgs();

            EventUtility.fireEvent(LoadAdhocStocksEvent,this,eventArgs);
            if(eventArgs.DeptStockAdhocList!= null && eventArgs.DeptStockAdhocList.Count > 0)
            {
                foreach (DepartmentStockTempView stockTempView in eventArgs.DeptStockAdhocList)
                {
                    stockList.Add(stockTempView);
                }
                bdsStockDefect.EndEdit();
                dgvStock.Refresh();
                dgvStock.Invalidate();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (stockList.Count < 1)
            {
                MessageBox.Show("Không có gì để lưu");
                return;
            }
            DepartmentStockAdhocProcessingEventArgs checkingEventArgs = new DepartmentStockAdhocProcessingEventArgs();
            checkingEventArgs.DeptStockProcessedList = ObjectConverter.ConvertToNonGenericList(stockList);
            if (!CheckDepartmentDataIntegrity())
            {
                DialogResult result =
                    MessageBox.Show(
                        "Kết quả xử lý không hoàn tất. Bạn vẫn muốn lưu kết quả ?", "Cảnh báo",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if(result == DialogResult.No)
                {
                    return;    
                }
                
            }
            EventUtility.fireEvent(ProcessAdhocStocksEvent, this, checkingEventArgs);
            if (!checkingEventArgs.HasErrors)
            {
                MessageBox.Show("Lưu kết quả thành công");
                ClearForm();
            }
        }
        private bool CheckDepartmentDataIntegrity()
        {
            for (int i = 0; i < stockList.Count; i++)
            {
                DepartmentStockTempView defect = stockList[i];

                if (   defect.ErrorQuantity < 0 
                       || defect.GoodQuantity < 0 
                       || defect.DamageQuantity < 0 
                       || defect.LostQuantity < 0 
                       || defect.UnconfirmQuantity < 0)
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
            txtDescription.Text = "";
            txtProductName.Text = "";
            txtProductType.Text = "";
            txtStockQuantity.Text = "0";
            pictureBox1.ImageLocation = "";
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvStock_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DepartmentStockTempView defect = stockList[e.RowIndex];
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

        

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void dgvStock_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvStock_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvStock.CurrentCell == null)
            {
                return;
            }
            DataGridViewSelectedCellCollection cellCollection = dgvStock.SelectedCells;
            if(cellCollection.Count <= 0)
            {
                return;
            }
            /*DepartmentStockCheckingForm form = GlobalUtility.GetFormObject<DepartmentStockCheckingForm>(FormConstants.DEPARTMENT_STOCK_CHECKING_FORM);
            form.Status = ViewStatus.OPENDIALOG;
            form.RestrictDepartmentStocksChecked += new EventHandler(form_RestrictDepartmentStocksChecked);
            form.RestrictDepartmentStocks = stockList[cellCollection[0].RowIndex].DepartmentStocks;
            form.RestrictProductMaster = stockList[cellCollection[0].RowIndex].ProductMaster;
            form.Closing += new CancelEventHandler(form_Closing);
            // save current checking value
            foreach (DepartmentStock departmentStock in form.RestrictDepartmentStocks)
            {
                departmentStock.OldGoodQuantity = departmentStock.GoodQuantity;
                departmentStock.OldErrorQuantity = departmentStock.ErrorQuantity;
                departmentStock.OldUnconfirmQuantity = departmentStock.UnconfirmQuantity;
                departmentStock.OldDamageQuantity = departmentStock.DamageQuantity;
                departmentStock.OldLostQuantity = departmentStock.LostQuantity;
            }
            this.Enabled = false;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Show();*/

        }

        void form_Closing(object sender, CancelEventArgs e)
        {
            this.Enabled = true;
        }

        void form_RestrictDepartmentStocksChecked(object sender, EventArgs e)
        {
            DepartmentStockCheckingForm form = (DepartmentStockCheckingForm)sender;
            ProductMaster master = form.RestrictProductMaster;
            for(int i=0; i < stockList.Count;i++)
            {
                /*DepartmentStockView stockView = stockList[i];
                if (stockView.ProductMaster.ProductMasterId.Equals(master.ProductMasterId))
                {
                    bool isReadOnly = false;
                    stockView.DepartmentStocks = form.RestrictDepartmentStocks;
                    stockView.GoodQuantity = 0;
                    stockView.ErrorQuantity = 0;
                    stockView.UnconfirmQuantity = 0;
                    stockView.LostQuantity = 0;
                    stockView.DamageQuantity = 0;
                    foreach (DepartmentStock stock in stockView.DepartmentStocks)
                    {
                        stockView.GoodQuantity += stock.GoodQuantity;
                        stockView.ErrorQuantity += stock.ErrorQuantity;
                        stockView.UnconfirmQuantity += stock.UnconfirmQuantity;
                        stockView.LostQuantity += stock.LostQuantity;
                        stockView.DamageQuantity += stock.DamageQuantity;
                        if(    stock.GoodQuantity > 0 
                               || stock.ErrorQuantity > 0 
                               || stock.DamageQuantity > 0
                               || stock.LostQuantity > 0
                               || stock.UnconfirmQuantity > 0)
                        {
                            isReadOnly = true;
                        }
                    }
                    dgvStock.Rows[i].ReadOnly = isReadOnly;
                    foreach (DataGridViewCell cell in dgvStock.Rows[i].Cells)
                    {
                        if (cell.ColumnIndex >= 5)
                        {
                            cell.ReadOnly = isReadOnly;
                        }
                    }
                    

                    bdsStockDefect.EndEdit();
                    dgvStock.Refresh();
                    dgvStock.Invalidate();

                    return;
                }*/
            }
        }

        private void systemHotkey1_Pressed(object sender, EventArgs e)
        {

        }

        #region Implementation of IDepartmentStockAdhocProcessingView

        private IDepartmentStockAdhocProcessingController departmentStockAdhocProcessingController;
        public IDepartmentStockAdhocProcessingController DepartmentStockAdhocProcessingController
        {
            get
            {
                return departmentStockAdhocProcessingController;
            }
            set
            {
                departmentStockAdhocProcessingController = value;
                departmentStockAdhocProcessingController.DepartmentStockAdhocProcessingView = this;
            }
        }

        public event EventHandler<DepartmentStockAdhocProcessingEventArgs> LoadAdhocStocksEvent;
        public event EventHandler<DepartmentStockAdhocProcessingEventArgs> ProcessAdhocStocksEvent;

        #endregion
    }
}