using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
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
        private StockDefectCollection stockDefectList = null;

        private StockViewCollection deptStockViewList = null;
        private DepartmentStockDefectCollection deptStockDefectList = null;



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
                stockDefectList = new StockDefectCollection(bdsStockDefect);
                bdsStockDefect.DataSource = stockDefectList;    
                bdsStockDefect.ResetBindings(true);

            /*}
            else
            {
                deptStockDefectList = new DepartmentStockDefectCollection(bdsStockDefect);
                bdsStockDefect.DataSource = stockDefectList;
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
                    StockDefect newStockDefect = stockDefectList.AddNew();

                    if (checkingEventArgs.ScannedStockDefect != null)
                    {
                        
                        // assign total quantity
                        StockDefect defect = checkingEventArgs.ScannedStockDefect;
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

                        stockDefectList[stockDefectList.Count - 1].GoodCount = 1;

                        stockDefectList[stockDefectList.Count - 1].OldDamageCount =
                            stockDefectList[stockDefectList.Count - 1].DamageCount = 0;

                        stockDefectList[stockDefectList.Count - 1].OldErrorCount =
                            stockDefectList[stockDefectList.Count - 1].ErrorCount = 0;

                        stockDefectList[stockDefectList.Count - 1].OldUnconfirmCount =
                            stockDefectList[stockDefectList.Count - 1].UnconfirmCount = 0;

                        stockDefectList[stockDefectList.Count - 1].OldLostCount =
                            stockDefectList[stockDefectList.Count - 1].LostCount = 0;

                    }
                    else
                    {
                        newStockDefect.Product = stock.Product;
                        newStockDefect.ProductMaster = stock.ProductMaster;
                        newStockDefect.Stock = stock;
                        newStockDefect.Quantity = stock.Quantity;
                        newStockDefect.GoodCount = 1;

                        newStockDefect.OldDamageCount = newStockDefect.DamageCount;
                        newStockDefect.OldErrorCount = newStockDefect.ErrorCount;
                        newStockDefect.OldUnconfirmCount = newStockDefect.UnconfirmCount;
                        newStockDefect.OldLostCount = newStockDefect.LostCount;
                    }
                    dgvStock.CurrentCell = dgvStock[5, stockDefectList.Count - 1];
                }
            
                    /* ----------------- DEPARTMENT STOCK CHECKING --------------*/
                /* }
                 * else   
                {
                    checkingEventArgs.InputBarcode = id;
                    EventUtility.fireEvent(LoadDepartmentGoodsByProductIdEvent, this, checkingEventArgs);
                    DepartmentStock stock = checkingEventArgs.ScannedDepartmentStock;
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

                    int stockDefIndex = -1;
                    if (dgvStock.CurrentCell != null)
                    {
                        stockDefIndex = dgvStock.CurrentCell.RowIndex;
                    }
                    if (HasInDepartmentStockDefectList(stock, deptStockDefectList, out stockDefIndex))
                    {
                        if (stockDefIndex > -1 && stockDefIndex < deptStockDefectList.Count)
                        {
                            deptStockDefectList[stockDefIndex].GoodCount += 1;
                            dgvStock.CurrentCell = dgvStock[5, stockDefIndex];
                        }

                    }
                    else // create new department stock defect row
                    {
                        DepartmentStockDefect newStockDefect = deptStockDefectList.AddNew();

                        if (checkingEventArgs.ScannedDepartmentStockDefect != null)
                        {
                            txtStockQuantity.Text =
                                (stock.Quantity + checkingEventArgs.ScannedStockDefect.GoodCount).ToString("##,##0");
                            // assign total quantity
                            DepartmentStockDefect defect = checkingEventArgs.ScannedDepartmentStockDefect;
                            deptStockDefectList[deptStockDefectList.Count - 1] = defect;

                            if (defect.ErrorCount != 0
                                || defect.DamageCount != 0
                                || defect.LostCount != 0
                                || defect.UnconfirmCount != 0)
                            {
                                deptStockDefectList[deptStockDefectList.Count - 1].Quantity = stock.Quantity + defect.ErrorCount +
                                                                                      defect.DamageCount +
                                                                                      defect.UnconfirmCount +
                                                                                      defect.LostCount;
                            }
                            else
                            {
                                deptStockDefectList[deptStockDefectList.Count - 1].Quantity = stock.Quantity;
                            }

                            deptStockDefectList[deptStockDefectList.Count - 1].GoodCount = 1;

                            deptStockDefectList[deptStockDefectList.Count - 1].OldDamageCount =
                                deptStockDefectList[deptStockDefectList.Count - 1].DamageCount = 0;

                            deptStockDefectList[deptStockDefectList.Count - 1].OldErrorCount =
                                deptStockDefectList[deptStockDefectList.Count - 1].ErrorCount = 0;

                            deptStockDefectList[deptStockDefectList.Count - 1].OldUnconfirmCount =
                                deptStockDefectList[deptStockDefectList.Count - 1].UnconfirmCount = 0;

                            deptStockDefectList[deptStockDefectList.Count - 1].OldLostCount =
                                deptStockDefectList[deptStockDefectList.Count - 1].LostCount = 0;

                        }
                        else
                        {
                            newStockDefect.Product = stock.Product;
                            newStockDefect.ProductMaster = stock.ProductMaster;
                            newStockDefect.DepartmentStock = stock;
                            newStockDefect.Quantity = stock.Quantity;
                            newStockDefect.GoodCount = 1;

                            newStockDefect.OldDamageCount = newStockDefect.DamageCount;
                            newStockDefect.OldErrorCount = newStockDefect.ErrorCount;
                            newStockDefect.OldUnconfirmCount = newStockDefect.UnconfirmCount;
                            newStockDefect.OldLostCount = newStockDefect.LostCount;
                        }
                        dgvStock.CurrentCell = dgvStock[5, deptStockDefectList.Count - 1];
                    }
                }*/
            bdsStockDefect.EndEdit();
            dgvStock.Refresh();
            dgvStock.Invalidate();
            txtBarcode.Text = "";
        }

        private bool HasInDepartmentStockDefectList(DepartmentStock stock, DepartmentStockDefectCollection list, out int stockDefIndex)
        {
            int count = 0;
            foreach (DepartmentStockDefect stockDefect in list)
            {
                if (stockDefect.DepartmentStock.DepartmentStockPK.DepartmentId == stock.DepartmentStockPK.DepartmentId
                    && stockDefect.DepartmentStock.DepartmentStockPK.ProductId == stock.DepartmentStockPK.ProductId)
                {
                    stockDefIndex = count;
                    return true;
                }
                count += 1;
            }
            stockDefIndex = count;
            return false;
        }

        private bool HasInStockDefectList(Stock stock, StockDefectCollection list, out int stockDefIndex)
        {
            int count = 0;
            foreach (StockDefect stockDefect in list)
            {
                if(stockDefect.Stock.StockId == stock.StockId)
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
            if(stockDefectList.Count < 1)
            {
                MessageBox.Show("Không có gì để lưu");
                return;
            }
            /*if (!DepartmentChecking)
            {*/
                /* ----------------- STOCK CHECKING --------------*/
                InventoryCheckingEventArgs checkingEventArgs = new InventoryCheckingEventArgs();
                checkingEventArgs.SaveStockDefectList = ObjectConverter.ConvertToNonGenericList(stockDefectList);
                if (!CheckDataIntegrity())
                    return;
                EventUtility.fireEvent(SaveInventoryCheckingEvent, this, checkingEventArgs);
                if (!checkingEventArgs.HasErrors)
                {
                    MessageBox.Show("Lưu kết quả thành công");
                    ClearForm();
                }
            /*}
            else
            {*/
                /* ----------------- DEPARTMENT STOCK CHECKING --------------*/
             /*   InventoryCheckingEventArgs checkingEventArgs = new InventoryCheckingEventArgs();
                checkingEventArgs.SaveDepartmentStockDefectList = ObjectConverter.ConvertToNonGenericList(stockDefectList);
                if(!CheckDepartmentDataIntegrity())
                    return;
                EventUtility.fireEvent(SaveDepartmentInventoryCheckingEvent, this, checkingEventArgs);
                if (!checkingEventArgs.HasErrors)
                {
                    MessageBox.Show("Lưu kết quả thành công");
                    ClearForm();
                }
            }*/
        }

        private bool CheckDepartmentDataIntegrity()
        {
            for (int i = 0; i < stockDefectList.Count; i++)
            {
                StockDefect defect = stockDefectList[i];

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

        private bool CheckDataIntegrity()
        {

            for(int i = 0; i < stockDefectList.Count;i++)
            {
                StockDefect defect = stockDefectList[i];

                if(defect.ErrorCount < 0 || defect.GoodCount < 0 || defect.DamageCount < 0 || defect.LostCount < 0 || defect.UnconfirmCount < 0 )
                {
                    MessageBox.Show("Lỗi ở dòng thứ " + (i + 1) + " : Có số lượng âm");
                    dgvStock.CurrentCell = dgvStock[5, i];
                    return false;
                }

                long totalQuantity = defect.ErrorCount + defect.GoodCount + defect.DamageCount + defect.LostCount +
                                     defect.UnconfirmCount;
                if(defect.Quantity!=totalQuantity)
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
            stockDefectList.Clear();
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
            StockDefect defect = stockDefectList[e.RowIndex];
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
