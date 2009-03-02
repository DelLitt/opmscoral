using System;
using System.Collections;
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
using AppFrame.ModelCriteria;
using AppFrame.Presenter.GoodsSale;
using AppFrame.Utility;
using AppFrame.View.GoodsSale;
//using Aspose.Cells;
using Aspose.Cells;
using ArrayList=System.Collections.ArrayList;

namespace AppFrameClient.View.GoodsSale
{
    public partial class GoodsSaleListForm : BaseForm,IGoodsSaleListView
    {
        private PurchaseOrderCollection pOList;
        public GoodsSaleListForm()
        {
            InitializeComponent();
            pOList = new PurchaseOrderCollection(bdsPurchaseOrders);
            bdsPurchaseOrders.DataSource = pOList;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            
            GoodsSaleListEventArgs goodsSaleListEventArgs = new GoodsSaleListEventArgs();
            goodsSaleListEventArgs.PurchaseOrderSearchCriteria = CreateCriteria();
            EventUtility.fireEvent(GoodsSaleListSearchEvent,this,goodsSaleListEventArgs);
        }



        #region IGoodsSaleListView Members

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
                goodsSaleListController.GoodsSaleListView = this;
                goodsSaleListController.CompletedGoodsSaleListSearchEvent += new EventHandler<GoodsSaleListEventArgs>(goodsSaleListController_CompletedGoodsSaleListSearchEvent);
            }
        }

        void goodsSaleListController_CompletedGoodsSaleListSearchEvent(object sender, GoodsSaleListEventArgs e)
        {
            e.PurchaseOrders.ParentBindingSource = bdsPurchaseOrders;
            bdsPurchaseOrders.DataSource = e.PurchaseOrders;

            long totalAmount = 0;
            foreach(PurchaseOrder purchaseOrder in e.PurchaseOrders)
            {
                totalAmount += purchaseOrder.PurchasePrice;
            }
            txtTotalAmount.Text = totalAmount.ToString("##,##0");
        }

        public event EventHandler<AppFrame.Presenter.GoodsSale.GoodsSaleListEventArgs> GoodsSaleListSearchEvent;

        public event EventHandler<AppFrame.Presenter.GoodsSale.GoodsSaleListEventArgs> ExportToExcelEvent;

        public event EventHandler<AppFrame.Presenter.GoodsSale.GoodsSaleListEventArgs> PrintGoodsSaleEvent;

        #endregion

        public void FormToModel()
        {
            base.FormToModel();
        }
        public void ModelToForm()
        {
            base.ModelToForm();            
        }
        public ObjectCriteria CreateCriteria()
        {
            // create new criteria
            GoodsSaleListController.PurchaseOrderCriteria = new ObjectCriteria();       
         
            ObjectCriteria objectCriteria = GoodsSaleListController.PurchaseOrderCriteria;
            // search like Bill Number
            if(!string.IsNullOrEmpty(txtBillNumber.Text))
            {
                objectCriteria.AddLikeCriteria("PurchaseOrderId", "%" + txtBillNumber.Text + "%");
            }
            // search from date 1 to date 2
            DateTime dateTime = new DateTime();                        
            objectCriteria.AddGreaterOrEqualsCriteria("CreateDate", DateUtility.ZeroTime(dtpFromDate.Value))
                .AddLesserOrEqualsCriteria("CreateDate", DateUtility.MaxTime(dtpToDate.Value));

            GoodsSaleListController.PurchaseOrderCriteria = objectCriteria;
            return objectCriteria;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
            goodsSaleListController.CompletedGoodsSaleListSearchEvent -= new EventHandler<GoodsSaleListEventArgs>(goodsSaleListController_CompletedGoodsSaleListSearchEvent);
        }

        #region IGoodsSaleListView Members


        public event EventHandler<GoodsSaleListEventArgs> SelectGoodsSaleEvent;

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = saveFileDialog1.ShowDialog();
            if (result == DialogResult.Cancel)
            {
                return;
            }

            string fileName = saveFileDialog1.FileName;
            Workbook workbook = new Workbook();
            
            string path = Path.GetDirectoryName(Application.ExecutablePath)+ "\\Templates\\GoodsSaleListTemplate.xls";
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
            MessageBox.Show("Xuất ra tập tin báo cáo thành công!");
        }
    }
}
