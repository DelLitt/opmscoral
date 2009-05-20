using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;
using AppFrame.Collection;
using AppFrame.Common;
using AppFrame.Model;
using AppFrame.Presenter.GoodsIO.DepartmentGoodsIO;
using AppFrame.Utility;
using AppFrame.View.GoodsIO.DepartmentGoodsIO;
using AppFrameClient.Common;
using AppFrameClient.ViewModel;

namespace AppFrameClient.View.GoodsIO.DepartmentStockData
{
    public partial class DepartmentStockViewCheckingForm : AppFrame.Common.BaseForm, IDepartmentStockCheckingView
    {
        private DepartmentStockViewCollection stockList = null;
        public DepartmentStockViewCheckingForm()
        {
            InitializeComponent();
        }

        #region IDepartmentStockCheckingView Members

        public event EventHandler<AppFrame.Presenter.GoodsIO.DepartmentGoodsIO.DepartmentStockCheckingEventArgs> FillProductMasterToComboEvent;

        public event EventHandler<AppFrame.Presenter.GoodsIO.DepartmentGoodsIO.DepartmentStockCheckingEventArgs> LoadGoodsByProductIdEvent;

        public event EventHandler<AppFrame.Presenter.GoodsIO.DepartmentGoodsIO.DepartmentStockCheckingEventArgs> SaveInventoryCheckingEvent;
        public event EventHandler<DepartmentStockCheckingEventArgs> SaveTempInventoryCheckingEvent;
        public event EventHandler<DepartmentStockCheckingEventArgs> LoadTempInventoryCheckingEvent;

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
            if (dgvStocks.CurrentCell != null)
            {
                stockDefIndex = dgvStocks.CurrentCell.RowIndex;
            }
            if (HasInStockDefectList(stock, stockList, out stockDefIndex))
            {
                if (stockDefIndex > -1 && stockDefIndex < stockList.Count)
                {
                    stockList[stockDefIndex].GoodQuantity += 1;
                    dgvStocks.CurrentCell = dgvStocks[5, stockDefIndex];
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
                    dgvStocks.CurrentCell = dgvStocks[5, stockList.Count - 1];
            }
            bdsStockDefect.EndEdit();
            dgvStocks.Refresh();
            dgvStocks.Invalidate();
            txtBarcode.Text = "";
            txtBarcode.Focus();
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
            stockList = new DepartmentStockViewCollection(bdsStockDefect);
            bdsStockDefect.DataSource = stockList;
            bdsStockDefect.EndEdit();
            bdsStockDefect.ResetBindings(true);
            dgvStocks.Refresh();
            dgvStocks.Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (stockList.Count < 1)
            {
                MessageBox.Show("Không có gì để lưu");
                return;
            }
            DepartmentStockCheckingEventArgs checkingEventArgs = new DepartmentStockCheckingEventArgs();
            checkingEventArgs.SaveStockViewList = ObjectConverter.ConvertToNonGenericList(stockList);
            if (!CheckDepartmentDataIntegrity())
            {
                DialogResult result =
                    MessageBox.Show(
                        "Kết quả kiểm kê không khớp với số liệu trong chương trình. Bạn vẫn muốn lưu kết quả ?","Cảnh báo",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if(result == DialogResult.No)
                {
                    return;    
                }
                
            }
            EventUtility.fireEvent(SaveInventoryCheckingEvent, this, checkingEventArgs);
            if (!checkingEventArgs.HasErrors)
            {
                MessageBox.Show("Lưu kết quả thành công");
                ClearForm();
                // clear all temp files
                ClearTempFiles();
            }
        }

        private void ClearTempFiles()
        {
            try
            {
                string saveTempPath = Environment.CurrentDirectory + "\\CheckingTemp";
                if (!Directory.Exists(saveTempPath))
                {
                    Directory.CreateDirectory(saveTempPath);
                }

                string[] files = Directory.GetFiles(saveTempPath, "*.tmpchk");
                foreach (string file in files)
                {
                    if(File.Exists(file))
                    {
                        File.Delete(file);
                    }
                }
            }
            catch (Exception exception)
            {
                
            }
        }

        private bool CheckDepartmentDataIntegrity()
        {
            for (int i = 0; i < stockList.Count; i++)
            {
                DepartmentStockView defect = stockList[i];

                if (   defect.ErrorQuantity < 0 
                    || defect.GoodQuantity < 0 
                    || defect.DamageQuantity < 0 
                    || defect.LostQuantity < 0 
                    || defect.UnconfirmQuantity < 0)
                {
                    MessageBox.Show("Lỗi ở dòng thứ " + (i + 1) + " : Có số lượng âm");
                    dgvStocks.CurrentCell = dgvStocks[5, i];
                    dgvStocks.Focus();
                    return false;
                }

                long totalQuantity = defect.ErrorQuantity + defect.GoodQuantity + defect.DamageQuantity + defect.LostQuantity +
                                     defect.UnconfirmQuantity;
                if (defect.Quantity != totalQuantity)
                {
                    MessageBox.Show("Lỗi ở dòng thứ " + (i + 1) + " : Số lượng tồn không khớp với số lượng kiểm kê");
                    dgvStocks.CurrentCell = dgvStocks[5, i];
                    dgvStocks.Focus();
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
            DialogResult result = MessageBox.Show("Bạn muốn thoát ? ", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                            MessageBoxDefaultButton.Button1);
            if(result == System.Windows.Forms.DialogResult.No)
            {
                return;
            }
            Close();
        }

        private void dgvStock_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DepartmentStockView defect = stockList[e.RowIndex];
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
            dgvStocks.Refresh();
            dgvStocks.Invalidate();

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

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string saveTempPath = Environment.CurrentDirectory + "\\CheckingTemp";
                if(!Directory.Exists(saveTempPath))
                {
                    Directory.CreateDirectory(saveTempPath); 
                }
                string saveTempFile = saveTempPath + "\\" + "deptChecking" + DateTime.Now.ToString("yyyyMMdd") + ".tmpchk";
                Stream stream = File.Open(saveTempFile, FileMode.Create);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(stream, ObjectConverter.ConvertToNonGenericList(stockList));
                stream.Close();
                MessageBox.Show("Lưu tạm thành công !", "Thành công");
            }
            catch (Exception)
            {
                MessageBox.Show("Lưu tạm thất bại !", "Thất bại");
            }
        }

        private void dgvStock_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvStock_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvStocks.CurrentCell == null)
            {
                return;
            }
            DataGridViewSelectedCellCollection cellCollection = dgvStocks.SelectedCells;
            if(cellCollection.Count <= 0)
            {
                return;
            }
            DepartmentStockCheckingForm form = GlobalUtility.GetFormObject<DepartmentStockCheckingForm>(FormConstants.DEPARTMENT_STOCK_CHECKING_FORM);
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
            form.Show();

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
                DepartmentStockView stockView = stockList[i];
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
                    dgvStocks.Rows[i].ReadOnly = isReadOnly;
                    foreach (DataGridViewCell cell in dgvStocks.Rows[i].Cells)
                    {
                        if (cell.ColumnIndex >= 5)
                        {
                            cell.ReadOnly = isReadOnly;
                        }
                    }
                    

