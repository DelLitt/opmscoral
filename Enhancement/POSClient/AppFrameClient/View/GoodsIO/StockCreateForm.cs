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
    public partial class StockCreateForm : BaseForm, IStockCreateView
    {
        private const int MAX_COLUMN = 11;
        private const int BLOCK_ID_POS = 0;
        private const int PRODUCT_MASTER_ID_POS = 1;
        private const int STOCK_IN_DATE_ID_POS = 2;
        private const int PRODUCT_MASTER_NAME_POS = 3;
        private const int PRODUCT_PRICE_POS = 4;
        private const int PRODUCT_QUANTITY_POS = 5;
        private const int ACCEPT_QUANTITY_POS = 7;
        private const int RETURN_QUANTITY_POS = 8;
        private const int REMAIN_QUANTITY_POS = 6;
        private const int STOCK_QUANTITY_POS = 9;
        private StockCreateEventArgs _currentEventArgs;

        public StockCreateForm()
        {
            InitializeComponent();
            cbbStatus.SelectedIndex = 0;
        }

        private void StockCreateForm_Load(object sender, EventArgs e)
        {
            dataTable.Columns.Add("Mã lô");
            dataTable.Columns.Add("Mã sản phẩm");
            dataTable.Columns.Add("Ngày nhập");
            dataTable.Columns.Add("Tên sản phẩm");
            dataTable.Columns.Add("Giá nhập");
            dataTable.Columns.Add("Nhập vào");
            dataTable.Columns.Add("Chưa approve");
            dataTable.Columns.Add("Chấp nhận");
            dataTable.Columns.Add("Trả lại");
            dataTable.Columns.Add("Số lượng trong kho");
            dataTable.Columns.Add("Index");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var eventArgs = new StockCreateEventArgs
                                {
                                    ImportDateFrom = chkImportDateFrom.Checked ? dtpImportDateFrom.Value : DateTime.MinValue,
                                    ImportDateTo = chkImportDateTo.Checked ? dtpImportDateTo.Value : DateTime.MaxValue,
                                    StockInStatus = cbbStatus.SelectedIndex == 0 ? StockInDetail.StockInStatus.IMPORTED : StockInDetail.StockInStatus.RETURNED_FROM_DEPT
                                };
            EventUtility.fireEvent(SearchStockInDetailEvent, this, eventArgs);
            StockInDetailList = eventArgs.StockInDetailList;
            PopulateDataGrid(eventArgs);
            _currentEventArgs = eventArgs;
        }

        private IStockCreateController stockCreateController;
        public IStockCreateController StockCreateController
        {
            set
            {
                stockCreateController = value;
                stockCreateController.StockCreateView = this;
            }
        }

        public IList StockInDetailList { get; set; }
        public event EventHandler<StockCreateEventArgs> CreateStockEvent;
        public event EventHandler<StockCreateEventArgs> SearchStockInDetailEvent;
        private readonly DataTable dataTable = new DataTable();
        private void chkImportDateFrom_CheckedChanged(object sender, EventArgs e)
        {
            dtpImportDateFrom.Enabled = chkImportDateFrom.Checked;
        }

        private void chkImportDateTo_CheckedChanged(object sender, EventArgs e)
        {
            dtpImportDateTo.Enabled = chkImportDateTo.Checked;
        }

        public void PopulateDataGrid(StockCreateEventArgs e)
        {
            if (StockInDetailList != null)
            {
                dataTable.Rows.Clear();
                for (int i = 0; i < StockInDetailList.Count; i++)
                {
                    var stockInDetail = (StockInDetail)StockInDetailList[i];
                    dataTable.Rows.Add(AddBlockToDataGrid(stockInDetail, e.StockList, e.ReturnProductList, i));
                }
                dgvStockInDetail.DataSource = dataTable;
                dgvStockInDetail.Refresh();

                dgvStockInDetail.Columns[BLOCK_ID_POS].Width = 70;
                dgvStockInDetail.Columns[PRODUCT_MASTER_ID_POS].Width = 80;
                dgvStockInDetail.Columns[STOCK_IN_DATE_ID_POS].Width = 80;
                dgvStockInDetail.Columns[MAX_COLUMN - 1].Visible = false;

                for (int i = 0; i < dgvStockInDetail.Columns.Count; i++)
                {
                    if (i != ACCEPT_QUANTITY_POS && i != RETURN_QUANTITY_POS)
                    {
                        dgvStockInDetail.Columns[i].ReadOnly = true;
                    }
                }
            }
        }

        private object[] AddBlockToDataGrid(StockInDetail stockInDetail, IList stockList, IList returnStockList, int rowIndex)
        {
            var obj = new object[MAX_COLUMN];
            obj[BLOCK_ID_POS] = stockInDetail.Product.BlockInDetail.BlockInDetailPK.BlockDetailId;
            obj[PRODUCT_MASTER_ID_POS] = stockInDetail.Product.ProductMaster.ProductMasterId;
            obj[STOCK_IN_DATE_ID_POS] = stockInDetail.StockIn.StockInDate;
            obj[PRODUCT_MASTER_NAME_POS] = stockInDetail.Product.ProductMaster.ProductName;
            obj[PRODUCT_PRICE_POS] = stockInDetail.Price;
            obj[PRODUCT_QUANTITY_POS] = stockInDetail.Quantity;

            long stockQty = 0;
            if (stockList != null && stockList.Count > 0)
            {
                foreach (Stock stock in stockList)
                {
                    if (stockInDetail.Product.ProductId == stock.Product.ProductId)
                    {
                        stockQty += stock.Quantity;
                    }
                }
            }
            obj[STOCK_QUANTITY_POS] = stockQty;

            long returnQty = 0;
            if (returnStockList != null && returnStockList.Count > 0)
            {
                foreach (ReturnProduct returnProduct in returnStockList)
                {
                    if (stockInDetail.Product.ProductId == returnProduct.ProductId)
                    {
                        returnQty += returnProduct.Quantity;
                    }
                }
            }
            var remainQty = stockInDetail.Quantity - stockQty - returnQty;
            obj[REMAIN_QUANTITY_POS] = remainQty;
            obj[MAX_COLUMN - 1] = rowIndex;
            return obj;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // validate data
            if (!ValidateData())
            {
                return;
            }

            var createdStockList = new List<Stock>();
            var createReturnProductList = new List<ReturnProduct>();
            var stockInDetailList = new List<StockInDetail>();

            for (int i = 0; i < dgvStockInDetail.RowCount; i++)
            {
                var index = NumberUtility.ParseInt(dgvStockInDetail[MAX_COLUMN - 1, i].Value);
                var acceptQty = NumberUtility.ParseLong(dgvStockInDetail[ACCEPT_QUANTITY_POS, i].Value);
                var returnQty = NumberUtility.ParseLong(dgvStockInDetail[RETURN_QUANTITY_POS, i].Value);
                var stockInDetail = (StockInDetail)StockInDetailList[index];

                // approve for product
                if (acceptQty != 0)
                {
                    Stock currentStock = null;
                    if (_currentEventArgs != null && _currentEventArgs.StockList != null)
                    {
                        foreach (Stock stock in _currentEventArgs.StockList)
                        {
                            if (stock.Product.ProductId == stockInDetail.Product.ProductId)
                            {
                                currentStock = stock;
                                currentStock.Quantity += acceptQty;
                                break;
                            }
                        }
                        if (currentStock == null)
                        {
                            currentStock = new Stock
                                               {
                                                   Quantity = acceptQty,
                                                   Product = ((StockInDetail)StockInDetailList[index]).Product
                                               };
                        }
                        createdStockList.Add(currentStock);
                    }
                }
                // return the product
                if (returnQty != 0)
                {
                    var returnProduct = new ReturnProduct
                                            {
                                                ProductId = ((StockInDetail)StockInDetailList[index]).Product.ProductId,
                                                Quantity = returnQty
                                            };

                    createReturnProductList.Add(returnProduct);
                }
                if (stockInDetail.Quantity == acceptQty + returnQty)
                {
                    stockInDetail.StockInType = (long)StockInDetail.StockInStatus.COMPLETELY_STOCKED;
                    stockInDetailList.Add(stockInDetail);
                }
            }
            if (createdStockList.Count > 0 || createReturnProductList.Count > 0)
            {
                var eventArgs = new StockCreateEventArgs { CreateStockList = createdStockList, CreateReturnProductList = createReturnProductList, UpdateStockInDetailList = stockInDetailList };
                EventUtility.fireEvent(CreateStockEvent, this, eventArgs);

                EventUtility.fireEvent(SearchStockInDetailEvent, this, _currentEventArgs);
                StockInDetailList = _currentEventArgs.StockInDetailList;
                PopulateDataGrid(_currentEventArgs);
            }
        }

        private void btnAcceptAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvStockInDetail.RowCount; i++)
            {
                dgvStockInDetail[ACCEPT_QUANTITY_POS, i].Value = dgvStockInDetail[REMAIN_QUANTITY_POS, i].Value;
                dgvStockInDetail[RETURN_QUANTITY_POS, i].Value = 0;
            }
        }

        private void btnRejectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvStockInDetail.RowCount; i++)
            {
                dgvStockInDetail[ACCEPT_QUANTITY_POS, i].Value = 0;
                dgvStockInDetail[RETURN_QUANTITY_POS, i].Value = dgvStockInDetail[REMAIN_QUANTITY_POS, i].Value;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvStockInDetail.RowCount; i++)
            {
                dgvStockInDetail[ACCEPT_QUANTITY_POS, i].Value = 0;
                dgvStockInDetail[RETURN_QUANTITY_POS, i].Value = 0;
            }
        }

        private bool ValidateData()
        {
            long sum = 0;
            for (int i = 0; i < dgvStockInDetail.RowCount; i++)
            {
                long acceptQty = 0;
                if (!NumberUtility.CheckLongNullIsZero(dgvStockInDetail[ACCEPT_QUANTITY_POS, i].Value, out acceptQty) || acceptQty < 0)
                {
                    MessageBox.Show("Error in accept quantity");
                    return false;
                }

                long returnQty = 0;
                if (!NumberUtility.CheckLongNullIsZero(dgvStockInDetail[RETURN_QUANTITY_POS, i].Value, out returnQty) || returnQty < 0)
                {
                    MessageBox.Show("Error in return quantity");
                    return false;
                }

                sum += acceptQty + returnQty;

                var remainQty = NumberUtility.ParseLong(dgvStockInDetail[REMAIN_QUANTITY_POS, i].Value);
                if (acceptQty + returnQty > remainQty)
                {
                    MessageBox.Show("Accept quantity and return quantity is bigger than remain");
                    return false;
                }
            }
            if (sum == 0)
            {
                MessageBox.Show("Nothing to stock");
                return false;
            }
            return true;
        }
    }
}
