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
        private const int QUANTITY_POS = 5;
        private const int PRICE_POS = 6;
        private const int SELL_PRICE_POS = 7;
        private DepartmentStockInDetailCollection deptSIDetailList;
        private IList CurrentRowProductColorList { get; set; }
        private IList CurrentRowProductSizeList { get; set; }
        public DepartmentStockIn deptSI { get; set; }
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
            try
            {
                var departmentStockInEventArgs = new DepartmentStockInEventArgs();
                if (dgvDeptStockIn == null || dgvDeptStockIn.CurrentRow == null)
                {
                    return;
                }
                int selectedIndex = dgvDeptStockIn.CurrentRow.Index;
                departmentStockInEventArgs.SelectedIndex = selectedIndex;
                departmentStockInEventArgs.SelectedDepartmentStockInDetail = deptSIDetailList[selectedIndex];

                // bind the quantity, price and sellprice
                long qty = NumberUtility.ParseLong(dgvDeptStockIn[QUANTITY_POS, selectedIndex].Value);
                long inPrice = NumberUtility.ParseLong(dgvDeptStockIn[PRICE_POS, selectedIndex].Value);
                long sellPrice = NumberUtility.ParseLong(dgvDeptStockIn[SELL_PRICE_POS, selectedIndex].Value);

                if (e.ColumnIndex == 1 || e.ColumnIndex == 2)
                {
                    departmentStockInEventArgs.SelectedDepartmentStockInDetail.Product.ProductMaster.ProductMasterId =
                        dgvDeptStockIn.CurrentCell.Value as string;
                    if (e.ColumnIndex == 1)
                    {
                        EventUtility.fireEvent(LoadGoodsByIdEvent, this, departmentStockInEventArgs);
                    }
                    else
                    {
                        EventUtility.fireEvent(LoadGoodsByNameEvent, this, departmentStockInEventArgs);
                    }

                    // load goods to current row
                    var loadGoods =
                        departmentStockInEventArgs.SelectedDepartmentStockInDetail.Product.ProductMaster;
                    deptSIDetailList[selectedIndex] = departmentStockInEventArgs.SelectedDepartmentStockInDetail;

                    bdsStockIn.EndEdit();
                    dgvDeptStockIn.Refresh();
                    dgvDeptStockIn.Invalidate();


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

                    departmentStockInEventArgs.SelectedDepartmentStockInDetail.Product.ProductMaster.ProductName = name;
                    departmentStockInEventArgs.SelectedDepartmentStockInDetail.Product.ProductMaster.ProductColor = color;
                    EventUtility.fireEvent(LoadGoodsByNameColorEvent, this, departmentStockInEventArgs);
                    // load goods to current row
                    var loadGoods =
                        departmentStockInEventArgs.SelectedDepartmentStockInDetail.Product.ProductMaster;
                    deptSIDetailList[selectedIndex] = departmentStockInEventArgs.SelectedDepartmentStockInDetail;
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

                    departmentStockInEventArgs.SelectedDepartmentStockInDetail.Product.ProductMaster.ProductName = name;
                    departmentStockInEventArgs.SelectedDepartmentStockInDetail.Product.ProductMaster.ProductSize = size;
                    departmentStockInEventArgs.SelectedDepartmentStockInDetail.Product.ProductMaster.ProductColor = color;
                    EventUtility.fireEvent(LoadGoodsByNameColorSizeEvent, this, departmentStockInEventArgs);
                    // load goods to current row
                    var loadGoods =
                        departmentStockInEventArgs.SelectedDepartmentStockInDetail.Product.ProductMaster;
                    deptSIDetailList[selectedIndex] = departmentStockInEventArgs.SelectedDepartmentStockInDetail;
                    bdsStockIn.EndEdit();

                }
                if (deptSIDetailList[selectedIndex] != null)
                {
                    deptSIDetailList[selectedIndex].Quantity = qty;
                    CalculateTotalStorePrice();
                    //                    deptSIDetailList[selectedIndex].Price = inPrice;
                    //                    deptSIDetailList[selectedIndex].OnStorePrice = sellPrice;
                }
                dgvDeptStockIn.Refresh();
                dgvDeptStockIn.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mã sản phẩm không hợp lệ hoặc lỗi khi nhập");
            }
        }

        private void DepartmentStockInExtra_Load(object sender, EventArgs e)
        {
            var eventArgs = new DepartmentStockInEventArgs();
            EventUtility.fireEvent(FillDepartmentEvent, this, eventArgs);
            bdsDept.DataSource = eventArgs.DepartmentList;
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
            }
            else
            {
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
            }
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
        public event EventHandler<DepartmentStockInEventArgs> SaveStockInEvent;

        #endregion

        private void mnuCreateNewItem_Click(object sender, EventArgs e)
        {
            btnAddProduct_Click(sender, null);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool isNeedClearData = (deptSI == null || deptSI.DepartmentStockInPK == null || string.IsNullOrEmpty(deptSI.DepartmentStockInPK.StockInId));
            DepartmentStockIn result = SaveDeptStockIn(false);

            if (isNeedClearData && result != null)
            {
                deptSI = new DepartmentStockIn();
                deptSIDetailList.Clear();
                txtDexcription.Text = "";
                txtSumProduct.Text = "";
                txtSumValue.Text = "";
                CreateNewStockInDetail();
            }
        }

        private void dgvDeptStockIn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0 && e.RowIndex < deptSIDetailList.Count)
            {
                if (deptSI != null
                    && deptSI.DepartmentStockInPK != null
                    && !string.IsNullOrEmpty(deptSI.DepartmentStockInPK.StockInId)
                    && deptSIDetailList[e.RowIndex].DepartmentStockInDetailPK != null
                    && !string.IsNullOrEmpty(deptSIDetailList[e.RowIndex].DepartmentStockInDetailPK.StockInId))
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
                }
            }
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
            foreach (DepartmentStockInDetail detail in deptSIDetailList)
            {
                count = 0;
                foreach (DepartmentStockInDetail detail2 in deptSIDetailList)
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
                            return null;
                        }
                    }

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
            eventArgs.DepartmeneStockIn = deptSI;
            EventUtility.fireEvent(SaveDepartmentStockInEvent, this, eventArgs);
            if (eventArgs.EventResult != null)
            {
                MessageBox.Show("Lưu thành công");
                return eventArgs.DepartmeneStockIn;
            }
            else
            {
                return null;
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
            // Create new SaveFileDialog object
            SaveFileDialog DialogSave = new SaveFileDialog();

            // Default file extension
            DialogSave.DefaultExt = "xac";

            // Available file extensions
            DialogSave.Filter = "POS file (*.xac)|*.xac";

            // Adds a extension if the user does not
            DialogSave.AddExtension = true;

            // Restores the selected directory, next time
            DialogSave.RestoreDirectory = true;

            // Startup directory
            DialogSave.InitialDirectory = @"C:/";
            bool isNeedClearData = (deptSI == null || deptSI.DepartmentStockInPK == null || string.IsNullOrEmpty(deptSI.DepartmentStockInPK.StockInId));
            // Show the dialog and process the result
            if (DialogSave.ShowDialog() == DialogResult.OK)
            {
                DepartmentStockIn dept = SaveDeptStockIn(true);

                if (dept != null)
                {
                    IList list = new ArrayList();
                    foreach (DepartmentStockInDetail detail in dept.DepartmentStockInDetails)
                    {
                        list.Add(detail);
                        AppFrame.Model.Product p = detail.Product;
                    }
                    dept.DepartmentStockInDetails = list;
                    Stream stream = File.Open(DialogSave.FileName, FileMode.Create);
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(stream, dept);
                    stream.Close();

                    if (isNeedClearData)
                    {
                        deptSI = new DepartmentStockIn();
                        deptSIDetailList.Clear();
                        CreateNewStockInDetail();
                    }
                }
            }
        }
    }
}