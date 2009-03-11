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
using Fath;

namespace AppFrameClient.View.GoodsIO.DepartmentStockData
{
    public partial class DepartmentStockOutExtraForm : BaseForm, IDepartmentStockOutView
    {
        private const int QUANTITY_POS = 6;
        private const int PRICE_POS = 7;
        private const int SELL_PRICE_POS = 8;
        private DepartmentStockOutDetailCollection deptSIDetailList;
        private IList CurrentRowProductColorList { get; set; }
        private IList CurrentRowProductSizeList { get; set; }
        public DepartmentStockOut deptSI { get; set; }
        private IList productMasterList { get; set; }

        private IList DepartmentStockDefectList { get; set; }

        public DepartmentStockOutExtraForm()
        {
            InitializeComponent();
            DepartmentStockDefectList = new ArrayList();
            productMasterList = new ArrayList();
        }

        private void ctxMenuDept_Opening(object sender, CancelEventArgs e)
        {

        }

        private void nhToolStripMenuItem_Click(object sender, EventArgs e)
        {
//            StockOutDetail detail = deptSIDetailList[dgvDeptStockIn.CurrentCell.OwningRow.Index];
//            // deep copy in separeate memory space
//            StockInDetail newDetail = CreateNewStockInDetail();
//            var newPM = (ProductMaster)detail.Product.ProductMaster.Clone();
//            newDetail.Product.ProductMaster = newPM;
//            bdsStockIn.EndEdit();
        }

        private DepartmentStockOutDetail CreateNewStockInDetail()
        {
            var deptSIDet = deptSIDetailList.AddNew();
            deptSIDet.Product = new Product();
            deptSIDet.Product.ProductMaster = new ProductMaster();
            deptSIDet.Product.ProductMaster.ProductName = "";
            deptSIDet.Product.ProductMaster.ProductColor = new ProductColor { ColorName = "" };
            deptSIDet.Product.ProductMaster.ProductSize = new ProductSize { SizeName = "" };
            deptSIDetailList.EndNew(deptSIDetailList.Count - 1);
            return deptSIDet;
        }
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            // create DepartmentStockIn
            if (deptSI == null)
            {
                deptSI = new DepartmentStockOut();
            }
            deptSI.CreateDate = DateTime.Now;
            deptSI.UpdateDate = DateTime.Now;
            deptSI.CreateId = ClientInfo.getInstance().LoggedUser.Name;
            deptSI.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
            deptSI.ExclusiveKey = 0;
//            int maxAddedItemsCount = int.Parse(numericUpDown.Text);
//            for (int i = 0; i < maxAddedItemsCount; i++)
//            {
//                StockInDetail deptSIDet = CreateNewStockInDetail();
//
//            }

            deptSI.DepartmentStockOutDetails =
                ObjectConverter.ConvertToNonGenericList<DepartmentStockOutDetail>(deptSIDetailList);
            bdsStockIn.EndEdit();

//            for (int j = 0; j < maxAddedItemsCount; j++)
//            {
//                for (int i = 0; i <= SELL_PRICE_POS; i++)
//                {
//                    dgvDeptStockIn[i, deptSIDetailList.Count - j - 1].ReadOnly = false;
//                }
//            }
        }


