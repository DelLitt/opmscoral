using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AppFrame.Common;
using AppFrame.Model;
using AppFrame.Presenter.GoodsIO;
using AppFrame.Presenter.GoodsIO.DepartmentGoodsIO;
using AppFrame.Presenter.GoodsIO.MainStock;
using AppFrame.Utility;
using AppFrame.View.GoodsIO.DepartmentGoodsIO;
using AppFrameClient.Common;

namespace AppFrameClient.View.GoodsIO.DepartmentStockData
{
    public partial class DepartmentStockInForm : BaseForm, IDepartmentStockInView
    {

        #region Members
        private const int MAX_COLUMNS = 12;
        public static readonly int PRODUCT_ID_POS = 0;
        public static readonly int PRODUCT_PRICE_POS = 2;
        public static readonly int PRODUCT_SELL_PRICE_POS = 3;
        public static readonly int PRODUCT_QUANTITY_POS = 1;
        public static readonly int STOCK_QUANTITY_POS = 4;
        public static readonly int STOCK_REMAIN_QUANTITY_POS = 5;
        public static readonly int PRODUCT_NAME_POS = 6;
        public static readonly int PRODUCT_TYPE_POS = 7;
        public static readonly int PRODUCT_COLOR_POS = 8;
        public static readonly int PRODUCT_SIZE_POS = 9;
        public static readonly int PRODUCT_COUNTRY_POS = 10;
        public static readonly int PRODUCT_SUPPLIER_POS = 11;

        public IList DepartmentStockInDetailList { get; set; }
        public IList DepartmentStockList { get; set; }
        public IList DepartmentRemainStockList { get; set; }
        public Department Department { get; set; }
        public bool IsNeedClosing { get; set; }
        public StockIn CurrentStockIn { get; set; }
        private readonly DataTable dataTable = new DataTable();

        private IDepartmentStockInController _departmentStockInController;
        public IDepartmentStockInController DepartmentStockInController
        {
            set
            {
                _departmentStockInController = value;
                _departmentStockInController.DepartmentStockInView = this;
            }
        }

        public IProductMasterSearchOrCreateController ProductMasterSearchOrCreateController { get; set; }

        public event EventHandler<DepartmentStockInEventArgs> InitDepartmentStockInEvent;
        public event EventHandler<ProductMasterSearchOrCreateEventArgs> OpenProductMasterSearchEvent;
        public event EventHandler<DepartmentStockInEventArgs> SaveDepartmentStockInEvent;
        public event EventHandler<DepartmentStockInEventArgs> FindProductMasterEvent;
        public event EventHandler<DepartmentStockInEventArgs> SyncDepartmentStockInEvent;

        #endregion


        public DepartmentStockInForm()
        {
            InitializeComponent();
            dataTable.Columns.Add("Mã sản phẩm");
            dataTable.Columns.Add("Số lượng");
            dataTable.Columns.Add("Giá nhập vào");
            dataTable.Columns.Add("Giá bán");
            dataTable.Columns.Add("Số lượng đã xuất");
            dataTable.Columns.Add("Tổng số lượng trong kho");
            dataTable.Columns.Add("Tên mặt hàng");
            dataTable.Columns.Add("Chủng loại");
            dataTable.Columns.Add("Màu sắc");
            dataTable.Columns.Add("Kích cỡ");
            dataTable.Columns.Add("Xuất xứ");
            dataTable.Columns.Add("Nhà cung cấp");
            dataTable.Columns.Add("DelFlg");
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            if (DepartmentStockInDetailList == null)
            {
                DepartmentStockInDetailList = new ArrayList();
            }
            BindDataToList();
            for (int i = 0; i < numericUpDown.Value; i++)
            {
                var stockInDetail = new DepartmentStockInDetail{Product = new Product{ProductMaster = new ProductMaster()}};
                DepartmentStockInDetailList.Add(stockInDetail);
            }
            PopulateDataGrid();
        }