                    bdsStockDefect.EndEdit();
                    dgvStocks.Refresh();
                    dgvStocks.Invalidate();

                    return;
                }
            }
        }

        private void mnuSum_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedCellCollection selectedCells = dgvStocks.SelectedCells;
            try
            {
                long sumQty = 0;
                foreach (DataGridViewCell cell in selectedCells)
                {
                    long qty = Int64.Parse(cell.Value.ToString());
                    sumQty += qty;
                }
                txtSum.Text = sumQty.ToString();
            }
            catch (Exception)
            {
                txtSum.Text = "N/A";
            }
        }

        private void dgvStocks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvStocks_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            long totalQty = 0;
            long totalGoodQty = 0;
            foreach (DepartmentStockView stockView in stockList)
            {
                totalQty += stockView.Quantity;
                totalGoodQty += stockView.GoodQuantity;
            }

            txtQuantity.Text = totalQty.ToString();
            txtGoodQuantity.Text = totalGoodQty.ToString();
        }

        private void btnTempLoad_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn muốn đọc từ file tạm ?","Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                            MessageBoxDefaultButton.Button2);
            if(result == DialogResult.No)
            {
                return;
            }
            try
            {
                string saveTempPath = Environment.CurrentDirectory + "\\CheckingTemp";
                if (!Directory.Exists(saveTempPath))
                {
                    Directory.CreateDirectory(saveTempPath);
                }
                string saveTempFile = saveTempPath + "\\" + "deptChecking" + DateTime.Now.ToString("yyyyMMdd") + ".tmpchk";
                Stream stream = File.Open(saveTempFile, FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();

                IList stockTempList = (IList) bf.Deserialize(stream);
                stream.Close();
                stockList.Clear();
                foreach (DepartmentStockView stockView in stockTempList)
                {
                    stockList.Add(stockView);
                }
                bdsStockDefect.EndEdit();
                dgvStocks.Refresh();
                dgvStocks.Invalidate();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Có lỗi khi đọc file tạm.");
            }
        }

        private void dgvStocks_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DepartmentStockView stock = stockList[dgvStocks.CurrentCell.RowIndex];

                txtProductType.Text = stock.ProductMaster.ProductType.TypeName;
                txtProductName.Text = stock.ProductMaster.ProductName;
                txtStockQuantity.Text = stock.Quantity.ToString("##,##0");
                txtDescription.Text = stock.ProductMaster.Description;
                pictureBox1.ImageLocation = stock.ProductMaster.ImagePath;
                if (!CheckUtility.IsNullOrEmpty(pictureBox1.ImageLocation))
                {
                    pictureBox1.Load();
                }
            }
            catch (Exception)
            {
                
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
