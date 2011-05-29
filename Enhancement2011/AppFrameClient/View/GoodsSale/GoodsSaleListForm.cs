using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
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
using AppFrameClient.ViewModel;
//using Aspose.Cells;
using Microsoft.Reporting.WinForms;
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
            goodsSaleListEventArgs.FromDate = DateUtility.ZeroTime(dtpFromDate.Value);
            goodsSaleListEventArgs.ToDate = DateUtility.MaxTime(dtpToDate.Value);
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
            //e.PurchaseOrders.ParentBindingSource = bdsPurchaseOrders;
            bdsPurchaseOrders.DataSource = e.PurchaseOrderViewList;

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
            objectCriteria.AddOrder("CreateDate", false);
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
            #region unused code
            /*DialogResult result = saveFileDialog1.ShowDialog();
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
            MessageBox.Show("Xuất ra tập tin báo cáo thành công!");*/
            #endregion
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dgvSaleList.CurrentRow == null) return;
            PurchaseOrderView currPO = (PurchaseOrderView)bdsPurchaseOrders[dgvSaleList.CurrentRow.Index];
            PrintPage(currPO);
        }

        private void PrintPage(PurchaseOrderView view)
        {
            
            // create bill and printing

            Receipt receipt = new Receipt();
            receipt.PurchaseOrder = view.PurchaseOrder;
            receipt.ReceiptPK = new ReceiptPK { DepartmentId = CurrentDepartment.Get().DepartmentId };
            receipt.CreateDate = DateTime.Now;
            receipt.UpdateDate = DateTime.Now;
            receipt.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
            receipt.CreateId = ClientInfo.getInstance().LoggedUser.Name;
            receipt.ReceiptName = "HDBH";
            receipt.ReceiptNumber = view.PurchaseOrder.PurchaseOrderPK.PurchaseOrderId;
            receipt.TotalAmount = view.SellAmount-view.ReturnAmount;
            receipt.CustomerPayment = 0;
            receipt.Charge = 0;
            view.PurchaseOrder.Receipts = new ArrayList();
            view.PurchaseOrder.Receipts.Add(receipt);
            IList returnDetails = new ArrayList();
            IList purchaseDetails = view.PurchaseOrder.PurchaseOrderDetails;
            int maxIndex = view.PurchaseOrder.PurchaseOrderDetails.Count - 1;
            PurchaseOrder purchaseOrder = view.PurchaseOrder;

            if(view.ReturnPOList !=null && view.ReturnPOList.Count > 0)
            {
                foreach (ReturnPo returnPo in view.ReturnPOList)
                {
                    returnDetails.Add(returnPo);
                }
            }
            

            PurchaseOrderBill = new LocalReport();
            bool isReturnOrder = false;
            if (returnDetails.Count > 0)
            {
                PurchaseOrderBill.ReportEmbeddedResource = "AppFrameClient.Report.ReturnPurchaseOrder.rdlc";

                receipt.ReceiptName = "HDDTH";
                if (purchaseDetails.Count == 0)
                {
                    receipt.ReceiptNumber = receipt.ReceiptNumber + "RET";
                }
                isReturnOrder = true;
            }
            else
            {
                receipt.ReceiptName = "HDBH";
                PurchaseOrderBill.ReportEmbeddedResource = "AppFrameClient.Report.PurchaseOrder.rdlc";

            }

            PurchaseOrderBindingSource.DataSource = view.PurchaseOrder;
            PurchaseOrderDetailCollection printPOD = new PurchaseOrderDetailCollection();
            foreach (PurchaseOrderDetail detail in purchaseDetails)
            {
                printPOD.Add(detail);
            }
            PurchaseOrderDetailCollectionBindingSource.DataSource = CreateNonDuplicate(printPOD);
            ReceiptBindingSource.DataSource = receipt;
            DepartmentBindingSource.DataSource = CurrentDepartment.Get();

            PurchaseOrderDetailBindingSource.DataSource = ObjectConverter.ConvertGenericList<PurchaseOrderDetail>(returnDetails);

            ReportDataSource PODataRDS = new ReportDataSource("AppFrame_Model_PurchaseOrder");
            PODataRDS.Value = PurchaseOrderBindingSource;
            PurchaseOrderBill.DataSources.Add(PODataRDS);

            ReportDataSource PODetRDS = new ReportDataSource("AppFrame_Collection_PurchaseOrderDetailCollection");
            PODetRDS.Value = PurchaseOrderDetailCollectionBindingSource;
            PurchaseOrderBill.DataSources.Add(PODetRDS);

            ReportDataSource DepartmentRDS = new ReportDataSource("AppFrame_Model_Department");
            DepartmentRDS.Value = DepartmentBindingSource;
            PurchaseOrderBill.DataSources.Add(DepartmentRDS);

            ReportDataSource ReceiptRDS = new ReportDataSource("AppFrame_Model_Receipt");
            ReceiptRDS.Value = ReceiptBindingSource;
            PurchaseOrderBill.DataSources.Add(ReceiptRDS);


            ReportDataSource POReturnDetRDS = new ReportDataSource("AppFrame_Model_PurchaseOrderDetail");
            POReturnDetRDS.Value = PurchaseOrderDetailBindingSource;
            PurchaseOrderBill.DataSources.Add(POReturnDetRDS);

            //this.reportPurchaseOrder.LocalReport.Refresh();
            PrintDirectlyToPrinter();

        }

        private LocalReport PurchaseOrderBill = null;
        private void PrintDirectlyToPrinter()
        {
            streamList.Clear();
            //const string printerName = "Epson TM-T88IV";
            var configurationAppSettings = new AppSettingsReader();
            string printerName = (string)configurationAppSettings.GetValue("PrinterName", typeof(String));
            PrintDocument printDoc = new PrintDocument();
            printDoc.PrinterSettings.PrinterName = printerName;

            if (!printDoc.PrinterSettings.IsValid)
            {
                MessageBox.Show(String.Format("Can't find printer \"{0}\".", printerName));

                return;
            }
            PageSettings pageSettings = printDoc.PrinterSettings.DefaultPageSettings;
            pageSettings.PrinterResolution.X = 180;
            pageSettings.PrinterResolution.Y = 180;

            printDoc.PrintPage += new PrintPageEventHandler(printDoc_PrintPage);
            printDoc.EndPrint += new PrintEventHandler(printDoc_EndPrint);    
            printDoc.Print();
            

        }

        void printDoc_EndPrint(object sender, PrintEventArgs e)
        {
            
            // empty data sources
            PurchaseOrderBindingSource.DataSource = null;

            PurchaseOrderDetailCollectionBindingSource.DataSource = null;
            ReceiptBindingSource.DataSource = null;
            DepartmentBindingSource.DataSource = null;
            PurchaseOrderDetailBindingSource.DataSource = null;
            // empty printing report
            PurchaseOrderBill = null;
        }

        IList<Stream> streamList = new List<Stream>();
        private Stream CreateStream(string name, string fileNameExtension, Encoding encoding,
                              string mimeType, bool willSeek)
        {
            //Stream stream = new FileStream(name + "." + fileNameExtension, FileMode.Create);
            //Stream stream = new FileStream(name + "." + fileNameExtension, FileMode.Create,FileAccess.ReadWrite);
            Stream stream = new MemoryStream(new byte[1024 * 64]);
            //Stream test1= new MemoryStream()
            streamList.Add(stream);
            return stream;
        }

        void printDoc_PrintPage(object sender, PrintPageEventArgs e)
        {

            string deviceInfo =
          "<DeviceInfo>" +
          "  <OutputFormat>EMF</OutputFormat>" +
          "  <PageWidth>2.8in</PageWidth>" +
          "  <PageHeight>8in</PageHeight>" +
          "  <DpiX>180</DpiX>" +
          "  <DpiY>180</DpiY>" +
          "  <MarginTop>0.0in</MarginTop>" +
          "  <MarginLeft>0.0in</MarginLeft>" +
          "  <MarginRight>0.0in</MarginRight>" +
          "  <MarginBottom>0.0in</MarginBottom>" +
          "</DeviceInfo>";
            Warning[] warnings;
            if (PurchaseOrderBill == null)
            {
                return;
            }
            
            PurchaseOrderBill.Render("Image", deviceInfo, CreateStream, out warnings);
            if (streamList.Count > 0)
            {
                foreach (Stream stream in streamList)
                {
                    stream.Position = 0;
                }
                Metafile pageImage = new Metafile(streamList[0]);

                e.Graphics.DrawImage(pageImage, 0, 0);
            }

        }

        private PurchaseOrderDetailCollection CreateNonDuplicate(PurchaseOrderDetailCollection list)
        {
            PurchaseOrderDetailCollection newList = new PurchaseOrderDetailCollection();
            foreach (PurchaseOrderDetail detail in list)
            {
                PurchaseOrderDetail newDetail = null;
                if (!ExistInList(newList, detail, out newDetail))
                {
                    newList.Add(detail);
                }
                else
                {
                    newDetail.Quantity += detail.Quantity;
                    //newDetail.Price = detail.Price;
                }
            }

            return newList;
        }

        private bool ExistInList(PurchaseOrderDetailCollection newList, PurchaseOrderDetail detail, out PurchaseOrderDetail newDetail)
        {
            foreach (PurchaseOrderDetail orderDetail in newList)
            {
                if (orderDetail.ProductMaster.ProductName.Equals(detail.ProductMaster.ProductName))
                {
                    newDetail = orderDetail;
                    return true;
                }
            }
            newDetail = null;
            return false;
        }
    }
}
