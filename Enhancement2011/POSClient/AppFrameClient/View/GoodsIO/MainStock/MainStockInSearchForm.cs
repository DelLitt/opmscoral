using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;
using AppFrame.Common;
using AppFrame.Model;
using AppFrame.Presenter.GoodsIO.DepartmentGoodsIO;
using AppFrame.Presenter.GoodsIO.MainStock;
using AppFrame.Utility;
using AppFrame.View.GoodsIO.DepartmentGoodsIO;
using AppFrame.View.GoodsIO.MainStock;
using AppFrameClient.Common;
using AppFrameClient.View.GoodsIO.DepartmentStockData;

namespace AppFrameClient.View.GoodsIO.MainStock
{
    public partial class MainStockInSearchForm : BaseForm, IMainStockInSearchView
    {

        #region Members
        private const int MAX_COLUMNS = 4;
        public static readonly int STOCK_IN_ID_POS = 0;
        public static readonly int STOCK_IN_DATE_POS = 1;
        public static readonly int PRODUCT_QUANTITY_POS = 2;
        public static readonly int UPDATER_POS = 3;
        public IList StockInList { get; set; }
        private readonly DataTable dataTable = new DataTable();
        private MainStockInSearchEventArgs CurrentEventArgs { get; set; }
        private IMainStockInSearchController _stockInSearchController;
        public IMainStockInSearchController MainStockInSearchController
        {
            set
            {
                _stockInSearchController = value;
                _stockInSearchController.StockInSearchView = this;
                _stockInSearchController.CompletedMainStockInSearchEvent += new EventHandler<MainStockInSearchEventArgs>(_stockInSearchController_CompletedMainStockInSearchEvent);
            }
            get
            {
                return _stockInSearchController;
            }
        }

        void _stockInSearchController_CompletedMainStockInSearchEvent(object sender, MainStockInSearchEventArgs e)
        {
            Enabled = true;
            StockInList = e.StockInList;
           if(StockInList!= null)
               PopulateDataGrid();            
        }

        public IDepartmentStockInSearchController DepartmentStockInSearchController
        {
            set { throw new System.NotImplementedException(); }
        }

        public event EventHandler<MainStockInSearchEventArgs> SearchStockInEvent;
        public event EventHandler<MainStockInSearchEventArgs> SearchSingleStockInEvent;
        public event EventHandler<DepartmentStockInSearchEventArgs> SearchDepartmentStockInEvent;
        #endregion

        public MainStockInSearchForm()
        {
            InitializeComponent();
            dataTable.Columns.Add("Mã lô");
            dataTable.Columns.Add("Ngày nhập");
            dataTable.Columns.Add("Tổng số lượng nhập");
            dataTable.Columns.Add("Người nhập");
        }

        private void chkImportDateFrom_CheckedChanged(object sender, EventArgs e)
        {
            dtpImportDateFrom.Enabled = chkImportDateFrom.Checked;
        }

        private void chkImportDateTo_CheckedChanged(object sender, EventArgs e)
        {
            dtpImportDateTo.Enabled = chkImportDateTo.Checked;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            /*var eventArgs = new MainStockInSearchEventArgs
                                {
                                    StockInId = txtBlockInDetailId.Text,
                                    StockInDateFrom = chkImportDateFrom.Checked ? DateUtility.ZeroTime(dtpImportDateFrom.Value) : DateUtility.ZeroTime(DateTime.Now.Subtract(new TimeSpan(3,0,0))),
                                    StockInDateTo = chkImportDateTo.Checked ? DateUtility.MaxTime(dtpImportDateTo.Value) : DateUtility.MaxTime(DateTime.Now)
                                };
            EventUtility.fireAsyncEvent(SearchStockInEvent, this, eventArgs,new AsyncCallback(EndEvent));
            Enabled = false;
            CurrentEventArgs = eventArgs;*/
            /*StockInList = eventArgs.StockInList;
            if(StockInList!= null)
                PopulateDataGrid();*/
            DateTime StockInDateFrom = chkImportDateFrom.Checked
                                  ? DateUtility.ZeroTime(dtpImportDateFrom.Value)
                                  : DateUtility.ZeroTime(DateTime.Now.Subtract(new TimeSpan(3, 0, 0)));
            DateTime StockInDateTo = chkImportDateTo.Checked
                                ? DateUtility.MaxTime(dtpImportDateTo.Value)
                                : DateUtility.MaxTime(DateTime.Now);
            stock_inTableAdapter.Fill(masterDB.stock_in, StockInDateFrom, StockInDateTo);
            if(stockinBindingSource.Count == 0 )
            {
                MessageBox.Show("Không tìm thấy lô hàng nhập nào cả !");
                return;
            }
            stockinBindingSource.ResetBindings(false);
            dgvProduct.Refresh();
            dgvProduct.Invalidate();
        }

