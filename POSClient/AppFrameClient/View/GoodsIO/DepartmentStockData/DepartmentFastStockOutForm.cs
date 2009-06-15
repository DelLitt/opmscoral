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
using AppFrame.Presenter.GoodsIO.DepartmentGoodsIO;
using AppFrame.Utility;
using AppFrame.View.GoodsIO.DepartmentGoodsIO;
using AppFrameClient.Common;
using AppFrameClient.Presenter.GoodsIO.DepartmentStockData;


namespace AppFrameClient.View.GoodsIO.DepartmentStockData
{
    public partial class DepartmentFastStockOutForm : BaseForm, IDepartmentStockOutView
    {
        private const int QUANTITY_POS = 6;
        private const int PRICE_POS = 7;
        private const int SELL_PRICE_POS = 8;
        private DepartmentStockOutDetailCollection deptSODetailList;
        private IList CurrentRowProductColorList { get; set; }
        private IList CurrentRowProductSizeList { get; set; }
        public DepartmentStockOut deptSO { get; set; }
        private IList productMasterList { get; set; }

        private IList departmentStockList { get; set; }

        public DepartmentFastStockOutForm()
        {
            InitializeComponent();
            departmentStockList = new ArrayList();
            productMasterList = new ArrayList();
        }

        private void ctxMenuDept_Opening(object sender, CancelEventArgs e)
        {

        }

        private void nhToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private DepartmentStockOutDetail CreateNewStockInDetail()
        {
            var deptSIDet = deptSODetailList.AddNew();
            deptSIDet.Product = new Product();
            deptSIDet.Product.ProductMaster = new ProductMaster();
            deptSIDet.Product.ProductMaster.ProductName = "";
            deptSIDet.Product.ProductMaster.ProductColor = new ProductColor { ColorName = "" };
            deptSIDet.Product.ProductMaster.ProductSize = new ProductSize { SizeName = "" };
            deptSODetailList.EndNew(deptSODetailList.Count - 1);
            return deptSIDet;
        }
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            // create DepartmentStockIn
            if (deptSO == null)
            {
                deptSO = new DepartmentStockOut();
            }
            deptSO.CreateDate = DateTime.Now;
            deptSO.UpdateDate = DateTime.Now;
            deptSO.CreateId = ClientInfo.getInstance().LoggedUser.Name;
            deptSO.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
            deptSO.ExclusiveKey = 0;
//            int maxAddedItemsCount = int.Parse(numericUpDown.Text);
//            for (int i = 0; i < maxAddedItemsCount; i++)
//            {
//                StockInDetail deptSIDet = CreateNewStockInDetail();
//
//            }

            deptSO.DepartmentStockOutDetails =
                ObjectConverter.ConvertToNonGenericList<DepartmentStockOutDetail>(deptSODetailList);
            bdsStockIn.EndEdit();

//            for (int j = 0; j < maxAddedItemsCount; j++)
//            {
//                for (int i = 0; i <= SELL_PRICE_POS; i++)
//                {
//                    dgvDeptStockIn[i, deptSODetailList.Count - j - 1].ReadOnly = false;
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
            int currentColumnIndex = dgvDeptStockIn.CurrentCell.OwningColumn.Index;
            int currentRowIndex = dgvDeptStockIn.CurrentCell.OwningRow.Index;
            if (currentColumnIndex == 1) // ProductId
            {
                deptSODetailList[currentRowIndex].Product.ProductMaster.ProductMasterId =
                    ((ComboBox)sender).Text;
            }
            if (currentColumnIndex == 2)   // ProductName
            {
                deptSODetailList[currentRowIndex].Product.ProductMaster.ProductName =
                    ((ComboBox)sender).Text;
            }


            if (((ComboBox)sender).DataSource == null)
            {
                FillProductToComboBox(sender, dgvDeptStockIn.CurrentCell.OwningColumn.Name);
            }
        }

        private void FillProductToComboBox(object sender, string name)
        {
            var mainStockInEventArgs = new DepartmentStockOutEventArgs();
            if (dgvDeptStockIn == null || dgvDeptStockIn.CurrentRow == null)
            {
                return;
            }
            int selectedIndex = dgvDeptStockIn.CurrentRow.Index;
            mainStockInEventArgs.SelectedIndex = selectedIndex;
            mainStockInEventArgs.SelectedDepartmentStockOutDetail = deptSODetailList[selectedIndex];
            mainStockInEventArgs.IsFillToComboBox = true;
            if (name.Equals("columnProductName"))
            {
                mainStockInEventArgs.ComboBoxDisplayMember = "ProductName";
            }
            if (name.Equals("columnProductId"))
            {
                mainStockInEventArgs.ComboBoxDisplayMember = "ProductMasterId";
            }
            EventUtility.fireEvent<DepartmentStockOutEventArgs>(FillProductToComboEvent, sender, mainStockInEventArgs);
        }

