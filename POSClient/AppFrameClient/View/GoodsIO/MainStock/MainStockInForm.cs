using System;
using System.Collections;
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
using Fath;

namespace AppFrameClient.View.GoodsIO.MainStock
{
    public partial class MainStockInForm : BaseForm, IMainStockInView
    {
        private const int QUANTITY_POS = 5;
        private const int PRICE_POS = 6;
        private const int SELL_PRICE_POS = 7;
        private StockInDetailCollection deptSIDetailList;
        private IList CurrentRowProductColorList { get; set; }
        private IList CurrentRowProductSizeList { get; set; }
        public StockIn deptSI { get; set; }
        public MainStockInForm()
        {
            InitializeComponent();
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

            if(columnName.Equals("columnColor") )
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
            

            if( columnName.Equals("columnSize"))
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
                    ((ComboBox) sender).DataSource = null;
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
                txtStockInId.Text = deptSI.StockInId;
                CalculateTotalStorePrice();
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
                productMasterSearchOrCreateController=value;    
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

            if (deptSI == null)
            {
                deptSI = new StockIn();
            }
            bool isNeedClearData = string.IsNullOrEmpty(deptSI.StockInId);
            deptSI.StockInDate = dtpImportDate.Value;
            deptSI.StockInDetails = deptSIDetailList;
            var eventArgs = new MainStockInEventArgs();
            eventArgs.StockIn = deptSI;
            EventUtility.fireEvent(SaveStockInEvent, this, eventArgs);
            if (!string.IsNullOrEmpty(deptSI.StockInId))
            {
                MessageBox.Show("Lưu thành công");
                if (isNeedClearData)
                {
                    deptSI = new StockIn();
                    deptSIDetailList.Clear();
                    CreateNewStockInDetail();
                }
            }
            else
            {
                MessageBox.Show("Có lỗi khi lưu");
            }
        }

        private void dgvDeptStockIn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0 && e.RowIndex < deptSIDetailList.Count)
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
            StockInDetail detail = deptSIDetailList[selectedIndex];
            if (MessageBox.Show("Bạn có muốn xóa không?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (detail.StockInDetailPK != null && !string.IsNullOrEmpty(deptSIDetailList[selectedIndex].StockInDetailPK.StockInId))
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
            var eventArgs = new MainStockInEventArgs{ProductMasterIdForPrice = deptSIDetailList[dgvDeptStockIn.CurrentRow.Index].Product.ProductMaster.ProductMasterId};
            EventUtility.fireEvent(GetPriceEvent, this, eventArgs);
            string priceStr = "";
            if (eventArgs.DepartmentPrice != null)
            {
                priceStr = "Giá : " + eventArgs.DepartmentPrice.Price.ToString("#,##", CultureInfo.CreateSpecificCulture("de-DE")) ;
            }
            /*var code39 = new Code39
                             {
                                 FontFamilyName = "Free 3 of 9",
                                 //2.FontFamilyName = "MW6 Code39MT",
                                 //3.FontFamilyName = "MW6 Code39S",
                                 //4.FontFamilyName = "MW6 Code39LT",
                                 //5.FontFamilyName = "Code EAN13",
                                 FontFileName = "Common\\FREE3OF9.TTF",
                                 //2.FontFileName = "Common\\MW6Code39MT.TTF",
                                 //3.FontFileName = "Common\\MW6Code39S.TTF",
                                 //4.FontFileName = "Common\\MW6Code39LT.TTF",
                                 //5.FontFileName = "Common\\ean13.ttf",
                                 ShowCodeString = true,
                                 FontSize = 12,
                                 TitleFont = new Font("Tahoma", 12),
                                 CodeStringFont = new Font("Tahoma",12),
                                 Title = priceStr + " VND"
                        };

            var code39Gen = code39.GenerateBarcode("*" + deptSIDetailList[dgvDeptStockIn.CurrentRow.Index].Product.ProductId+ "*",
                                                   (int)((float)1.5*e.Graphics.DpiX),(int)((float)0.75*e.Graphics.DpiY));*/

            /*var setting = new Code39Settings();
            setting.BarCodeHeight = 50;
            setting.DrawText = true;
            var code39Ex = new Code39Ex(deptSIDetailList[dgvDeptStockIn.CurrentRow.Index].Product.ProductId,
                setting);*/

            
            BarcodeX codeGen = new BarcodeX();
            codeGen.Title = priceStr.ToUpper();
            codeGen.Font = new Font("Arial", (float) 18, FontStyle.Regular);
            codeGen.Data = "*" + deptSIDetailList[dgvDeptStockIn.CurrentRow.Index].Product.ProductId+ "*";
            codeGen.Width = (int)(1.25*150);
            codeGen.Height = (int)(0.75*150);
            codeGen.Symbology = bcType.Code39;
            codeGen.ShowText = true;
            
            
            for (int i = 0; i < numberToPrint; i++)
            {
                System.Drawing.Rectangle rc=new System.Drawing.Rectangle((i%3)*135,25,(int)(1.5*100),(int)(0.75*100));
                //(i % 3) * 124, (i / 3) * 87, 117, 79 
			    e.Graphics.DrawImage(codeGen.Image((int)((float)1.5*e.Graphics.DpiX),(int)((float)0.75*e.Graphics.DpiY)),rc);
                //e.Graphics.DrawImage(code39Gen, new Rectangle((i % 3) * 135, 100, (int)(1.5 * 100), (int)(0.75 * 100)));
                
			    //e.HasMorePages=false;
                //e.Graphics.DrawImageUnscaled(codeGen.Image(codeGen.Width,codeGen.Height));
            }                  
        }

        private void CalculateTotalStorePrice()
        {
            long totalInPrice = 0;
            long totalProduct = 0;
            foreach (StockInDetail detail in deptSIDetailList)
            {
                totalInPrice += detail.Price * detail.Quantity;
                totalProduct += detail.Quantity;
            }
            txtSumValue.Text = totalInPrice.ToString();
            txtSumProduct.Text = totalProduct.ToString();
        }

        #region IMainStockInView Members


        public event EventHandler<MainStockInEventArgs> LoadAllGoodsByNameEvent;

        #endregion
    }
}