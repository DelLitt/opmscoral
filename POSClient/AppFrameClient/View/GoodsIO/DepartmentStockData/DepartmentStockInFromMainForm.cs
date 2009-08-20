using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
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
    public partial class DepartmentStockInFromMainForm : BaseForm, IDepartmentStockInExtraView
    {
        private const int QUANTITY_POS = 4;
        private const int PRICE_POS = 5;
        private const int SELL_PRICE_POS = 6;
        private DepartmentStockInDetailCollection deptSIDetailList;
        private IList CurrentRowProductColorList { get; set; }
        private IList CurrentRowProductSizeList { get; set; }
        public DepartmentStockIn deptSI { get; set; }
        private IList productMasterList { get; set; }
        public DepartmentStockInFromMainForm()
        {
            InitializeComponent();
        }

        private void ctxMenuDept_Opening(object sender, CancelEventArgs e)
        {

        }

        private void nhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DepartmentStockInDetail detail = deptSIDetailList[dgvDeptStockIn.CurrentCell.OwningRow.Index];
            // deep copy in separeate memory space
            DepartmentStockInDetail newDetail = CreateNewStockInDetail();
            var newPM = (ProductMaster)detail.Product.ProductMaster.Clone();
            newDetail.Product.ProductMaster = newPM;
            bdsStockIn.EndEdit();
        }

        private DepartmentStockInDetail CreateNewStockInDetail()
        {
            var deptSIDet = deptSIDetailList.AddNew();
            deptSIDet.Product = new Product();
            deptSIDet.Product.ProductMaster = new ProductMaster();
            deptSIDet.Product.ProductMaster.ProductName = "";
            deptSIDet.Product.ProductMaster.ProductColor = new ProductColor { ColorName = "" };
            deptSIDet.Product.ProductMaster.ProductSize = new ProductSize { SizeName = "" };
            deptSIDet.DepartmentStockInDetailPK = new DepartmentStockInDetailPK();
            deptSIDetailList.EndNew(deptSIDetailList.Count - 1);
            return deptSIDet;
        }
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            // create DepartmentStockIn
            if (deptSI == null)
            {
                deptSI = new DepartmentStockIn();
            }
            deptSI.CreateDate = DateTime.Now;
            deptSI.UpdateDate = DateTime.Now;
            deptSI.CreateId = ClientInfo.getInstance().LoggedUser.Name;
            deptSI.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
            deptSI.ExclusiveKey = 0;
            int maxAddedItemsCount = int.Parse(numericUpDown.Text);
            for (int i = 0; i < maxAddedItemsCount; i++)
            {
                DepartmentStockInDetail deptSIDet = CreateNewStockInDetail();

            }

            deptSI.DepartmentStockInDetails =
                ObjectConverter.ConvertToNonGenericList<DepartmentStockInDetail>(deptSIDetailList);
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

            var departmentStockInEventArgs = new DepartmentStockInEventArgs();
            if (dgvDeptStockIn == null || dgvDeptStockIn.CurrentRow == null)
            {
                return;
            }
            int selectedIndex = dgvDeptStockIn.CurrentRow.Index;
            departmentStockInEventArgs.SelectedIndex = selectedIndex;
            departmentStockInEventArgs.SelectedDepartmentStockInDetail = deptSIDetailList[selectedIndex];

            if (columnName.Equals("columnColor"))
            {
                // put colors to list
                EventUtility.fireEvent(LoadProductColorEvent, this, departmentStockInEventArgs);
                if (departmentStockInEventArgs.ProductColorList != null && departmentStockInEventArgs.ProductColorList.Count > 0)
                {
                    var comboBox = ((ComboBox)e.Control);
                    comboBox.DataSource = departmentStockInEventArgs.ProductColorList;
                    CurrentRowProductColorList = departmentStockInEventArgs.ProductColorList;
                    comboBox.DisplayMember = "ColorName";
                    comboBox.ValueMember = "ColorName";
                }
                else
                {
                    CurrentRowProductColorList = null;
                }
                departmentStockInEventArgs.ProductColorList = null;
            }


            if (columnName.Equals("columnSize"))
            {
                // put size to list
                EventUtility.fireEvent(LoadProductSizeEvent, this, departmentStockInEventArgs);
                if (departmentStockInEventArgs.ProductSizeList != null && departmentStockInEventArgs.ProductSizeList.Count > 0)
                {
                    var comboBox = ((ComboBox)e.Control);
                    comboBox.DataSource = departmentStockInEventArgs.ProductSizeList;
                    CurrentRowProductSizeList = departmentStockInEventArgs.ProductSizeList;
                    comboBox.DisplayMember = "SizeName";
                    comboBox.ValueMember = "SizeName";
                }
                else
                {
                    CurrentRowProductSizeList = null;
                }
                departmentStockInEventArgs.ProductSizeList = null;
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
            var departmentStockInEventArgs = new DepartmentStockInEventArgs();
            if (dgvDeptStockIn == null || dgvDeptStockIn.CurrentRow == null)
            {
                return;
            }
            int selectedIndex = dgvDeptStockIn.CurrentRow.Index;
            departmentStockInEventArgs.SelectedIndex = selectedIndex;
            departmentStockInEventArgs.SelectedDepartmentStockInDetail = deptSIDetailList[selectedIndex];
            departmentStockInEventArgs.IsFillToComboBox = true;
            if (name.Equals("columnProductName"))
            {
                departmentStockInEventArgs.ComboBoxDisplayMember = "ProductName";
            }
            if (name.Equals("columnProductId"))
            {
                departmentStockInEventArgs.ComboBoxDisplayMember = "ProductMasterId";
            }
            EventUtility.fireEvent<DepartmentStockInEventArgs>(FillProductToComboEvent, sender, departmentStockInEventArgs);
        }

        #endregion

        private void dgvDeptStockIn_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            CalculateTotalStorePrice();
