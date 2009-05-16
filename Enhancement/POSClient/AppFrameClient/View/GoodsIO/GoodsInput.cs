using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AppFrame.Logic;
using System.Collections;
using AppFrame.Model;
using AppFrameClient.Common;
using AppFrame.Utility;
using AppFrame;

namespace AppFrameClient.View.GoodsIO
{
    public partial class GoodsInput : Form
    {
        private static readonly int MAX_COLUMNS = 10;
        public static readonly int PRODUCT_ID_POS = 0;
        public static readonly int PRODUCT_PRICE_POS = 1;
        public static readonly int PRODUCT_QUANTITY_POS = 2;
        public static readonly int PRODUCT_NAME_POS = 3;
        public static readonly int PRODUCT_TYPE_POS = 4;
        public static readonly int PRODUCT_COLOR_POS = 5;
        public static readonly int PRODUCT_SIZE_POS = 6;


        #region Members
        private int blockId = 1;
        private int blockDetailId;
        private IList sizeList;
        private IList typeList;
        private IList colorList;
        private IList supplierList;
        public bool IsNeedClosing { get; set; }
        public IBlockInDetailLogic BlockInDetailLogic { get; set; }
        public BlockInDetail BlockInDetail { get; set; }
        private DataTable dataTable = new DataTable();
        public ISupplierLogic SupplierLogic { get; set; }

        public IProductColorLogic ColorLogic { get; set; }

        public IProductSizeLogic SizeLogic { get; set; }

        public IProductTypeLogic TypeLogic { get; set; }
        public IProductMasterLogic ProductMasterLogic { get; set; }

        public int BlockId
        {
            get { return blockId; }
            set { blockId = value; }
        }

        #endregion

