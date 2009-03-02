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
using AppFrame.Utility;
using AppFrame.View.GoodsIO;

namespace AppFrameClient.View.GoodsIO
{
    public partial class StockSearchForm : BaseForm, IStockSearchView
    {
        private const int MAX_COLUMN = 8;
        private const int PRODUCT_MASTER_ID_POS = 0;
        private const int PRODUCT_MASTER_NAME_POS = 1;
        private const int PRODUCT_QUANTITY_POS = 2;
        private const int PRODUCT_SUM_POS = 3;
        private const int PRODUCT_TYPE_POS = 4;
        private const int PRODUCT_COLOR_POS = 5;
        private const int PRODUCT_SIZE_POS = 6;

        public StockSearchForm()
        {
            InitializeComponent();
            dataTable.Columns.Add("Mã sản phẩm");
            dataTable.Columns.Add("Tên sản phẩm");
            dataTable.Columns.Add("Số lượng trong kho");
            dataTable.Columns.Add("Tổng giá trị");
            dataTable.Columns.Add("Chủng loại");
            dataTable.Columns.Add("Màu sắc");
            dataTable.Columns.Add("Kích cỡ");
            dataTable.Columns.Add("Index");
        }

        private void StockSearchForm_Load(object sender, EventArgs e)
        {
            var eventArgs = new StockSearchEventArgs();
            EventUtility.fireEvent(InitStockSearchEvent, this, eventArgs);

            productMasterControl.cbbProductType.DataSource = eventArgs.ProductTypeList;
            productMasterControl.cbbProductType.DisplayMember = "TypeName";

            productMasterControl.cbbProductSize.DataSource = eventArgs.ProductSizeList;
            productMasterControl.cbbProductSize.DisplayMember = "SizeName";

            productMasterControl.cbbProductColor.DataSource = eventArgs.ProductColorList;
            productMasterControl.cbbProductColor.DisplayMember = "ColorName";

            productMasterControl.cbbCountry.DataSource = eventArgs.CountryList;
            productMasterControl.cbbCountry.DisplayMember = "CountryName";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var eventArgs = new StockSearchEventArgs
            {
                ProductMasterId = productMasterControl.txtProductMasterId.Text,
                ProductMasterName = productMasterControl.txtProductName.Text,
                ProductSize = productMasterControl.cbbProductSize.SelectedIndex > 0 ? ((ProductSize)productMasterControl.cbbProductSize.SelectedItem) : null,
                ProductType = productMasterControl.cbbProductType.SelectedIndex > 0 ? ((ProductType)productMasterControl.cbbProductType.SelectedItem) : null,
                ProductColor = productMasterControl.cbbProductColor.SelectedIndex > 0 ?
                    ((ProductColor)productMasterControl.cbbProductColor.SelectedItem) : null,
                Country = productMasterControl.cbbCountry.SelectedIndex > 0 ? ((Country)productMasterControl.cbbCountry.SelectedItem) : null
            };
            EventUtility.fireEvent(SearchStockEvent, sender, eventArgs);
            IList stockList = eventArgs.StockList;
            

        }

        public IList StockList { get; set; }
        private IStockSearchController _stockSearchController;
        public IStockSearchController StockSearchController
        {
            set
            {
                _stockSearchController = value;
                _stockSearchController.StockSearchView = this;
            }
        }

        public event EventHandler<StockSearchEventArgs> InitStockSearchEvent;
        public event EventHandler<StockSearchEventArgs> SearchStockEvent;
        private readonly DataTable dataTable = new DataTable();

        public void PopulateDataGrid(StockCreateEventArgs e)
        {
            if (StockList != null)
            {
                dataTable.Rows.Clear();
                for (int i = 0; i < StockList.Count; i++)
                {
                    var stock = (Stock)StockList[i];
                    dataTable.Rows.Add(AddBlockToDataGrid(stock, i));
                }
                dgvStockList.DataSource = dataTable;
                dgvStockList.Refresh();
            }
        }

        private static object[] AddBlockToDataGrid(Stock stock, int rowIndex)
        {
            var obj = new object[MAX_COLUMN];
            obj[PRODUCT_MASTER_ID_POS] = stock.Product.ProductMaster.ProductMasterId;
            obj[PRODUCT_MASTER_NAME_POS] = stock.Product.ProductMaster.ProductName;
            obj[PRODUCT_QUANTITY_POS] = stock.Quantity;
            obj[PRODUCT_SUM_POS] = 0;
            obj[MAX_COLUMN - 1] = rowIndex;
            return obj;
        }
    }
}
