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
using AppFrame.Presenter.GoodsIO.MainStock;
using AppFrame.Utility;
using AppFrame.View.GoodsIO.MainStock;
using AppFrameClient.Common;
using AppFrameClient.Utility;
using AppFrameClient.View.GoodsIO.DepartmentStockData;
using AppFrameClient.ViewModel;

namespace AppFrameClient.View.GoodsIO.MainStock
{
    public partial class InventoryCheckingForm : AppFrame.Common.BaseForm,IInventoryCheckingView
    {
        private StockViewCollection stockViewList = null;
        private StockCollection stockList = null;

        private StockViewCollection deptStockViewList = null;
        private DepartmentStockCollection deptStockDefectList = null;



        public bool DepartmentChecking { get; set; }
        public InventoryCheckingForm()
        {
            InitializeComponent();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            LoadGoodsByProductId(txtBarcode.Text.Trim());
            CalculateTotal();
            txtBarcode.Focus();
        }

        private void CalculateTotal()
        {
            long totalSum = 0;
            long totalGoodSum = 0;
            foreach (Stock stock in stockList)
            {
                totalSum += stock.Quantity;
                totalGoodSum += stock.GoodQuantity;
            }
            txtSum.Text = totalSum.ToString();
            txtRealitySum.Text = totalGoodSum.ToString();
        }

        #region IInventoryCheckingView Members

        public event EventHandler<AppFrame.Presenter.GoodsIO.MainStock.InventoryCheckingEventArgs> FillProductMasterToComboEvent;

        public event EventHandler<AppFrame.Presenter.GoodsIO.MainStock.InventoryCheckingEventArgs> LoadGoodsByProductIdEvent;

        public event EventHandler<AppFrame.Presenter.GoodsIO.MainStock.InventoryCheckingEventArgs> SaveInventoryCheckingEvent;

        private AppFrame.Presenter.GoodsIO.MainStock.IInventoryCheckingController inventoryCheckingController;
        public AppFrame.Presenter.GoodsIO.MainStock.IInventoryCheckingController InventoryCheckingController
        {
            get
            {
                return inventoryCheckingController;
            }
            set
            {
                inventoryCheckingController = value;
                inventoryCheckingController.InventoryCheckingView = this;
            }
        }

        #endregion

        private void InventoryCheckingForm_Load(object sender, EventArgs e)
        {
            /*if(!DepartmentChecking)
            {*/
                stockViewList = new StockViewCollection(bdsProductMasters);
                bdsProductMasters.DataSource = stockViewList;
                bdsProductMasters.ResetBindings(true);
                stockList = new StockCollection(bdsStockDefect);
                bdsStockDefect.DataSource = stockList;    
                bdsStockDefect.ResetBindings(true);

            /*}
            else
            {
                deptStockDefectList = new DepartmentStockDefectCollection(bdsStockDefect);
                bdsStockDefect.DataSource = stockList;
                bdsStockDefect.ResetBindings(true);
            }*/
            
            //cboProductMasters.DisplayMember = "ProductMaster.TypeAndName";
            //LoadGoodsToCombo();

            txtSum.ForeColor = Color.Green;
            txtRealitySum.ForeColor = Color.Red;
        }

        private void LoadGoodsToCombo()
        {
            InventoryCheckingEventArgs checkingEventArgs = new InventoryCheckingEventArgs();
            EventUtility.fireEvent(FillProductMasterToComboEvent,this,checkingEventArgs);
            stockViewList.Clear();
            foreach(var obj in checkingEventArgs.ReturnStockViewList)
            {
                stockViewList.Add((StockView)obj);                
            }
            bdsProductMasters.EndEdit();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
             Close();
        }

        private ProductMasterSearchDepartmentForm form;
        private void button2_Click(object sender, EventArgs e)
        {
            form = GlobalUtility.GetOnlyChildFormObject<ProductMasterSearchDepartmentForm>(GlobalCache.Instance().MainForm, FormConstants.PRODUCT_MASTER_SEARCH_DEPARMENT_FORM);
            form.SelectProductEvent += new EventHandler<AppFrame.Presenter.GoodsIO.ProductMasterSearchDepartmentEventArgs>(form_SelectProductEvent);
            if (form != null)
                form.Show();
        }

        void form_SelectProductEvent(object sender, AppFrame.Presenter.GoodsIO.ProductMasterSearchDepartmentEventArgs e)
        {
            LoadGoodsByProductId(e.ReturnProduct.ProductId);
            
        }