        #endregion

        private void dgvDeptStockIn_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            CalculateTotalStorePrice();
//            try
//            {
//                var mainStockInEventArgs = new DepartmentStockOutEventArgs();
//                if (dgvDeptStockIn == null || dgvDeptStockIn.CurrentRow == null)
//                {
//                    return;
//                }
//                int selectedIndex = dgvDeptStockIn.CurrentRow.Index;
//                mainStockInEventArgs.SelectedIndex = selectedIndex;
//                mainStockInEventArgs.SelectedStockOutDetail = deptSODetailList[selectedIndex];
//
//                // bind the quantity, price and sellprice
//                long qty = NumberUtility.ParseLong(dgvDeptStockIn[QUANTITY_POS, selectedIndex].Value);
//                long inPrice = NumberUtility.ParseLong(dgvDeptStockIn[PRICE_POS, selectedIndex].Value);
//                long sellPrice = NumberUtility.ParseLong(dgvDeptStockIn[SELL_PRICE_POS, selectedIndex].Value);
//
//                if (e.ColumnIndex == 1 || e.ColumnIndex == 2)
//                {
//                    mainStockInEventArgs.SelectedStockInDetail.Product.ProductMaster.ProductMasterId =
//                        dgvDeptStockIn.CurrentCell.Value as string;
//                    if (e.ColumnIndex == 1)
//                    {
//                        EventUtility.fireEvent(LoadGoodsByIdEvent, this, mainStockInEventArgs);
//                    }
//                    else
//                    {
//                        EventUtility.fireEvent(LoadGoodsByNameEvent, this, mainStockInEventArgs);
//                    }
//
//                    // load goods to current row
//                    var loadGoods =
//                        mainStockInEventArgs.SelectedStockInDetail.Product.ProductMaster;
//                    deptSODetailList[selectedIndex] = mainStockInEventArgs.SelectedStockInDetail;
//                    bdsStockIn.EndEdit();
//
//                }
//                else if (e.ColumnIndex == 3)
//                {
//                    // get the product name
//                    var name = dgvDeptStockIn[2, dgvDeptStockIn.CurrentCell.RowIndex].Value as string;
//                    if (string.IsNullOrEmpty(name))
//                    {
//                        // ignore
//                        return;
//                    }
//                    // get the color (if selected)
//                    ProductColor color = null;
//                    var colorStr = dgvDeptStockIn.CurrentCell.Value as string;
//                    if (CurrentRowProductColorList != null)
//                    {
//                        foreach (ProductColor c in CurrentRowProductColorList)
//                        {
//                            if (c.ColorName.Equals(colorStr))
//                            {
//                                color = c;
//                                break;
//                            }
//                        }
//                    }
//
//                    mainStockInEventArgs.SelectedStockInDetail.Product.ProductMaster.ProductName = name;
//                    mainStockInEventArgs.SelectedStockInDetail.Product.ProductMaster.ProductColor = color;
//                    EventUtility.fireEvent(LoadGoodsByNameColorEvent, this, mainStockInEventArgs);
//                    // load goods to current row
//                    var loadGoods =
//                        mainStockInEventArgs.SelectedStockInDetail.Product.ProductMaster;
//                    deptSODetailList[selectedIndex] = mainStockInEventArgs.SelectedStockInDetail;
//                    bdsStockIn.EndEdit();
//                }
//                else if (e.ColumnIndex == 4)
//                {
//                    // get the product name
//                    var name = dgvDeptStockIn[2, dgvDeptStockIn.CurrentCell.RowIndex].Value as string;
//                    if (string.IsNullOrEmpty(name))
//                    {
//                        // ignore
//                        return;
//                    }
//                    // get the color (if selected)
//                    // get the color (if selected)
//                    ProductColor color = null;
//                    var colorStr = dgvDeptStockIn[3, dgvDeptStockIn.CurrentCell.RowIndex].Value as string;
//                    if (CurrentRowProductColorList != null)
//                    {
//                        foreach (ProductColor c in CurrentRowProductColorList)
//                        {
//                            if (c.ColorName.Equals(colorStr))
//                            {
//                                color = c;
//                                break;
//                            }
//                        }
//                    }
//
//                    // get the color (if selected)
//                    ProductSize size = null;
//                    var sizeStr = dgvDeptStockIn.CurrentCell.Value as string;
//                    if (CurrentRowProductSizeList != null)
//                    {
//                        foreach (ProductSize c in CurrentRowProductSizeList)
//                        {
//                            if (c.SizeName.Equals(sizeStr))
//                            {
//                                size = c;
//                                break;
//                            }
//                        }
//                    }
//
//                    mainStockInEventArgs.SelectedStockInDetail.Product.ProductMaster.ProductName = name;
//                    mainStockInEventArgs.SelectedStockInDetail.Product.ProductMaster.ProductSize = size;
//                    mainStockInEventArgs.SelectedStockInDetail.Product.ProductMaster.ProductColor = color;
//                    EventUtility.fireEvent(LoadGoodsByNameColorSizeEvent, this, mainStockInEventArgs);
//                    // load goods to current row
//                    var loadGoods =
//                        mainStockInEventArgs.SelectedStockInDetail.Product.ProductMaster;
//                    deptSODetailList[selectedIndex] = mainStockInEventArgs.SelectedStockInDetail;
//                    bdsStockIn.EndEdit();
//                }
//                if (deptSODetailList[selectedIndex] != null)
//                {
//                    deptSODetailList[selectedIndex].Quantity = qty;
//                    deptSODetailList[selectedIndex].Price = inPrice;
//                    deptSODetailList[selectedIndex].SellPrice = sellPrice;
//                    CalculateTotalStorePrice();
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Mã sản phẩm không hợp lệ hoặc lỗi khi nhập");
//            }
        }

        private void CalculateTotalStorePrice()
        {
            long totalInPrice = 0;
            long totalProduct = 0;
            foreach (DepartmentStockOutDetail detail in deptSODetailList)
            {
                if (detail.DelFlg == CommonConstants.DEL_FLG_NO)
                {
                    totalProduct += detail.Quantity;
                }
            }
            
            txtSumProduct.Text = totalProduct.ToString();
        }

        private void DepartmentStockInExtra_Load(object sender, EventArgs e)
        {
            cbbStockOutType.Enabled = false;
            btnReset.Enabled = false;
            cboProductMasters.Enabled = false;
            rdoFastStockOut.Checked = true;

            IList list = new ArrayList();
            if (ClientSetting.IsSubStock())
            {
                list.Add(new StockDefectStatus {DefectStatusId = 7, DefectStatusName = "Xuất đi cửa hàng khác"});
            }
            else
            {
                list.Add(new StockDefectStatus { DefectStatusId = 4, DefectStatusName = "Xuất tạm để sửa hàng" });
                list.Add(new StockDefectStatus { DefectStatusId = 6, DefectStatusName = "Xuất trả về kho chính" });    
            
            }
            DepartmentStockOutEventArgs eventArgs = new DepartmentStockOutEventArgs();
            EventUtility.fireEvent(LoadAllDepartments,this,eventArgs);
            if(eventArgs.DepartmentsList!= null && eventArgs.DepartmentsList.Count > 0)
            {
                BindingSource bdsDepartment = new BindingSource();
                bdsDepartment.DataSource = typeof (Department);
                cboDepartment.DataSource = bdsDepartment;
                cboDepartment.DisplayMember = "DepartmentName";
                foreach (Department department in eventArgs.DepartmentsList)
                {
                    if (department.DepartmentId != CurrentDepartment.Get().DepartmentId)
                    {
                        bdsDepartment.Add(department);
                    }
                }
                bdsDepartment.EndEdit();
                cboDepartment.Refresh();
                cboDepartment.Invalidate();
            }

            cbbStockOutType.DataSource = list;
            cbbStockOutType.DisplayMember = "DefectStatusName";

            deptSODetailList = new DepartmentStockOutDetailCollection(bdsStockIn);
            bdsStockIn.DataSource = deptSODetailList;
            dgvDeptStockIn.DataError += new DataGridViewDataErrorEventHandler(dgvDeptStockIn_DataError);
            
            // create DepartmentStockIn
            if (deptSO == null)
            {
                deptSO = new DepartmentStockOut();
                deptSO.CreateDate = DateTime.Now;
                deptSO.UpdateDate = DateTime.Now;
                deptSO.CreateId = ClientInfo.getInstance().LoggedUser.Name;
                deptSO.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                deptSO.ExclusiveKey = 0;
                CreateNewStockInDetail();
//                btnBarcode.Visible = false;
//                numericUpDownBarcode.Visible = false;
//                btnPreview.Visible = false;
                // load products to extra combo box
                LoadProductMasterToComboBox();
                deptSODetailList.RemoveAt(0);
                bdsStockIn.EndEdit();

            }
            else
            {
//                btnBarcode.Visible = true;
//                numericUpDownBarcode.Visible = true;
//                btnPreview.Visible = true;
                IList deptStockInDetails = deptSO.DepartmentStockOutDetails;
                foreach (DepartmentStockOutDetail detail in deptStockInDetails)
                {
                    if (detail.DelFlg == CommonConstants.DEL_FLG_NO)
                    {
                        deptSODetailList.Add(detail);
                        //detail.OldQuantity = detail.Quantity;
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
//                txtDexcription.Text = deptSO.Description;
            }
            deptSO.DepartmentStockOutDetails =
                    ObjectConverter.ConvertToNonGenericList<DepartmentStockOutDetail>(deptSODetailList);
            
            
        }

       

        void dgvDeptStockIn_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        #region IDepartmentStockInView Members

        private DepartmentStockOutController mainStockInController;
        public DepartmentStockOutController DepartmentStockInController
        {
            get
            {
                return mainStockInController;
            }
            set
            {
                mainStockInController = value;
                mainStockInController.DepartmentStockOutView = this;
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

        public event EventHandler<DepartmentStockInEventArgs> InitDepartmentStockInEvent;

        public event EventHandler<AppFrame.Presenter.GoodsIO.ProductMasterSearchOrCreateEventArgs> OpenProductMasterSearchEvent;

        public event EventHandler<DepartmentStockInEventArgs> SaveDepartmentStockInEvent;

        public event EventHandler<DepartmentStockInEventArgs> FindProductMasterEvent;
        private IDepartmentStockOutController _mainStockOutController;
        public IDepartmentStockOutController DepartmentStockOutController { set
        {
            _mainStockOutController = value;
            _mainStockOutController.DepartmentStockOutView = this;
        }
        }
        public event EventHandler<DepartmentStockOutEventArgs> FindBarcodeEvent;
        public event EventHandler<DepartmentStockOutEventArgs> SaveStockOutEvent;
        public event EventHandler<DepartmentStockOutEventArgs> FillProductToComboEvent;
        public event EventHandler<DepartmentStockOutEventArgs> LoadGoodsByNameEvent;

        public event EventHandler<DepartmentStockOutEventArgs> LoadProductColorEvent;

        public event EventHandler<DepartmentStockOutEventArgs> LoadProductSizeEvent;

        public event EventHandler<DepartmentStockOutEventArgs> LoadStockStatusEvent;
        public event EventHandler<DepartmentStockOutEventArgs> LoadGoodsByNameColorSizeEvent;
        public event EventHandler<DepartmentStockOutEventArgs> GetSyncDataEvent;
        public event EventHandler<DepartmentStockOutEventArgs> SyncToMainEvent;
        public event EventHandler<DepartmentStockOutEventArgs> LoadAllDepartments;
        public event EventHandler<DepartmentStockOutEventArgs> DispatchDepartmentStockOut;

        #endregion



        private void mnuCreateNewItem_Click(object sender, EventArgs e)
        {
            btnAddProduct_Click(sender, null);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn hãy kiểm tra kỹ trước khi lưu số liệu bởi vì sau khi lưu sẽ không thay đổi được nữa. Bạn có chắc chắn muốn lưu ?","Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == System.Windows.Forms.DialogResult.No)
            {
                return;
            }
            // first remove all blank row
            int count = 0;
            int length = deptSODetailList.Count;
            for (int i = 0; i < length - count; i++)
            {
                DepartmentStockOutDetail detail = deptSODetailList[i];
                if (string.IsNullOrEmpty(detail.Product.ProductMaster.ProductMasterId)
                    && string.IsNullOrEmpty(detail.Product.ProductMaster.ProductName))
                {
                    deptSODetailList.RemoveAt(i - count);
                    count++;
                }
            }

            if (deptSODetailList.Count == 0)
            {
                MessageBox.Show("Không có sản phẩm nào để nhập kho!!!!");
                return;
            }

            // validate quantity
            int line = 1;
            foreach (DepartmentStockOutDetail detail in deptSODetailList)
            {
                foreach (DepartmentStock stock in departmentStockList)
                {
                    if (detail.Product.ProductId.Equals(stock.Product.ProductId))
                    {
                        if (detail.GoodQuantity < 0 || detail.GoodQuantity > stock.GoodQuantity)
                        {
                            MessageBox.Show("Lỗi ở dòng " + line + " : Số lượng Tốt phải là số dương nhỏ hơn hoặc bằng " + stock.GoodQuantity);
                            return;
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
                if ((detail.DefectStatus.DefectStatusId == 4 && detail.ErrorQuantity == 0)
                    || (detail.DefectStatus.DefectStatusId == 6 && detail.DamageQuantity + detail.GoodQuantity + detail.ErrorQuantity == 0)
                    || (detail.DefectStatus.DefectStatusId == 7 && detail.GoodQuantity == 0)) 
                {
                    MessageBox.Show("Lỗi ở dòng " + line + " : Số lượng xuất phải lớn hơn 0.");
                    return;
                }
                line++;
            }

            if (deptSO == null)
            {
                deptSO = new DepartmentStockOut();
            }
            bool isNeedClearData = deptSO.DepartmentStockOutPK == null || deptSO.DepartmentStockOutPK.StockOutId == 0;
            deptSO.StockOutDate = dtpImportDate.Value;
            deptSO.DefectStatus = (StockDefectStatus)cbbStockOutType.SelectedItem;
            deptSO.DepartmentStockOutDetails = deptSODetailList;
//            deptSO.Description = txtDexcription.Text;
            var eventArgs = new DepartmentStockOutEventArgs();
            eventArgs.DepartmentStockOut = deptSO;
            EventUtility.fireEvent(SaveStockOutEvent, this, eventArgs);
            if (eventArgs.EventResult != null)
            {

                MessageBox.Show("Lưu thành công");
                if (isNeedClearData)
                {
                    deptSO = new DepartmentStockOut();
                    deptSODetailList.Clear();
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
            /*if (e.ColumnIndex == 0 && e.RowIndex >= 0 && e.RowIndex < deptSODetailList.Count)
            {
                if (deptSO != null
                    && !string.IsNullOrEmpty(deptSO.StockInId)
                    && deptSODetailList[e.RowIndex].StockInDetailPK != null
                    && !string.IsNullOrEmpty(deptSODetailList[e.RowIndex].StockInDetailPK.StockInId))
                {
                    return;
                }
                var productMasterForm = GlobalUtility.GetFormObject<ProductMasterSearchOrCreateForm>(FormConstants.PRODUCT_MASTER_SEARCH_OR_CREATE_FORM);
                productMasterForm.ShowDialog();
                ProductMaster productMaster = productMasterForm.SelectedProductMaster;
                if (productMaster != null)
                {
                    deptSODetailList[e.RowIndex].Product.ProductMaster = productMaster;
                    bdsStockIn.EndEdit();
                    dgvDeptStockIn.Refresh();
                    dgvDeptStockIn.Invalidate();
                    //bdsStockIn.ResetBindings(false);
                }
            }*/
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvDeptStockIn.CurrentRow == null)
            {
                return;
            }
            var selectedIndex = dgvDeptStockIn.CurrentRow.Index;
            if (selectedIndex < 0 || selectedIndex >= deptSODetailList.Count)
            {
                return;
            }
            DepartmentStockOutDetail detail = deptSODetailList[selectedIndex];
            if (MessageBox.Show("Bạn có muốn xóa không?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (detail.StockOutDetailId != 0)
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
                    //deptSODetailList.RemoveAt(selectedIndex);
                    DataGridViewSelectedCellCollection cellCollection = dgvDeptStockIn.SelectedCells;
                    IList<int> rowIndexes = new List<int>();
                    foreach (DataGridViewCell cell in cellCollection)
                    {
                        if(NotInList(cell.RowIndex,rowIndexes))
                        {
                            rowIndexes.Add(cell.RowIndex);
                        }
                    }
                    foreach (int rowIndex in rowIndexes)
                    {
                        deptSODetailList.RemoveAt(rowIndex);
                    }
                    bdsStockIn.EndEdit();
                    dgvDeptStockIn.Refresh();
                    dgvDeptStockIn.Invalidate();
                }
            }
            CalculateTotalStorePrice();
        }

        private bool NotInList(int index, IList<int> indexes)
        {
            foreach (int i in indexes)
            {
                if(i == index)
                {
                    return false;
                }
            }
            return true;
        }

        private void LoadProductMasterToComboBox()
        {
            var mainStockInEventArgs = new DepartmentStockOutEventArgs();
            /*if (dgvDeptStockIn == null || dgvDeptStockIn.CurrentRow == null)
            {
                return;
            }*/
            // selectectIndex is the firstrow
            //int selectedIndex = 0;
            //mainStockInEventArgs.SelectedIndex = selectedIndex;
            //mainStockInEventArgs.SelectedStockInDetail = deptSODetailList[selectedIndex];
            mainStockInEventArgs.SelectedDepartmentStockOutDetail = new DepartmentStockOutDetail { Product = new Product { ProductMaster = new ProductMaster { ProductName = "" } } };
            mainStockInEventArgs.IsFillToComboBox = true;
            mainStockInEventArgs.ComboBoxDisplayMember = "ProductName";
            EventUtility.fireEvent<DepartmentStockOutEventArgs>(FillProductToComboEvent, cboProductMasters, mainStockInEventArgs);
            
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
            }
            else
            {
                var eventArgs = new DepartmentStockOutEventArgs();
                eventArgs.ProductId = txtBarcode.Text;
                EventUtility.fireEvent(FindBarcodeEvent, this, eventArgs);
                if (eventArgs.EventResult == null)
                {
                    MessageBox.Show("Không tìm thấy mã vạch này");
                    return;
                }
                bool found = false;
                foreach (DepartmentStockOutDetail detail in deptSODetailList)
                {
                    if (eventArgs.SelectedDepartmentStockOutDetail.Product.ProductId.Equals(detail.Product.ProductId))
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
                if (eventArgs.DepartmentStock != null)
                {
                    found = false;
                    foreach (Stock detail in departmentStockList)
                    {
                        if (eventArgs.DepartmentStock.Product.ProductId.Equals(detail.Product.ProductId))
                        {
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        departmentStockList.Add(eventArgs.DepartmentStock);
                    }
                }
                eventArgs.SelectedDepartmentStockOutDetail.GoodQuantity = 1;
                deptSODetailList.Add(eventArgs.SelectedDepartmentStockOutDetail);
                deptSODetailList.EndNew(deptSODetailList.Count - 1);
                cbbStockOutType.Enabled = false;
                LockField(deptSODetailList.Count - 1, eventArgs.SelectedDepartmentStockOutDetail);
            }
        }

        private void LockField(int rowIndex, DepartmentStockOutDetail stockOutDetail)
        {
            stockOutDetail.DefectStatus = cbbStockOutType.SelectedItem as StockDefectStatus;
            StockDefectStatus defectStatus = stockOutDetail.DefectStatus;
            // Xuat tam de sua hang
            if (defectStatus.DefectStatusId == 4)
            {
                for (int i = 0; i < dgvDeptStockIn.ColumnCount; i++)
                {
                    if (i != 8)
                    {
                        dgvDeptStockIn[i, rowIndex].ReadOnly = true;
                        dgvDeptStockIn[i, rowIndex].Style.ForeColor = Color.Gray;
                    }
                    else
                    {
                        dgvDeptStockIn[i, rowIndex].Style.ForeColor = Color.Black;
                    }
                }
            }
            // Xuất trả về kho chính
            else if (defectStatus.DefectStatusId == 6)
            {
                for (int i = 0; i < dgvDeptStockIn.ColumnCount; i++)
                {
                    if (i != 8 && i != 7 && i != 9)
                    {
                        dgvDeptStockIn[i, rowIndex].ReadOnly = true;
                        dgvDeptStockIn[i, rowIndex].Style.ForeColor = Color.Gray;
                    }
                    else
                    {
                        dgvDeptStockIn[i, rowIndex].Style.ForeColor = Color.Black;
                    }
                }
            }
            //Xuất đi cửa hàng khác
            else if (defectStatus.DefectStatusId == 7)
            {
                for (int i = 0; i < dgvDeptStockIn.ColumnCount; i++)
                {
                    if (i != 7)
                    {
                        dgvDeptStockIn[i, rowIndex].ReadOnly = true;
                        dgvDeptStockIn[i, rowIndex].Style.ForeColor = Color.Gray;
                    }
                    else
                    {
                        dgvDeptStockIn[i, rowIndex].Style.ForeColor = Color.Black;
                        dgvDeptStockIn[i, rowIndex].Style.BackColor = Color.LightYellow;
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

            var eventArgs = new DepartmentStockOutEventArgs();
            eventArgs.SelectedProductMasterList = selectedProductMasterList;
            EventUtility.fireEvent(LoadStockStatusEvent, this, eventArgs);
            if (eventArgs.FoundDepartmentStockOutDetailList != null && eventArgs.FoundDepartmentStockOutDetailList.Count > 0)
            {
                foreach (DepartmentStockOutDetail detail in eventArgs.FoundDepartmentStockOutDetailList)
                {
                    bool found = false;
                    foreach (DepartmentStockOutDetail detail1 in deptSODetailList)
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
                     // DefectStatusId = 6, DefectStatusName = "Xuất trả về kho chính" });
                     // DefectStatusId = 7, DefectStatusName = "Xuất đi cửa hàng khác" });
                    StockDefectStatus defectStatus = (StockDefectStatus)cbbStockOutType.SelectedItem;
                    
                    if (defectStatus.DefectStatusId == 4)
                    {
                        // if xuattam, so we check error quantity
                        if (detail.ErrorQuantity == 0) // = 0 , so we don't need to show it 
                        {
                            continue;
                        }
                    }

                    if (defectStatus.DefectStatusId == 7)
                    {
                        // if xuatdicuahangkhac, so we check good quantity
                        if (detail.GoodQuantity == 0) // = 0 , so we don't need to show it 
                        {
                            continue;
                        }
                    }
                    detail.DefectStatus = defectStatus;
                    detail.GoodQuantity = 1;
                    deptSODetailList.Add(detail);
                    deptSODetailList.EndNew(deptSODetailList.Count - 1);
                    LockField(deptSODetailList.Count - 1, detail);
                }
                foreach (DepartmentStock def in eventArgs.DepartmentStockList)
                {
                    bool found = false;
                    foreach (DepartmentStock detail in departmentStockList)
                    {
                        if (def.Product.ProductId.Equals(detail.Product.ProductId))
                        {
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        departmentStockList.Add(def);
                    }
                }
                CalculateTotalStorePrice();
            }
        }

        #region IDepartmentStockInView Members


        public event EventHandler<DepartmentStockInEventArgs> LoadAllGoodsByNameEvent;

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

            var mainStockInEventArgs = new DepartmentStockOutEventArgs();
            mainStockInEventArgs.SelectedDepartmentStockOutDetail = new DepartmentStockOutDetail();
            mainStockInEventArgs.SelectedDepartmentStockOutDetail.Product = new Product { ProductMaster = new ProductMaster() };
            mainStockInEventArgs.SelectedDepartmentStockOutDetail.Product.ProductMaster.ProductName = productName;
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
            deptSO = new DepartmentStockOut();
            deptSODetailList.Clear();
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
            deptSODetailList.Clear();
        }

        private void cboProductMasters_DropDown(object sender, EventArgs e)
        {
            var mainStockInEventArgs = new DepartmentStockOutEventArgs();
            /*if (dgvDeptStockIn == null || dgvDeptStockIn.CurrentRow == null)
            {
                return;
            }*/
            // selectectIndex is the firstrow
            //int selectedIndex = 0;
            //mainStockInEventArgs.SelectedIndex = selectedIndex;
            //mainStockInEventArgs.SelectedStockInDetail = deptSODetailList[selectedIndex];
            mainStockInEventArgs.SelectedDepartmentStockOutDetail = new DepartmentStockOutDetail { Product = new Product { ProductMaster = new ProductMaster { ProductName = cboProductMasters.Text } } };
            mainStockInEventArgs.IsFillToComboBox = true;
            mainStockInEventArgs.ComboBoxDisplayMember = "ProductName";
            EventUtility.fireEvent<DepartmentStockOutEventArgs>(FillProductToComboEvent, cboProductMasters, mainStockInEventArgs);
        }

        private void systemHotkey1_Pressed(object sender, EventArgs e)
        {
            txtBarcode.Focus();
        }

        private void deleteStock_Pressed(object sender, EventArgs e)
        {
            btnDelete_Click(sender,e);
        }

        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtBarcode.Text) && txtBarcode.Text.Length == 12)
            {
                var eventArgs = new DepartmentStockOutEventArgs();
                eventArgs.ProductId = txtBarcode.Text;
                EventUtility.fireEvent(FindBarcodeEvent, this, eventArgs);
                if (eventArgs.EventResult == null)
                {
                    MessageBox.Show("Không tìm thấy mã vạch này");
                    txtBarcode.Text = "";
                    return;
                }
                bool found = false;
                foreach (DepartmentStockOutDetail detail in deptSODetailList)
                {
                    if (eventArgs.SelectedDepartmentStockOutDetail.Product.ProductId.Equals(detail.Product.ProductId))
                    {
                        found = true;
                        break;
                    }
                }
                if (found)
                {
                    txtBarcode.Text = "";
                    MessageBox.Show("Mã vạch đã được nhập");
                    return;
                }
                if (eventArgs.DepartmentStock != null)
                {
                    found = false;
                    foreach (DepartmentStock detail in departmentStockList)
                    {
                        if (eventArgs.DepartmentStock.Product.ProductId.Equals(detail.Product.ProductId))
                        {
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        departmentStockList.Add(eventArgs.DepartmentStock);
                    }
                }
                if(eventArgs.SelectedDepartmentStockOutDetail.Quantity > 0 )
                {
                    eventArgs.SelectedDepartmentStockOutDetail.GoodQuantity = 1;    
                }
                else
                {
                    MessageBox.Show("Mặt hàng này trong kho đã hết. Xin vui lòng kiểm tra lại.");
                    txtBarcode.Text = "";
                    return;
                }
                
                deptSODetailList.Add(eventArgs.SelectedDepartmentStockOutDetail);
                deptSODetailList.EndNew(deptSODetailList.Count - 1);
                cbbStockOutType.Enabled = false;
                txtBarcode.Text = "";
                LockField(deptSODetailList.Count - 1, eventArgs.SelectedDepartmentStockOutDetail);
                if(rdoFastStockOut.Checked)
                {
                    // do fast stock out in here
                    // first remove all blank row
                    int count = 0;
                    int length = deptSODetailList.Count;
                    for (int i = 0; i < length - count; i++)
                    {
                        DepartmentStockOutDetail detail = deptSODetailList[i];
                        if (string.IsNullOrEmpty(detail.Product.ProductMaster.ProductMasterId)
                            && string.IsNullOrEmpty(detail.Product.ProductMaster.ProductName))
                        {
                            deptSODetailList.RemoveAt(i - count);
                            count++;
                        }
                    }

                    if (deptSODetailList.Count == 0)
                    {
                        MessageBox.Show("Không có sản phẩm nào để nhập kho!!!!");
                        return;
                    }

                    // validate quantity
                    int line = 1;
                    foreach (DepartmentStockOutDetail detail in deptSODetailList)
                    {
                        foreach (DepartmentStock stock in departmentStockList)
                        {
                            if (detail.Product.ProductId.Equals(stock.Product.ProductId))
                            {
                                if (detail.GoodQuantity < 0 || detail.GoodQuantity > stock.GoodQuantity)
                                {
                                    MessageBox.Show("Lỗi ở dòng " + line + " : Số lượng Tốt phải là số dương nhỏ hơn hoặc bằng " + stock.GoodQuantity);
                                    return;
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
                        if ((detail.DefectStatus.DefectStatusId == 4 && detail.ErrorQuantity == 0)
                            || (detail.DefectStatus.DefectStatusId == 6 && detail.DamageQuantity + detail.GoodQuantity + detail.ErrorQuantity == 0)
                            || (detail.DefectStatus.DefectStatusId == 7 && detail.GoodQuantity == 0))
                        {
                            MessageBox.Show("Lỗi ở dòng " + line + " : Số lượng xuất phải lớn hơn 0.");
                            return;
                        }
                        line++;
                    }

                    if (deptSO == null)
                    {
                        deptSO = new DepartmentStockOut();
                    }
                    bool isNeedClearData = deptSO.DepartmentStockOutPK == null || deptSO.DepartmentStockOutPK.StockOutId == 0;
                    deptSO.StockOutDate = dtpImportDate.Value;
                    deptSO.DefectStatus = (StockDefectStatus)cbbStockOutType.SelectedItem;
                    deptSO.OtherDepartmentId = ((Department) cboDepartment.SelectedItem).DepartmentId;
                    deptSO.DepartmentStockOutDetails = deptSODetailList;
                    //            deptSO.Description = txtDexcription.Text;
                    var ea = new DepartmentStockOutEventArgs();
                    ea.DepartmentStockOut = deptSO;
                    
                    ea.DepartmentStockList = departmentStockList;
                    EventUtility.fireEvent(SaveStockOutEvent, this, ea);
                    EventUtility.fireAsyncEvent(DispatchDepartmentStockOut,this,ea, new AsyncCallback(EndEvent));
                    if (eventArgs.EventResult != null)
                    {
                        //MessageBox.Show("Lưu thành công");
                        if (isNeedClearData)
                        {
                            deptSO = new DepartmentStockOut();
                            deptSODetailList.Clear();
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
            }
        }

        private void txtBarcode_Enter(object sender, EventArgs e)
        {
            txtBarcode.BackColor = Color.LightGreen;
        }

        private void txtBarcode_Leave(object sender, EventArgs e)
        {
            txtBarcode.BackColor = Color.FromKnownColor(KnownColor.Window);
        }

        private void rdoFastStockOut_Click(object sender, EventArgs e)
        {
            cbbStockOutType.Enabled = false;
            btnReset.Enabled = false;
        }

        private void rdoStockOut_CheckedChanged(object sender, EventArgs e)
        {
            cbbStockOutType.Enabled = false;
            btnReset.Enabled = false;
            if (!rdoStockOut.Checked)
            {
                cboProductMasters.Enabled = false;
            }
            else
            {
                cboProductMasters.Enabled = true;
            }
        }

        private void rdoFastStockOut_CheckedChanged(object sender, EventArgs e)
        {
            if(rdoFastStockOut.Checked)
            {
                cboProductMasters.Enabled = false;
            }
            else
            {
                cboProductMasters.Enabled = true;                
            }
        }
    }
}