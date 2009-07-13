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
using AppFrame.Presenter.GoodsIO.DepartmentGoodsIO;
using AppFrame.Utility;
using AppFrame.View.GoodsIO.DepartmentGoodsIO;
using AppFrameClient.Common;

namespace AppFrameClient.View.GoodsIO.DepartmentStockData
{
    public partial class DepartmentStockInSearchForm : BaseForm, IDepartmentStockInSearchView
    {

        #region Members
        private const int MAX_COLUMNS = 4;
        public static readonly int STOCK_IN_ID_POS = 0;
        public static readonly int STOCK_IN_DATE_POS = 1;
        public static readonly int PRODUCT_QUANTITY_POS = 2;
        public static readonly int UPDATER_POS = 3;
        public IList DepartmentStockInList { get; set; }
        private readonly DataTable dataTable = new DataTable();
        private IDepartmentStockInSearchController _departmentStockInSearchController;
        public IDepartmentStockInSearchController DepartmentStockInSearchController
        {
            set
            {
                _departmentStockInSearchController = value;
                _departmentStockInSearchController.DepartmentStockInSearchView = this;
                _departmentStockInSearchController.CompletedSearchDepartmentStockInEvent += new EventHandler<DepartmentStockInSearchEventArgs>(_departmentStockInSearchController_CompletedSearchDepartmentStockInEvent);
            }
            get
            {
                return _departmentStockInSearchController;
            }
        }

        void _departmentStockInSearchController_CompletedSearchDepartmentStockInEvent(object sender, DepartmentStockInSearchEventArgs e)
        {
            Enabled = true;
            DepartmentStockInList = e.DepartmeneStockInList;
            PopulateDataGrid();
        }
        public event EventHandler<DepartmentStockInSearchEventArgs> SearchDepartmentStockInEvent;
        #endregion

        public DepartmentStockInSearchForm()
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
            var eventArgs = new DepartmentStockInSearchEventArgs
                                {
                                    StockInId = txtBlockInDetailId.Text,
                                    StockInDateFrom = chkImportDateFrom.Checked ? DateUtility.ZeroTime(dtpImportDateFrom.Value) : DateUtility.MaxTime(DateTime.Now.Subtract(new TimeSpan(3,0,0,0))),
                                    StockInDateTo = chkImportDateTo.Checked ? DateUtility.MaxTime(dtpImportDateTo.Value) : DateUtility.MaxTime(DateTime.Now)
                                };
            EventUtility.fireAsyncEvent(SearchDepartmentStockInEvent, this, eventArgs,new AsyncCallback(EndEvent));
            Enabled = false;
            /*DepartmentStockInList = eventArgs.DepartmeneStockInList;
            PopulateDataGrid();*/
        }

        private void PopulateDataGrid()
        {
            dataTable.Rows.Clear();
            for (int i = 0; i < DepartmentStockInList.Count; i++)
            {
                var result = (AppFrame.Model.DepartmentStockIn)DepartmentStockInList[i];
                dataTable.Rows.Add(AddProductToDataGrid(result));

            }
            dgvProduct.DataSource = dataTable;
            dgvProduct.Columns[PRODUCT_QUANTITY_POS].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvProduct.Columns[STOCK_IN_DATE_POS].Width = 150;
            dgvProduct.Refresh();
        }

        private static object[] AddProductToDataGrid(AppFrame.Model.DepartmentStockIn stockInDetail)
        {
            var obj = new object[MAX_COLUMNS];
            obj[STOCK_IN_ID_POS] = stockInDetail.DepartmentStockInPK.StockInId;
            obj[STOCK_IN_DATE_POS] = stockInDetail.StockInDate.ToString("dd/MM/yyyy HH:mm:ss");
            long quantity = 0;
            foreach (DepartmentStockInDetail detail in stockInDetail.DepartmentStockInDetails)
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
                DepartmentStockIn selected = null;
                foreach (DepartmentStockIn stockIn in DepartmentStockInList)
                {
                    if (stockInId.Equals(stockIn.DepartmentStockInPK.StockInId))
                    {
                        selected = stockIn;
                        break;
                    }
                }
                if (selected != null)
                {
                    var departmentStockIn = GlobalUtility.GetFormObject<DepartmentStockInForm>(FormConstants.DEPARTMENT_STOCK_IN_FORM);
                    // TODO departmentStockIn.CurrentStockIn = selected;
                    departmentStockIn.ShowDialog();
                }
            }
        }

        private void dgvProduct_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ViewStockInDetail(e.RowIndex);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}