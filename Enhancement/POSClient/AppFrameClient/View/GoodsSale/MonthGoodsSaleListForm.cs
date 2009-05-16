using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using AppFrame;
using AppFrame.Collection;
using AppFrame.Common;
using AppFrame.Model;
using AppFrame.Presenter.GoodsSale;
using AppFrame.Utility;
using AppFrame.View.GoodsSale;
using AppFrameClient.ViewModel;
//using Aspose.Cells;

namespace AppFrameClient.View.GoodsSale
{
    public partial class MonthGoodsSaleListForm : BaseForm, IMonthGoodsSaleListView
    {
        public MonthGoodsSaleListForm()
        {
            InitializeComponent();
           
        }

        private void FillForm()
        {
            Department department = CurrentDepartment.Get();
            txtDepartmentId.Text = department.DepartmentId.ToString().PadLeft(3, '0');
            txtDepartmentName.Text = department.DepartmentName;

            int currentYear = DateTime.Now.Year;
            int currentMonth = DateTime.Now.Month;
            int daysOfMonth = DateTime.DaysInMonth(currentYear, currentMonth);
            // get first day of month
            txtDateFrom.Text = new DateTime(currentYear,currentMonth,1).ToString("dd/MM/yyyy");
            // get last day of month
            txtDateTo.Text = new DateTime(currentYear, currentMonth, daysOfMonth).ToString("dd/MM/yyyy");

            GoodsSaleListEventArgs goodsSaleListEventArgs = new GoodsSaleListEventArgs();
            goodsSaleListEventArgs.PurchaseOrderSearchCriteria = CreateCriteria();
            DateTime firstOfMonth = DateTime.ParseExact(txtDateFrom.Text, "dd/MM/yyyy", null);
            DateTime lastOfMonth = DateTime.ParseExact(txtDateTo.Text, "dd/MM/yyyy", null);
            goodsSaleListEventArgs.FromDate = DateUtility.ZeroTime(firstOfMonth);
            goodsSaleListEventArgs.ToDate = DateUtility.MaxTime(lastOfMonth);

            EventUtility.fireEvent(GoodsSaleListSearchEvent, this, goodsSaleListEventArgs);
        }

        public ObjectCriteria CreateCriteria()
        {
            // create new criteria
            GoodsSaleListController.PurchaseOrderCriteria = new ObjectCriteria();

            ObjectCriteria objectCriteria = GoodsSaleListController.PurchaseOrderCriteria;

            // search from date 1 to date 2
            DateTime firstOfMonth = DateTime.ParseExact(txtDateFrom.Text, "dd/MM/yyyy", null);
            DateTime lastOfMonth = DateTime.ParseExact(txtDateTo.Text, "dd/MM/yyyy", null);
            objectCriteria.AddGreaterOrEqualsCriteria("CreateDate", DateUtility.ZeroTime(firstOfMonth))
                .AddLesserOrEqualsCriteria("CreateDate", DateUtility.MaxTime(lastOfMonth));

            GoodsSaleListController.PurchaseOrderCriteria = objectCriteria;
            return objectCriteria;
        }

        #region IMonthGoodsSaleListView Members

        private IGoodsSaleListController goodsSaleListController;
        public AppFrame.Presenter.GoodsSale.IGoodsSaleListController GoodsSaleListController
        {
            get
            {
                return goodsSaleListController;
            }
            set
            {
                goodsSaleListController = value;
                goodsSaleListController.MonthGoodsSaleListView = this;
                goodsSaleListController.CompletedGoodsSaleListSearchEvent += new EventHandler<GoodsSaleListEventArgs>(goodsSaleListController_CompletedGoodsSaleListSearchEvent);
            }
        }

        void goodsSaleListController_CompletedGoodsSaleListSearchEvent(object sender, GoodsSaleListEventArgs e)
        {
            //e.PurchaseOrders.ParentBindingSource = bdsPurchaseOrders;
            bdsPurchaseOrders.DataSource = e.PurchaseOrderViewList;
            bdsPurchaseOrders.EndEdit();
            bdsPurchaseOrders.ResetBindings(false);
            long totalAmount = 0;
            long sellQty = 0;
            long retQty = 0;
            foreach (PurchaseOrderView view in e.PurchaseOrderViewList)
            {
                totalAmount += (view.SellAmount - view.ReturnAmount);
                sellQty += view.SellQuantity;
                retQty += view.ReturnQuantity;
            }
            txtTotalAmount.Text = totalAmount.ToString("##,#00");
            txtSellQty.Text = sellQty.ToString();
            txtRetQty.Text = retQty.ToString();
        }

        public event EventHandler<AppFrame.Presenter.GoodsSale.GoodsSaleListEventArgs> GoodsSaleListSearchEvent;

        public event EventHandler<AppFrame.Presenter.GoodsSale.GoodsSaleListEventArgs> ExportToExcelEvent;

        public event EventHandler<AppFrame.Presenter.GoodsSale.GoodsSaleListEventArgs> PrintGoodsSaleEvent;

        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
            goodsSaleListController.CompletedGoodsSaleListSearchEvent -= new EventHandler<GoodsSaleListEventArgs>(goodsSaleListController_CompletedGoodsSaleListSearchEvent);
        }

        private void MonthGoodsSaleListForm_Load(object sender, EventArgs e)
        {
            FillForm();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*DialogResult result = saveFileDialog1.ShowDialog();
            if (result == DialogResult.Cancel)
            {
                return;
            }
            string fileName = saveFileDialog1.FileName;

            Workbook workbook = new Workbook();
            string path = Path.GetDirectoryName(Application.ExecutablePath) + "\\Templates\\GoodsSaleListTemplate.xls";
            workbook.Open(path);
            Worksheet sheet = workbook.Worksheets[0];
            sheet.Name = "Sheet1";
            //IList<PurchaseOrder> testList = ObjectConverter.ConvertGenericList<PurchaseOrder>((PurchaseOrderCollection)bdsPurchaseOrders.DataSource);
            DataTable test = ObjectConverter.ConvertToDataTable(dgvSaleList);

            // put department name
            sheet.Cells[5, 3].PutValue(CurrentDepartment.Get().DepartmentName);

            // put total amount
            sheet.Cells[14, 3].PutValue(txtTotalAmount.Text);

            sheet.Cells.ImportDataTable(test, true, 10, 1);
            saveFileDialog1.ShowDialog();
            
            workbook.Save(fileName);
            MessageBox.Show("Xuất ra tập tin báo cáo thành công!");*/
        }
    }
}
