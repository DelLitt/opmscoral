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
    public partial class MainStockOutExtraForm : BaseForm, IMainStockOutView
    {
        private const int QUANTITY_POS = 6;
        private const int PRICE_POS = 7;
        private const int SELL_PRICE_POS = 8;
        private StockOutDetailCollection stockOutDetailList;
        private IList CurrentRowProductColorList { get; set; }
        private IList CurrentRowProductSizeList { get; set; }
        public StockOut stockOut { get; set; }
        private IList productMasterList { get; set; }

        private IList stockList { get; set;}

        public MainStockOutExtraForm()
        {
            InitializeComponent();
            stockList = new ArrayList();
            productMasterList = new ArrayList();
        }

        private void ctxMenuDept_Opening(object sender, CancelEventArgs e)
        {

        }

        private void nhToolStripMenuItem_Click(object sender, EventArgs e)
        {
//            StockOutDetail detail = stockOutDetailList[dgvDeptStockOut.CurrentCell.OwningRow.Index];
//            // deep copy in separeate memory space
//            StockInDetail newDetail = CreateNewStockInDetail();
//            var newPM = (ProductMaster)detail.Product.ProductMaster.Clone();
//            newDetail.Product.ProductMaster = newPM;
//            bdsStockIn.EndEdit();
        }

        private StockOutDetail CreateNewStockInDetail()
        {
            var deptSIDet = stockOutDetailList.AddNew();
            deptSIDet.Product = new Product();
            deptSIDet.Product.ProductMaster = new ProductMaster();
            deptSIDet.Product.ProductMaster.ProductName = "";
            deptSIDet.Product.ProductMaster.ProductColor = new ProductColor { ColorName = "" };
            deptSIDet.Product.ProductMaster.ProductSize = new ProductSize { SizeName = "" };
            stockOutDetailList.EndNew(stockOutDetailList.Count - 1);
            return deptSIDet;
        }
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            // create DepartmentStockIn
            if (stockOut == null)
            {
                stockOut = new StockOut();
            }
            stockOut.CreateDate = DateTime.Now;
            stockOut.UpdateDate = DateTime.Now;
            stockOut.CreateId = ClientInfo.getInstance().LoggedUser.Name;
            stockOut.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
            stockOut.ExclusiveKey = 0;
//            int maxAddedItemsCount = int.Parse(numericUpDown.Text);
//            for (int i = 0; i < maxAddedItemsCount; i++)
//            {
//                StockInDetail deptSIDet = CreateNewStockInDetail();
//
//            }

            stockOut.StockOutDetails =
                ObjectConverter.ConvertToNonGenericList<StockOutDetail>(stockOutDetailList);
            bdsStockIn.EndEdit();

//            for (int j = 0; j < maxAddedItemsCount; j++)
//            {
//                for (int i = 0; i <= SELL_PRICE_POS; i++)
//                {
//                    dgvDeptStockOut[i, stockOutDetailList.Count - j - 1].ReadOnly = false;
//                }
//            }
        }


        #region Load products to combo box for select
        private void dgvDeptStockIn_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {


        }

        void Control_KeyUp(object sender, KeyEventArgs e)
        {

        }

        void comboBox_DropDown(object sender, EventArgs e)
        {

            if (!(sender is ComboBox))
            {
                return;
            }
            // set empty current datasource

            //MessageBox.Show(dgvBill.CurrentCell.ColumnIndex.ToString());
            int currentColumnIndex = dgvDeptStockOut.CurrentCell.OwningColumn.Index;
            int currentRowIndex = dgvDeptStockOut.CurrentCell.OwningRow.Index;
            if (currentColumnIndex == 1) // ProductId
            {
                stockOutDetailList[currentRowIndex].Product.ProductMaster.ProductMasterId =
                    ((ComboBox)sender).Text;
            }
            if (currentColumnIndex == 2)   // ProductName
            {
                stockOutDetailList[currentRowIndex].Product.ProductMaster.ProductName =
                    ((ComboBox)sender).Text;
            }


            if (((ComboBox)sender).DataSource == null)
            {
                FillProductToComboBox(sender, dgvDeptStockOut.CurrentCell.OwningColumn.Name);
            }
        }

        private void FillProductToComboBox(object sender, string name)
        {
            var mainStockInEventArgs = new MainStockOutEventArgs();
            if (dgvDeptStockOut == null || dgvDeptStockOut.CurrentRow == null)
            {
                return;
            }
            int selectedIndex = dgvDeptStockOut.CurrentRow.Index;
            mainStockInEventArgs.SelectedIndex = selectedIndex;
            mainStockInEventArgs.SelectedStockOutDetail = stockOutDetailList[selectedIndex];
            mainStockInEventArgs.IsFillToComboBox = true;
            if (name.Equals("columnProductName"))
            {
                mainStockInEventArgs.ComboBoxDisplayMember = "ProductName";
            }
            if (name.Equals("columnProductId"))
            {
                mainStockInEventArgs.ComboBoxDisplayMember = "ProductMasterId";
            }
            EventUtility.fireEvent<MainStockOutEventArgs>(FillProductToComboEvent, sender, mainStockInEventArgs);
        }

        #endregion

        private void dgvDeptStockIn_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            CalculateTotalStorePrice();
        }

        private void DepartmentStockInExtra_Load(object sender, EventArgs e)
        {
            IList list = new ArrayList();
            list.Add(new StockDefectStatus { DefectStatusId = 4, DefectStatusName = "Xuất tạm để sửa hàng"});
            list.Add(new StockDefectStatus { DefectStatusId = 5, DefectStatusName = "Xuất trả về nhà sản xuất" });
            list.Add(new StockDefectStatus { DefectStatusId = 7, DefectStatusName = "Xuất đi cửa hàng khác ngoài hệ thống" });
            list.Add(new StockDefectStatus { DefectStatusId = 9, DefectStatusName = "Xuất hàng mẫu" });

            cbbStockOutType.DataSource = list;
            cbbStockOutType.DisplayMember = "DefectStatusName";

            stockOutDetailList = new StockOutDetailCollection(bdsStockIn);
            bdsStockIn.DataSource = stockOutDetailList;
            dgvDeptStockOut.DataError += new DataGridViewDataErrorEventHandler(dgvDeptStockIn_DataError);
            
            // create DepartmentStockIn
            if (stockOut == null)
            {
                stockOut = new StockOut();
                stockOut.CreateDate = DateTime.Now;
                stockOut.UpdateDate = DateTime.Now;
                stockOut.CreateId = ClientInfo.getInstance().LoggedUser.Name;
                stockOut.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                stockOut.ExclusiveKey = 0;
                CreateNewStockInDetail();
//                btnBarcode.Visible = false;
//                numericUpDownBarcode.Visible = false;
//                btnPreview.Visible = false;
                // load products to extra combo box
                LoadProductMasterToComboBox();
                stockOutDetailList.RemoveAt(0);
                bdsStockIn.EndEdit();

            }
            else
            {
//                btnBarcode.Visible = true;
//                numericUpDownBarcode.Visible = true;
//                btnPreview.Visible = true;
                IList deptStockInDetails = stockOut.StockOutDetails;
                foreach (StockOutDetail detail in deptStockInDetails)
                {
                    if (detail.DelFlg == CommonConstants.DEL_FLG_NO)
                    {
                        stockOutDetailList.Add(detail);
                        //detail.OldQuantity = detail.Quantity;
                    }
                }

                for (int i = 0; i < dgvDeptStockOut.Columns.Count; i++)
                {
                    dgvDeptStockOut.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                    if (i != QUANTITY_POS
                            && i != PRICE_POS
                            && i != SELL_PRICE_POS)
                    {
                        dgvDeptStockOut.Columns[i].ReadOnly = true;
                    }
                }
//                txtDexcription.Text = stockOut.Description;
            }
            stockOut.StockOutDetails =
                    ObjectConverter.ConvertToNonGenericList<StockOutDetail>(stockOutDetailList);
            
            
        }

       

        void dgvDeptStockIn_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        #region IDepartmentStockInView Members

        private MainStockOutController mainStockInController;
        public MainStockOutController MainStockInController
        {
            get
            {
                return mainStockInController;
            }
            set
            {
                mainStockInController = value;
                mainStockInController.MainStockOutView = this;
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
        private IMainStockOutController _mainStockOutController;
        public IMainStockOutController MainStockOutController { set
        {
            _mainStockOutController = value;
            _mainStockOutController.MainStockOutView = this;
        }
        }
        public event EventHandler<MainStockOutEventArgs> FindBarcodeEvent;
        public event EventHandler<MainStockOutEventArgs> SaveStockOutEvent;
        public event EventHandler<MainStockOutEventArgs> FillProductToComboEvent;
        public event EventHandler<MainStockOutEventArgs> LoadGoodsByNameEvent;

        public event EventHandler<MainStockOutEventArgs> LoadProductColorEvent;

        public event EventHandler<MainStockOutEventArgs> LoadProductSizeEvent;

        public event EventHandler<MainStockOutEventArgs> LoadStockStatusEvent;
        public event EventHandler<MainStockOutEventArgs> LoadGoodsByNameColorSizeEvent;

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
            int length = stockOutDetailList.Count;
            for (int i = 0; i < length - count; i++)
            {
                StockOutDetail detail = stockOutDetailList[i];
                if (string.IsNullOrEmpty(detail.Product.ProductMaster.ProductMasterId)
                    && string.IsNullOrEmpty(detail.Product.ProductMaster.ProductName))
                {
                    stockOutDetailList.RemoveAt(i - count);
                    count++;
                }
            }

            if (stockOutDetailList.Count == 0)
            {
                MessageBox.Show("Không có sản phẩm nào để nhập kho!!!!");
                return;
            }

            // validate quantity
            int line = 1;
            long StockDefectId = ((StockDefectStatus) cbbStockOutType.SelectedItem).DefectStatusId;
            foreach (StockOutDetail detail in stockOutDetailList)
            {
                foreach (Stock stock in stockList)
                {
                    if (detail.Product.ProductId.Equals(stock.Product.ProductId))
                    {
                        if(StockDefectId == 9)
                        {
                            if (detail.GoodQuantity < 0)
                            {
                                MessageBox.Show("Lỗi ở dòng " + line + " : Số lượng Tốt phải là số dương ");
                                dgvDeptStockOut.CurrentCell = dgvDeptStockOut[3, Math.Max(0,line-1)];
                                return;
                            }
                        }
                        else
                        {
                            if (detail.GoodQuantity < 0 || detail.GoodQuantity > stock.GoodQuantity)
                            {
                                MessageBox.Show("Lỗi ở dòng " + line + " : Số lượng Tốt phải là số dương nhỏ hơn hoặc bằng " + stock.GoodQuantity);
                                dgvDeptStockOut.CurrentCell = dgvDeptStockOut[3, Math.Max(0, line - 1)];
                                return;
                            }   
                        }
                        if (detail.LostQuantity < 0 || detail.LostQuantity > stock.LostQuantity)
                        {
                            MessageBox.Show("Lỗi ở dòng " + line + " : Số lượng Mất phải là số dương nhỏ hơn hoặc bằng " + stock.LostQuantity);
                            return;
                        }
                        if (detail.DamageQuantity < 0 || detail.DamageQuantity > stock.DamageQuantity)
                        {
                            MessageBox.Show("Lỗi ở dòng " + line + " : Số lượng Lỗi phải là số dương nhỏ hơn hoặc bằng " + stock.DamageQuantity);
                            return;
                        }
                        if (detail.ErrorQuantity < 0 || detail.ErrorQuantity > stock.ErrorQuantity)
                        {
                            MessageBox.Show("Lỗi ở dòng " + line + " : Số lượng Hư phải là số dương nhỏ hơn hoặc bằng " + stock.ErrorQuantity);
                            return;
                        }
                    }
                }

                line++;
            }

            if (stockOut == null)
            {
                stockOut = new StockOut();
            }
            bool isNeedClearData = stockOut.StockoutId == 0;
            stockOut.StockOutDate = dtpImportDate.Value;
            stockOut.StockOutDetails = stockOutDetailList;
            stockOut.DefectStatus = (StockDefectStatus) cbbStockOutType.SelectedItem;
            if(stockOut.DefectStatus.DefectStatusId == 9)
            {
                stockOut.NotUpdateMainStock = true;
            }
//            stockOut.Description = txtDexcription.Text;
            var eventArgs = new MainStockOutEventArgs();
            eventArgs.StockOut = stockOut;
            EventUtility.fireEvent(SaveStockOutEvent, this, eventArgs);
            if (eventArgs.EventResult != null)
            {
                MessageBox.Show("Lưu thành công");
                if (isNeedClearData)
                {
                    stockOut = new StockOut();
                    stockOutDetailList.Clear();
//                    txtDexcription.Text = "";
//                    txtPriceIn.Text = "";
//                    txtPriceOut.Text = "";
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
            /*if (e.ColumnIndex == 0 && e.RowIndex >= 0 && e.RowIndex < stockOutDetailList.Count)
            {
                if (stockOut != null
                    && !string.IsNullOrEmpty(stockOut.StockInId)
                    && stockOutDetailList[e.RowIndex].StockInDetailPK != null
                    && !string.IsNullOrEmpty(stockOutDetailList[e.RowIndex].StockInDetailPK.StockInId))
                {
                    return;
                }
                var productMasterForm = GlobalUtility.GetFormObject<ProductMasterSearchOrCreateForm>(FormConstants.PRODUCT_MASTER_SEARCH_OR_CREATE_FORM);
                productMasterForm.ShowDialog();
                ProductMaster productMaster = productMasterForm.SelectedProductMaster;
                if (productMaster != null)
                {
                    stockOutDetailList[e.RowIndex].Product.ProductMaster = productMaster;
                    bdsStockIn.EndEdit();
                    dgvDeptStockOut.Refresh();
                    dgvDeptStockOut.Invalidate();
                    //bdsStockIn.ResetBindings(false);
                }
            }*/
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvDeptStockOut.CurrentRow == null)
            {
                return;
            }
            var selectedIndex = dgvDeptStockOut.CurrentRow.Index;
            if (selectedIndex < 0 || selectedIndex >= stockOutDetailList.Count)
            {
                return;
            }
            StockOutDetail detail = stockOutDetailList[selectedIndex];
            if (MessageBox.Show("Bạn có muốn xóa không?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (detail.StockOutDetailId != 0)
                {
                    detail.DelFlg = 1;
                    for (int j = 0; j < dgvDeptStockOut.Columns.Count; j++)
                    {
                        dgvDeptStockOut[j, selectedIndex].ReadOnly = true;
                        dgvDeptStockOut[j, selectedIndex].Style.BackColor = Color.Gray;
                    }
                }
                else
                {
                    stockOutDetailList.RemoveAt(selectedIndex);
                }
            }
            CalculateTotalStorePrice();
        }

        private void CalculateTotalStorePrice()
        {
            long totalQty = 0;
            long totalAmt = 0;
            foreach (StockOutDetail outDetail in stockOutDetailList)
            {
                totalQty += outDetail.GoodQuantity;
                
            }
            txtSumProduct.Text = totalQty.ToString();
        }

        private void LoadProductMasterToComboBox()
        {
            var mainStockInEventArgs = new MainStockOutEventArgs();
            /*if (dgvDeptStockOut == null || dgvDeptStockOut.CurrentRow == null)
            {
                return;
            }*/
            // selectectIndex is the firstrow
            //int selectedIndex = 0;
            //mainStockInEventArgs.SelectedIndex = selectedIndex;
            //mainStockInEventArgs.SelectedStockInDetail = stockOutDetailList[selectedIndex];
            mainStockInEventArgs.SelectedStockOutDetail = new StockOutDetail { Product = new Product { ProductMaster = new ProductMaster { ProductName = "" } } };
            mainStockInEventArgs.IsFillToComboBox = true;
            mainStockInEventArgs.ComboBoxDisplayMember = "ProductName";
            EventUtility.fireEvent<MainStockOutEventArgs>(FillProductToComboEvent, cboProductMasters, mainStockInEventArgs);
            
        }

        

        

        private void btnInput_Click(object sender, EventArgs e)
        {
            if (cbbStockOutType.SelectedIndex < 0)
            {
                MessageBox.Show("Hãy chọn Loại để xuất kho");
                return;
            }
            if (string.IsNullOrEmpty(txtBarcode.Text))
            {
                if (cboProductMasters.SelectedIndex < 0)
                {
                    MessageBox.Show("Hãy chọn 1 sản phẩm để xuất kho");
                    return;
                }
                if (lstColor.SelectedIndices == null || lstColor.SelectedIndices.Count <= 0)
                {
                    MessageBox.Show("Hãy chọn màu sản phẩm để xuất kho");
                    return;
                }
                if (lstSize.SelectedIndices == null || lstSize.SelectedIndices.Count <= 0)
                {
                    MessageBox.Show("Hãy chọn kích cỡ sản phẩm để xuất kho");
                    return;
                }
                if (cbbStockOutType.SelectedIndex < 0)
                {
                    MessageBox.Show("Hãy chọn Loại để xuất kho");
                    return;
                }
                //            long outValue = 0;
                //            if (!NumberUtility.CheckLongNullIsZero(txtPriceIn.Text, out outValue)
                //                || outValue < 0
                //                || !NumberUtility.CheckLongNullIsZero(txtPriceOut.Text, out outValue)
                //                || outValue < 0)
                //            {
                //                MessageBox.Show("Giá phải là số dương");
                //                return;
                //            }
                cbbStockOutType.Enabled = false;
                PopulateGridByProductMaster(lstColor.SelectedItems, lstSize.SelectedItems);
                CalculateTotalStorePrice();
            }
            else
            {
                var eventArgs = new MainStockOutEventArgs();
                eventArgs.ProductId = txtBarcode.Text;
                EventUtility.fireEvent(FindBarcodeEvent, this, eventArgs);
                if (eventArgs.EventResult == null)
                {
                    MessageBox.Show("Không tìm thấy mã vạch này");
                    return;
                }
                bool found = false;
                foreach (StockOutDetail detail in stockOutDetailList)
                {
                    if (eventArgs.SelectedStockOutDetail.Product.ProductId.Equals(detail.Product.ProductId))
                    {
                        found = true;
                        break;
                    }
                }
                if (found)
                {
                    MessageBox.Show("Mã vạch đã được nhập");
                    return;
                }
                if (eventArgs.Stock != null)
                {
                    found = false;
                    foreach (Stock detail in stockList)
                    {
                        if (eventArgs.Stock.Product.ProductId.Equals(detail.Product.ProductId))
                        {
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        stockList.Add(eventArgs.Stock);
                    }
                }
                stockOutDetailList.Add(eventArgs.SelectedStockOutDetail);
                stockOutDetailList.EndNew(stockOutDetailList.Count - 1);
                cbbStockOutType.Enabled = false;
                LockField(stockOutDetailList.Count - 1, eventArgs.SelectedStockOutDetail);
            }
        }

        private void LockField(int rowIndex, StockOutDetail stockOutDetail)
        {
            stockOutDetail.DefectStatus = cbbStockOutType.SelectedItem as StockDefectStatus;
            // Xuat tam de sua hang
            if (cbbStockOutType.SelectedIndex == 0)
            {
                for (int i = 0; i < dgvDeptStockOut.ColumnCount; i++)
                {
                    if (i != 8 && i != 7 ) // for shoes
                    {
                        dgvDeptStockOut[i, rowIndex].ReadOnly = true;
                        dgvDeptStockOut[i, rowIndex].Style.ForeColor = Color.Gray;
                    }
                    else
                    {
                        dgvDeptStockOut[i, rowIndex].Style.ForeColor = Color.Black;
                        dgvDeptStockOut[i, rowIndex].Style.BackColor = Color.LightYellow;
                    }
                }
            }
            // Xuất trả về nhà sản xuất
            else if (cbbStockOutType.SelectedIndex == 1)
            {
                for (int i = 0; i < dgvDeptStockOut.ColumnCount; i++)
                {
                    if (i != 8 && i != 7 && i != 9)
                    {
                        dgvDeptStockOut[i, rowIndex].ReadOnly = true;
                        dgvDeptStockOut[i, rowIndex].Style.ForeColor = Color.Gray;
                        dgvDeptStockOut[i, rowIndex].Style.BackColor = Color.White;
                    }
                    else
                    {
                        dgvDeptStockOut[i, rowIndex].Style.ForeColor = Color.Black;
                        dgvDeptStockOut[i, rowIndex].Style.BackColor = Color.LightGreen;
                    }
                }
            }
            //Xuất đi cửa hàng khác
            else if (cbbStockOutType.SelectedIndex == 2)
            {
                for (int i = 0; i < dgvDeptStockOut.ColumnCount; i++)
                {
                    if (i != 7)
                    {
                        dgvDeptStockOut[i, rowIndex].ReadOnly = true;
                        dgvDeptStockOut[i, rowIndex].Style.ForeColor = Color.Gray;
                        dgvDeptStockOut[i, rowIndex].Style.BackColor = Color.White;
                    }
                    else
                    {
                        dgvDeptStockOut[i, rowIndex].Style.ForeColor = Color.Black;
                        dgvDeptStockOut[i, rowIndex].Style.BackColor = Color.LightGreen;
                    }
                }
            }
            else if (cbbStockOutType.SelectedIndex == 3) // xuất hàng mẫu
            {
                for (int i = 0; i < dgvDeptStockOut.ColumnCount; i++)
                {
                    if (i != 7)
                    {
                        dgvDeptStockOut[i, rowIndex].ReadOnly = true;
                        dgvDeptStockOut[i, rowIndex].Style.ForeColor = Color.Gray;
                        dgvDeptStockOut[i, rowIndex].Style.BackColor = Color.White;
                    }
                    else
                    {
                        dgvDeptStockOut[i, rowIndex].Style.ForeColor = Color.Black;
                        dgvDeptStockOut[i, rowIndex].Style.BackColor = Color.LightGreen;
                    }
                }
            }
        }

        private void PopulateGridByProductMaster(IList colorList, IList sizeList)
        {
            IList selectedProductMasterList = new ArrayList();
            foreach (ProductColor color in colorList)
            {
                foreach (ProductSize size in sizeList)
                {
                    foreach (ProductMaster productMaster in productMasterList)
                    {
                        // do not allow duplicate
                        bool goOut = false;
                        foreach (ProductMaster detail in selectedProductMasterList)
                        {
                            if (productMaster.ProductMasterId.Equals(detail.ProductMasterId))
                            {
                                goOut = true;
                                break;
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
                            selectedProductMasterList.Add(productMaster);
                        }
                    }
                }
            }

            var eventArgs = new MainStockOutEventArgs();
            eventArgs.DefectStatusId = ((StockDefectStatus)cbbStockOutType.SelectedItem).DefectStatusId;
            eventArgs.SelectedProductMasterList = selectedProductMasterList;
            EventUtility.fireEvent(LoadStockStatusEvent, this, eventArgs);
            if (eventArgs.FoundStockOutDetailList != null && eventArgs.FoundStockOutDetailList.Count > 0)
            {
                foreach (StockOutDetail detail in eventArgs.FoundStockOutDetailList)
                {
                    bool found = false;
                    foreach (StockOutDetail detail1 in stockOutDetailList)
                    {
                        if (detail.Product.ProductId.Equals(detail1.Product.ProductId))
                        {
                            found = true;
                            break;
                        }
                    }
                    if (found)
                    {
//                        MessageBox.Show("Mã vạch đã được nhập");
//                        return;
                        continue;
                    }
                    // DefectStatusId = 4, DefectStatusName = "Xuất tạm để sửa hàng" });
                    // DefectStatusId = 5, DefectStatusName = "Xuất trả về nhà sản xuất" });
                    // DefectStatusId = 7, DefectStatusName = "Xuất đi cửa hàng khác ngoài hệ thống" });
                    StockDefectStatus defectStatus = (StockDefectStatus)cbbStockOutType.SelectedItem;
                    if(defectStatus.DefectStatusId == 4 )
                    {
                        // if xuattam, so we check error quantity & good quantity ( for shoes )
                        if(detail.GoodQuantity == 0 && detail.ErrorQuantity == 0) // = 0 , so we don't need to show it 
                        {
                            continue;
                        }
                    }
                    
                    if (defectStatus.DefectStatusId == 5)
                    {
                        // if travenhasanxuat, so we check good && error quantity
                        if (detail.GoodQuantity == 0 /*&& detail.ErrorQuantity == 0*/) // = 0 , so we don't need to show it 
                        {
                            continue;
                        }
                    }
                    
                    if (defectStatus.DefectStatusId == 7)
                    {
                        // if xuatdicuahangkhac, so we check good quantity
                        if (detail.GoodQuantity == 0 ) // = 0 , so we don't need to show it 
                        {
                            continue;
                        }
                    }
                    detail.DefectStatus = defectStatus;
                    stockOutDetailList.Add(detail);
                    stockOutDetailList.EndNew(stockOutDetailList.Count - 1);
                    LockField(stockOutDetailList.Count - 1, detail);
                }
                foreach(Stock def in eventArgs.StockList)
                {
                    bool found = false;
                    foreach (Stock detail in stockList)
                    {
                        if (def.Product.ProductId.Equals(detail.Product.ProductId))
                        {

                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        // DefectStatusId = 4, DefectStatusName = "Xuất tạm để sửa hàng" });
                        // DefectStatusId = 5, DefectStatusName = "Xuất trả về nhà sản xuất" });
                        // DefectStatusId = 7, DefectStatusName = "Xuất đi cửa hàng khác ngoài hệ thống" });

                        stockList.Add(def);
                    }
                }

            }
        }

        #region IMainStockInView Members


        public event EventHandler<MainStockInEventArgs> LoadAllGoodsByNameEvent;

        #endregion

        private void btnNewProductInput_Click(object sender, EventArgs e)
        {
            ProductMasterCreateForm form =
                GlobalUtility.GetOnlyChildFormObject<ProductMasterCreateForm>(GlobalCache.Instance().MainForm,
                                                                              FormConstants.PRODUCT_MASTER_CREATE_FORM);
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
                if (dgvDeptStockOut.CurrentCell != null)
                {
                    if (dgvDeptStockOut.CurrentCell.Value!=null)
                    {
                        Clipboard.SetText(dgvDeptStockOut.CurrentCell.Value.ToString());
                    }
                    else
                    {
                         Clipboard.SetText("");
                    }
                }

            }
            if(e.Control && e.KeyCode == Keys.V)
            {
                DataGridViewSelectedCellCollection cells = dgvDeptStockOut.SelectedCells;
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

            var mainStockInEventArgs = new MainStockOutEventArgs();
            mainStockInEventArgs.SelectedStockOutDetail = new StockOutDetail();
            mainStockInEventArgs.SelectedStockOutDetail.Product = new Product { ProductMaster = new ProductMaster() };
            mainStockInEventArgs.SelectedStockOutDetail.Product.ProductMaster.ProductName = productName;
            EventUtility.fireEvent(LoadGoodsByNameEvent, this, mainStockInEventArgs);

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
            stockOut = new StockOut();
            stockOutDetailList.Clear();
//            txtDexcription.Text = "";
//            txtPriceIn.Text = "";
//            txtPriceOut.Text = "";
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
            ProductMasterCreateForm form =
                GlobalUtility.GetFormObject<ProductMasterCreateForm>(FormConstants.PRODUCT_MASTER_CREATE_FORM);
            form.ProductMaster = proMaster;
            form.CloseProductMasterEvent += new EventHandler<ProductMasterEventArgs>(form_CloseProductMasterEvent);
            form.Status = ViewStatus.OPENDIALOG;
            form.ShowDialog();
            cboProductMasters.SelectedIndex = i;
            cboProductMasters.SelectedItem = proMaster;
            cboProductMasters.DroppedDown = false;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cbbStockOutType.Enabled = true;
            stockOutDetailList.Clear();
            txtSumProduct.Text = "0";
        }

        private void cboProductMasters_DropDown(object sender, EventArgs e)
        {
            var mainStockInEventArgs = new MainStockOutEventArgs();
            /*if (dgvDeptStockIn == null || dgvDeptStockIn.CurrentRow == null)
            {
                return;
            }*/
            // selectectIndex is the firstrow
            //int selectedIndex = 0;
            //mainStockInEventArgs.SelectedIndex = selectedIndex;
            //mainStockInEventArgs.SelectedStockInDetail = deptSIDetailList[selectedIndex];
            mainStockInEventArgs.SelectedStockOutDetail = new StockOutDetail { Product = new Product { ProductMaster = new ProductMaster { ProductName = cboProductMasters.Text } } };
            mainStockInEventArgs.IsFillToComboBox = true;
            mainStockInEventArgs.ComboBoxDisplayMember = "ProductName";
            EventUtility.fireEvent<MainStockOutEventArgs>(FillProductToComboEvent, cboProductMasters, mainStockInEventArgs);
        }

        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBarcode.Text) && txtBarcode.Text.Length == 12)
            {
                var eventArgs = new MainStockOutEventArgs();
                eventArgs.ProductId = txtBarcode.Text;
                eventArgs.DefectStatusId = ((StockDefectStatus)cbbStockOutType.SelectedItem).DefectStatusId;
                EventUtility.fireEvent(FindBarcodeEvent, this, eventArgs);
                if (eventArgs.EventResult == null)
                {
                    MessageBox.Show("Không tìm thấy mã vạch này");
                    return;
                }
                bool found = false;
                StockOutDetail foundStockOutDetail = null;
                foreach (StockOutDetail detail in stockOutDetailList)
                {
                    if (eventArgs.SelectedStockOutDetail.Product.ProductId.Equals(detail.Product.ProductId))
                    {
                        found = true;
                        foundStockOutDetail = detail;
                        break;
                    }
                }
                if (found)
                {
                    //MessageBox.Show("Mã vạch đã được nhập");
                    foundStockOutDetail.GoodQuantity += 1;
                    return;
                }
                if (eventArgs.Stock != null)
                {
                    found = false;
                    foreach (Stock detail in stockList)
                    {
                        if (eventArgs.Stock.Product.ProductId.Equals(detail.Product.ProductId))
                        {
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        stockList.Add(eventArgs.Stock);
                    }
                }
                // reset quantity to 1
                eventArgs.SelectedStockOutDetail.GoodQuantity = 1;
                stockOutDetailList.Add(eventArgs.SelectedStockOutDetail);
                stockOutDetailList.EndNew(stockOutDetailList.Count - 1);
                cbbStockOutType.Enabled = false;
                txtBarcode.Text = "";
                LockField(stockOutDetailList.Count - 1, eventArgs.SelectedStockOutDetail);
            
            }
            CalculateTotalStorePrice();
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

        private void txtSumProduct_TextChanged(object sender, EventArgs e)
        {

        }
    }
}