        private void PopulateDataGrid()
        {
            dataTable.Rows.Clear();
            for (int i = 0; i < StockInList.Count; i++)
            {
                var result = (StockIn)StockInList[i];
                dataTable.Rows.Add(AddProductToDataGrid(result));

            }
            dgvProduct.DataSource = dataTable;
            dgvProduct.Columns[PRODUCT_QUANTITY_POS].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvProduct.Columns[STOCK_IN_DATE_POS].Width = 150;
            dgvProduct.Refresh();
        }

        private static object[] AddProductToDataGrid(StockIn stockInDetail)
        {
            var obj = new object[MAX_COLUMNS];
            obj[STOCK_IN_ID_POS] = stockInDetail.StockInId;
            obj[STOCK_IN_DATE_POS] = stockInDetail.StockInDate.ToString("dd/MM/yyyy HH:mm:ss");
            long quantity = 0;
            foreach (StockInDetail detail in stockInDetail.StockInDetails)
            {
                if (detail.DelFlg == 0)
                {
                    quantity += detail.Quantity;
                }
            }
            obj[PRODUCT_QUANTITY_POS] = quantity;
            obj[UPDATER_POS] = stockInDetail.UpdateId;
            return obj;
        }

        private void dgvProduct_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ViewStockInDetail(e.RowIndex);
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (dgvProduct.SelectedCells.Count > 0)
            {
                ViewStockInDetail(dgvProduct.SelectedCells[0].RowIndex);
            }
        }

        private void ViewStockInDetail(int rowIndex)
        {
            if (rowIndex >= 0 && rowIndex < dgvProduct.RowCount)
            {
                string stockInId = dgvProduct[STOCK_IN_ID_POS, rowIndex].Value.ToString();
                StockIn selected = null;
                btnSelect.Enabled = false;
                var eventArgs = new MainStockInSearchEventArgs
                {
                    StockInId = stockInId
                };
                EventUtility.fireEvent(SearchSingleStockInEvent, this, eventArgs);
                selected = eventArgs.StockIn;

                if (selected != null)
                {
                    ArrayList details = new ArrayList();
                    foreach (StockInDetail stockInDetail in selected.StockInDetails)
                    {
                        details.Add(stockInDetail);
                    }
                    selected.StockInDetails = SortDetail(details);
                    var departmentStockIn = GlobalUtility.GetFormObject<MainStockInForm>(FormConstants.MAIN_STOCK_IN_FORM);
                    departmentStockIn.deptSI = selected;
                    departmentStockIn.ShowDialog();

                    // refresh list
                    DateTime StockInDateFrom = chkImportDateFrom.Checked
                                  ? DateUtility.ZeroTime(dtpImportDateFrom.Value)
                                  : DateUtility.ZeroTime(DateTime.Now.Subtract(new TimeSpan(3, 0, 0)));
                    DateTime StockInDateTo = chkImportDateTo.Checked
                                        ? DateUtility.MaxTime(dtpImportDateTo.Value)
                                        : DateUtility.MaxTime(DateTime.Now);
                    stock_inTableAdapter.Fill(masterDB.stock_in, StockInDateFrom, StockInDateTo);
                    stockinBindingSource.ResetBindings(false);
                    dgvProduct.Refresh();
                    dgvProduct.Invalidate();
                }
                btnSelect.Enabled = true;
            }
        }

        private IList SortDetail(ArrayList stockInDetails)
        {
            var result = from detail in stockInDetails.OfType<StockInDetail>()
                         orderby detail.Product.ProductMaster.ProductName,
                                 detail.Product.ProductMaster.ProductColor.ColorId,
                                 detail.Product.ProductMaster.ProductSize.SizeId ascending 
                         select detail;
            return result.ToList();
        }

        
        private void dgvProduct_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ViewStockInDetail(e.RowIndex);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MainStockInSearchForm_Load(object sender, EventArgs e)
        {
            
        }
    }
}