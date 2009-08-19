using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using AppFrame.Collection;
using AppFrame.Common;
using AppFrame.Model;
using AppFrame.Presenter.GoodsIO;
using AppFrame.Presenter.GoodsIO.MainStock;
using AppFrame.Utility;
using AppFrame.View.GoodsIO.MainStock;
using AppFrameClient.Common;
using AppFrameClient.Presenter.GoodsIO.MainStock;


namespace AppFrameClient.View.GoodsIO.MainStock
{
    public partial class MainStockInEditExtraForm : BaseForm, IMainStockInView
    {
        private const int QUANTITY_POS = 6;
        private const int PRICE_POS = 7;
        private const int SELL_PRICE_POS = 8;
        private StockInDetailCollection deptSIDetailList;
        private IList CurrentRowProductColorList { get; set; }
        private IList CurrentRowProductSizeList { get; set; }
        public StockIn deptSI { get; set; }
        private IList productMasterList { get; set; }

        public StockIn StockIn
        {
            get; set;
        }
        public MainStockInEditExtraForm()
        {
            InitializeComponent();
            
        }

        private void LoadStockIn()
        {
            deptSIDetailList.Clear();
            MainStockInEventArgs eventArgs = new MainStockInEventArgs();
            eventArgs.StockIn = StockIn;
            foreach (StockInDetail inDetail in StockIn.StockInDetails)
            {
                inDetail.ProductMaster = inDetail.Product.ProductMaster;
                deptSIDetailList.Add(inDetail);
            }
            bdsStockIn.ResetBindings(false);
            dgvDeptStockIn.Refresh();
            dgvDeptStockIn.Invalidate();
            
        }

        private void ctxMenuDept_Opening(object sender, CancelEventArgs e)
        {

        }

        private void nhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StockInDetail detail = deptSIDetailList[dgvDeptStockIn.CurrentCell.OwningRow.Index];
            // deep copy in separeate memory space
            StockInDetail newDetail = CreateNewStockInDetail();
            var newPM = (ProductMaster)detail.Product.ProductMaster.Clone();
            newDetail.Product.ProductMaster = newPM;
            bdsStockIn.EndEdit();
        }

        private StockInDetail CreateNewStockInDetail()
        {
            var deptSIDet = deptSIDetailList.AddNew();
            deptSIDet.Product = new Product();
            deptSIDet.Product.ProductMaster = new ProductMaster();
            deptSIDet.Product.ProductMaster.ProductName = "";
            deptSIDet.Product.ProductMaster.ProductColor = new ProductColor { ColorName = "" };
            deptSIDet.Product.ProductMaster.ProductSize = new ProductSize { SizeName = "" };
            deptSIDet.StockInDetailPK = new StockInDetailPK();
            deptSIDetailList.EndNew(deptSIDetailList.Count - 1);
            return deptSIDet;
        }
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            // create DepartmentStockIn
            if (deptSI == null)
            {
                deptSI = new StockIn();
            }
            deptSI.CreateDate = DateTime.Now;
            deptSI.UpdateDate = DateTime.Now;
            deptSI.CreateId = ClientInfo.getInstance().LoggedUser.Name;
            deptSI.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
            deptSI.ExclusiveKey = 0;
            int maxAddedItemsCount = int.Parse(numericUpDown.Text);
            for (int i = 0; i < maxAddedItemsCount; i++)
            {
                StockInDetail deptSIDet = CreateNewStockInDetail();

            }

            deptSI.StockInDetails =
                ObjectConverter.ConvertToNonGenericList<StockInDetail>(deptSIDetailList);
            bdsStockIn.EndEdit();