        private void LoadGoodsByProductId(string id)
        {
            InventoryCheckingEventArgs checkingEventArgs = new InventoryCheckingEventArgs();
            /*if (!DepartmentChecking) 
            {*/
                /* ----------------- STOCK CHECKING --------------*/
                checkingEventArgs.InputBarcode = id;
                EventUtility.fireEvent(LoadGoodsByProductIdEvent, this, checkingEventArgs);
                Stock stock = checkingEventArgs.ScannedStock;
                if (stock == null)
                {
                    MessageBox.Show("Không tìm thấy mã vạch trong kho", "Lỗi");
                    return;
                }

                if (stock.ProductMaster.ProductType != null)
                    txtProductType.Text = stock.ProductMaster.ProductType.TypeName;

                txtProductName.Text = stock.ProductMaster.ProductName;

                txtDescription.Text = stock.ProductMaster.Description;
                pictureBox1.ImageLocation = stock.ProductMaster.ImagePath;
                if (!string.IsNullOrEmpty(pictureBox1.ImageLocation))
                {
                    if(File.Exists(pictureBox1.ImageLocation)) pictureBox1.Load();
                }

                int stockDefIndex = -1;
                Stock foundStock = GetFromStockList(stock, stockList);
                
                if(foundStock != null)
                {
                    foundStock.GoodQuantity += 1;
                }
                else
                {
                    stock.GoodQuantity = 1;
                   stockList.Add(stock); 
                }
                /*if (HasInStockList(stock, stockList, out stockDefIndex))
                {
                    if (stockDefIndex > -1 && stockDefIndex < stockList.Count)
                    {
                        stockList[stockDefIndex].GoodQuantity += 1;
                        dgvStock.CurrentCell = dgvStock[5, stockDefIndex];
                    }

                }
                else // create new stock defect row
                {
                        Stock newStockDefect = stockList.AddNew();
                    
                        // assign total quantity
                        Stock defect = checkingEventArgs.ScannedStock;
                        stockList[stockList.Count - 1] = defect;
                        
                        txtStockQuantity.Text = stockList[stockList.Count - 1].Quantity.ToString("##,##0");

                        stockList[stockList.Count - 1].OldGoodQuantity = stockList[stockList.Count - 1].GoodQuantity = 1;

                        stockList[stockList.Count - 1].OldDamageQuantity = stockList[stockList.Count - 1].DamageQuantity = 0;

                        stockList[stockList.Count - 1].OldErrorQuantity =stockList[stockList.Count - 1].ErrorQuantity = 0;

                        stockList[stockList.Count - 1].OldUnconfirmQuantity = stockList[stockList.Count - 1].UnconfirmQuantity = 0;

                        stockList[stockList.Count - 1].OldLostQuantity = stockList[stockList.Count - 1].LostQuantity = 0;

                    
                    dgvStock.CurrentCell = dgvStock[5, stockList.Count - 1];
                }*/
            
                    /* ----------------- DEPARTMENT STOCK CHECKING --------------*/
                
                bdsStockDefect.EndEdit();
                bdsStockDefect.ResetBindings(false);
                dgvStock.Refresh();
                dgvStock.Invalidate();
                int stockIndex = GetIndexFromList(stock, stockList);
                dgvStock.CurrentCell = dgvStock[5, stockIndex];
                txtBarcode.Text = "";
                txtBarcode.Focus();
        }

        private int GetIndexFromList(Stock stock, StockCollection collection)
        {

            for(int i=0;i<collection.Count;i++)
            {
                if(collection[i].Product.ProductId.Equals(stock.Product.ProductId))
                {
                    return i;
                }
            }
            return -1;
        }

        private Stock GetFromStockList(Stock stock, StockCollection collection)
        {
            foreach (Stock stockChecked in collection)
            {
                if (stockChecked.Product.ProductId.Equals(stock.Product.ProductId))
                {
                    return stockChecked;
                }
            }
            return null;
        }

        private bool HasInStockList(Stock stock, StockCollection list, out int stockDefIndex)
        {
            int count = -1;
            foreach (Stock stockDefect in list)
            {
                if(stockDefect.Product.ProductId.Equals(stock.Product.ProductId))
                {
                    stockDefIndex = count;
                    return true;
                }
                count += 1;
            }
            stockDefIndex = count;
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(stockList.Count < 1)
            {
                MessageBox.Show("Không có gì để lưu");
                return;
            }
                /* ----------------- STOCK CHECKING --------------*/
                InventoryCheckingEventArgs checkingEventArgs = new InventoryCheckingEventArgs();
                checkingEventArgs.SaveStockList = ObjectConverter.ConvertToNonGenericList(stockList);
                if (!CheckDataIntegrity())
                {
                    DialogResult result = MessageBox.Show("Số lượng không khớp, bạn vẫn muốn lưu ?", "Cảnh báo",
                                                          MessageBoxButtons.YesNo);
                    if (result == DialogResult.No) return;
                }
                
                EventUtility.fireEvent(SaveInventoryCheckingEvent, this, checkingEventArgs);
                if (!checkingEventArgs.HasErrors)
                {
                    MessageBox.Show("Lưu kết quả thành công");
                    ClearForm();
                }
        }

        