        private void PopulateDataGrid()
        {
            dataTable.Rows.Clear();
            for (int i = 0; i < DepartmentStockInDetailList.Count; i++)
            {
                var stockInDetail = (DepartmentStockInDetail)DepartmentStockInDetailList[i];
                dataTable.Rows.Add(AddProductToDataGrid(stockInDetail, i));

            }
            dgvProduct.DataSource = dataTable;
            dgvProduct.Columns[dgvProduct.ColumnCount - 1].Visible = false;
            if (CurrentStockIn == null)
            {
                for (int i = 0; i < dgvProduct.Columns.Count; i++)
                {
                    dgvProduct.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                    if (i >= 5)
                    {
                        dgvProduct.Columns[i].ReadOnly = true;
                    }
                }
            }
            else
            {
                for (int i = 0; i < dgvProduct.Columns.Count; i++)
                {
                    dgvProduct.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                    if (i != PRODUCT_QUANTITY_POS + 1 
                            && i != PRODUCT_SELL_PRICE_POS + 1 
                            && i != PRODUCT_PRICE_POS + 1)
                    {
                        dgvProduct.Columns[i].ReadOnly = true;
                    }
                }
                for (int i = 0; i < dgvProduct.RowCount; i++)
                {
                    dgvProduct.Columns[STOCK_QUANTITY_POS + 1].Width = 150;
                    dgvProduct.Columns[STOCK_REMAIN_QUANTITY_POS + 1].Width = 180;
                    
                    if (dgvProduct[MAX_COLUMNS, i].Value.ToString().Equals("1"))
                    {
                        for (int j = 0; j < dgvProduct.Columns.Count; j++)
                        {
                            dgvProduct[j, i].ReadOnly = true;
                            dgvProduct[j, i].Style.BackColor = Color.Gray;
                        }
                    }
                    else if (NumberUtility.ParseLong(dgvProduct[STOCK_QUANTITY_POS + 1, i].Value) > 0)
                    {
                        dgvProduct[STOCK_QUANTITY_POS + 1, i].Style.BackColor = Color.Teal;
                    }
                }
            }

            dgvProduct.Refresh();
        }

        private object[] AddProductToDataGrid(DepartmentStockInDetail stockInDetail, int rowIndex)
        {
            var obj = new object[MAX_COLUMNS];
            obj[PRODUCT_PRICE_POS] = stockInDetail.Product.Price;
            obj[PRODUCT_QUANTITY_POS] = stockInDetail.Product.Quantity;
            obj[PRODUCT_SELL_PRICE_POS] = stockInDetail.OnStorePrice;
            if (DepartmentStockList != null && DepartmentStockList.Count > 0 && !string.IsNullOrEmpty(stockInDetail.Product.ProductId))
            {
                foreach (DepartmentStock stock in DepartmentStockList)
                {
                    if (stock.Product.ProductId == stockInDetail.Product.ProductId)
                    {
                        obj[STOCK_QUANTITY_POS] = stockInDetail.Quantity - stock.Quantity;
                        break;
                    }
                }
            }
            if (DepartmentRemainStockList != null && DepartmentRemainStockList.Count > 0 && !string.IsNullOrEmpty(stockInDetail.Product.ProductMaster.ProductMasterId))
            {
                foreach (DepartmentStockSearchResult stock in DepartmentRemainStockList)
                {
                    if (stock.DepartmentStock.Product.ProductMaster.ProductMasterId.Equals(stockInDetail.Product.ProductMaster.ProductMasterId))
                    {
                        obj[STOCK_REMAIN_QUANTITY_POS] = stock.SumQuantity;
                        break;
                    }
                }
            }
            if (stockInDetail.Product.ProductMaster != null)
            {
                obj[PRODUCT_ID_POS] = stockInDetail.Product.ProductMaster.ProductMasterId;
                obj[PRODUCT_NAME_POS] = stockInDetail.Product.ProductMaster.ProductName;
                if (stockInDetail.Product.ProductMaster.ProductType != null)
                {
                    obj[PRODUCT_TYPE_POS] = stockInDetail.Product.ProductMaster.ProductType.TypeName;
                }
                if (stockInDetail.Product.ProductMaster.ProductSize != null)
                {
                    obj[PRODUCT_SIZE_POS] = stockInDetail.Product.ProductMaster.ProductSize.SizeName;
                }
                if (stockInDetail.Product.ProductMaster.ProductColor != null)
                {
                    obj[PRODUCT_COLOR_POS] = stockInDetail.Product.ProductMaster.ProductColor.ColorName;
                }
                if (stockInDetail.Product.ProductMaster.Country != null)
                {
                    obj[PRODUCT_COUNTRY_POS] = stockInDetail.Product.ProductMaster.Country.CountryName;
                }
                if (stockInDetail.Product.ProductMaster.Manufacturer != null)
                {
                    obj[PRODUCT_SUPPLIER_POS] = stockInDetail.Product.ProductMaster.Manufacturer.ManufacturerName;
                }
            }

