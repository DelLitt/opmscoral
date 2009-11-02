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
            
        }

        private bool HasInStockDefectList(DepartmentStockTempView stock, DepartmentStockTempViewCollection list, out int stockDefIndex)
        {
            int count = 0;
            foreach (DepartmentStockTempView stockDefect in list)
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
            DepartmentStockAdhocProcessingEventArgs eventArgs = new DepartmentStockAdhocProcessingEventArgs();
            eventArgs.DeptStockProcessedList = new ArrayList();
            foreach (DepartmentStockTempView tempView in stockList)
            {
                long checkedGoodQty = tempView.GoodQuantity;
                long checkedErrorQty = tempView.ErrorQuantity;
                long checkedDamageQty = tempView.DamageQuantity;
                long checkedLostQty = tempView.LostQuantity;
                long checkedUnconfirmQty = tempView.UnconfirmQuantity;

                long goodQty = 0;
                long errorQty = 0;
                long damageQty = 0;
                long lostQty = 0;
                long unconfirmQty = 0;

                foreach(DepartmentStockTemp stockTemp in tempView.DepartmentStockTemps)
                {
                    goodQty += stockTemp.GoodQuantity;
                    errorQty += stockTemp.ErrorQuantity;
                    damageQty += stockTemp.DamageQuantity;
                    lostQty += stockTemp.LostQuantity;
                    unconfirmQty += stockTemp.UnconfirmQuantity;
                }

                bool needAdjust = false;
                
                if(    checkedGoodQty!=goodQty 
                    || checkedErrorQty!= errorQty 
                    || checkedLostQty != lostQty
                    || checkedUnconfirmQty != unconfirmQty
                    || checkedDamageQty != damageQty)
                {
                    needAdjust = true;
                }
                SortListByProductId(tempView.DepartmentStockTemps);
                IList departmentStocks = tempView.DepartmentStockTemps;
                if (needAdjust)
                {
                    AdjustGoodQuantity(tempView.DepartmentStockTemps,checkedGoodQty);
                    for(int i=departmentStocks.Count;i>= 0;i--)
                    {
                        DepartmentStockTemp stock = (DepartmentStockTemp) departmentStocks[i];
                        if (i > 0)
                        {
                            // fixing
                            AutoFixing(stock, ref checkedErrorQty, ref checkedDamageQty, ref checkedLostQty, ref checkedUnconfirmQty);
                        }
                        else // last fixing
                        {
                            // don't need to fix, just map the remain quantities to stock
                            stock.ErrorQuantity = checkedErrorQty;
                            stock.DamageQuantity = checkedDamageQty;
                            stock.LostQuantity = checkedLostQty;
                            stock.UnconfirmQuantity = checkedUnconfirmQty;
                        }
                        
                    }
                }
                foreach (DepartmentStockTemp stockTemp in departmentStocks)
                {
                    eventArgs.DeptStockProcessedList.Add(stockTemp);    
                }
                
            }
            SortStockTempByDeptId(eventArgs.DeptStockProcessedList);
            EventUtility.fireEvent(ProcessAdhocStocksEvent,this,eventArgs);
            if(!eventArgs.HasErrors)
            {
                MessageBox.Show("Lưu kết quả thành công !");
                ClearForm();
            }
        }

        private void SortStockTempByDeptId(IList list)
        {
            DepartmentStockTemp swap = null;
            for (int i = 0; i < list.Count-1;i++ )
            {
                DepartmentStockTemp stockTemp1 = (DepartmentStockTemp) list[i];
                for (int j = i+1; j < list.Count; j++)
                {
                    DepartmentStockTemp stockTemp2 = (DepartmentStockTemp)list[j];
                    if(stockTemp1.DepartmentId > stockTemp2.DepartmentId)
                    {
                        swap = stockTemp1;
                        stockTemp1 = stockTemp2;
                        stockTemp2 = swap;
                    }
                }
            }
        }

        private void AutoFixing(DepartmentStockTemp stock, ref long errorQuantity, ref long damageQuantity, ref long lostQuantity, ref long unconfirmQuantity)
        {
            if (errorQuantity > 0)
            {
                if (stock.GoodQuantity >= errorQuantity)
                {
                    stock.ErrorQuantity = errorQuantity;
                    stock.GoodQuantity -= errorQuantity;
                    errorQuantity = 0;
                }
                else
                {
                    stock.ErrorQuantity = stock.GoodQuantity;
                    stock.GoodQuantity = 0;
                    errorQuantity -= stock.ErrorQuantity;
                }
            }
            if (lostQuantity > 0)
            {
                if (stock.GoodQuantity >= lostQuantity)
                {
                    stock.LostQuantity = lostQuantity;
                    stock.GoodQuantity -= lostQuantity;
                    lostQuantity = 0;
                }
                else
                {
                    stock.LostQuantity = stock.GoodQuantity;
                    stock.GoodQuantity = 0;
                    lostQuantity -= stock.LostQuantity;
                }
            }
            if (damageQuantity > 0)
            {
                if (stock.GoodQuantity >= damageQuantity)
                {
                    stock.DamageQuantity = damageQuantity;
                    stock.GoodQuantity -= damageQuantity;
                    damageQuantity = 0;
                }
                else
                {
                    stock.DamageQuantity = stock.GoodQuantity;
                    stock.GoodQuantity = 0;
                    damageQuantity -= stock.DamageQuantity;
                }
            }
            if (unconfirmQuantity > 0)
            {
                if (stock.GoodQuantity >= unconfirmQuantity)
                {
                    stock.UnconfirmQuantity = unconfirmQuantity;
                    stock.GoodQuantity -= unconfirmQuantity;
                    unconfirmQuantity = 0;
                }
                else
                {
                    stock.UnconfirmQuantity = stock.GoodQuantity;
                    stock.GoodQuantity = 0;
                    unconfirmQuantity -= stock.UnconfirmQuantity;
                }
            }
        }
        private void AdjustGoodQuantity(IList temps,long goodQuantity)
        {
            long qty = 0;
            // get total quantity
            foreach (DepartmentStockTemp stockTemp in temps)
            {
                qty += stockTemp.Quantity;      
            }

            // check quantity and audit value
            if (qty < goodQuantity)
            {

                for (int i = 0; i < temps.Count; i++)
                {
                    DepartmentStockTemp stockTemp = (DepartmentStockTemp) temps[i];
                    if (i == temps.Count - 1)
                    {
                        stockTemp.GoodQuantity = goodQuantity;
                        return;
                    }

                    stockTemp.GoodQuantity = stockTemp.Quantity;
                    goodQuantity -= stockTemp.GoodQuantity;
                }
            }
            else
            {
                for (int i = temps.Count - 1; i >=0; i--)
                {
                    DepartmentStockTemp stockTemp = (DepartmentStockTemp)temps[i];
                    if (i == 0)
                    {
                        stockTemp.GoodQuantity = goodQuantity;
                        return;
                    }

                    stockTemp.GoodQuantity = stockTemp.Quantity;
                    goodQuantity -= stockTemp.GoodQuantity;
                }
            }
        }

        private void SortListByProductId(IList temps)
        {
            DepartmentStockTemp stockTemp = null;
            for(int i=0;i < temps.Count-1; i++)
            {
                DepartmentStockTemp stockTemp1 = (DepartmentStockTemp) temps[i];
                //long prdId1 = Int64.Parse(stockTemp1.Product.ProductId);
                long prdId1 = ParseProductId(stockTemp1.Product.ProductId);
                for (int j = i + 1; j < temps.Count;j++ )
                {
                    DepartmentStockTemp stockTemp2 = (DepartmentStockTemp)temps[j];
                    long prdId2 = ParseProductId(stockTemp2.Product.ProductId);
                    if(prdId1>prdId2)
                    {
                        stockTemp = stockTemp1;
                        stockTemp1 = stockTemp2;
                        stockTemp2 = stockTemp;
                    }
                }

            }
        }

        private long ParseProductId(string id)
        {
            long ret = 0;
            try
            {
                ret = Int64.Parse(id);

            }
            catch (Exception)
            {
                DateTime dt =StringUtility.ConvertFourCharToDate(id.Substring(7, 3));
                string retStr = dt.ToString("yyMMdd") + String.Format("000000",id.Substring(10, 2));
                ret = Int64.Parse(retStr);
            }
            return ret;
        }

        private void dgvStock_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private DepartmentStockTempView selectedTempView = null;
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
            dgvStock.Enabled = false;
            int startY = dgvStock.Location.Y + dgvStock.ColumnHeadersHeight + (cellCollection[0].OwningRow.Height*(cellCollection[0].RowIndex+1));
            int maxY = dgvStock.Size.Height + dgvStock.Location.Y;
            if(maxY < startY + pnlSelectedStocks.Size.Height)
            {
                startY = startY - cellCollection[0].OwningRow.Height - pnlSelectedStocks.Size.Height;
            }

            pnlSelectedStocks.Location = new Point(pnlSelectedStocks.Location.X, startY);
            pnlSelectedStocks.Visible = true;
            selectedTempView = stockList[cellCollection[0].RowIndex];           
            DepartmentStockTempCollection selectedStockList = new DepartmentStockTempCollection(bdsSelectedStock);
            foreach (DepartmentStockTemp departmentStock in selectedTempView.DepartmentStockTemps)
            {
                departmentStock.OldGoodQuantity = departmentStock.GoodQuantity;
                departmentStock.OldErrorQuantity = departmentStock.ErrorQuantity;
                departmentStock.OldUnconfirmQuantity = departmentStock.UnconfirmQuantity;
                departmentStock.OldDamageQuantity = departmentStock.DamageQuantity;
                departmentStock.OldLostQuantity = departmentStock.LostQuantity;
            }
            bdsSelectedStock.EndEdit();
            dgvSelectedStock.Refresh();
            dgvSelectedStock.Invalidate();
            foreach (DepartmentStockTemp stockTemp in selectedTempView.DepartmentStockTemps)
            {
               selectedStockList.Add(stockTemp); 
            }
            // save current checking value
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

        private void dgvSelectedStock_VisibleChanged(object sender, EventArgs e)
        {
            
        }

        private void dgvSelectedStock_Leave(object sender, EventArgs e)
        {
            
        }

        private void btnSaveSelectedStocks_Click(object sender, EventArgs e)
        {
                DialogResult result = MessageBox.Show("Bạn muốn lưu kết quả ?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                                MessageBoxDefaultButton.Button2);
                if (result == DialogResult.No)
                {
                    dgvStock.Focus();
                    return;
                }

                pnlSelectedStocks.Visible = false;
                if (selectedTempView != null)
                {
                    DepartmentStockTempCollection editedStockTemps = (DepartmentStockTempCollection)bdsSelectedStock.DataSource;
                    selectedTempView.DepartmentStockTemps.Clear();
                    selectedTempView.Quantity = 0;
                    selectedTempView.RealQuantity = 0;
                    selectedTempView.GoodQuantity = 0;
                    selectedTempView.ErrorQuantity = 0;
                    selectedTempView.DamageQuantity = 0;
                    selectedTempView.LostQuantity = 0;
                    selectedTempView.UnconfirmQuantity = 0;
                    foreach (DepartmentStockTemp stockTemp in editedStockTemps)
                    {
                        selectedTempView.GoodQuantity += stockTemp.GoodQuantity;
                        selectedTempView.ErrorQuantity += stockTemp.ErrorQuantity;
                        selectedTempView.LostQuantity += stockTemp.LostQuantity;
                        selectedTempView.DamageQuantity += stockTemp.DamageQuantity;
                        selectedTempView.UnconfirmQuantity += stockTemp.UnconfirmQuantity;
                        selectedTempView.Quantity += stockTemp.Quantity;
                        selectedTempView.RealQuantity += stockTemp.GoodQuantity + stockTemp.ErrorQuantity +
                                                    stockTemp.DamageQuantity + stockTemp.UnconfirmQuantity +
                                                    stockTemp.LostQuantity;
                        selectedTempView.DepartmentStockTemps.Add(stockTemp);
                    }

                    editedStockTemps = null;
                    selectedTempView = null;
                    bdsStockDefect.EndEdit();
                    dgvStock.Enabled = true;
                    dgvStock.Focus();
                    dgvStock.Refresh();
                    dgvStock.Invalidate();
                }
            
        }

        private void btnCloseSelectedStocks_Click(object sender, EventArgs e)
        {
            pnlSelectedStocks.Visible = false;
            dgvStock.Enabled = true;
        }
    }
}