        private bool CheckDataIntegrity()
        {

            for(int i = 0; i < stockList.Count;i++)
            {
                Stock stock = stockList[i];

                if(stock.ErrorQuantity < 0 || stock.GoodQuantity < 0 || stock.DamageQuantity < 0 || stock.LostQuantity < 0 || stock.UnconfirmQuantity < 0 )
                {
                    MessageBox.Show("Lỗi ở dòng thứ " + (i + 1) + " : Có số lượng âm");
                    dgvStock.CurrentCell = dgvStock[5, i];
                    return false;
                }

                long totalQuantity = stock.ErrorQuantity + stock.GoodQuantity + stock.DamageQuantity + stock.LostQuantity +
                                     stock.UnconfirmQuantity;
                if(stock.Quantity!=totalQuantity)
                {
                    MessageBox.Show("Lỗi ở dòng thứ " + (i + 1) + " : Số lượng tồn không khớp với số lượng kiểm kê");
                    dgvStock.CurrentCell = dgvStock[5, i];
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

        private void dgvStock_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        #region IInventoryCheckingView Members


        public event EventHandler<InventoryCheckingEventArgs> LoadDepartmentGoodsByProductIdEvent;

        public event EventHandler<InventoryCheckingEventArgs> SaveDepartmentInventoryCheckingEvent;

        #endregion

        private void dgvStock_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Stock stock = stockList[e.RowIndex];
            long currError = stock.ErrorQuantity - stock.OldErrorQuantity;
            long currDamage = stock.DamageQuantity - stock.OldDamageQuantity;
            long currLost = stock.LostQuantity - stock.OldLostQuantity;
            long currUnconfirm = stock.UnconfirmQuantity - stock.OldUnconfirmQuantity;

            stock.GoodQuantity = stock.GoodQuantity - currUnconfirm - currError - currLost - currDamage;

            stock.OldDamageQuantity = stock.DamageQuantity;
            stock.OldErrorQuantity = stock.ErrorQuantity;
            stock.OldLostQuantity = stock.LostQuantity;
            stock.OldUnconfirmQuantity = stock.UnconfirmQuantity;

            bdsStockDefect.EndEdit();
            CalculateTotal();
            bdsStockDefect.ResetBindings(false);
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

        private void btnTempSave_Click(object sender, EventArgs e)
        {
            try
            {
                string saveTempPath = Environment.CurrentDirectory + "\\CheckingTemp";
                if (!Directory.Exists(saveTempPath))
                {
                    Directory.CreateDirectory(saveTempPath);
                }
                string saveTempFile = saveTempPath + "\\" + "mainStockChecking" + DateTime.Now.ToString("yyyyMMdd") + ".tmpchk";
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

        private void btnLoadTemp_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn muốn đọc từ file tạm ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                            MessageBoxDefaultButton.Button2);
            if (result == DialogResult.No)
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
                string saveTempFile = saveTempPath + "\\" + "mainStockChecking" + DateTime.Now.ToString("yyyyMMdd") + ".tmpchk";
                Stream stream = File.Open(saveTempFile, FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();

                IList stockTempList = (IList)bf.Deserialize(stream);
                stream.Close();
                stockList.Clear();
                //scanTypesList.Clear();
                foreach (Stock stockView in stockTempList)
                {
                    stockList.Add(stockView);
                    //UpdateScanType(stockView);
                }
                
                bdsStockDefect.ResetBindings(false);
                dgvStock.Refresh();
                dgvStock.Invalidate();
                CalculateTotal();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Có lỗi khi đọc file tạm.");
            }
        }

        private void countRealToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedCellCollection selectedCells = dgvStock.SelectedCells;
            try
            {
                long sumQty = 0;
                foreach (DataGridViewCell cell in selectedCells)
                {
                    long qty = 0;
                    //long qty = Int64.Parse(cell.Value.ToString());
                    ClientUtility.TryActionHelper(delegate { qty = Int64.Parse(cell.Value.ToString()); },1);
                    sumQty += qty;
                }
                lblStatus.Text = "Số lượng : " + sumQty.ToString();
            }
            catch (Exception)
            {
                lblStatus.Text = "N/A";
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selectedRowCollection = dgvStock.SelectedRows;

            ArrayList removeIndices = new ArrayList();
            foreach (DataGridViewRow row in selectedRowCollection)
            {
                removeIndices.Add(row.Index);
            }
            
            removeIndices.Sort();
            
            for(int i = removeIndices.Count-1;i >=0;i--)
            {
                 stockList.RemoveAt((int)removeIndices[i]);                   
            }
            CalculateTotal();
        }

    }
}
