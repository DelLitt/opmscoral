using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using AppFrame.Collection;
using AppFrame.Common;
using AppFrame.Model;
using AppFrame.Presenter.GoodsIO.DepartmentGoodsIO;
using AppFrame.Presenter.GoodsIO.MainStock;
using AppFrame.Utility;
using AppFrame.View.GoodsIO.DepartmentGoodsIO;
using AppFrame.View.GoodsIO.MainStock;
using AppFrameClient.Common;
using AppFrameClient.View.GoodsIO.DepartmentStockData;
using Aspose.Cells;

namespace AppFrameClient.View.GoodsIO.MainStock
{
    public partial class MainStockInSearchReportForm : BaseForm, IMainStockInSearchView
    {

        #region Members
        private const int MAX_COLUMNS = 4;
        public static readonly int STOCK_IN_ID_POS = 0;
        public static readonly int STOCK_IN_DATE_POS = 1;
        public static readonly int PRODUCT_QUANTITY_POS = 2;
        public static readonly int UPDATER_POS = 3;
        private StockInDetailCollection stockInDetList = null;
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
            }
            get
            {
                return _stockInSearchController;
            }
        }

        public IDepartmentStockInSearchController DepartmentStockInSearchController
        {
            set { throw new System.NotImplementedException(); }
        }

        public event EventHandler<MainStockInSearchEventArgs> SearchStockInEvent;
        public event EventHandler<DepartmentStockInSearchEventArgs> SearchDepartmentStockInEvent;
        #endregion

        public MainStockInSearchReportForm()
        {
            InitializeComponent();
    /*        dataTable.Columns.Add("Mã lô");
            dataTable.Columns.Add("Ngày nhập");
            dataTable.Columns.Add("Tổng số lượng nhập");
            dataTable.Columns.Add("Người nhập");*/
            stockInDetList = new StockInDetailCollection(bdsStockIn);
            bdsStockIn.DataSource = stockInDetList;
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
            stockInDetList.Clear();
            var eventArgs = new MainStockInSearchEventArgs
            {
                StockInId = txtBlockInDetailId.Text,
                StockInDateFrom = chkImportDateFrom.Checked ? DateUtility.ZeroTime(dtpImportDateFrom.Value) : DateTime.MinValue,
                StockInDateTo = chkImportDateTo.Checked ? DateUtility.MaxTime(dtpImportDateTo.Value) : DateTime.MaxValue
            };
            EventUtility.fireEvent(SearchStockInEvent, this, eventArgs);
            CurrentEventArgs = eventArgs;
            StockInList = eventArgs.StockInList;
            foreach (StockIn stockIn in StockInList)
            {
                foreach (StockInDetail detail in stockIn.StockInDetails)
                {
                    stockInDetList.Add(detail);                    
                }
            }
            bdsStockIn.EndEdit();
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

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            DialogResult result = saveFileDialog1.ShowDialog();
            if (result == DialogResult.Cancel)
            {
                return;
            }
            string fileName = saveFileDialog1.FileName;

            Workbook workbook = new Workbook();
            string path = Path.GetDirectoryName(Application.ExecutablePath) + "\\Templates\\GoodsSaleMainStockInReportTemplate.xls";
            //string path = "Templates\\GoodsSaleMainStockInReportTemplate.xls";
            workbook.Open(path);
            //workbook.Open("g:\\Book1.xls");
            Worksheet sheet = workbook.Worksheets[0];
            sheet.Name = "Sheet1";
            //IList<PurchaseOrder> testList = ObjectConverter.ConvertGenericList<PurchaseOrder>((PurchaseOrderCollection)bdsPurchaseOrders.DataSource);
            DataTable test = ObjectConverter.ConvertToDataTable(dgvProduct);

            // put department name
            //sheet.Cells[5, 3].PutValue(CurrentDepartment.Get().DepartmentName);

            // put total amount
            //sheet.Cells[14, 3].PutValue(txtTotalAmount.Text);

            foreach (StockIn stockIn in StockInList)
            {

            }

            sheet.Cells.ImportDataTable(test, true, 10, 1);
            saveFileDialog1.ShowDialog();

            workbook.Save(fileName);
            MessageBox.Show("Xuất ra tập tin báo cáo thành công!");
        }
    }
}