using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
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
    public partial class DepartmentFastStockInForm : BaseForm, IDepartmentStockInView
    {
        private const int QUANTITY_POS = 6;
        private const int PRICE_POS = 7;
        private const int SELL_PRICE_POS = 8;
        private DepartmentStockInDetailCollection deptSODetailList;
        private IList CurrentRowProductColorList { get; set; }
        private IList CurrentRowProductSizeList { get; set; }
        public DepartmentStockIn deptSO { get; set; }
        private IList productMasterList { get; set; }

        private IList departmentStockList { get; set; }

        public DepartmentFastStockInForm()
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

        private DepartmentStockInDetail CreateNewStockInDetail()
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
                deptSO = new DepartmentStockIn();
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

            deptSO.DepartmentStockInDetails =
                ObjectConverter.ConvertToNonGenericList<DepartmentStockInDetail>(deptSODetailList);
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
            var mainStockInEventArgs = new DepartmentStockInEventArgs();
            if (dgvDeptStockIn == null || dgvDeptStockIn.CurrentRow == null)
            {
                return;
            }
            int selectedIndex = dgvDeptStockIn.CurrentRow.Index;
            mainStockInEventArgs.SelectedIndex = selectedIndex;
            mainStockInEventArgs.SelectedDepartmentStockInDetail = deptSODetailList[selectedIndex];
            mainStockInEventArgs.IsFillToComboBox = true;
            if (name.Equals("columnProductName"))
            {
                mainStockInEventArgs.ComboBoxDisplayMember = "ProductName";
            }
            if (name.Equals("columnProductId"))
            {
                mainStockInEventArgs.ComboBoxDisplayMember = "ProductMasterId";
            }
            //EventUtility.fireEvent<DepartmentStockOutEventArgs>(FillProductToComboEvent, sender, mainStockInEventArgs);
        }

        #endregion

        private void dgvDeptStockIn_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            CalculateTotalStorePrice();

        }

        private void CalculateTotalStorePrice()
        {
            long totalInPrice = 0;
            long totalProduct = 0;
            foreach (DepartmentStockInDetail detail in deptSODetailList)
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
            rdoFastStockIn.Checked = true;
            rdoStockIn.Checked = false;
            DepartmentStockInEventArgs eventArgs = new DepartmentStockInEventArgs();
            EventUtility.fireEvent(LoadAllDepartments,this,eventArgs);
            if(eventArgs.DepartmentsList!= null && eventArgs.DepartmentsList.Count > 0)
            {
                BindingSource bdsDepartment = new BindingSource();
                bdsDepartment.DataSource = typeof (Department);
                cboDepartment.DataSource = bdsDepartment;
                cboDepartment.DisplayMember = "DepartmentName";
                foreach (Department department in eventArgs.DepartmentsList)
                {
                    /*if (department.DepartmentId != CurrentDepartment.Get().DepartmentId)
                    {
                        string deptId = department.DepartmentId.ToString();
                        string currId = CurrentDepartment.Get().DepartmentId.ToString();
                        if(currId.StartsWith(deptId))
                        {*/
                            bdsDepartment.Add(department);    
                        /*}
                    }
                    if (ClientSetting.MarketDept.Equals(department.DepartmentId.ToString()))
                    {
                        bdsDepartment.Add(department);
                    }*/
                }
                bdsDepartment.EndEdit();
                cboDepartment.Refresh();
                cboDepartment.Invalidate();
            }

            /*foreach (Department department in cboDepartment.Items)
            {
                string departmentId = department.DepartmentId.ToString();
                string currentSubStock = CurrentDepartment.Get().DepartmentId.ToString();
                if (currentSubStock.StartsWith(departmentId))
                {
                    cboDepartment.SelectedItem = department;
                    cboDepartment.Enabled = false;
                    break;
                }
            }*/
            rdoFastStockIn_CheckedChanged(null, null);
            rdoStockIn_CheckedChanged(null, null);
            deptSODetailList = new DepartmentStockInDetailCollection(bdsStockIn);
            bdsStockIn.DataSource = deptSODetailList;
            dgvDeptStockIn.DataError += new DataGridViewDataErrorEventHandler(dgvDeptStockIn_DataError);
            UpdateStockOutDescription();
            GlobalMessage message = (GlobalMessage)GlobalUtility.GetObject("GlobalMessage");
            message.HasNewMessageEvent += new EventHandler<GlobalMessageEventArgs>(Instance_HasNewMessageEvent);
        }

        void Instance_HasNewMessageEvent(object sender, GlobalMessageEventArgs e)
        {
            if (!e.Channel.Equals(ChannelConstants.DEPT2SUBSTOCK_STOCKOUT))
            {
                return;
            }
            UpdateStatus(e);
        }
        protected delegate void UpdateStatusDelegate(GlobalMessageEventArgs e);
        protected void UpdateStatus(GlobalMessageEventArgs e)
        {
            if (this.InvokeRequired)
            {
                UpdateStatusDelegate dlg = new
                    UpdateStatusDelegate(this.UpdateStatus);
                this.Invoke(dlg, new object[] { e });
                return;
            }

            //do something with the GUI control here
            if (e.IsError)
            {
                ShowError(lblMessage, e.Message);
            }
            else
            {
                ShowMessage(lblMessage, e.Message);
            }
        }
       

        void dgvDeptStockIn_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        #region IDepartmentStockInView Members

        private IDepartmentStockInController mainStockInController;
        public IDepartmentStockInController DepartmentStockInController
        {
            get
            {
                return mainStockInController;
            }
            set
            {
                mainStockInController = value;
                mainStockInController.DepartmentStockInView = this;
            }
        }

        private IProductMasterSearchOrCreateController productMasterSearchOrCreateController;
        public IProductMasterSearchOrCreateController ProductMasterSearchOrCreateController
        {
            set
            {
                productMasterSearchOrCreateController = value; 
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        

        public event EventHandler<DepartmentStockInEventArgs> InitDepartmentStockInEvent;

        public event EventHandler<AppFrame.Presenter.GoodsIO.ProductMasterSearchOrCreateEventArgs> OpenProductMasterSearchEvent;

        public event EventHandler<DepartmentStockInEventArgs> SaveDepartmentStockInEvent;

        public event EventHandler<DepartmentStockInEventArgs> FindProductMasterEvent;
        public event EventHandler<DepartmentStockInEventArgs> SyncDepartmentStockInEvent;
        public event EventHandler<DepartmentStockInEventArgs> FindByBarcodeEvent;
        public event EventHandler<DepartmentStockInEventArgs> SaveReDepartmentStockInEvent;
        public event EventHandler<DepartmentStockInEventArgs> LoadAllDepartments;
        public event EventHandler<DepartmentStockInEventArgs> FindBarcodeEvent;
        public event EventHandler<DepartmentStockInEventArgs> SaveStockInBackEvent;
        public event EventHandler<DepartmentStockInEventArgs> DispatchDepartmentStockIn;
        public event EventHandler<DepartmentStockInEventArgs> FindByStockInIdEvent;

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
                DepartmentStockInDetail detail = deptSODetailList[i];
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
            foreach (DepartmentStockInDetail detail in deptSODetailList)
            {
                detail.CreateDate = DateTime.Now;
                detail.CreateId = ClientInfo.getInstance().LoggedUser.Name;
                detail.UpdateDate = DateTime.Now;
                detail.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                foreach (DepartmentStock stock in departmentStockList)
                {
                    if (detail.Product.ProductId.Equals(stock.Product.ProductId))
                    {
                        if (detail.Quantity < 0)
                        {
                            MessageBox.Show("Lỗi ở dòng " + line + " : Số lượng phải là số dương. ");
                            return;
                        }
                    }
                }
                
                line++;
            }
            // confirm before save
            DialogResult isConfirmed = System.Windows.Forms.DialogResult.Cancel;
            if (!ClientSetting.ConfirmByEmployeeId)
            {
                LoginForm loginForm = GlobalUtility.GetFormObject<LoginForm>(FormConstants.CONFIRM_LOGIN_VIEW);
                loginForm.StartPosition = FormStartPosition.CenterScreen;
                isConfirmed = loginForm.ShowDialog();
            }
            else
            {
                EmployeeCheckingForm employeeCheckingForm = GlobalUtility.GetFormObject<EmployeeCheckingForm>(FormConstants.EMPLOYEE_CHECKING_VIEW);
                employeeCheckingForm.StartPosition = FormStartPosition.CenterScreen;
                isConfirmed = employeeCheckingForm.ShowDialog();
            }
            if (isConfirmed != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }

            // continue stock in
            if(rdoFastStockIn.Checked)
            {
                ShowMessage("Đang yêu cầu trả hàng ....");    
            }
            

            if (deptSO == null)
            {
                deptSO = new DepartmentStockIn();
            }
            deptSO.DepartmentStockInPK = new DepartmentStockInPK
                                             {
                                                 DepartmentId = CurrentDepartment.Get().DepartmentId
                                             };
            deptSO.StockInDate = DateTime.Now;
            deptSO.DepartmentStockInDetails = ObjectConverter.ConvertToNonGenericList(deptSODetailList);
//            deptSO.Description = txtDexcription.Text;
            var eventArgs = new DepartmentStockInEventArgs();
            eventArgs.DepartmentStockIn = deptSO;
            eventArgs.Department = (Department)cboDepartment.SelectedItem;
            eventArgs.DepartmentStockList = departmentStockList;
            
            if(rdoFastStockIn.Checked)
            {
                try
                {
                    EventUtility.fireEvent(DispatchDepartmentStockIn, this, eventArgs);
                }
                catch (Exception)
                {
                    lblMessage.ForeColor = Color.Red;
                    lblMessage.Text = " Không kết nối được với máy cửa hàng! ";
                    deptSO = new DepartmentStockIn();
                    deptSODetailList.Clear();
                    //                    txtDexcription.Text = "";
                    //                    txtPriceIn.Text = "";
                    //                    txtPriceOut.Text = "";
                    txtSumProduct.Text = "";
                    txtSumValue.Text = "";
                    return;
                }
            }
            else
            {
                EventUtility.fireEvent(SaveStockInBackEvent, this, eventArgs);
            }
            
            if (eventArgs.EventResult != null)
            {
                /*if (!rdoFastStockIn.Checked)
                {*/
                    lblMessage.ForeColor = Color.Blue;
                    lblMessage.Text = "Lưu thành công !";
                /*}*/
                deptSO = new DepartmentStockIn();
                deptSODetailList.Clear();
//                    txtDexcription.Text = "";
//                    txtPriceIn.Text = "";
//                    txtPriceOut.Text = "";
                    txtSumProduct.Text = "";
                    txtSumValue.Text = "";
                    //CreateNewStockInDetail();
                txtBarcode.Focus();    
            }
            else
            {
                if (rdoFastStockIn.Checked)
                {
                    lblMessage.ForeColor = Color.Blue;
                    lblMessage.Text = "Đã yêu cầu cửa hàng trả hàng ... ";
                    return;
                }

                lblMessage.ForeColor = Color.Red;
                lblMessage.Text = "Có lỗi khi lưu !";
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
            DepartmentStockInDetail detail = deptSODetailList[selectedIndex];
            if (MessageBox.Show("Bạn có muốn xóa không?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                /*if (detail.DepartmentStockInDetailPK.ProductId != 0)
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
                }*/
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
            mainStockInEventArgs.SelectedDepartmentStockOutDetail = new DepartmentStockOutDetail
                                                                        {
                                                                            Product = new Product { ProductMaster = new ProductMaster { ProductName = "" } }
                                                                        };
            mainStockInEventArgs.IsFillToComboBox = true;
            mainStockInEventArgs.ComboBoxDisplayMember = "ProductName";
            //EventUtility.fireEvent<DepartmentStockOutEventArgs>(FillProductToComboEvent, cboProductMasters, mainStockInEventArgs);
            
        }

        

        

        private void btnInput_Click(object sender, EventArgs e)
        {
            /*if (cbbStockOutType.SelectedIndex < 0)
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
            }*/
        }

        private void LockField(int rowIndex, DepartmentStockOutDetail stockOutDetail)
        {
            //stockOutDetail.DefectStatus = cbbStockOutType.SelectedItem as StockDefectStatus;
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
            //EventUtility.fireEvent(LoadStockStatusEvent, this, eventArgs);
            if (eventArgs.FoundDepartmentStockOutDetailList != null && eventArgs.FoundDepartmentStockOutDetailList.Count > 0)
            {
                foreach (DepartmentStockInDetail detail in eventArgs.FoundDepartmentStockOutDetailList)
                {
                    bool found = false;
                    foreach (DepartmentStockInDetail detail1 in deptSODetailList)
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
                    //StockDefectStatus defectStatus = (StockDefectStatus)cbbStockOutType.SelectedItem;
                    
                    /*if (defectStatus.DefectStatusId == 4)
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
                    detail.GoodQuantity = 1;*/
                    deptSODetailList.Add(detail);
                    deptSODetailList.EndNew(deptSODetailList.Count - 1);
                    
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
            /*ProductMaster proMaster = cboProductMasters.SelectedItem as ProductMaster;
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
            productMasterList = mainStockInEventArgs.FoundProductMasterList;*/
        }

        private void button3_Click(object sender, EventArgs e)
        {
            deptSO = new DepartmentStockIn();
            deptSODetailList.Clear();
//            txtDexcription.Text = "";
//            txtPriceIn.Text = "";
//            txtPriceOut.Text = "";
            txtSumProduct.Text = "";
            txtSumValue.Text = "";
            /*ClearSelectionOnListBox(lstColor);
            ClearSelectionOnListBox(lstSize);
            cboProductMasters.Text = "";*/
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
            /*var proMaster = cboProductMasters.SelectedItem as ProductMaster;
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
            cboProductMasters.DroppedDown = false;*/
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            //cbbStockOutType.Enabled = true;
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
            //mainStockInEventArgs.SelectedDepartmentStockOutDetail = new DepartmentStockOutDetail { Product = new Product { ProductMaster = new ProductMaster { ProductName = cboProductMasters.Text } } };
            mainStockInEventArgs.IsFillToComboBox = true;
            mainStockInEventArgs.ComboBoxDisplayMember = "ProductName";
            //EventUtility.fireEvent<DepartmentStockOutEventArgs>(FillProductToComboEvent, cboProductMasters, mainStockInEventArgs);
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
            lblMessage.Text = " Đang chờ nhập ...";
            lblMessage.ForeColor = Color.Blue;
            if (!string.IsNullOrEmpty(txtBarcode.Text) && txtBarcode.Text.Length == 12)
            {
                var eventArgs = new DepartmentStockInEventArgs();
                eventArgs.ProductId = txtBarcode.Text;
                EventUtility.fireEvent(FindBarcodeEvent, this, eventArgs);
                if (eventArgs.EventResult == null)
                {
                    MessageBox.Show("Không tìm thấy mã vạch này");
                    txtBarcode.Text = "";
                    return;
                }
                txtGoodsDescription.Text = eventArgs.SelectedDepartmentStockInDetail.Product.ProductMaster.ProductFullName;
                bool found = false;
                DepartmentStockInDetail foundStockInDetail = null;
                foreach (DepartmentStockInDetail detail in deptSODetailList)
                {
                    if (eventArgs.SelectedDepartmentStockInDetail.Product.ProductId.Equals(detail.Product.ProductId))
                    {
                        found = true;
                        foundStockInDetail = detail;
                        break;
                    }
                }
                if (found)
                {
                    txtBarcode.Text = "";
                    foundStockInDetail.Quantity += 1;
                    bdsStockIn.ResetBindings(false);
                    txtBarcode.Text = "";
                    txtBarcode.Focus();
                    dgvDeptStockIn.Refresh();
                    dgvDeptStockIn.Invalidate();
                    CalculateTotalStorePrice();
                    //MessageBox.Show("Mã vạch đã được nhập");
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
                eventArgs.SelectedDepartmentStockInDetail.Quantity = 1;

                deptSODetailList.Add(eventArgs.SelectedDepartmentStockInDetail);
                deptSODetailList.EndNew(deptSODetailList.Count - 1);
                //cbbStockOutType.Enabled = false;
                bdsStockIn.ResetBindings(false);
                txtBarcode.Text = "";
                txtBarcode.Focus();
                dgvDeptStockIn.Refresh();
                dgvDeptStockIn.Invalidate();
                CalculateTotalStorePrice();

                if (rdoFastStockIn.Checked)
                {
                    #region unused code
                    /*// do fast stock out in here
                    // first remove all blank row
                    int count = 0;
                    int length = deptSODetailList.Count;
                    for (int i = 0; i < length - count; i++)
                    {
                        DepartmentStockInDetail detail = deptSODetailList[i];
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
                    foreach (DepartmentStockInDetail detail in deptSODetailList)
                    {
                        detail.CreateDate = DateTime.Now;
                        detail.CreateId = ClientInfo.getInstance().LoggedUser.Name;
                        detail.UpdateDate = DateTime.Now;
                        detail.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                        detail.ExclusiveKey = 1;
                        foreach (DepartmentStock stock in departmentStockList)
                        {
                            if (detail.Product.ProductId.Equals(stock.Product.ProductId))
                            {
                                if (detail.Quantity <= 0 )
                                {
                                    MessageBox.Show("Lỗi ở dòng " + line +
                                                    " : Số lượng phải là số dương !");
                                    return;
                                }
                            }
                        }
                        
                        line++;
                    }

                    if (deptSO == null)
                    {
                        deptSO = new DepartmentStockIn();
                    }
                    
                    deptSO.StockInDate = DateTime.Now;
                    deptSO.DepartmentStockInPK = new DepartmentStockInPK
                                                     {
                                                       DepartmentId = CurrentDepartment.Get().DepartmentId
                                                     };
                    deptSO.DepartmentStockInDetails = deptSODetailList;
                    deptSO.ExclusiveKey = 1;
                    //            deptSO.Description = txtDexcription.Text;
                    var ea = new DepartmentStockInEventArgs();
                    ea.DepartmentStockIn = deptSO;
                    ea.Department = (Department)cboDepartment.SelectedItem;
                    ea.DepartmentStockList = departmentStockList;
                    try
                    {
                        //EventUtility.fireAsyncEvent(DispatchDepartmentStockIn, this, ea,new AsyncCallback(EndEvent));
                        EventUtility.fireEvent(DispatchDepartmentStockIn, this, ea);
                    }
                    catch (Exception)
                    {
                        lblMessage.ForeColor = Color.Red;
                        lblMessage.Text = " Không kết nối được với máy cửa hàng! ";
                        deptSO = new DepartmentStockIn();
                        deptSODetailList.Clear();
                        //                    txtDexcription.Text = "";
                        //                    txtPriceIn.Text = "";
                        //                    txtPriceOut.Text = "";
                        txtSumProduct.Text = "";
                        txtSumValue.Text = "";
                        return;
                    }
                    EventUtility.fireEvent(SaveStockInBackEvent, this, ea);
                    if (ea.EventResult != null)
                    {
                         lblMessage.ForeColor = Color.Blue;
                         lblMessage.Text = "Lưu thành công !";
                        
                            deptSO = new DepartmentStockIn();
                            deptSODetailList.Clear();
                            //                    txtDexcription.Text = "";
                            //                    txtPriceIn.Text = "";
                            //                    txtPriceOut.Text = "";
                            txtSumProduct.Text = "";
                            txtSumValue.Text = "";
                            //CreateNewStockInDetail();
                    }
                    else
                    {
                        lblMessage.ForeColor = Color.Red;
                        lblMessage.Text = "Có lỗi khi lưu ! ";
                    }*/
                    #endregion
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
            /*cbbStockOutType.Enabled = false;
            btnReset.Enabled = false;*/
        }

        private void rdoStockOut_CheckedChanged(object sender, EventArgs e)
        {
            /*cbbStockOutType.Enabled = false;
            btnReset.Enabled = false;
            if (!rdoStockOut.Checked)
            {
                cboProductMasters.Enabled = false;
            }
            else
            {
                cboProductMasters.Enabled = true;
            }*/
        }
        

        private void rdoFastStockIn_CheckedChanged(object sender, EventArgs e)
        {
            if(rdoFastStockIn.Checked)
            {
                
                foreach (Department department in cboDepartment.Items)
                {
                    string departmentId = department.DepartmentId.ToString();
                    //string currentSubStock = CurrentDepartment.Get().DepartmentId.ToString();
                    string fastDept = ClientSetting.FastDept;
                    //if (currentSubStock.StartsWith(departmentId))
                    if (fastDept.Equals(departmentId))
                    {
                        cboDepartment.SelectedItem = department;
                        cboDepartment.Enabled = false;
                        break;
                    }
                }
            }
            else
            {
                cboDepartment.Enabled = true;
            }
            UpdateStockOutDescription();  
        }

        private void rdoStockIn_CheckedChanged(object sender, EventArgs e)
        {
            if (!rdoStockIn.Checked)
            {
                cboDepartment.Enabled = false;
            }
            else
            {
                cboDepartment.Enabled = false;
                foreach (Department department in cboDepartment.Items)
                {
                    string departmentId = department.DepartmentId.ToString();
                    //string currentSubStock = CurrentDepartment.Get().DepartmentId.ToString();
                    string marketDept = ClientSetting.MarketDept;
                    if (marketDept.Equals(departmentId))
                    {
                        cboDepartment.SelectedItem = department;
                        cboDepartment.Enabled = false;
                        break;
                    }
                }
                
            }
            UpdateStockOutDescription();  
        }

        private void UpdateStockOutDescription()
        {
            string text = " NHẬP HÀNG TỪ ";
            text += cboDepartment.Text;

            lblDescription.Text = text;           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txtInputDate.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void systemHotkey2_Pressed(object sender, EventArgs e)
        {
            btnSave_Click(sender,e);
        }

        private ErrorForm _errorForm = null;
        private void ImportByFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = false;
            fileDialog.CheckFileExists = true;
            fileDialog.CheckPathExists = true;
            fileDialog.Filter = "Text Files|*.txt";
            DialogResult result = fileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {

                Dictionary<string, int> list = new Dictionary<string, int>();

                string path = fileDialog.FileName;
                StreamReader fileReader = new StreamReader(File.OpenRead(path));

                while (!fileReader.EndOfStream)
                {
                    string line = fileReader.ReadLine();
                    string[] parseLines = line.Split(',');

                    try
                    {
                        if (parseLines.Length == 2)
                        {
                            if (list.ContainsKey(parseLines[0].Trim()))
                            {
                                list[parseLines[0].Trim()] += Int32.Parse(parseLines[1].Trim());
                            }
                            else
                            {
                                list.Add(parseLines[0].Trim(), Int32.Parse(parseLines[1].Trim()));
                            }

                        }
                        else
                        {
                            if (list.ContainsKey(parseLines[0].Trim()))
                            {
                                list[parseLines[0].Trim()] += 1;
                            }
                            else
                            {
                                list.Add(parseLines[0].Trim(), 1);
                            }

                        }
                    }
                    catch (Exception)
                    {
                        if (_errorForm == null)
                        {
                            _errorForm = new ErrorForm();
                            _errorForm.Caption = "Lỗi";
                            _errorForm.ErrorString = "Các mã vạch bị lỗi khi nhập mã vạch từ file text";
                        }
                        _errorForm.ErrorDetails.Add(line);
                        continue;
                    }
                }
                foreach (KeyValuePair<string, int> barCodeLine in list)
                {
                    if (!string.IsNullOrEmpty(barCodeLine.Key) && barCodeLine.Key.Length == 12)
                    {
                        var eventArgs = new DepartmentStockInEventArgs();
                        eventArgs.ProductId = barCodeLine.Key;
                        EventUtility.fireEvent(FindBarcodeEvent, this, eventArgs);
                        if (eventArgs.EventResult == null)
                        {
                            if (_errorForm == null)
                            {
                                _errorForm = new ErrorForm();
                                //_errorForm.Caption = "Lỗi";
                                _errorForm.ErrorString = "Các mã vạch bị lỗi khi nhập mã vạch từ file text";
                            }
                            _errorForm.ErrorDetails.Add(barCodeLine.Key + "," + barCodeLine.Value);
                            continue;
                        }
                        bool found = false;
                        DepartmentStockInDetail foundStockInDetail = null;
                        foreach (DepartmentStockInDetail detail in deptSODetailList)
                        {
                            if (eventArgs.SelectedDepartmentStockInDetail.Product.ProductId.Equals(detail.Product.ProductId))
                            {
                                found = true;
                                foundStockInDetail = detail;
                                break;
                            }
                        }

                        if (found)
                        {
                            foundStockInDetail.Quantity += barCodeLine.Value;
                            bdsStockIn.ResetBindings(false);
                            dgvDeptStockIn.Refresh();
                            dgvDeptStockIn.Invalidate();
                            CalculateTotalStorePrice();
                        }
                        else
                        {
                            // reset quantity to 1
                            eventArgs.SelectedDepartmentStockInDetail.Quantity = barCodeLine.Value;
                            deptSODetailList.Add(eventArgs.SelectedDepartmentStockInDetail);
                            bdsStockIn.ResetBindings(false);
                            dgvDeptStockIn.Refresh();
                            dgvDeptStockIn.Invalidate();
                            //LockField(deptSODetailList.Count - 1, eventArgs.SelectedDepartmentStockInDetail);
                            CalculateTotalStorePrice();
                        }

                        // process department stock
                        if (eventArgs.DepartmentStock != null)
                        {
                            found = false;
                            foreach (DepartmentStock detail in departmentStockList)
                            {
                                if (eventArgs.DepartmentStock.DepartmentStockPK.ProductId.Equals(detail.Product.ProductId))
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
                    }

                }
                CalculateTotalStorePrice();
                if (_errorForm != null)
                {
                    _errorForm.ShowDialog();
                    _errorForm = null;
                }
            }
        }
    }
}