            for (int j = 0; j < maxAddedItemsCount; j++)
            {
                for (int i = 0; i <= SELL_PRICE_POS; i++)
                {
                    dgvDeptStockIn[i, deptSIDetailList.Count - j - 1].ReadOnly = false;
                }
            }
        }


        #region Load products to combo box for select
        private void dgvDeptStockIn_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            string columnName = dgvDeptStockIn.CurrentCell.OwningColumn.Name;
            if (columnName.Equals("columnProductId")
                || columnName.Equals("columnProductName"))
            {


                var comboBox = ((ComboBox)e.Control);

                // firstly, remove event regard to cell 
                comboBox.DropDown -= new EventHandler(comboBox_DropDown);
                comboBox.KeyUp -= new KeyEventHandler(Control_KeyUp);

                comboBox.DroppedDown = false;

                comboBox.DataSource = null;
                comboBox.Text = (string)dgvDeptStockIn.CurrentCell.Value;
                comboBox.DropDown += new EventHandler(comboBox_DropDown);
                comboBox.KeyUp += new KeyEventHandler(Control_KeyUp);
            }

            var mainStockInEventArgs = new MainStockInEventArgs();
            if (dgvDeptStockIn == null || dgvDeptStockIn.CurrentRow == null)
            {
                return;
            }
            int selectedIndex = dgvDeptStockIn.CurrentRow.Index;
            mainStockInEventArgs.SelectedIndex = selectedIndex;
            mainStockInEventArgs.SelectedStockInDetail = deptSIDetailList[selectedIndex];

            if (columnName.Equals("columnColor"))
            {
                // put colors to list
                EventUtility.fireEvent(LoadProductColorEvent, this, mainStockInEventArgs);
                if (mainStockInEventArgs.ProductColorList != null && mainStockInEventArgs.ProductColorList.Count > 0)
                {
                    var comboBox = ((ComboBox)e.Control);
                    comboBox.DataSource = mainStockInEventArgs.ProductColorList;
                    CurrentRowProductColorList = mainStockInEventArgs.ProductColorList;
                    comboBox.DisplayMember = "ColorName";
                    comboBox.ValueMember = "ColorName";
                }
                else
                {
                    CurrentRowProductColorList = null;
                }
                mainStockInEventArgs.ProductColorList = null;
            }


            if (columnName.Equals("columnSize"))
            {
                // put size to list
                EventUtility.fireEvent(LoadProductSizeEvent, this, mainStockInEventArgs);
                if (mainStockInEventArgs.ProductSizeList != null && mainStockInEventArgs.ProductSizeList.Count > 0)
                {
                    var comboBox = ((ComboBox)e.Control);
                    comboBox.DataSource = mainStockInEventArgs.ProductSizeList;
                    CurrentRowProductSizeList = mainStockInEventArgs.ProductSizeList;
                    comboBox.DisplayMember = "SizeName";
                    comboBox.ValueMember = "SizeName";
                }
                else
                {
                    CurrentRowProductSizeList = null;
                }
                mainStockInEventArgs.ProductSizeList = null;
            }

        }

        void Control_KeyUp(object sender, KeyEventArgs e)
        {
            var comboBox = (ComboBox)sender;
            int currentColumnIndex = dgvDeptStockIn.CurrentCell.OwningColumn.Index;
            if (currentColumnIndex == 1 || currentColumnIndex == 2)
            {
                if (e.KeyCode == Keys.F3 || comboBox.DroppedDown)
                {
                    ((ComboBox)sender).DataSource = null;
                    comboBox_DropDown(sender, null);
                }
            }
        }

        void comboBox_DropDown(object sender, EventArgs e)
        {

            if (!(sender is ComboBox))
            {
                return;
            }
            // set empty current datasource

            //MessageBox.Show(dgvBill.CurrentCell.ColumnIndex.ToString());
            int currentColumnIndex = dgvDeptStockIn.CurrentCell.OwningColumn.Index;
            int currentRowIndex = dgvDeptStockIn.CurrentCell.OwningRow.Index;
            if (currentColumnIndex == 1) // ProductId
            {
                deptSIDetailList[currentRowIndex].Product.ProductMaster.ProductMasterId =
                    ((ComboBox)sender).Text;
            }
            if (currentColumnIndex == 2)   // ProductName
            {
                deptSIDetailList[currentRowIndex].Product.ProductMaster.ProductName =
                    ((ComboBox)sender).Text;
            }


            if (((ComboBox)sender).DataSource == null)
            {
                FillProductToComboBox(sender, dgvDeptStockIn.CurrentCell.OwningColumn.Name);
            }
        }

        private void FillProductToComboBox(object sender, string name)
        {
            var mainStockInEventArgs = new MainStockInEventArgs();
            if (dgvDeptStockIn == null || dgvDeptStockIn.CurrentRow == null)
            {
                return;
            }
            int selectedIndex = dgvDeptStockIn.CurrentRow.Index;
            mainStockInEventArgs.SelectedIndex = selectedIndex;
            mainStockInEventArgs.SelectedStockInDetail = deptSIDetailList[selectedIndex];
            mainStockInEventArgs.IsFillToComboBox = true;
            if (name.Equals("columnProductName"))
            {
                mainStockInEventArgs.ComboBoxDisplayMember = "ProductName";
            }
            if (name.Equals("columnProductId"))
            {
                mainStockInEventArgs.ComboBoxDisplayMember = "ProductMasterId";
            }
            EventUtility.fireEvent<MainStockInEventArgs>(FillProductToComboEvent, sender, mainStockInEventArgs);
        }

        #endregion

        private void dgvDeptStockIn_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var mainStockInEventArgs = new MainStockInEventArgs();
                if (dgvDeptStockIn == null || dgvDeptStockIn.CurrentRow == null)
                {
                    return;
                }
                int selectedIndex = dgvDeptStockIn.CurrentRow.Index;
                mainStockInEventArgs.SelectedIndex = selectedIndex;
                mainStockInEventArgs.SelectedStockInDetail = deptSIDetailList[selectedIndex];

                // bind the quantity, price and sellprice
                long qty = NumberUtility.ParseLong(dgvDeptStockIn[QUANTITY_POS, selectedIndex].Value);
                long inPrice = NumberUtility.ParseLong(dgvDeptStockIn[PRICE_POS, selectedIndex].Value);
                long sellPrice = NumberUtility.ParseLong(dgvDeptStockIn[SELL_PRICE_POS, selectedIndex].Value);

                if (e.ColumnIndex == 1 || e.ColumnIndex == 2)
                {
                    mainStockInEventArgs.SelectedStockInDetail.Product.ProductMaster.ProductMasterId =
                        dgvDeptStockIn.CurrentCell.Value as string;
                    if (e.ColumnIndex == 1)
                    {
                        EventUtility.fireEvent(LoadGoodsByIdEvent, this, mainStockInEventArgs);
                    }
                    else
                    {
                        EventUtility.fireEvent(LoadGoodsByNameEvent, this, mainStockInEventArgs);
                    }

                    // load goods to current row
                    var loadGoods =
                        mainStockInEventArgs.SelectedStockInDetail.Product.ProductMaster;
                    deptSIDetailList[selectedIndex] = mainStockInEventArgs.SelectedStockInDetail;
                    bdsStockIn.EndEdit();

                }
                else if (e.ColumnIndex == 3)
                {
                    // get the product name
                    var name = dgvDeptStockIn[2, dgvDeptStockIn.CurrentCell.RowIndex].Value as string;
                    if (string.IsNullOrEmpty(name))
                    {
                        // ignore
                        return;
                    }
                    // get the color (if selected)
                    ProductColor color = null;
                    var colorStr = dgvDeptStockIn.CurrentCell.Value as string;
                    if (CurrentRowProductColorList != null)
                    {
                        foreach (ProductColor c in CurrentRowProductColorList)
                        {
                            if (c.ColorName.Equals(colorStr))
                            {
                                color = c;
                                break;
                            }
                        }
                    }

                    mainStockInEventArgs.SelectedStockInDetail.Product.ProductMaster.ProductName = name;
                    mainStockInEventArgs.SelectedStockInDetail.Product.ProductMaster.ProductColor = color;
                    EventUtility.fireEvent(LoadGoodsByNameColorEvent, this, mainStockInEventArgs);
                    // load goods to current row
                    var loadGoods =
                        mainStockInEventArgs.SelectedStockInDetail.Product.ProductMaster;
                    deptSIDetailList[selectedIndex] = mainStockInEventArgs.SelectedStockInDetail;
                    bdsStockIn.EndEdit();
                }
                else if (e.ColumnIndex == 4)
                {
                    // get the product name
                    var name = dgvDeptStockIn[2, dgvDeptStockIn.CurrentCell.RowIndex].Value as string;
                    if (string.IsNullOrEmpty(name))
                    {
                        // ignore
                        return;
                    }
                    // get the color (if selected)
                    // get the color (if selected)
                    ProductColor color = null;
                    var colorStr = dgvDeptStockIn[3, dgvDeptStockIn.CurrentCell.RowIndex].Value as string;
                    if (CurrentRowProductColorList != null)
                    {
                        foreach (ProductColor c in CurrentRowProductColorList)
                        {
                            if (c.ColorName.Equals(colorStr))
                            {
                                color = c;
                                break;
                            }
                        }
                    }

                    // get the color (if selected)
                    ProductSize size = null;
                    var sizeStr = dgvDeptStockIn.CurrentCell.Value as string;
                    if (CurrentRowProductSizeList != null)
                    {
                        foreach (ProductSize c in CurrentRowProductSizeList)
                        {
                            if (c.SizeName.Equals(sizeStr))
                            {
                                size = c;
                                break;
                            }
                        }
                    }

                    mainStockInEventArgs.SelectedStockInDetail.Product.ProductMaster.ProductName = name;
                    mainStockInEventArgs.SelectedStockInDetail.Product.ProductMaster.ProductSize = size;
                    mainStockInEventArgs.SelectedStockInDetail.Product.ProductMaster.ProductColor = color;
                    EventUtility.fireEvent(LoadGoodsByNameColorSizeEvent, this, mainStockInEventArgs);
                    // load goods to current row
                    var loadGoods =
                        mainStockInEventArgs.SelectedStockInDetail.Product.ProductMaster;
                    deptSIDetailList[selectedIndex] = mainStockInEventArgs.SelectedStockInDetail;
                    bdsStockIn.EndEdit();
                }
                if (deptSIDetailList[selectedIndex] != null)
                {
                    deptSIDetailList[selectedIndex].Quantity = qty;
                    deptSIDetailList[selectedIndex].Price = inPrice;
                    deptSIDetailList[selectedIndex].SellPrice = sellPrice;
                    CalculateTotalStorePrice();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mã sản phẩm không hợp lệ hoặc lỗi khi nhập");
            }
        }

        private void CalculateTotalStorePrice()
        {
            long totalInPrice = 0;
            long totalProduct = 0;
            foreach (StockInDetail detail in deptSIDetailList)
            {
                if (detail.DelFlg == CommonConstants.DEL_FLG_NO)
                {
                    totalInPrice += detail.Price * detail.Quantity;
                    totalProduct += detail.Quantity;
                }
            }
            txtSumValue.Text = totalInPrice.ToString();
            txtSumProduct.Text = totalProduct.ToString();
        }

        private void DepartmentStockInExtra_Load(object sender, EventArgs e)
        {
            
            deptSIDetailList = new StockInDetailCollection(bdsStockIn);
            bdsStockIn.DataSource = deptSIDetailList;
            dgvDeptStockIn.DataError += new DataGridViewDataErrorEventHandler(dgvDeptStockIn_DataError);
            
            // create DepartmentStockIn
            if (deptSI == null)
            {
                deptSI = new StockIn();
                deptSI.CreateDate = DateTime.Now;
                deptSI.UpdateDate = DateTime.Now;
                deptSI.CreateId = ClientInfo.getInstance().LoggedUser.Name;
                deptSI.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                deptSI.ExclusiveKey = 0;
                CreateNewStockInDetail();
                btnBarcode.Visible = false;
                numericUpDownBarcode.Visible = false;
                btnPreview.Visible = false;
                // load products to extra combo box
                LoadProductMasterToComboBox();
                deptSIDetailList.RemoveAt(0);
                bdsStockIn.EndEdit();

            }
            else
            {
                btnBarcode.Visible = true;
                numericUpDownBarcode.Visible = true;
                btnPreview.Visible = true;
                IList deptStockInDetails = deptSI.StockInDetails;
                foreach (StockInDetail detail in deptStockInDetails)
                {
                    if (detail.DelFlg == CommonConstants.DEL_FLG_NO)
                    {
                        deptSIDetailList.Add(detail);
                        detail.OldQuantity = detail.Quantity;
                    }
                }

                for (int i = 0; i < dgvDeptStockIn.Columns.Count; i++)
                {
                    dgvDeptStockIn.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                    if (i != QUANTITY_POS
                            && i != PRICE_POS
                            && i != SELL_PRICE_POS)
                    {
                        dgvDeptStockIn.Columns[i].ReadOnly = true;
                    }
                }
                txtDexcription.Text = deptSI.Description;
            }
            deptSI.StockInDetails =
                    ObjectConverter.ConvertToNonGenericList<StockInDetail>(deptSIDetailList);
            
            
        }

       

        void dgvDeptStockIn_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        #region IDepartmentStockInView Members

        private MainStockInController mainStockInController;
        public MainStockInController MainStockInController
        {
            get
            {
                return mainStockInController;
            }
            set
            {
                mainStockInController = value;
                mainStockInController.MainStockInView = this;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }


        private IProductMasterSearchOrCreateController productMasterSearchOrCreateController;
        public IProductMasterSearchOrCreateController ProductMasterSearchOrCreateController
        {
            set
            {
                productMasterSearchOrCreateController = value;
            }
        }

        public event EventHandler<MainStockInEventArgs> InitDepartmentStockInEvent;

        public event EventHandler<AppFrame.Presenter.GoodsIO.ProductMasterSearchOrCreateEventArgs> OpenProductMasterSearchEvent;

        public event EventHandler<MainStockInEventArgs> SaveDepartmentStockInEvent;

        public event EventHandler<MainStockInEventArgs> FindProductMasterEvent;
        public event EventHandler<MainStockInEventArgs> FillProductToComboEvent;

        #endregion



        #region IDepartmentStockInView Members

        public event EventHandler<MainStockInEventArgs> LoadGoodsByIdEvent;

        public event EventHandler<MainStockInEventArgs> LoadGoodsByNameEvent;

        public event EventHandler<MainStockInEventArgs> LoadProductColorEvent;

        public event EventHandler<MainStockInEventArgs> LoadProductSizeEvent;
        public event EventHandler<MainStockInEventArgs> LoadGoodsByNameColorEvent;
        public event EventHandler<MainStockInEventArgs> LoadGoodsByNameColorSizeEvent;
        public event EventHandler<MainStockInEventArgs> SaveStockInEvent;
        public event EventHandler<MainStockInEventArgs> GetPriceEvent;

        #endregion

        private void mnuCreateNewItem_Click(object sender, EventArgs e)
        {
            btnAddProduct_Click(sender, null);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn hãy kiểm tra kỹ trước khi lưu số liệu bởi vì sau khi lưu sẽ không thay đổi được nữa. Bạn có chắc chắn muốn lưu ?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.No)
            {
                return;
            }
            // first remove all blank row
            int count = 0;
            int length = deptSIDetailList.Count;
            for (int i = 0; i < length - count; i++)
            {
                StockInDetail detail = deptSIDetailList[i];
                if (string.IsNullOrEmpty(detail.Product.ProductMaster.ProductMasterId)
                    && string.IsNullOrEmpty(detail.Product.ProductMaster.ProductName))
                {
                    deptSIDetailList.RemoveAt(i - count);
                    count++;
                }
            }

            if (deptSIDetailList.Count == 0)
            {
                MessageBox.Show("Không có sản phẩm nào để nhập kho!!!!");
                return;
            }

            // validate quantity
            StringBuilder errMsg = new StringBuilder();
            int line = 1;
            foreach (StockInDetail detail in deptSIDetailList)
            {
                if (detail.Quantity == 0)
                {
                    errMsg.Append(" " + line + " ");
                }
                line++;
            }
            if (errMsg.Length > 0)
            {
                MessageBox.Show("Lỗi ở dòng " + errMsg.ToString() + " : Số lượng phải lớn hơn 0");
                return;
            }
            foreach (StockInDetail detail in deptSIDetailList)
            {
                count = 0;
                foreach (StockInDetail detail2 in deptSIDetailList)
                {
                    if (detail.DelFlg == CommonConstants.DEL_FLG_NO && detail.Product.ProductMaster.ProductMasterId.Equals(detail2.Product.ProductMaster.ProductMasterId))
                    {
                        if (count == 0)
                        {
                            count++;
                        }
                        else
                        {
                            MessageBox.Show("Lỗi : Mã hàng " + detail.Product.ProductMaster.ProductMasterId + " nhập 2 lần");
                            return;
                        }
                    }

                }
            }

            
            bool isNeedClearData = string.IsNullOrEmpty(deptSI.StockInId);
            deptSI.StockInDate = dtpImportDate.Value;
            deptSI.StockInDetails = deptSIDetailList;
            deptSI.Description = txtDexcription.Text;
            var eventArgs = new MainStockInEventArgs();
            eventArgs.StockIn = StockIn;
            EventUtility.fireEvent(SaveStockInEvent, this, eventArgs);
            if (eventArgs.EventResult != null)
            {
                MessageBox.Show("Lưu thành công");
                if (isNeedClearData)
                {
                    deptSI = new StockIn();
                    deptSIDetailList.Clear();
                    txtDexcription.Text = "";
                    txtPriceIn.Text = "";
                    txtPriceOut.Text = "";
                    txtSumProduct.Text = "";
                    txtSumValue.Text = "";
                    ClearSelectionOnListBox(lstColor);
                    ClearSelectionOnListBox(lstSize);
                    //CreateNewStockInDetail();
                }
            }
            else
            {
                //MessageBox.Show("Có lỗi khi lưu");
            }
        }

        private void dgvDeptStockIn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvDeptStockIn.CurrentRow == null)
            {
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }
            DataGridViewSelectedRowCollection rowCollection = dgvDeptStockIn.SelectedRows;

            foreach (DataGridViewRow row in rowCollection)
            {
                int selectedIndex = row.Index;

                StockInDetail detail = deptSIDetailList[selectedIndex];
                
                    if (detail.StockInDetailPK != null &&
                        !string.IsNullOrEmpty(deptSIDetailList[selectedIndex].StockInDetailPK.StockInId))
                    {
                        detail.DelFlg = 1;
                        for (int j = 0; j < dgvDeptStockIn.Columns.Count; j++)
                        {
                            dgvDeptStockIn[j, selectedIndex].ReadOnly = true;
                            dgvDeptStockIn[j, selectedIndex].Style.BackColor = Color.Gray;
                        }
                    }
                    else
                    {
                        deptSIDetailList.RemoveAt(selectedIndex);
                    }
            }
            CalculateTotalStorePrice();
            LockRowsForEdit();
        }

        private void btnBarcode_Click(object sender, EventArgs e)
        {
            if (dgvDeptStockIn.CurrentRow == null)
            {
                MessageBox.Show("Hãy chọn 1 hàng để in mã vạch");
                return;
            }
            var selectedIndex = dgvDeptStockIn.CurrentRow.Index;
            if (selectedIndex < 0 || selectedIndex >= deptSIDetailList.Count)
            {
                return;
            }
            StockInDetail detail = deptSIDetailList[selectedIndex];
            if (detail.StockInDetailPK != null
                && !string.IsNullOrEmpty(deptSIDetailList[selectedIndex].StockInDetailPK.StockInId)
                && !string.IsNullOrEmpty(deptSIDetailList[selectedIndex].Product.ProductId))
            {
                barcodePrintDialog.Document = barcodePrintDocument;
                if (barcodePrintDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        barcodePrintDocument.Print();
                    }
                    catch (Exception)
                    {
                    }

                }
            }
            else
            {
                MessageBox.Show("Sản phẩm này chưa được lưu kho!!!!!!!");
                return;
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (dgvDeptStockIn.CurrentRow == null)
            {
                MessageBox.Show("Hãy chọn 1 hàng để in mã vạch");
                return;
            }
            var selectedIndex = dgvDeptStockIn.CurrentRow.Index;
            if (selectedIndex < 0 || selectedIndex >= deptSIDetailList.Count)
            {
                return;
            }
            StockInDetail detail = deptSIDetailList[selectedIndex];
            if (detail.StockInDetailPK != null
                && !string.IsNullOrEmpty(deptSIDetailList[selectedIndex].StockInDetailPK.StockInId)
                && !string.IsNullOrEmpty(deptSIDetailList[selectedIndex].Product.ProductId))
            {
                var printPreviewDialog1 = new PrintPreviewDialog(); // instantiate new print preview dialog
                printPreviewDialog1.Document = this.barcodePrintDocument;
                printPreviewDialog1.WindowState = FormWindowState.Maximized;
                try
                {
                    printPreviewDialog1.ShowDialog();
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                MessageBox.Show("Sản phẩm này chưa được lưu kho!!!!!!!");
                return;
            }
        }

        private void barcodePrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            var height = 87;
            var numberToPrint = (int)numericUpDownBarcode.Value;
            string code = deptSIDetailList[dgvDeptStockIn.CurrentRow.Index].Product.ProductId;

            if (numberToPrint > 3)
            {
                height = (numberToPrint / 3) * 87;
            }
            var eventArgs = new MainStockInEventArgs { ProductMasterIdForPrice = deptSIDetailList[dgvDeptStockIn.CurrentRow.Index].Product.ProductMaster.ProductMasterId };
            EventUtility.fireEvent(GetPriceEvent, this, eventArgs);
            string priceStr = "";
            if (eventArgs.DepartmentPrice != null)
            {
                priceStr = "Giá" + eventArgs.DepartmentPrice.Price.ToString("#,##", CultureInfo.CreateSpecificCulture("de-DE"));
            }
            
        }
        private void LoadProductMasterToComboBox()
        {
            var mainStockInEventArgs = new MainStockInEventArgs();
            mainStockInEventArgs.SelectedStockInDetail = new StockInDetail{Product = new Product{ProductMaster = new ProductMaster{ProductName = ""}}};
            mainStockInEventArgs.IsFillToComboBox = true;
            mainStockInEventArgs.ComboBoxDisplayMember = "ProductName";
            EventUtility.fireEvent<MainStockInEventArgs>(FillProductToComboEvent, cboProductMasters, mainStockInEventArgs);
            
        }

        

        

        private void btnInput_Click(object sender, EventArgs e)
        {
            
            if (cboProductMasters.SelectedIndex < 0)
            {
                MessageBox.Show("Hãy chọn 1 sản phẩm để nhập kho");
                return;
            }
            if (lstColor.SelectedIndices == null ||lstColor.SelectedIndices.Count <= 0)
            {
                MessageBox.Show("Hãy chọn màu sản phẩm để nhập kho");
                return;
            }
            if (lstSize.SelectedIndices == null || lstSize.SelectedIndices.Count <= 0)
            {
                MessageBox.Show("Hãy chọn kích cỡ sản phẩm để nhập kho");
                return;
            }
            long outValue = 0;
            if (!NumberUtility.CheckLongNullIsZero(txtPriceIn.Text, out outValue)
                || outValue < 0
                || !NumberUtility.CheckLongNullIsZero(txtPriceOut.Text, out outValue)
                || outValue < 0)
            {
                MessageBox.Show("Giá phải là số dương");
                return;
            }
            PopulateGridByProductMaster(lstColor.SelectedItems, lstSize.SelectedItems);
            CalculateTotalStorePrice();
            LockRowsForEdit();
        }

        private void PopulateGridByProductMaster(IList colorList, IList sizeList)
        {
                foreach (ProductColor color in colorList)
                {
                    foreach (ProductSize size in sizeList)
                    {
                        foreach (ProductMaster productMaster in productMasterList)
                        {
                        
                        // do not allow duplicate
                        bool goOut = false;
                        foreach (StockInDetail detail in deptSIDetailList)
                        {
                            if (detail.Product != null 
                                && detail.Product.ProductMaster != null 
                                && productMaster.ProductMasterId.Equals(detail.Product.ProductMaster.ProductMasterId))
                            {
                                goOut = true;
                            }
                        }
                        if (goOut)
                        {
                            continue;
                        }

                        if (productMaster.ProductColor != null 
                            && productMaster.ProductColor.ColorId == color.ColorId
                            && productMaster.ProductSize != null
                            && productMaster.ProductSize.SizeId == size.SizeId)
                        {
                            StockInDetail stockInDetail = deptSIDetailList.AddNew();
                            stockInDetail.Price = NumberUtility.ParseLong(txtPriceIn.Text);
                            stockInDetail.SellPrice = NumberUtility.ParseLong(txtPriceOut.Text);
                            stockInDetail.StockInDetailPK = new StockInDetailPK();
                            if (stockInDetail.Product == null)
                            {
                                stockInDetail.Product = new Product();
                            }
                            stockInDetail.Product.ProductMaster = productMaster;
                            if (stockInDetail.DepartmentPrice == null)
                            {
                                stockInDetail.DepartmentPrice = new DepartmentPrice();
                                DepartmentPricePK pricePk = new DepartmentPricePK
                                                                {
                                                                    ProductMasterId =
                                                                        stockInDetail.Product.ProductMaster.
                                                                        ProductMasterId,
                                                                    DepartmentId = 0
                                                                };
                                stockInDetail.DepartmentPrice.DepartmentPricePK = pricePk;
                            }
                            stockInDetail.DepartmentPrice.Price = NumberUtility.ParseLong(txtPriceOut.Text);
                            stockInDetail.DepartmentPrice.WholeSalePrice =
                                    NumberUtility.ParseLong(txtWSPriceOut.Text);
                            stockInDetail.WholeSalePrice = NumberUtility.ParseLong(txtWSPriceOut.Text);                            
                            deptSIDetailList.EndNew(deptSIDetailList.Count - 1);
                        }
                    }
                }
                
            }
            bdsStockIn.ResetBindings(false);
            dgvDeptStockIn.Refresh();
            dgvDeptStockIn.Invalidate();
        }

        #region IMainStockInView Members


        public event EventHandler<MainStockInEventArgs> LoadAllGoodsByNameEvent;
        public event EventHandler<MainStockInEventArgs> FindByBarcodeEvent;
        public event EventHandler<MainStockInEventArgs> SaveReStockInEvent;
        public event EventHandler<MainStockInEventArgs> LoadStockInEvent;
        public event EventHandler<MainStockInEventArgs> UpdateStockInEvent;

        #endregion

        private void btnNewProductInput_Click(object sender, EventArgs e)
        {
            ProductMasterExtraForm form =
                GlobalUtility.GetOnlyChildFormObject<ProductMasterExtraForm>(GlobalCache.Instance().MainForm,
                                                                              FormConstants.PRODUCT_MASTER_EXTRA_FORM);
            form.CloseProductMasterEvent += new EventHandler<ProductMasterEventArgs>(form_CloseProductMasterEvent);
            form.Status = ViewStatus.OPENDIALOG;
            form.Show();
        }

        void form_CloseProductMasterEvent(object sender, ProductMasterEventArgs e)
        {
            List<ProductMaster> productMasters = e.CreatedProductMasterList;
            //PopulateGridByProductMaster(productMasters[0]);
            // close ProductMasterCreateForm
            ((Form)sender).Close();
            LoadProductMasterToComboBox();
        }

        private void dgvDeptStockIn_KeyUp(object sender, KeyEventArgs e)
        {
            // if copy
            if(e.Control && e.KeyCode == Keys.C)
            {
                if (dgvDeptStockIn.CurrentCell != null)
                {
                    if (dgvDeptStockIn.CurrentCell.Value!=null)
                    {
                        Clipboard.SetText(dgvDeptStockIn.CurrentCell.Value.ToString());
                    }
                    else
                    {
                         Clipboard.SetText("");
                    }
                }

            }
            if(e.Control && e.KeyCode == Keys.V)
            {
                DataGridViewSelectedCellCollection cells = dgvDeptStockIn.SelectedCells;
                foreach (DataGridViewCell cell in cells)
                {
                    cell.Value = Clipboard.GetText();
                    CalculateTotalStorePrice();
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtDexcription_TextChanged(object sender, EventArgs e)
        {

        }

        private void cboProductMasters_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPriceOut.Enabled = true;
            txtWSPriceOut.Enabled = true;
            btnPriceInput.Enabled = true;
            txtPriceIn.Text = "0";
            txtWSPriceOut.Text = "0";
            txtPriceOut.Text = "0";
            ProductMaster proMaster = cboProductMasters.SelectedItem as ProductMaster;
            if (proMaster == null)
            {
                return;
            }
            string productName = proMaster.ProductName;
            BindingSource bindingSource = (BindingSource)cboProductMasters.DataSource;

            if (string.IsNullOrEmpty(productName))
            {
                return;
            }

            var mainStockInEventArgs = new MainStockInEventArgs();
            mainStockInEventArgs.SelectedStockInDetail = new StockInDetail();
            mainStockInEventArgs.SelectedStockInDetail.Product = new Product{ProductMaster = new ProductMaster()};
            mainStockInEventArgs.SelectedStockInDetail.Product.ProductMaster.ProductName = productName;
            EventUtility.fireEvent(LoadGoodsByNameEvent, this, mainStockInEventArgs);

            DepartmentPrice currentPrice = mainStockInEventArgs.DepartmentPrice;
            if(currentPrice!=null)
            {
                txtPriceOut.Text = currentPrice.Price.ToString();
                txtWSPriceOut.Text = currentPrice.WholeSalePrice.ToString();

                txtPriceOut.Enabled = false;
                txtWSPriceOut.Enabled = false;
                btnPriceInput.Enabled = false;
            }
            // clear the binding list
            colorBindingSource.Clear();
            sizeBindingSource.Clear();

            IList colorList = new ArrayList();
            IList sizeList = new ArrayList();
            foreach (ProductMaster productMaster in mainStockInEventArgs.FoundProductMasterList)
            {
                if (productMaster.ProductColor != null)
                {
                    bool found = false;
                    foreach (ProductColor color in colorList)
                    {
                        if (color.ColorId == productMaster.ProductColor.ColorId)
                        {
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        colorList.Add(productMaster.ProductColor);
                    }
                }
                if (productMaster.ProductSize != null)
                {
                    bool found = false;
                    foreach (ProductSize size in sizeList)
                    {
                        if (size.SizeId == productMaster.ProductSize.SizeId)
                        {
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        sizeList.Add(productMaster.ProductSize);
                    }
                }
            }
            colorBindingSource.DataSource = colorList;
            sizeBindingSource.DataSource = sizeList;
            productMasterList = mainStockInEventArgs.FoundProductMasterList;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            deptSI = new StockIn();
            deptSIDetailList.Clear();
            txtDexcription.Text = "";
            txtPriceIn.Text = "";
            txtPriceOut.Text = "";
            txtSumProduct.Text = "";
            txtSumValue.Text = "";
            ClearSelectionOnListBox(lstColor);
            ClearSelectionOnListBox(lstSize);
            cboProductMasters.Text = "";
        }

        private void ClearSelectionOnListBox(ListBox color)
        {
            foreach (int item in color.SelectedIndices)
            {
                color.SetSelected(item,false);                                
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var proMaster = cboProductMasters.SelectedItem as ProductMaster;
            int i = cboProductMasters.SelectedIndex;
            if (proMaster == null)
            {
                return;
            }
            ProductMasterExtraForm form =
                GlobalUtility.GetFormObject<ProductMasterExtraForm>(FormConstants.PRODUCT_MASTER_EXTRA_FORM);
            form.ProductMaster = proMaster;
            form.CloseProductMasterEvent += new EventHandler<ProductMasterEventArgs>(form_CloseProductMasterEvent);
            form.Status = ViewStatus.EDIT;
            form.ShowDialog();
            cboProductMasters.SelectedIndex = i;
            cboProductMasters.SelectedItem = proMaster;
            cboProductMasters.DroppedDown = false;
        }

        private void cboProductMasters_DropDown(object sender, EventArgs e)
        {
            var mainStockInEventArgs = new MainStockInEventArgs();
            /*if (dgvDeptStockIn == null || dgvDeptStockIn.CurrentRow == null)
            {
                return;
            }*/
            // selectectIndex is the firstrow
            //int selectedIndex = 0;
            //mainStockInEventArgs.SelectedIndex = selectedIndex;
            //mainStockInEventArgs.SelectedStockInDetail = deptSIDetailList[selectedIndex];
            mainStockInEventArgs.SelectedStockInDetail = new StockInDetail { Product = new Product { ProductMaster = new ProductMaster { ProductName = cboProductMasters.Text } } };
            mainStockInEventArgs.IsFillToComboBox = true;
            mainStockInEventArgs.ComboBoxDisplayMember = "ProductName";
            EventUtility.fireEvent<MainStockInEventArgs>(FillProductToComboEvent, cboProductMasters, mainStockInEventArgs);
        }

        private void ctrlV_Pressed(object sender, EventArgs e)
        {
            if(dgvDeptStockIn.SelectedCells.Count > 0)
            {
                DataGridViewSelectedCellCollection collection = dgvDeptStockIn.SelectedCells;
                foreach (DataGridViewCell cell in collection)
                {
                    cell.Value = Clipboard.GetText();
                }
            }
        }

        private void ctrlC_Pressed(object sender, EventArgs e)
        {
            if(dgvDeptStockIn.CurrentCell!=null)
            {
                Clipboard.SetText(dgvDeptStockIn.CurrentCell.Value.ToString());
            }
        }

        private void btnPriceInput_Click(object sender, EventArgs e)
        {
            long inputPrice = 0;
            long price = 0;
            long wsPrice = 0;

            if (!CheckUtility.IsNullOrEmpty(txtPriceIn.Text))
            {
                Int64.TryParse(txtPriceIn.Text.Trim(), out inputPrice);
            }

            if(!CheckUtility.IsNullOrEmpty(txtPriceOut.Text))
            {
                Int64.TryParse(txtPriceOut.Text.Trim(), out price);
            }

            if (!CheckUtility.IsNullOrEmpty(txtWSPriceOut.Text))
            {
                Int64.TryParse(txtWSPriceOut.Text.Trim(), out wsPrice);
            }

            DataGridViewSelectedRowCollection selectedRows = dgvDeptStockIn.SelectedRows;
            foreach (DataGridViewRow row in selectedRows)
            {
                deptSIDetailList[row.Index].Price = inputPrice;
                deptSIDetailList[row.Index].SellPrice = price;
            }
        }

        private void MainStockInEditExtraForm_Shown(object sender, EventArgs e)
        {
            LoadStockIn();
            LockRowsForEdit();
        }

        private void LockRowsForEdit()
        {
            foreach (DataGridViewRow row in dgvDeptStockIn.Rows)
            {
                if(deptSIDetailList[row.Index].DelFlg == 1)
                {
                    row.ReadOnly = true;
                    row.DefaultCellStyle.BackColor = Color.Gray;
                }
                else
                {
                    row.Cells[6].Style.BackColor = Color.LightYellow;
                }
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvDeptStockIn.CurrentCell != null)
            {
                Clipboard.SetText(dgvDeptStockIn.CurrentCell.Value.ToString());
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvDeptStockIn.SelectedCells.Count > 0)
            {
                DataGridViewSelectedCellCollection collection = dgvDeptStockIn.SelectedCells;
                foreach (DataGridViewCell cell in collection)
                {
                    cell.Value = Clipboard.GetText();
                }
            }
        }
    }
}