        #region Load products to combo box for select
        private void dgvDeptStockIn_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
//            string columnName = dgvDeptStockIn.CurrentCell.OwningColumn.Name;
//            if (columnName.Equals("columnProductId")
//                || columnName.Equals("columnProductName"))
//            {
//
//
//                var comboBox = ((ComboBox)e.Control);
//
//                // firstly, remove event regard to cell 
//                comboBox.DropDown -= new EventHandler(comboBox_DropDown);
//                comboBox.KeyUp -= new KeyEventHandler(Control_KeyUp);
//
//                comboBox.DroppedDown = false;
//
//                comboBox.DataSource = null;
//                comboBox.Text = (string)dgvDeptStockIn.CurrentCell.Value;
//                comboBox.DropDown += new EventHandler(comboBox_DropDown);
//                comboBox.KeyUp += new KeyEventHandler(Control_KeyUp);
//            }
//
//            var mainStockInEventArgs = new DepartmentStockOutEventArgs();
//            if (dgvDeptStockIn == null || dgvDeptStockIn.CurrentRow == null)
//            {
//                return;
//            }
//            int selectedIndex = dgvDeptStockIn.CurrentRow.Index;
//            mainStockInEventArgs.SelectedIndex = selectedIndex;
//            mainStockInEventArgs.SelectedStockOutDetail = deptSIDetailList[selectedIndex];
//
//            if (columnName.Equals("columnColor"))
//            {
//                // put colors to list
//                EventUtility.fireEvent(LoadProductColorEvent, this, mainStockInEventArgs);
//                if (mainStockInEventArgs.ProductColorList != null && mainStockInEventArgs.ProductColorList.Count > 0)
//                {
//                    var comboBox = ((ComboBox)e.Control);
//                    comboBox.DataSource = mainStockInEventArgs.ProductColorList;
//                    CurrentRowProductColorList = mainStockInEventArgs.ProductColorList;
//                    comboBox.DisplayMember = "ColorName";
//                    comboBox.ValueMember = "ColorName";
//                }
//                else
//                {
//                    CurrentRowProductColorList = null;
//                }
//                mainStockInEventArgs.ProductColorList = null;
//            }
//
//
//            if (columnName.Equals("columnSize"))
//            {
//                // put size to list
//                EventUtility.fireEvent(LoadProductSizeEvent, this, mainStockInEventArgs);
//                if (mainStockInEventArgs.ProductSizeList != null && mainStockInEventArgs.ProductSizeList.Count > 0)
//                {
//                    var comboBox = ((ComboBox)e.Control);
//                    comboBox.DataSource = mainStockInEventArgs.ProductSizeList;
//                    CurrentRowProductSizeList = mainStockInEventArgs.ProductSizeList;
//                    comboBox.DisplayMember = "SizeName";
//                    comboBox.ValueMember = "SizeName";
//                }
//                else
//                {
//                    CurrentRowProductSizeList = null;
//                }
//                mainStockInEventArgs.ProductSizeList = null;
//            }

        }

        void Control_KeyUp(object sender, KeyEventArgs e)
        {
//            var comboBox = (ComboBox)sender;
//            int currentColumnIndex = dgvDeptStockIn.CurrentCell.OwningColumn.Index;
//            if (currentColumnIndex == 1 || currentColumnIndex == 2)
//            {
//                if (e.KeyCode == Keys.F3 || comboBox.DroppedDown)
//                {
//                    ((ComboBox)sender).DataSource = null;
//                    comboBox_DropDown(sender, null);
//                }
//            }
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
            var mainStockInEventArgs = new DepartmentStockOutEventArgs();
            if (dgvDeptStockIn == null || dgvDeptStockIn.CurrentRow == null)
            {
                return;
            }
            int selectedIndex = dgvDeptStockIn.CurrentRow.Index;
            mainStockInEventArgs.SelectedIndex = selectedIndex;
            mainStockInEventArgs.SelectedDepartmentStockOutDetail = deptSIDetailList[selectedIndex];
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
//            try
//            {
//                var mainStockInEventArgs = new DepartmentStockOutEventArgs();
//                if (dgvDeptStockIn == null || dgvDeptStockIn.CurrentRow == null)
//                {
//                    return;
//                }
//                int selectedIndex = dgvDeptStockIn.CurrentRow.Index;
//                mainStockInEventArgs.SelectedIndex = selectedIndex;
//                mainStockInEventArgs.SelectedStockOutDetail = deptSIDetailList[selectedIndex];
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
//                    deptSIDetailList[selectedIndex] = mainStockInEventArgs.SelectedStockInDetail;
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
//                    deptSIDetailList[selectedIndex] = mainStockInEventArgs.SelectedStockInDetail;
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
//                    deptSIDetailList[selectedIndex] = mainStockInEventArgs.SelectedStockInDetail;
//                    bdsStockIn.EndEdit();
//                }
//                if (deptSIDetailList[selectedIndex] != null)
//                {
//                    deptSIDetailList[selectedIndex].Quantity = qty;
//                    deptSIDetailList[selectedIndex].Price = inPrice;
//                    deptSIDetailList[selectedIndex].SellPrice = sellPrice;
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
//            long totalInPrice = 0;
//            long totalProduct = 0;
//            foreach (StockInDetail detail in deptSIDetailList)
//            {
//                if (detail.DelFlg == CommonConstants.DEL_FLG_NO)
//                {
//                    totalInPrice += detail.Price * detail.Quantity;
//                    totalProduct += detail.Quantity;
//                }
//            }
//            txtSumValue.Text = totalInPrice.ToString();
//            txtSumProduct.Text = totalProduct.ToString();
        }

        private void DepartmentStockInExtra_Load(object sender, EventArgs e)
        {
            IList list = new ArrayList();
            list.Add(new StockDefectStatus { DefectStatusId = 4, DefectStatusName = "Xuất tạm để sửa hàng"});
            list.Add(new StockDefectStatus { DefectStatusId = 6, DefectStatusName = "Xuất trả về kho chính" });
            list.Add(new StockDefectStatus { DefectStatusId = 7, DefectStatusName = "Xuất đi cửa hàng khác" });

            cbbStockOutType.DataSource = list;
            cbbStockOutType.DisplayMember = "DefectStatusName";

            deptSIDetailList = new DepartmentStockOutDetailCollection(bdsStockIn);
            bdsStockIn.DataSource = deptSIDetailList;
            dgvDeptStockIn.DataError += new DataGridViewDataErrorEventHandler(dgvDeptStockIn_DataError);
            
            // create DepartmentStockIn
            if (deptSI == null)
            {
                deptSI = new DepartmentStockOut();
                deptSI.CreateDate = DateTime.Now;
                deptSI.UpdateDate = DateTime.Now;
                deptSI.CreateId = ClientInfo.getInstance().LoggedUser.Name;
                deptSI.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                deptSI.ExclusiveKey = 0;
                CreateNewStockInDetail();
//                btnBarcode.Visible = false;
//                numericUpDownBarcode.Visible = false;
//                btnPreview.Visible = false;
                // load products to extra combo box
                LoadProductMasterToComboBox();
                deptSIDetailList.RemoveAt(0);
                bdsStockIn.EndEdit();

            }
            else
            {
//                btnBarcode.Visible = true;
//                numericUpDownBarcode.Visible = true;
//                btnPreview.Visible = true;
                IList deptStockInDetails = deptSI.DepartmentStockOutDetails;
                foreach (DepartmentStockOutDetail detail in deptStockInDetails)
                {
                    if (detail.DelFlg == CommonConstants.DEL_FLG_NO)
                    {
                        deptSIDetailList.Add(detail);
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
//                txtDexcription.Text = deptSI.Description;
            }
            deptSI.DepartmentStockOutDetails =
                    ObjectConverter.ConvertToNonGenericList<DepartmentStockOutDetail>(deptSIDetailList);
            
            
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

        #endregion



        private void mnuCreateNewItem_Click(object sender, EventArgs e)
        {
            btnAddProduct_Click(sender, null);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // first remove all blank row
            int count = 0;
            int length = deptSIDetailList.Count;
            for (int i = 0; i < length - count; i++)
            {
                DepartmentStockOutDetail detail = deptSIDetailList[i];
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
            int line = 1;
            foreach (DepartmentStockOutDetail detail in deptSIDetailList)
            {
                foreach (StockDefect defect in DepartmentStockDefectList)
                {
                    if (detail.Product.ProductId.Equals(defect.Product.ProductId))
                    {
                        if (detail.GoodQuantity < 0 || detail.GoodQuantity > defect.GoodCount)
                        {
                            MessageBox.Show("Lỗi ở dòng " + line + " : Số lượng Tốt phải là số dương nhỏ hơn hoặc bằng " + defect.GoodCount);
                            return;
                        }
                        if (detail.LostQuantity < 0 || detail.LostQuantity > defect.LostCount)
                        {
                            MessageBox.Show("Lỗi ở dòng " + line + " : Số lượng Mất phải là số dương nhỏ hơn hoặc bằng " + defect.LostCount);
                            return;
                        }
                        if (detail.DamageQuantity < 0 || detail.DamageQuantity > defect.DamageCount)
                        {
                            MessageBox.Show("Lỗi ở dòng " + line + " : Số lượng Lỗi phải là số dương nhỏ hơn hoặc bằng " + defect.DamageCount);
                            return;
                        }
                        if (detail.ErrorQuantity < 0 || detail.ErrorQuantity > defect.ErrorCount)
                        {
                            MessageBox.Show("Lỗi ở dòng " + line + " : Số lượng Hư phải là số dương nhỏ hơn hoặc bằng " + defect.ErrorCount);
                            return;
                        }
                    }
                }
                if ((detail.DefectStatus.DefectStatusId == 4 && detail.DamageQuantity == 0)
                    || (detail.DefectStatus.DefectStatusId == 6 && detail.DamageQuantity + detail.GoodQuantity + detail.ErrorQuantity == 0)
                    || (detail.DefectStatus.DefectStatusId == 7 && detail.GoodQuantity == 0)) 
                {
                    MessageBox.Show("Lỗi ở dòng " + line + " : Số lượng xuất phải lớn hơn 0.");
                    return;
                }
                line++;
            }

            if (deptSI == null)
            {
                deptSI = new DepartmentStockOut();
            }
            bool isNeedClearData = deptSI.DepartmentStockOutPK == null || deptSI.DepartmentStockOutPK.StockOutId == 0;
            deptSI.StockOutDate = dtpImportDate.Value;
            deptSI.DepartmentStockOutDetails = deptSIDetailList;
//            deptSI.Description = txtDexcription.Text;
            var eventArgs = new DepartmentStockOutEventArgs();
            eventArgs.DepartmentStockOut = deptSI;
            EventUtility.fireEvent(SaveStockOutEvent, this, eventArgs);
            if (eventArgs.EventResult != null)
            {
                MessageBox.Show("Lưu thành công");
                if (isNeedClearData)
                {
                    deptSI = new DepartmentStockOut();
                    deptSIDetailList.Clear();
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
            /*if (e.ColumnIndex == 0 && e.RowIndex >= 0 && e.RowIndex < deptSIDetailList.Count)
            {
                if (deptSI != null
                    && !string.IsNullOrEmpty(deptSI.StockInId)
                    && deptSIDetailList[e.RowIndex].StockInDetailPK != null
                    && !string.IsNullOrEmpty(deptSIDetailList[e.RowIndex].StockInDetailPK.StockInId))
                {
                    return;
                }
                var productMasterForm = GlobalUtility.GetFormObject<ProductMasterSearchOrCreateForm>(FormConstants.PRODUCT_MASTER_SEARCH_OR_CREATE_FORM);
                productMasterForm.ShowDialog();
                ProductMaster productMaster = productMasterForm.SelectedProductMaster;
                if (productMaster != null)
                {
                    deptSIDetailList[e.RowIndex].Product.ProductMaster = productMaster;
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
            if (selectedIndex < 0 || selectedIndex >= deptSIDetailList.Count)
            {
                return;
            }
            DepartmentStockOutDetail detail = deptSIDetailList[selectedIndex];
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
                    deptSIDetailList.RemoveAt(selectedIndex);
                }
            }
            CalculateTotalStorePrice();
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
            //mainStockInEventArgs.SelectedStockInDetail = deptSIDetailList[selectedIndex];
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
                foreach (DepartmentStockOutDetail detail in deptSIDetailList)
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
                if (eventArgs.DepartmentStockDefect != null)
                {
                    found = false;
                    foreach (StockDefect detail in DepartmentStockDefectList)
                    {
                        if (eventArgs.DepartmentStockDefect.Product.ProductId.Equals(detail.Product.ProductId))
                        {
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        DepartmentStockDefectList.Add(eventArgs.DepartmentStockDefect);
                    }
                }
                deptSIDetailList.Add(eventArgs.SelectedDepartmentStockOutDetail);
                deptSIDetailList.EndNew(deptSIDetailList.Count - 1);
                cbbStockOutType.Enabled = false;
                LockField(deptSIDetailList.Count - 1, eventArgs.SelectedDepartmentStockOutDetail);
            }
        }

        private void LockField(int rowIndex, DepartmentStockOutDetail stockOutDetail)
        {
            stockOutDetail.DefectStatus = cbbStockOutType.SelectedItem as StockDefectStatus;
            // Xuat tam de sua hang
            if (cbbStockOutType.SelectedIndex == 0)
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
            else if (cbbStockOutType.SelectedIndex == 1)
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
            else if (cbbStockOutType.SelectedIndex == 2)
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
                    }
                }
            }
        }

        private void PopulateGridByProductMaster(IList colorList, IList sizeList)
        {
//            var mainStockInEventArgs = new DepartmentStockOutEventArgs();
//            EventUtility.fireEvent<DepartmentStockInEventArgs>(LoadAllGoodsByNameEvent, this, mainStockInEventArgs);
//            IList list = mainStockInEventArgs.ProductMasterList;
//            if (dgvDeptStockIn.SelectedRows.Count <= 0)
//            {
//                dgvDeptStockIn.CurrentCell = dgvDeptStockIn[1, 0];
//            }
//            foreach (ProductMaster productMaster in list)
//            {
//                StockInDetail stockInDetail = deptSIDetailList.AddNew();
//                stockInDetail.StockInDetailPK = new StockInDetailPK();
//                if (stockInDetail.Product == null)
//                {
//                    stockInDetail.Product = new Product();
//                }
//                stockInDetail.Product.ProductMaster = productMaster;
//                deptSIDetailList.EndNew(deptSIDetailList.Count - 1);
//            }

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
                    foreach (DepartmentStockOutDetail detail1 in deptSIDetailList)
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
                    deptSIDetailList.Add(detail);
                    deptSIDetailList.EndNew(deptSIDetailList.Count - 1);
                    LockField(deptSIDetailList.Count - 1, detail);
                }
                foreach (DepartmentStockDefect def in eventArgs.DepartmentStockDefectList)
                {
                    bool found = false;
                    foreach (DepartmentStockDefect detail in DepartmentStockDefectList)
                    {
                        if (def.Product.ProductId.Equals(detail.Product.ProductId))
                        {
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        DepartmentStockDefectList.Add(def);
                    }
                }

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
            deptSI = new DepartmentStockOut();
            deptSIDetailList.Clear();
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
            deptSIDetailList.Clear();
        }
    }
}