            obj[MAX_COLUMNS - 1] = stockInDetail.DelFlg;
            return obj;
        }

        private void BindDataToList()
        {
            if (DepartmentStockInDetailList != null)
            {
                for (int i = 0; i < DepartmentStockInDetailList.Count; i++)
                {
                    var stockInDetail = (DepartmentStockInDetail) DepartmentStockInDetailList[i];
                    stockInDetail.Product.Quantity = NumberUtility.ParseLong(dgvProduct[PRODUCT_QUANTITY_POS + 1, i].Value);
                    stockInDetail.Product.Price = NumberUtility.ParseLong(dgvProduct[PRODUCT_PRICE_POS + 1, i].Value);
                    stockInDetail.OnStorePrice = NumberUtility.ParseLong(dgvProduct[PRODUCT_SELL_PRICE_POS + 1, i].Value);
                    stockInDetail.Product.ProductMaster.ProductMasterId = dgvProduct[PRODUCT_ID_POS + 1, i].Value.ToString();
                    
                }
            }
        }

        private void ModifyDataGrid(Product product, int rowIndex)
        {
            dgvProduct[PRODUCT_PRICE_POS + 1, rowIndex].Value = product.Price;
            dgvProduct[PRODUCT_QUANTITY_POS + 1, rowIndex].Value = product.Quantity;
            if (product.ProductMaster != null)
            {
                dgvProduct[PRODUCT_ID_POS + 1, rowIndex].Value = product.ProductMaster.ProductMasterId;
                dgvProduct[PRODUCT_NAME_POS + 1, rowIndex].Value = product.ProductMaster.ProductName;
                if (product.ProductMaster.ProductType != null)
                {
                    dgvProduct[PRODUCT_TYPE_POS + 1, rowIndex].Value = product.ProductMaster.ProductType.TypeName;
                }
                
                if (product.ProductMaster.ProductSize != null)
                {
                    dgvProduct[PRODUCT_SIZE_POS + 1, rowIndex].Value = product.ProductMaster.ProductSize.SizeName;
                }
                    
                if (product.ProductMaster.ProductColor != null)
                {
                    dgvProduct[PRODUCT_COLOR_POS + 1, rowIndex].Value = product.ProductMaster.ProductColor.ColorName;
                }
                if (product.ProductMaster.Country != null)
                {
                    dgvProduct[PRODUCT_COUNTRY_POS + 1, rowIndex].Value = product.ProductMaster.Country.CountryName;
                }
                if (product.ProductMaster.Manufacturer != null)
                {
                    dgvProduct[PRODUCT_SUPPLIER_POS + 1, rowIndex].Value = product.ProductMaster.Manufacturer.ManufacturerName;
                }
            }
            else
            {
                dgvProduct[PRODUCT_ID_POS + 1, rowIndex].Value = "";
                dgvProduct[PRODUCT_NAME_POS + 1, rowIndex].Value = "";
                dgvProduct[PRODUCT_TYPE_POS + 1, rowIndex].Value = "";
                dgvProduct[PRODUCT_SIZE_POS + 1, rowIndex].Value = "";
                dgvProduct[PRODUCT_COLOR_POS + 1, rowIndex].Value = "";
                dgvProduct[PRODUCT_COUNTRY_POS + 1, rowIndex].Value = "";
                dgvProduct[PRODUCT_SUPPLIER_POS + 1, rowIndex].Value = "";
            }
        }

        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0 && e.RowIndex < DepartmentStockInDetailList.Count)
            {
/*                if (CurrentDepartmentStockIn != null)
                {
                    string productId = dgvProduct[PRODUCT_ID_POS + 1, e.RowIndex].Value.ToString();
                    foreach (DepartmentStockInDetail d in DepartmentStockInDetailList)
                    {
                        if (d.Product.ProductMaster != null
                                && d.Product.ProductMaster.ProductMasterId != null
                                && d.Product.ProductMaster.ProductMasterId.Equals(productId))
                        {
                            return;
                        }
                    }
                }
                */
                var productMasterForm = GlobalUtility.GetFormObject<ProductMasterSearchOrCreateForm>(FormConstants.PRODUCT_MASTER_SEARCH_OR_CREATE_FORM);
                productMasterForm.ShowDialog();
                ProductMaster productMaster = productMasterForm.SelectedProductMaster;
                if (productMaster != null)
                {
                    // check if the product master already existed
                    foreach (DepartmentStockInDetail stockInDetail in DepartmentStockInDetailList)
                    {
                        if (stockInDetail.Product != null && stockInDetail.Product.ProductMaster != null && stockInDetail.Product.ProductMaster.ProductMasterId == productMaster.ProductMasterId)
                        {
                            return;
                        }
                    }

                    if (e.RowIndex < DepartmentStockInDetailList.Count)
                    {
                        var stockInDetail = (DepartmentStockInDetail)DepartmentStockInDetailList[e.RowIndex];
                        if (stockInDetail.Product == null)
                        {
                            stockInDetail.Product = new Product();
                        }
                        stockInDetail.Product.ProductMaster = productMaster;
                        ModifyDataGrid(stockInDetail.Product, e.RowIndex);
                    }
                    else
                    {
                        var product = new Product
                                          {
                                              ProductMaster = productMaster
                                          };
                        DepartmentStockInDetailList.Add(new DepartmentStockInDetail { Product = product });
                        ModifyDataGrid(product, e.RowIndex);
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool isError = false;
            var builder = new StringBuilder();
            
            if(DepartmentStockInDetailList==null)
            {
                MessageBox.Show("Không có mặt hàng để nhập kho!","Lỗi",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            for (int i = 0; i < dgvProduct.RowCount; i++)
            {
                ProductMaster productMaster = GetProductMaster(dgvProduct[PRODUCT_ID_POS + 1, i].Value.ToString());
                if (productMaster == null)
                {
                    MessageBox.Show("Mã sản phẩm " + dgvProduct[PRODUCT_ID_POS + 1, i].Value.ToString() + " không tìm thấy");
                    return;
                }

                long quantity = NumberUtility.ParseLong(dgvProduct[PRODUCT_QUANTITY_POS + 1, i].Value);
                long price = NumberUtility.ParseLong(dgvProduct[PRODUCT_PRICE_POS + 1, i].Value);
                long sellPrice = NumberUtility.ParseLong(dgvProduct[PRODUCT_SELL_PRICE_POS + 1, i].Value);
                if (i < DepartmentStockInDetailList.Count)
                {
                    var stockInDetail = ((DepartmentStockInDetail) DepartmentStockInDetailList[i]);
                    stockInDetail.Product.Quantity = quantity;
                    stockInDetail.Product.Price = price;
                    stockInDetail.Price = price;
                    stockInDetail.Quantity = quantity;
                    stockInDetail.OnStorePrice = sellPrice;
                }
                if ((quantity == 0 && dgvProduct[PRODUCT_ID_POS + 1, i].Value.ToString().Length > 0) || (quantity != 0 && dgvProduct[PRODUCT_ID_POS + 1, i].Value.ToString().Length == 0))
                {
                    isError = true;
                    builder.Append("Lỗi ở dòng " + (i + 1) + ": Phải nhập số lượng và mã hàng hợp lệ \r\n");
                }
                else
                {
                    var soldQuantity = NumberUtility.ParseLong(dgvProduct[STOCK_QUANTITY_POS + 1, i].Value);
                    if (quantity < soldQuantity)
                    {
                        builder.Append("Lỗi ở dòng " + (i + 1) + ": Số lượng nhập vào phải lớn hơn hoặc bằng số lượng đã xuất \r\n");
                        isError = true;
                    }
                }
            }

            if (isError)
            {
                MessageBox.Show(builder.ToString());
                return;
            }

            // remove all blank row
            int length = DepartmentStockInDetailList.Count;
            int count = 0;
            for (int i = 0; i < length; i++)
            {
                var stockInDetail = ((DepartmentStockInDetail)DepartmentStockInDetailList[i - count]);
                if (stockInDetail.Product.ProductMaster == null)
                {
                    DepartmentStockInDetailList.Remove(stockInDetail);
                    count++;
                }
            }

            /*if (CurrentDepartmentStockIn == null)
            {
                var stockIn = new StockIn
                {
                    StockInDetails = DepartmentStockInDetailList,
                    CreateDate = DateTime.Now,
                    UpdateDate = DateTime.Now,
                    StockInDate = DateTime.Now
                };
                var eventArgs = new MainStockInEventArgs { StockIn = stockIn, Department = Department };
                EventUtility.fireEvent(SaveDepartmentStockInEvent, this, eventArgs);
                if (stockIn.StockInId != 0)
                {
                    MessageBox.Show("Lưu thành công");
                }
                // TODO CurrentDepartmentStockIn = stockIn;
                PopulateDataGrid();
                txtStockInId.Text = CurrentDepartmentStockIn.DepartmentStockInPK.StockInId;
            } 
            else 
            {
                CurrentDepartmentStockIn.UpdateDate = DateTime.Now;
                CurrentDepartmentStockIn.DepartmentStockInDetails = DepartmentStockInDetailList;
                var eventArgs = new MainStockInEventArgs { DepartmeneStockIn = CurrentDepartmentStockIn, Department = Department };
                EventUtility.fireEvent(SaveDepartmentStockInEvent, this, eventArgs);
                MessageBox.Show("Lưu thành công");

                //ClearForm();
            }

            if (DepartmentStockInDetailList != null)
                foreach (DepartmentStockInDetail detail in DepartmentStockInDetailList)
                {
                    detail.OldQuantity = detail.Quantity;
                }
            /*if (BlockInDetail.BlockInDetailPK != null)
            {
                txtBlockId.Text = BlockInDetail.BlockInDetailPK.BlockDetailId;
                ShowMessage("Lưu thành công");
                lblStatus.ForeColor = Color.Blue;
                PopulateDataGrid();
            }*/
        }

        private void ClearForm()
        {
            txtDexcription.Text = "";
            dgvProduct.Rows.Clear();
        }

        private void dgvProduct_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == PRODUCT_ID_POS + 1 && e.RowIndex < DepartmentStockInDetailList.Count)
            {
                //var productMasterId = dgvProduct[PRODUCT_ID_POS + 1, e.RowIndex].Value;
                var productMasterId = dgvProduct.CurrentCell.EditedFormattedValue;
                // ignore if blank
                if (productMasterId != null && productMasterId.ToString().Length > 0)
                {
                    CheckProductMasterId(productMasterId.ToString(), e.RowIndex);
                }
            }
        }

        private bool CheckProductMasterId(string productMasterId, int currentIndex)
        {
            ProductMaster productMaster = GetProductMaster(productMasterId);
            if (productMaster == null)
            {
                ShowMessage("Mã sản phẩm " + productMasterId + " không tìm thấy");
                dgvProduct[PRODUCT_ID_POS + 1, currentIndex].Style.ForeColor = Color.Red;
                if (currentIndex < DepartmentStockInDetailList.Count)
                {
                    var product = ((DepartmentStockInDetail)DepartmentStockInDetailList[currentIndex]).Product;
                    product.ProductMaster = new ProductMaster();
                    ModifyDataGrid(product, currentIndex);
                    dgvProduct[PRODUCT_ID_POS + 1, currentIndex].Value = productMasterId;
                }
            }
            else
            {
                if (currentIndex < DepartmentStockInDetailList.Count)
                {
                    var product = ((DepartmentStockInDetail)DepartmentStockInDetailList[currentIndex]).Product;
                    product.ProductMaster = productMaster;
                    ModifyDataGrid(product, currentIndex);
                    dgvProduct[PRODUCT_ID_POS + 1, currentIndex].Style.ForeColor = Color.Black;
                    return true;
                }
            }
            return false;
        }

        private ProductMaster GetProductMaster(string productMasterId)
        {
            var eventArgs = new DepartmentStockInEventArgs { ProductMasterId = productMasterId };
            EventUtility.fireEvent(FindProductMasterEvent, this, eventArgs);
            return eventArgs.SelectedProductMaster;
        }

        private void ShowMessage(string message)
        {
            //lblStatus.Text = message;
            MessageBox.Show(message);
        }

        private void DepartmentStockInForm_Load(object sender, EventArgs e)
        {
            /*if (CurrentDepartmentStockIn != null)
            {
                var eventArgs = new MainStockInEventArgs {DepartmeneStockIn = CurrentDepartmentStockIn};
                EventUtility.fireEvent(InitDepartmentStockInEvent, this, eventArgs);
                DepartmentStockInDetailList = eventArgs.DepartmeneStockIn.DepartmentStockInDetails;
                DepartmentStockList = eventArgs.DepartmentStockList;
                DepartmentRemainStockList = eventArgs.DepartmentRemainStockList;
                foreach (DepartmentStockInDetail detail in DepartmentStockInDetailList)
                {
                    detail.OldQuantity = detail.Quantity;
                }
                PopulateDataGrid();
                txtStockInId.Text = CurrentDepartmentStockIn.DepartmentStockInPK.StockInId;
            }
            txtDeptName.Text = CurrentDepartment.Get().DepartmentName;*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            BindDataToList();
            int selected = 0;
            if (dgvProduct.SelectedRows.Count > 0)
            {
                selected = dgvProduct.SelectedRows.Count;
            } 
            else
            {
                selected = dgvProduct.SelectedCells.Count;
            }

            int count = 0;
            for (int i = 0; i < selected; i++)
            {
                int rowIndex = -1;
                if (dgvProduct.SelectedRows.Count > 0)
                {
                    rowIndex = dgvProduct.SelectedRows[i].Index;
                }
                else
                {
                    rowIndex = dgvProduct.SelectedCells[i].RowIndex;
                }
                string productId = dgvProduct[PRODUCT_ID_POS + 1, rowIndex].Value.ToString();
                DepartmentStockInDetail detail = null;
                int pos = 0;
                foreach (DepartmentStockInDetail d in DepartmentStockInDetailList)
                {
                    if (d.DepartmentStockInDetailPK != null 
                            && d.Product.ProductMaster != null 
                            && d.Product.ProductMaster.ProductMasterId != null 
                            && d.Product.ProductMaster.ProductMasterId.Equals(productId))
                    {
                        detail = d;
                        break;
                    }
                    pos++;
                }
                if (detail != null)
                {
                    if (string.IsNullOrEmpty(detail.Product.ProductId))
                    {
                        DepartmentStockInDetailList.RemoveAt(pos);
                        count++;
                    }
                    else
                    {
                        var soldQuantity = NumberUtility.ParseLong(dgvProduct[STOCK_QUANTITY_POS + 1, i].Value);
                        if (soldQuantity > 0)
                        {
                            MessageBox.Show("Bạn không thể xóa mã hàng " + detail.Product.ProductMaster.ProductMasterId + " vì mã hàng này đã được xuất");
                            return;
                        }
                        DialogResult result = MessageBox.Show("Bạn có muốn xóa không?", "", MessageBoxButtons.YesNo);
                        if (result.Equals(DialogResult.Yes))
                        {
                            detail.DelFlg = 1;
                        }
                        else
                        {
                            return;
                        }
                    }
                }
                else
                {
                    
                    DepartmentStockInDetailList.RemoveAt(rowIndex - count);
                    count++;
                }
            }
            PopulateDataGrid();
        }

        private void dgvProduct_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            // calculate total value of block.
            try
            {
                if (DepartmentStockInDetailList == null)
                {
                    return;
                }
                long totalAmount = 0;
                foreach (DataGridViewRow row in dgvProduct.Rows)
                {
                    string strPrice = dgvProduct[PRODUCT_PRICE_POS + 1, e.RowIndex].Value as string;
                    long amount = 0;
                    if (!string.IsNullOrEmpty(strPrice) && long.TryParse(strPrice, out amount))
                    {
                        totalAmount += amount;
                    }
                    else // data error , do not need to calculate
                    {
                        totalAmount = 0;
                        break;
                    }
                }




                txtSumValue.Text = totalAmount.ToString();
            }
            catch(Exception)
            {
                
            }
        }

        #region IDepartmentStockInView Members


        public event EventHandler<MainStockInEventArgs> FillProductToComboEvent;

        #endregion

        #region IDepartmentStockInView Members


        public event EventHandler<MainStockInEventArgs> LoadGoodsByIdEvent;

        public event EventHandler<MainStockInEventArgs> LoadGoodsByNameEvent;

        #endregion
    }
}