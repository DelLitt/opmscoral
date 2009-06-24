using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using AppFrame.Collection;
using AppFrame.Common;
using AppFrame.Model;
using AppFrame.Presenter.GoodsIO.DepartmentGoodsIO;
using AppFrame.Utility;
using AppFrame.View.GoodsIO.DepartmentGoodsIO;
using AppFrameClient.Common;
using AppFrameClient.View.GoodsIO.DepartmentStockData;

namespace AppFrameClient.View.GoodsIO.DepartmentStockData
{
    public partial class DepartmentStockSearchForm : BaseForm, IDepartmentStockSearchView
    {
        private const int MAX_COLUMNS = 10;
        public static readonly int PRODUCT_ID_POS = 0;
        public static readonly int PRODUCT_NAME_POS = 1;
        public static readonly int PRODUCT_QUANTITY_POS = 2;
        public static readonly int PRODUCT_IN_PRICE_POS = 3;
        public static readonly int PRODUCT_SELL_PRICE_POS = 4;
        public static readonly int PRODUCT_TYPE_POS = 5;
        public static readonly int PRODUCT_COLOR_POS = 6;
        public static readonly int PRODUCT_SIZE_POS = 7;
        public static readonly int PRODUCT_COUNTRY_POS = 8;
        public static readonly int PRODUCT_SUPPLIER_POS = 9;

        private DepartmentStockViewCollection stockViewList;
        private DepartmentStockCollection stockList;
        public IList DepartmentStockSearchResultList { get; set; }
        public DepartmentStockSearchForm()
        {
            InitializeComponent();
            /*dataTable.Columns.Add("Mã sản phẩm");
            dataTable.Columns.Add("Tên mặt hàng");
            dataTable.Columns.Add("Số lượng");
            dataTable.Columns.Add("Tổng giá nhập vào");
            dataTable.Columns.Add("Tổng giá bán");
            dataTable.Columns.Add("Chủng loại");
            dataTable.Columns.Add("Màu sắc");
            dataTable.Columns.Add("Kích cỡ");
            dataTable.Columns.Add("Xuất xứ");
            dataTable.Columns.Add("Nhà cung cấp");*/
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var eventArgs = new DepartmentStockSearchEventArgs
                                {
                                    ProductMasterId = productMasterSearchControl.txtProductMasterId.Text,
                                    ProductMasterName = productMasterSearchControl.txtProductName.Text,
                                    ProductSize = productMasterSearchControl.cbbProductSize.SelectedIndex > 0 ? ((ProductSize)productMasterSearchControl.cbbProductSize.SelectedItem) : null,
                                    ProductType = productMasterSearchControl.cbbProductType.SelectedIndex > 0 ? ((ProductType)productMasterSearchControl.cbbProductType.SelectedItem) : null,
                                    ProductColor = productMasterSearchControl.cbbProductColor.SelectedIndex > 0 ?
                                                                                                                    ((ProductColor)productMasterSearchControl.cbbProductColor.SelectedItem) : null,
                                    Country = productMasterSearchControl.cbbCountry.SelectedIndex > 0 ? ((Country)productMasterSearchControl.cbbCountry.SelectedItem) : null,
                                    Manufacturer = productMasterSearchControl.cbbManufacturer.SelectedIndex > 0 ? ((Manufacturer)productMasterSearchControl.cbbManufacturer.SelectedItem) : null,
                                    Distributor = productMasterSearchControl.cbbDistributor.SelectedIndex > 0 ? ((Distributor)productMasterSearchControl.cbbDistributor.SelectedItem) : null,
                                    Packager = productMasterSearchControl.cbbPackager.SelectedIndex > 0 ? ((Packager)productMasterSearchControl.cbbPackager.SelectedItem) : null
                                };
            EventUtility.fireEvent(SearchDepartmentStockEvent, this, eventArgs);
            DepartmentStockSearchResultList = eventArgs.DepartmentStockList;
            if(DepartmentStockSearchResultList!= null && DepartmentStockSearchResultList.Count > 0)
            {
                stockViewList.Clear();
                foreach (DepartmentStockView departmentStockView in DepartmentStockSearchResultList)
                {
                    stockViewList.Add(departmentStockView);
                }
                bdsStockView.ResetBindings(false);
                dgvStockView.Refresh();
                dgvStockView.Invalidate();
            }
        }

        private IDepartmentStockSearchController _departmentStockSearchController;
        public IDepartmentStockSearchController DepartmentStockSearchController
        {
            set
            {
                _departmentStockSearchController = value;
                _departmentStockSearchController.DepartmentStockSearchView = this;
            }
        }

        private readonly DataTable dataTable = new DataTable();
        public event EventHandler<DepartmentStockSearchEventArgs> InitDepartmentStockSearchEvent;
        public event EventHandler<DepartmentStockSearchEventArgs> SearchDepartmentStockEvent;