        public GoodsInput()
        {
            InitializeComponent();
            dataTable.Columns.Add("Mã sản phẩm");
            dataTable.Columns.Add("Giá nhập vào");
            dataTable.Columns.Add("Số lượng");
            dataTable.Columns.Add("Tên mặt hàng");
            dataTable.Columns.Add("Chủng loại");
            dataTable.Columns.Add("Màu sắc");
            dataTable.Columns.Add("Kích cỡ");
            dataTable.Columns.Add("Tạo mã vạch");
            dataTable.Columns.Add("Xuất xứ");
            dataTable.Columns.Add("Index");
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void GoodsInput_Load(object sender, EventArgs e)
        {
            if (supplierList == null)
            {
                supplierList = SupplierLogic.FindAll(null);
                cbbSupplier.DisplayMember = "SupplierName";
                cbbSupplier.DataSource = supplierList;
            }
            if (sizeList == null)
            {
                sizeList = SizeLogic.FindAll(null);
            }
            if (colorList == null)
            {
                colorList = ColorLogic.FindAll(null);
            }
            if (typeList == null)
            {
                typeList = TypeLogic.FindAll(null);
            }
            if (BlockInDetail != null)
            {
                txtBlockId.Text = BlockInDetail.BlockInDetailPK.BlockDetailId + "";
                txtDexcription.Text = BlockInDetail.DetailValue;
                for (int i = 0; i < supplierList.Count; i++ )
                {
                    if (((Supplier)supplierList[i]).SupplierId == BlockInDetail.SupplierId)
                    {
                        cbbSupplier.SelectedItem = supplierList[i];
                        break;
                    }
                }
                dtpImportDate.Value = BlockInDetail.BlockIn.ImportDate;
                PopulateDataGrid();
            } 
            else
            {
                BlockInDetail = new BlockInDetail();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool isError = false;
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < dgvProduct.RowCount; i++ )
            {
                if (dgvProduct[PRODUCT_ID_POS, i].Style.ForeColor == Color.Red)
                {
                    isError = true;
                    builder.Append((i + 1) + " ");
                    continue;
                }

                long quantity = NumberUtility.ParseLong(dgvProduct[PRODUCT_QUANTITY_POS + 1, i].Value);
                long price = NumberUtility.ParseLong(dgvProduct[PRODUCT_PRICE_POS + 1, i].Value);
                if (i < BlockInDetail.Products.Count)
                {
                    ((Product)BlockInDetail.Products[i]).Quantity = quantity;
                    ((Product)BlockInDetail.Products[i]).Price = price;
                }
                if ((quantity == 0 && dgvProduct[PRODUCT_ID_POS + 1, i].Value.ToString().Length > 0) || (quantity != 0 && dgvProduct[PRODUCT_ID_POS + 1, i].Value.ToString().Length == 0))
                {
                    isError = true;
                    builder.Append((i + 1) + " ");
                }
            }

            if (isError)
            {
                ShowMessage("Lỗi ở dòng: " + builder.ToString());
                return;
            }

            // remove all blank row
            int length = BlockInDetail.Products.Count;
            int count = 0;
            for (int i = 0; i < length; i++ )
            {
                var product = (Product) BlockInDetail.Products[i - count];
                if (product.ProductMaster == null)
                {
                    BlockInDetail.Products.Remove(product);
                    count++;
                }
            }

            if (BlockInDetail.BlockInDetailPK != null)
                {
                    if (cbbSupplier.SelectedValue != null)
                    {
                        BlockInDetail.SupplierId = ((Supplier)cbbSupplier.SelectedValue).SupplierId;    
                    }
                    
                    BlockInDetail.DetailValue = txtDexcription.Text;
                    BlockInDetail.ImportDate = dtpImportDate.Value;
                    BlockInDetailLogic.Update(BlockInDetail);
                }
                else
                {
                    if (cbbSupplier.SelectedValue != null)
                    {
                        BlockInDetail.SupplierId = ((Supplier)cbbSupplier.SelectedValue).SupplierId;
                    }
                    
                    BlockInDetail.DetailValue = txtDexcription.Text;
                    BlockInDetail.ImportDate = dtpImportDate.Value;
                    BlockInDetailLogic.Add(BlockInDetail);
                }
            if (BlockInDetail.BlockInDetailPK != null)
            {
                txtBlockId.Text = BlockInDetail.BlockInDetailPK.BlockDetailId;
                ShowMessage("Lưu thành công");
                lblStatus.ForeColor = Color.Blue;
                PopulateDataGrid();
            }
            
            if (IsNeedClosing)
            {
                this.Close();
            }
        }

        private void PopulateDataGrid() 
        {
            IList products = BlockInDetail.Products;
            //dgvProduct.DataSource = products;
            dataTable.Rows.Clear();
            for(int i = 0; i < products.Count; i++)
            {
                var product = (Product) products[i];
                dataTable.Rows.Add(AddProductToDataGrid(product, i));

            }
            dgvProduct.DataSource = dataTable;
            dgvProduct.Columns[dgvProduct.ColumnCount - 1].Visible = false;
            dgvProduct.Refresh();
        }

        private object[] AddProductToDataGrid(Product product, int rowIndex)
        {
            var obj = new object[MAX_COLUMNS];
            obj[PRODUCT_PRICE_POS] = product.Price;
            obj[PRODUCT_QUANTITY_POS] = product.Quantity;
            if (product.ProductMaster != null) 
            {
                obj[PRODUCT_ID_POS] = product.ProductMaster.ProductMasterId;
                obj[PRODUCT_NAME_POS] = product.ProductMaster.ProductName;
                obj[PRODUCT_TYPE_POS] = product.ProductMaster.ProductType.TypeName;
                obj[PRODUCT_SIZE_POS] = product.ProductMaster.ProductSize.SizeName;
                obj[PRODUCT_COLOR_POS] = product.ProductMaster.ProductColor.ColorName;
            }
            obj[MAX_COLUMNS - 1] = rowIndex;
            return obj;
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < numericUpDown.Value; i++)
            {
                BlockInDetail.Products.Add(new Product());
            }
            PopulateDataGrid();
        }

        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0) 
            {
                var productMasterForm = GlobalUtility.GetFormObject<ProductMasterSearchOrCreateForm>(FormConstants.PRODUCT_MASTER_SEARCH_OR_CREATE_FORM);
                productMasterForm.ShowDialog();

                if (productMasterForm.SelectedProductMaster != null)
                {
                    // check if the product master already existed
                    foreach (Product product in BlockInDetail.Products)
                    {
                        if (product.ProductMaster != null && product.ProductMaster.ProductMasterId == productMasterForm.SelectedProductMaster.ProductMasterId)
                        {
                            return;
                        }
                    }

                    if (e.RowIndex < BlockInDetail.Products.Count)
                    {
                        var product = (Product)BlockInDetail.Products[e.RowIndex];
                        product.ProductMaster = productMasterForm.SelectedProductMaster;
                        ModifyDataGrid(product, e.RowIndex);
                        //BindDataToProducts();
                        //PopulateDataGrid();
                    }
                    else 
                    {
                        var product = new Product
                                          {
                                              ProductMaster = productMasterForm.SelectedProductMaster
                                          };
                        BlockInDetail.Products.Add(product);
                        ModifyDataGrid(product, e.RowIndex);
                        //BindDataToProducts();
                        //PopulateDataGrid();
                    }
                }
            }
        }

        private void dgvProduct_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == PRODUCT_ID_POS + 1 && e.RowIndex < BlockInDetail.Products.Count)
            {
                var rowIndex = NumberUtility.ParseInt(dgvProduct[dgvProduct.Columns.Count - 1, e.RowIndex].Value);
                //var productMasterId = dgvProduct[PRODUCT_ID_POS + 1, e.RowIndex].Value;
                var productMasterId = dgvProduct.CurrentCell.EditedFormattedValue;
                // ignore if blank
                if (productMasterId != null && productMasterId.ToString().Length > 0)
                {
                    CheckProductMasterId(productMasterId.ToString(), rowIndex, e.RowIndex);
                }
                else
                {
                    ShowMessage("");
                }
            }
        }

        private void CheckProductMasterId (string productMasterId, int rowIndex, int currentIndex)
        {
            ProductMaster productMaster = ProductMasterLogic.FindById(productMasterId);
            if (productMaster == null)
            {
                ShowMessage("Mã sản phẩm " + productMasterId + " không tìm thấy");
                dgvProduct[PRODUCT_ID_POS + 1, currentIndex].Style.ForeColor = Color.Red;
                if (rowIndex < BlockInDetail.Products.Count)
                {
                    var product = (Product)BlockInDetail.Products[rowIndex];
                    product.ProductMaster = null;
                    ModifyDataGrid(product, currentIndex);
                    dgvProduct[PRODUCT_ID_POS + 1, rowIndex].Value = productMasterId;
                }
            }
            else
            {
                if (rowIndex < BlockInDetail.Products.Count)
                {
                    var product = (Product)BlockInDetail.Products[rowIndex];
                    product.ProductMaster = productMaster;
                    ModifyDataGrid(product, currentIndex);
                    dgvProduct[PRODUCT_ID_POS + 1, currentIndex].Style.ForeColor = Color.Black;
                    ShowMessage("");
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
                dgvProduct[PRODUCT_TYPE_POS + 1, rowIndex].Value = product.ProductMaster.ProductType.TypeName;
                dgvProduct[PRODUCT_SIZE_POS + 1, rowIndex].Value = product.ProductMaster.ProductSize.SizeName;
                dgvProduct[PRODUCT_COLOR_POS + 1, rowIndex].Value = product.ProductMaster.ProductColor.ColorName;
            }
            else
            {
                dgvProduct[PRODUCT_ID_POS + 1, rowIndex].Value = "";
                dgvProduct[PRODUCT_NAME_POS + 1, rowIndex].Value = "";
                dgvProduct[PRODUCT_TYPE_POS + 1, rowIndex].Value = "";
                dgvProduct[PRODUCT_SIZE_POS + 1, rowIndex].Value = "";
                dgvProduct[PRODUCT_COLOR_POS + 1, rowIndex].Value = "";
            }
        }


        private void ShowMessage(string message)
        {
            lblStatus.Text = message;
        }
    }
}