//            try
//            {
//                var departmentStockInEventArgs = new DepartmentStockInEventArgs();
//                if (dgvDeptStockIn == null || dgvDeptStockIn.CurrentRow == null)
//                {
//                    return;
//                }
//                int selectedIndex = dgvDeptStockIn.CurrentRow.Index;
//                departmentStockInEventArgs.SelectedIndex = selectedIndex;
//                departmentStockInEventArgs.SelectedDepartmentStockInDetail = deptSIDetailList[selectedIndex];
//
//                // bind the quantity, price and sellprice
//                long qty = NumberUtility.ParseLong(dgvDeptStockIn[QUANTITY_POS, selectedIndex].Value);
//                long inPrice = NumberUtility.ParseLong(dgvDeptStockIn[PRICE_POS, selectedIndex].Value);
//                long sellPrice = NumberUtility.ParseLong(dgvDeptStockIn[SELL_PRICE_POS, selectedIndex].Value);
//
//                if (e.ColumnIndex == 1 || e.ColumnIndex == 2)
//                {
//                    departmentStockInEventArgs.SelectedDepartmentStockInDetail.Product.ProductMaster.ProductMasterId =
//                        dgvDeptStockIn.CurrentCell.Value as string;
//                    if (e.ColumnIndex == 1)
//                    {
//                        EventUtility.fireEvent(LoadGoodsByIdEvent, this, departmentStockInEventArgs);
//                    }
//                    else
//                    {
//                        EventUtility.fireEvent(LoadGoodsByNameEvent, this, departmentStockInEventArgs);
//                    }
//
//                    // load goods to current row
//                    var loadGoods =
//                        departmentStockInEventArgs.SelectedDepartmentStockInDetail.Product.ProductMaster;
//                    deptSIDetailList[selectedIndex] = departmentStockInEventArgs.SelectedDepartmentStockInDetail;
//
//                    bdsStockIn.EndEdit();
//                    dgvDeptStockIn.Refresh();
//                    dgvDeptStockIn.Invalidate();
//
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
//                    departmentStockInEventArgs.SelectedDepartmentStockInDetail.Product.ProductMaster.ProductName = name;
//                    departmentStockInEventArgs.SelectedDepartmentStockInDetail.Product.ProductMaster.ProductColor = color;
//                    EventUtility.fireEvent(LoadGoodsByNameColorEvent, this, departmentStockInEventArgs);
//                    // load goods to current row
//                    var loadGoods =
//                        departmentStockInEventArgs.SelectedDepartmentStockInDetail.Product.ProductMaster;
//                    deptSIDetailList[selectedIndex] = departmentStockInEventArgs.SelectedDepartmentStockInDetail;
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
//                    departmentStockInEventArgs.SelectedDepartmentStockInDetail.Product.ProductMaster.ProductName = name;
//                    departmentStockInEventArgs.SelectedDepartmentStockInDetail.Product.ProductMaster.ProductSize = size;
//                    departmentStockInEventArgs.SelectedDepartmentStockInDetail.Product.ProductMaster.ProductColor = color;
//                    EventUtility.fireEvent(LoadGoodsByNameColorSizeEvent, this, departmentStockInEventArgs);
//                    // load goods to current row
//                    var loadGoods =
//                        departmentStockInEventArgs.SelectedDepartmentStockInDetail.Product.ProductMaster;
//                    deptSIDetailList[selectedIndex] = departmentStockInEventArgs.SelectedDepartmentStockInDetail;
//                    bdsStockIn.EndEdit();
//
//                }
//                if (deptSIDetailList[selectedIndex] != null)
//                {
//                    deptSIDetailList[selectedIndex].Quantity = qty;
//                    CalculateTotalStorePrice();
//                    //                    deptSIDetailList[selectedIndex].Price = inPrice;
//                    //                    deptSIDetailList[selectedIndex].OnStorePrice = sellPrice;
//                }
//                dgvDeptStockIn.Refresh();
//                dgvDeptStockIn.Invalidate();
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Mã sản phẩm không hợp lệ hoặc lỗi khi nhập");
//            }
        }

        private void DepartmentStockInExtra_Load(object sender, EventArgs e)
        {
            var eventArgs = new DepartmentStockInEventArgs();
            EventUtility.fireEvent(FillDepartmentEvent, this, eventArgs);

            IList departmentList = new ArrayList();
            departmentList.Add(new Department { DepartmentId = 0, DepartmentName = "--- Hãy chọn cửa hàng xuất ---" });
            foreach (Department department in eventArgs.DepartmentList)
            {
                departmentList.Add(department);
            }
            
            bdsDept.DataSource = departmentList;
            
            deptSIDetailList = new DepartmentStockInDetailCollection(bdsStockIn);
            bdsStockIn.DataSource = deptSIDetailList;
            dgvDeptStockIn.DataError += new DataGridViewDataErrorEventHandler(dgvDeptStockIn_DataError);

            deptSIDetailList = new DepartmentStockInDetailCollection(bdsStockIn);
            bdsStockIn.DataSource = deptSIDetailList;
            dgvDeptStockIn.DataError += new DataGridViewDataErrorEventHandler(dgvDeptStockIn_DataError);

            // create DepartmentStockIn
            if (deptSI == null)
            {
                deptSI = new DepartmentStockIn();
                deptSI.CreateDate = DateTime.Now;
                deptSI.UpdateDate = DateTime.Now;
                deptSI.CreateId = ClientInfo.getInstance().LoggedUser.Name;
                deptSI.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                deptSI.ExclusiveKey = 0;
                CreateNewStockInDetail();
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
                IList deptStockInDetails = deptSI.DepartmentStockInDetails;
                foreach (DepartmentStockInDetail detail in deptStockInDetails)
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
            deptSI.DepartmentStockInDetails =
                    ObjectConverter.ConvertToNonGenericList<DepartmentStockInDetail>(deptSIDetailList);
        }

        void dgvDeptStockIn_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        #region IDepartmentStockInView Members

        private DepartmentStockInExtraController departmentStockInController;
        public AppFrame.Presenter.GoodsIO.DepartmentGoodsIO.IDepartmentStockInController DepartmentStockInController
        {
            get
            {
                return departmentStockInController;
            }
            set
            {
                departmentStockInController = (DepartmentStockInExtraController)value;
                departmentStockInController.DepartmentStockInView = this;
                departmentStockInController.DepartmentStockInExtraView = this;
                departmentStockInController.CompletedFindByStockInEvent += new EventHandler<DepartmentStockInEventArgs>(departmentStockInController_CompletedFindByStockInEvent);
            }
        }

        void departmentStockInController_CompletedFindByStockInEvent(object sender, DepartmentStockInEventArgs e)
        {
            IList list = e.SelectedStockOutDetails;
            if (list != null && list.Count > 0)
            {
                foreach (DepartmentStockInDetail stockInDetail in list)
                {
                    if (!IsInList(deptSIDetailList, stockInDetail))
                    {
                        deptSIDetailList.Add(stockInDetail);
                    }
                }
            }
            this.Enabled = true;
            bdsStockIn.ResetBindings(false);
            dgvDeptStockIn.Refresh();
            dgvStockIn.Invalidate();
            panelStockIns.Visible = false;
            CalculateTotalStorePrice();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }


        private IProductMasterSearchOrCreateController productMasterSearchOrCreateController;
        public AppFrame.Presenter.GoodsIO.IProductMasterSearchOrCreateController ProductMasterSearchOrCreateController
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
        public event EventHandler<DepartmentStockInEventArgs> SyncDepartmentStockInEvent;
        public event EventHandler<DepartmentStockInEventArgs> FillProductToComboEvent;

        #endregion



        #region IDepartmentStockInView Members

        public event EventHandler<DepartmentStockInEventArgs> LoadGoodsByIdEvent;

        public event EventHandler<DepartmentStockInEventArgs> LoadGoodsByNameEvent;

        public event EventHandler<DepartmentStockInEventArgs> LoadProductColorEvent;

        public event EventHandler<DepartmentStockInEventArgs> LoadProductSizeEvent;
        public event EventHandler<DepartmentStockInEventArgs> FillDepartmentEvent;
        public event EventHandler<DepartmentStockInEventArgs> LoadGoodsByNameColorEvent;
        public event EventHandler<DepartmentStockInEventArgs> LoadGoodsByNameColorSizeEvent;
        public event EventHandler<DepartmentStockInEventArgs> LoadPriceAndStockEvent;
        public event EventHandler<DepartmentStockInEventArgs> LoadDepartmentStockInForExportEvent;
        public event EventHandler<DepartmentStockInEventArgs> UpdateDepartmentStockInForExportEvent;
        public event EventHandler<DepartmentStockInEventArgs> LoadMasterDataForExportEvent;
        public event EventHandler<DepartmentStockInEventArgs> SyncExportedMasterDataEvent;
        public event EventHandler<DepartmentStockInEventArgs> LoadStockInByProductMaster;
        public event EventHandler<DepartmentStockInEventArgs> SaveStockInEvent;

        #endregion

        private void mnuCreateNewItem_Click(object sender, EventArgs e)
        {
            btnAddProduct_Click(sender, null);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            string deptName = "";
            try
            {
                int index = cbbDept.SelectedIndex;
                if(index == 0 )
                {
                    MessageBox.Show("Bạn hãy chọn cửa hàng để xuất hàng", "Cảnh báo", MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }
                deptName = ((Department)bdsDept[index]).DepartmentName;
            }
            catch (Exception)
            {
                
            }
            DialogResult dResult = MessageBox.Show("Bạn muốn xuất hàng cho cửa hàng " + deptName + " ?", "Xác nhận",MessageBoxButtons.YesNo,MessageBoxIcon.Warning,MessageBoxDefaultButton.Button2);

            if(dResult != System.Windows.Forms.DialogResult.Yes)
            {
                return;
            }

            bool isNeedClearData = (deptSI == null || deptSI.DepartmentStockInPK == null || string.IsNullOrEmpty(deptSI.DepartmentStockInPK.StockInId));
            DepartmentStockIn result = SaveDeptStockIn(true);

            if (isNeedClearData && result != null)
            {
                if (!chkKeepInputInfo.Checked)
                {
                    deptSI = new DepartmentStockIn();
                    deptSIDetailList.Clear();
                    txtDexcription.Text = "";
                    txtSumProduct.Text = "";
                    txtSumValue.Text = "";
                    CreateNewStockInDetail();
                }
                else
                {
                    deptSI = new DepartmentStockIn();
                    RefrefshDeptSIDetailList();
                    txtDexcription.Text = "";
                    txtSumProduct.Text = "";
                    txtSumValue.Text = "";
                }
            }
        }

        private void RefrefshDeptSIDetailList()
        {
            foreach (DepartmentStockInDetail inDetail in deptSIDetailList)
            {
                inDetail.DepartmentStockIn = null;
                inDetail.DepartmentStockInDetailPK = new DepartmentStockInDetailPK
                                                     {
                                                         DepartmentId = ((Department)cbbDept.SelectedItem).DepartmentId,
                                                         ProductId = inDetail.Product.ProductId
                                                     };
            }
        }

        private void dgvDeptStockIn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
//            if (e.ColumnIndex == 0 && e.RowIndex >= 0 && e.RowIndex < deptSIDetailList.Count)
//            {
//                if (deptSO != null
//                    && deptSO.DepartmentStockInPK != null
//                    && !string.IsNullOrEmpty(deptSO.DepartmentStockInPK.StockInId)
//                    && deptSIDetailList[e.RowIndex].DepartmentStockInDetailPK != null
//                    && !string.IsNullOrEmpty(deptSIDetailList[e.RowIndex].DepartmentStockInDetailPK.StockInId))
//                {
//                    return;
//                }
//                var productMasterForm = GlobalUtility.GetFormObject<ProductMasterSearchOrCreateForm>(FormConstants.PRODUCT_MASTER_SEARCH_OR_CREATE_FORM);
//                productMasterForm.ShowDialog();
//                ProductMaster productMaster = productMasterForm.SelectedProductMaster;
//                if (productMaster != null)
//                {
//                    deptSIDetailList[e.RowIndex].Product.ProductMaster = productMaster;
//                    bdsStockIn.EndEdit();
//                    dgvDeptStockIn.Refresh();
//                    dgvDeptStockIn.Invalidate();
//                }
//            }
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
            DepartmentStockInDetail detail = deptSIDetailList[selectedIndex];
            if (MessageBox.Show("Bạn có muốn xóa không?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (detail.DepartmentStockInDetailPK != null && !string.IsNullOrEmpty(deptSIDetailList[selectedIndex].DepartmentStockInDetailPK.StockInId))
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

        private DepartmentStockIn SaveDeptStockIn(bool isNeedSync)
        {
            // check for department
            var dept = cbbDept.SelectedItem as Department;
            if (dept == null)
            {
                MessageBox.Show("Không có cửa hàng nào để xuất hàng");
                return null;
            }

            // first remove all blank row
            int count = 0;
            int length = deptSIDetailList.Count;
            for (int i = 0; i < length - count; i++)
            {
                DepartmentStockInDetail detail = deptSIDetailList[i];
                if (string.IsNullOrEmpty(detail.Product.ProductMaster.ProductMasterId)
                    && string.IsNullOrEmpty(detail.Product.ProductMaster.ProductName))
                {
                    deptSIDetailList.RemoveAt(i - count);
                    count++;
                }
            }

            if (deptSIDetailList.Count == 0)
            {
                MessageBox.Show("Không có sản phẩm nào để xuất!!!!");
                return null;
            }

            // validate quantity
            StringBuilder errMsg = new StringBuilder();
            int line = 1;
            if(chkRemoveZero.Checked)
            {
                RemoveZeroLines();
            }
            foreach (DepartmentStockInDetail detail in deptSIDetailList)
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
                return null;
            }
            line = 0;
            foreach (DepartmentStockInDetail detail in deptSIDetailList)
            {
                count = 0;
                foreach (DepartmentStockInDetail detail2 in deptSIDetailList)
                {
                    if (detail.DelFlg == CommonConstants.DEL_FLG_NO 
                        && detail.Product.ProductId.Equals(detail2.Product.ProductId))
                    {
                        if (count == 0)
                        {
                            count++;
                        }
                        else
                        {
                            MessageBox.Show("Lỗi : Mã vạch " + detail.Product.ProductId + " nhập 2 lần");
                            dgvDeptStockIn.CurrentCell = dgvDeptStockIn[3, line];
                            return null;
                        }
                    }
                    line++;
                }
            }

            if (deptSI == null)
            {
                deptSI = new DepartmentStockIn();
            }

            deptSI.StockInDate = dtpImportDate.Value;
            deptSI.DepartmentId = dept.DepartmentId;
            deptSI.Description = txtDexcription.Text;
            deptSI.DepartmentStockInDetails = deptSIDetailList;
            
            var eventArgs = new DepartmentStockInEventArgs();
            eventArgs.IsForSync = isNeedSync;
            eventArgs.DepartmentStockIn = deptSI;
            eventArgs.ExportGoodsToDepartment = true;
            EventUtility.fireEvent(SaveDepartmentStockInEvent, this, eventArgs);
            if (eventArgs.EventResult != null)
            {
                MessageBox.Show("Lưu thành công");
                txtDexcription.Text = "";
                txtQuantity.Text = "";
                txtSumValue.Text = "";
                txtSumProduct.Text = "";
                ClearSelectionOnListBox(lstColor);
                ClearSelectionOnListBox(lstSize);
                return eventArgs.DepartmentStockIn;
            }
            else
            {
                return null;
            }
        }

        private void RemoveZeroLines()
        {
            int index = deptSIDetailList.Count - 1;
            while(index >= 0)
            {
                DepartmentStockInDetail detail = deptSIDetailList[index];
                if(detail.StockQuantity == 0 || detail.Quantity == 0)
                {
                    deptSIDetailList.RemoveAt(index);
                }
                index -= 1;
            }

        }

        private void ClearSelectionOnListBox(ListBox color)
        {
            foreach (int item in color.SelectedIndices)
            {
                color.SetSelected(item, false);
            }
        }

        private void CalculateTotalStorePrice()
        {
            long totalInPrice = 0;
            long totalProduct = 0;
            foreach (DepartmentStockInDetail detail in deptSIDetailList)
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

        private void btnSaveAndExport_Click(object sender, EventArgs e)
        {
            
        }

        private void LoadProductMasterToComboBox()
        {
            var deptStockInEventArgs = new DepartmentStockInEventArgs();
            /*if (dgvDeptStockIn == null || dgvDeptStockIn.CurrentRow == null)
            {
                return;
            }*/
            // selectectIndex is the firstrow
            //int selectedIndex = 0;
            //mainStockInEventArgs.SelectedIndex = selectedIndex;
            //mainStockInEventArgs.SelectedStockInDetail = deptSIDetailList[selectedIndex];
            deptStockInEventArgs.SelectedDepartmentStockInDetail = new DepartmentStockInDetail { Product = new Product { ProductMaster = new ProductMaster { ProductName = "" } } };
            deptStockInEventArgs.IsFillToComboBox = true;
            deptStockInEventArgs.ComboBoxDisplayMember = "ProductName";
            EventUtility.fireEvent<DepartmentStockInEventArgs>(FillProductToComboEvent, cboProductMasters, deptStockInEventArgs);

        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            if (cboProductMasters.SelectedIndex < 0)
            {
                MessageBox.Show("Hãy chọn 1 sản phẩm để nhập kho");
                return;
            }
            if (lstColor.SelectedIndices == null || lstColor.SelectedIndices.Count <= 0)
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
            if (!NumberUtility.CheckLongNullIsZero(txtQuantity.Text, out outValue)
                || outValue < 0)
            {
                MessageBox.Show("Số lượng phải là số dương");
                return;
            }
            PopulateGridByProductMaster(lstColor.SelectedItems, lstSize.SelectedItems);
            CalculateTotalStorePrice();
        }

        private void PopulateGridByProductMaster(IList colorList, IList sizeList)
        {
            //            var mainStockInEventArgs = new MainStockInEventArgs();
            //
            //            mainStockInEventArgs.SelectedProductMaster = master;
            //            EventUtility.fireEvent<MainStockInEventArgs>(LoadAllGoodsByNameEvent, this, mainStockInEventArgs);
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
            var eventArgs = new DepartmentStockInEventArgs();
            eventArgs.DepartmentStockInDetailList = new ArrayList();
            IList selectedProductMasterList = new ArrayList();
            foreach (ProductColor color in colorList)
            {
                foreach (ProductSize size in sizeList)
                {
                    foreach (ProductMaster productMaster in productMasterList)
                    {

                        // do not allow duplicate
                        bool goOut = false;
                        foreach (DepartmentStockInDetail detail in deptSIDetailList)
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
                            selectedProductMasterList.Add(productMaster);
                            #region unused code
                            /*DepartmentStockInDetail stockInDetail = deptSIDetailList.AddNew();
                            stockInDetail.Quantity = NumberUtility.ParseLong(txtQuantity.Text);
                            //stockInDetail.SellPrice = NumberUtility.ParseLong(txtPriceOut.Text);
                            stockInDetail.DepartmentStockInDetailPK = new DepartmentStockInDetailPK();
                            if (stockInDetail.Product == null)
                            {
                                stockInDetail.Product = new Product();
                            }
                            stockInDetail.Product.ProductMaster = productMaster;
                            eventArgs.DepartmentStockInDetailList.Add(stockInDetail);
                            deptSIDetailList.EndNew(deptSIDetailList.Count - 1);*/
                            #endregion
                        }
                    }
                }
            }
            
            eventArgs.ProductMasterList = selectedProductMasterList;
            EventUtility.fireEvent(LoadStockInByProductMaster, this, eventArgs);

            /*if (eventArgs.DepartmentStockInDetailList.Count > 0)
            {
                EventUtility.fireEvent(LoadPriceAndStockEvent, this, eventArgs);
            }*/

            // remove 0 quanity
            int count = 0;
            int length = deptSIDetailList.Count;
            bool isMessage = false;
            for (int i = 0; i < length; i++)
            {
                if (deptSIDetailList[i - count].StockQuantity == 0)
                {
                    //isMessage = true;
                    deptSIDetailList.RemoveAt(i - count);
                    count++;
                }
            }
            if(eventArgs.SelectedStockOutDetails!=null && eventArgs.SelectedStockOutDetails.Count > 0 )
            {
                foreach (DepartmentStockInDetail inDetail in eventArgs.SelectedStockOutDetails)
                {
                    deptSIDetailList.Add(inDetail);
                }
                bdsStockIn.ResetBindings(false);
                dgvStockIn.Refresh();
                dgvStockIn.Invalidate();
            }
            /*if (isMessage)
            {
                MessageBox.Show("Sản phẩm có tồn kho 0 sẽ không đựoc xuất");
            }*/
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

            var mainStockInEventArgs = new DepartmentStockInEventArgs();
            mainStockInEventArgs.SelectedDepartmentStockInDetail = new DepartmentStockInDetail();
            mainStockInEventArgs.SelectedDepartmentStockInDetail.Product = new Product { ProductMaster = new ProductMaster() };
            mainStockInEventArgs.SelectedDepartmentStockInDetail.Product.ProductMaster.ProductName = productName;
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

        #region IDepartmentStockInView Members


        public event EventHandler<DepartmentStockInEventArgs> FindByBarcodeEvent;

        #endregion

        #region IDepartmentStockInView Members


        public event EventHandler<DepartmentStockInEventArgs> SaveReDepartmentStockInEvent;
        public event EventHandler<DepartmentStockInEventArgs> LoadAllDepartments;
        public event EventHandler<DepartmentStockInEventArgs> FindBarcodeEvent;
        public event EventHandler<DepartmentStockInEventArgs> SaveStockInBackEvent;
        public event EventHandler<DepartmentStockInEventArgs> DispatchDepartmentStockIn;
        public event EventHandler<DepartmentStockInEventArgs> FindByStockInIdEvent;

        #endregion

        private void cboProductMasters_DropDown(object sender, EventArgs e)
        {
            var deptStockInEventArgs = new DepartmentStockInEventArgs();
            /*if (dgvDeptStockIn == null || dgvDeptStockIn.CurrentRow == null)
            {
                return;
            }*/
            // selectectIndex is the firstrow
            //int selectedIndex = 0;
            //mainStockInEventArgs.SelectedIndex = selectedIndex;
            //mainStockInEventArgs.SelectedStockInDetail = deptSIDetailList[selectedIndex];
            deptStockInEventArgs.SelectedDepartmentStockInDetail = new DepartmentStockInDetail { Product = new Product { ProductMaster = new ProductMaster { ProductName = cboProductMasters.Text } } };
            deptStockInEventArgs.IsFillToComboBox = true;
            deptStockInEventArgs.ComboBoxDisplayMember = "ProductName";
            EventUtility.fireEvent<DepartmentStockInEventArgs>(FillProductToComboEvent, cboProductMasters, deptStockInEventArgs);
        }

        private void systemHotkey1_Pressed(object sender, EventArgs e)
        {
            if (dgvDeptStockIn.Focused && dgvDeptStockIn.CurrentCell != null)
            {
                Clipboard.SetText(dgvDeptStockIn.CurrentCell.Value.ToString());
                
            }
            
        }

        private void systemHotkey2_Pressed(object sender, EventArgs e)
        {
            if (dgvDeptStockIn.Focused)
            {
                DataGridViewSelectedCellCollection collection = dgvDeptStockIn.SelectedCells;
                foreach (DataGridViewCell cell in collection)
                {
                    cell.Value = Clipboard.GetText();
                }
            }
        }

        private void dgvStockIn_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSearchStockIn_Click(object sender, EventArgs e)
        {
            DateTime fromDate = DateUtility.ZeroTime(dtpFrom.Value);
            DateTime toDate = DateUtility.MaxTime(dtpTo.Value);
            this.stock_inTableAdapter.Fill(masterDB.stock_in, fromDate, toDate);
            bdsStockIn.ResetBindings(false);
            dgvStockIn.Refresh();
            dgvStockIn.Invalidate();
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection collection = dgvStockIn.SelectedRows;
            if(collection.Count > 0 )
            {
                IList stockInIds = new ArrayList();
                foreach (DataGridViewRow selectedRowCollection in collection)
                {
                    string stockInId = selectedRowCollection.Cells[0].Value.ToString();
                    stockInIds.Add(stockInId);
                }
                
                DepartmentStockInEventArgs ea = new DepartmentStockInEventArgs();
                ea.SelectedStockInIds = stockInIds;
                
                EventUtility.fireAsyncEvent(FindByStockInIdEvent,this,ea,new AsyncCallback(EndEvent));
                this.Enabled = false;
                //EventUtility.fireEvent(FindByStockInIdEvent,this,ea);
            }
            //stockinBindingSource.Clear();
        }

        private bool IsInList(DepartmentStockInDetailCollection collection, DepartmentStockInDetail detail)
        {
            foreach (DepartmentStockInDetail inDetail in collection)
            {
                if(detail.Product.ProductId.Equals(inDetail.Product.ProductId))
                {
                    return true;
                }
            }
            return false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panelStockIns.Visible = true;
            stock_inTableAdapter.Fill(masterDB.stock_in, DateTime.MinValue, DateTime.MinValue);
            //stockinBindingSource.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panelStockIns.Visible = false;
            //stockinBindingSource.Clear();
        }

        private void btnFix_Click(object sender, EventArgs e)
        {
            foreach (DepartmentStockInDetail inDetail in deptSIDetailList)
            {
                if(inDetail.StockQuantity < inDetail.Quantity)
                {
                    inDetail.Quantity = inDetail.StockQuantity;
                }
            }
            bdsStockIn.ResetBindings(false);
            dgvDeptStockIn.Refresh();
            dgvStockIn.Invalidate();
            MessageBox.Show("Sửa thành công !");
        }

        private void panelStockIns_Paint(object sender, PaintEventArgs e)
        {

        }

        private void chkRemoveZero_CheckedChanged(object sender, EventArgs e)
        {
            if(chkRemoveZero.Checked)
            {
                RemoveZeroLines();
                CalculateTotalStorePrice();
                MessageBox.Show("Hoàn tất bỏ những dòng bằng không");
                chkRemoveZero.Checked = false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form form = GlobalUtility.GetFormObject(FormConstants.STOCK_OUT_DIALOG);
            form.ShowDialog();
        }
    }
}