        private void DepartmentStockSearchForm_Load(object sender, EventArgs e)
        {
            stockViewList = new DepartmentStockViewCollection(bdsStockView);
            bdsStockView.ResetBindings(true);

            stockList = new DepartmentStockCollection(bdsStock);
            bdsStock.ResetBindings(true);

            var eventArgs = new DepartmentStockSearchEventArgs();
            EventUtility.fireEvent(InitDepartmentStockSearchEvent, this, eventArgs);

            productMasterSearchControl.cbbProductType.DataSource = eventArgs.ProductTypeList;
            productMasterSearchControl.cbbProductType.DisplayMember = "TypeName";

            productMasterSearchControl.cbbProductSize.DataSource = eventArgs.ProductSizeList;
            productMasterSearchControl.cbbProductSize.DisplayMember = "SizeName";

            productMasterSearchControl.cbbProductColor.DataSource = eventArgs.ProductColorList;
            productMasterSearchControl.cbbProductColor.DisplayMember = "ColorName";

            productMasterSearchControl.cbbCountry.DataSource = eventArgs.CountryList;
            productMasterSearchControl.cbbCountry.DisplayMember = "CountryName";
        }

        private void PopulateDataGrid()
        {
            dataTable.Rows.Clear();
            for (int i = 0; i < DepartmentStockSearchResultList.Count; i++)
            {
                var result = (DepartmentStockSearchResult)DepartmentStockSearchResultList[i];
                dataTable.Rows.Add(AddProductToDataGrid(result));

            }
            dgvStockView.DataSource = dataTable;
            dgvStockView.Columns[PRODUCT_IN_PRICE_POS].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvStockView.Columns[PRODUCT_QUANTITY_POS].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvStockView.Columns[PRODUCT_SELL_PRICE_POS].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvStockView.Refresh();
        }

        private static object[] AddProductToDataGrid(DepartmentStockSearchResult stockInDetail)
        {
            var obj = new object[MAX_COLUMNS];
            //obj[PRODUCT_ID_POS] = stockInDetail.DepartmentStock.Product.Price;
            obj[PRODUCT_IN_PRICE_POS] = stockInDetail.SumInPrice.ToString("#,##", CultureInfo.CreateSpecificCulture("de-DE"));
            obj[PRODUCT_QUANTITY_POS] = stockInDetail.SumQuantity.ToString("#,##", CultureInfo.CreateSpecificCulture("de-DE"));
            obj[PRODUCT_SELL_PRICE_POS] = stockInDetail.SumSellPrice.ToString("#,##", CultureInfo.CreateSpecificCulture("de-DE"));
            if (stockInDetail.DepartmentStock.Product.ProductMaster != null)
            {
                obj[PRODUCT_ID_POS] = stockInDetail.DepartmentStock.Product.ProductMaster.ProductMasterId;
                obj[PRODUCT_NAME_POS] = stockInDetail.DepartmentStock.Product.ProductMaster.ProductName;
                if (stockInDetail.DepartmentStock.Product.ProductMaster.ProductType != null)
                    obj[PRODUCT_TYPE_POS] = stockInDetail.DepartmentStock.Product.ProductMaster.ProductType.TypeName;
                if (stockInDetail.DepartmentStock.Product.ProductMaster.ProductSize != null)
                    obj[PRODUCT_SIZE_POS] = stockInDetail.DepartmentStock.Product.ProductMaster.ProductSize.SizeName;
                if (stockInDetail.DepartmentStock.Product.ProductMaster.ProductColor != null)
                    obj[PRODUCT_COLOR_POS] = stockInDetail.DepartmentStock.Product.ProductMaster.ProductColor.ColorName;
            }
            return obj;
        }

        private void dgvProduct_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                string productMasterId = dgvStockView[0, e.RowIndex].Value.ToString();
                var departmentStockIn = GlobalUtility.GetFormObject<DepartmentStockInDetailSearchForm>(FormConstants.DEPARTMENT_STOCK_IN_DETAIL_SEARCH_FORM);
                foreach (DepartmentStockSearchResult result in DepartmentStockSearchResultList)
                {
                    if (result.DepartmentStock.Product.ProductMaster.ProductMasterId.Equals(productMasterId))
                    {
                        departmentStockIn.ProductMaster = result.DepartmentStock.Product.ProductMaster;
                        break;
                    }
                }
                if (departmentStockIn.ProductMaster != null)
                {
                    departmentStockIn.SumStock = dgvStockView[PRODUCT_QUANTITY_POS, e.RowIndex].Value.ToString();
                    departmentStockIn.ShowDialog();
                }
                
            }
        }

        private void dgvStockView_SelectionChanged(object sender, EventArgs e)
        {
            stockList.Clear();
            if (dgvStockView.CurrentRow != null)
            {
                DataGridViewRow row = dgvStockView.CurrentRow;
                DepartmentStockView stockView = stockViewList[row.Index];
                if(stockView.DepartmentStocks != null && stockView.DepartmentStocks.Count > 0 )
                {
                    foreach (DepartmentStock stock in stockView.DepartmentStocks)
                    {
                        stockList.Add(stock);
                    }
                    bdsStock.ResetBindings(false);
                    dgvStock.Refresh();
                    dgvStock.Invalidate();
                }
            }
        }
    }
}