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
using AppFrame.Presenter.GoodsIO.MainStock;
using AppFrame.Utility;
using AppFrame.View.GoodsIO.MainStock;
using AppFrameClient.Common;
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
            txtBarcode.Focus();
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
                    pictureBox1.Load();
                }

            int stockDefIndex = -1;
                if (dgvStock.CurrentCell != null)
                {
                    stockDefIndex = dgvStock.CurrentCell.RowIndex;
                }
                if (HasInStockList(stock, stockList, out stockDefIndex))
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
                }
            
                    /* ----------------- DEPARTMENT STOCK CHECKING --------------*/
                
                bdsStockDefect.EndEdit();
                dgvStock.Refresh();
                dgvStock.Invalidate();
                txtBarcode.Text = "";
        }

        private bool HasInStockList(Stock stock, StockCollection list, out int stockDefIndex)
        {
            int count = 0;
            foreach (Stock stockDefect in list)
            {
                if(stockDefect.StockId == stock.StockId)
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
                    return;
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
    }
}
