using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using AppFrame;
using AppFrame.Common;
using AppFrame.Model;
using AppFrame.Presenter.GoodsSale;
using AppFrame.Utility;
using AppFrame.View.GoodsSale;
using AppFrameClient.ViewModel;
using Aspose.Cells;

namespace AppFrameClient.View.GoodsSale
{
    public partial class DayGoodsSaleListForm : BaseForm,IDayGoodsSaleListView
    {
        public DayGoodsSaleListForm()
        {
            InitializeComponent();
            
        }

        private void FillForm()
        {
            Department department = CurrentDepartment.Get();
            txtDepartmentId.Text = department.DepartmentId.ToString().PadLeft(3,'0');
            txtDepartmentName.Text = department.DepartmentName;
            txtDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            
            GoodsSaleListEventArgs goodsSaleListEventArgs = new GoodsSaleListEventArgs();
            goodsSaleListEventArgs.PurchaseOrderSearchCriteria = CreateCriteria();
            goodsSaleListEventArgs.FromDate = DateUtility.ZeroTime(DateTime.Now);
            goodsSaleListEventArgs.ToDate = DateTime.Now;
            EventUtility.fireEvent(GoodsSaleListSearchEvent, this, goodsSaleListEventArgs);
        }

        public ObjectCriteria CreateCriteria()
        {
            // create new criteria
            GoodsSaleListController.PurchaseOrderCriteria = new ObjectCriteria();

            ObjectCriteria objectCriteria = GoodsSaleListController.PurchaseOrderCriteria;
            
            // search from date 1 to date 2
            DateTime dateTime = new DateTime();

            objectCriteria.AddGreaterOrEqualsCriteria("CreateDate", DateUtility.ZeroTime(DateTime.Now))
                .AddLesserOrEqualsCriteria("CreateDate", DateTime.Now);

            GoodsSaleListController.PurchaseOrderCriteria = objectCriteria;
            return objectCriteria;
        }

        #region IDayGoodsSaleListView Members

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
                goodsSaleListController.DayGoodsSaleListView = this;
                goodsSaleListController.CompletedGoodsSaleListSearchEvent += new EventHandler<GoodsSaleListEventArgs>(goodsSaleListController_CompletedGoodsSaleListSearchEvent);
            }
        }

        void goodsSaleListController_CompletedGoodsSaleListSearchEvent(object sender, GoodsSaleListEventArgs e)
        {
            bdsPurchaseOrders.DataSource = e.PurchaseOrderViewList;
            bdsPurchaseOrders.ResetBindings(false);
            long totalAmount = 0;
            foreach (PurchaseOrderView view in e.PurchaseOrderViewList)
            {
                totalAmount += (view.SellAmount - view.ReturnAmount);
            }
            txtTotalAmount.Text = totalAmount.ToString("##,#00");
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

        private void DayGoodsSaleListForm_Load(object sender, EventArgs e)
        {
            FillForm();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = saveFileDialog1.ShowDialog();
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
            
            workbook.Save(fileName);
            MessageBox.Show("Xuất ra tập tin báo cáo thành công!");
        }
    }
}
