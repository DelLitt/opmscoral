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
using AppFrame.Collection;
using AppFrame.Common;
using AppFrame.Controls;
using AppFrame.Exceptions;
using AppFrame.Model;
using AppFrame.Presenter.GoodsIO;
using AppFrame.Presenter.GoodsSale;
using AppFrame.Utility;
using AppFrame.View.GoodsSale;
using AppFrameClient.Common;
using AppFrameClient.View.GoodsIO;
using AppFrameClient.View.GoodsIO.DepartmentStockData;
using Microsoft.Reporting.WinForms;


namespace AppFrameClient.View.GoodsSale
{
    public partial class GoodsSaleForm : BaseForm,IGoodsSaleView
    {
        private PurchaseOrderDetailCollection pODList;
        public GoodsSaleForm()
        {
            InitializeComponent();
            pODList = new PurchaseOrderDetailCollection(bdsBill);
            bdsBill.DataSource = pODList;
            dgvBill.DataError += new DataGridViewDataErrorEventHandler(dgvBill_DataError);
            
        }

        void dgvBill_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if(dgvBill.CurrentCell.OwningColumn.Name.Equals("columnProductId"))
            {
                
            }
        }


        #region IGoodsSaleView Members

        private IGoodsSaleController goodsSaleController;
        public AppFrame.Presenter.GoodsSale.IGoodsSaleController GoodsSaleController
        {
            get
            {
                return goodsSaleController;
            }
            set
            {
                goodsSaleController = value;
                goodsSaleController.GoodsSaleView = this;
                goodsSaleController.CompletedSavePurchaseOrderEvent += new EventHandler<GoodsSaleEventArgs>(goodsSaleController_CompletedSavePurchaseOrderEvent);
            }
        }

        
        void goodsSaleController_CompletedSavePurchaseOrderEvent(object sender, GoodsSaleEventArgs e)
        {
            MessageBox.Show("Lưu đơn hàng thành công!");
            ClearGoodsSaleForm();
        }

        private void ClearGoodsSaleForm()
        {
            ClearInput();
            txtCustomer.Text = "";
            txtBillNumber.Text = "";
            pODList.Clear();
            txtPayment.Text = "";
            txtTotalAmount.Text = "";
            txtCharge.Text = "";
            txtTax.Text = "5%";
            PurchaseOrderBill = null;
            ReturnPurchaseOrder = null;
            GoodsSaleController.PurchaseOrder = null;
        }

        public event EventHandler<AppFrame.Presenter.GoodsSale.GoodsSaleEventArgs> AddGoodsEvent;

        public event EventHandler<AppFrame.Presenter.GoodsSale.GoodsSaleEventArgs> DeleteGoodsEvent;

        public event EventHandler<AppFrame.Presenter.GoodsSale.GoodsSaleEventArgs> HelpEvent;

        public event EventHandler<AppFrame.Presenter.GoodsSale.GoodsSaleEventArgs> FirstRecordEvent;

        public event EventHandler<AppFrame.Presenter.GoodsSale.GoodsSaleEventArgs> PreviousRecordEvent;

        public event EventHandler<AppFrame.Presenter.GoodsSale.GoodsSaleEventArgs> NextRecordEvent;

        public event EventHandler<AppFrame.Presenter.GoodsSale.GoodsSaleEventArgs> LastRecordEvent;

        public event EventHandler<AppFrame.Presenter.GoodsSale.GoodsSaleEventArgs> PrintCheckEvent;

        public event EventHandler<AppFrame.Presenter.GoodsSale.GoodsSaleEventArgs> SaveCheckEvent;

        public event EventHandler<AppFrame.Presenter.GoodsSale.GoodsSaleEventArgs> ResetCheckEvent;

        public event EventHandler<AppFrame.Presenter.GoodsSale.GoodsSaleEventArgs> CloseFormEvent;

        public event EventHandler<AppFrame.Presenter.GoodsSale.GoodsSaleEventArgs> SavePurchaseOrderEvent;

        #endregion
        
        

        private void btnClose_Click(object sender, EventArgs e)
        {
            GoodsSaleController.CompletedSavePurchaseOrderEvent -= new EventHandler<GoodsSaleEventArgs>(goodsSaleController_CompletedSavePurchaseOrderEvent);
            Close();
            
            
        }

        /*private void dgvBill_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            dgvBill.ShowCellToolTips = true;
            //clear combobox
            if (dgvBill.CurrentCell.OwningColumn.Name.Equals("columnProductId"))
            {
                ComboBox comboBox = ((ComboBox) e.Control);
                comboBox.DroppedDown = false;
                comboBox.DropDown += new EventHandler(comboBox_DropDown);
                comboBox.DataSource = null;
                comboBox.Text = (string)dgvBill.CurrentCell.Value;
                
                e.Control.KeyUp += new KeyEventHandler(Control_KeyUp);
            }
            

        }

        void comboBox_DropDown(object sender, EventArgs e)
        {

            FillProductToComboBox(sender, "ProductId");
            
        }

        void Control_KeyUp(object sender, KeyEventArgs e)
        {
            ComboBox comboBox = (ComboBox) sender;
                if (e.KeyCode == Keys.F3 || comboBox.DroppedDown)
                {
                    
                    if (dgvBill.CurrentCell.OwningColumn.Name.Equals("columnProductId"))
                    {

                        FillProductToComboBox(sender, "ProductId");
                    }
                }

                // incase read from scanner
                if(!string.IsNullOrEmpty(comboBox.Text) 
                    && comboBox.Text.Length==CommonConstants.PRODUCT_ID_LENGTH)
                {
                    dgvBill.EndEdit();
                    // focus at last cell
                    dgvBill.CurrentCell = dgvBill[0, dgvBill.Rows.Count - 1];
                }
            
            
        }
        


        private void FillProductToComboBox(object box, string displayMember)
        {
            //((ComboBox) sender).DroppedDown = true;
            // push value to combo box of columnProductId
            if (!(box is ComboBox))
            {
                return;
            }
            //MessageBox.Show(dgvBill.CurrentCell.ColumnIndex.ToString());
            pODList[dgvBill.CurrentRow.Index].ProductMaster.ProductMasterId = ((ComboBox)box).Text;
            if (((ComboBox)box).DataSource == null)
            {
                GoodsSaleEventArgs goodsSaleEventArgs = new GoodsSaleEventArgs();
                goodsSaleEventArgs.SelectedIndex = dgvBill.CurrentRow.Index;
                goodsSaleEventArgs.SelectedPurchaseOrderDetail = pODList[dgvBill.CurrentRow.Index];
                goodsSaleEventArgs.IsFillComboBox = true;
                goodsSaleEventArgs.ComboBoxDisplayMember = displayMember;
                EventUtility.fireEvent<GoodsSaleEventArgs>(FillProductToComboEvent, box, goodsSaleEventArgs);
            }
        }*/
        private void CreateRowNumbers()
        {
            foreach(DataGridViewRow row in dgvBill.Rows)
            {
                dgvBill.Rows[row.Index].HeaderCell.Value = row.Index + 1;
                dgvBill.InvalidateRow(row.Index);
            }
            dgvBill.Refresh();
            dgvBill.Invalidate();
            
        }


        private void GoodsSaleForm_Load(object sender, EventArgs e)
        {
            timer1.Start();
            Department currentDepartment = CurrentDepartment.Get();
            txtDepartment.Text = currentDepartment.DepartmentName;
            txtEmployee.Text = ClientInfo.getInstance().LoggedUser.Name;
            txtWorkingTime.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
            //this.reportPurchaseOrder.RefreshReport();
            //this.reportPurchaseOrder.RefreshReport();
            txtBarcode.Focus();
            //btnAdd_Click(this, null);
            
        }




        #region IGoodsSaleView Members


        public event EventHandler<GoodsSaleEventArgs> FillProductToComboEvent;

        #endregion

        

        private void btnAdd_Click(object sender, EventArgs e)
        {
            PurchaseOrderDetail orderDetail = pODList.AddNew();
            orderDetail.CreateId = ClientInfo.getInstance().LoggedUser.Name;
            orderDetail.CreateDate = DateTime.Now;
            orderDetail.UpdateDate = DateTime.Now;
            orderDetail.UpdateId = orderDetail.CreateId;
            orderDetail.DelFlg = 0;
            orderDetail.DepartmentId = CurrentDepartment.Get().DepartmentId;
            orderDetail.Quantity = 1;
            if (GoodsSaleController.PurchaseOrder == null)
            {
                PurchaseOrder order = new PurchaseOrder();
                GoodsSaleController.PurchaseOrder = order;
            }
            orderDetail.PurchaseOrder = GoodsSaleController.PurchaseOrder;
            PurchaseOrderDetailPK purchaseOrderDetailPK = new PurchaseOrderDetailPK();
            purchaseOrderDetailPK.DepartmentId = CurrentDepartment.Get().DepartmentId;
            orderDetail.PurchaseOrderDetailPK = purchaseOrderDetailPK;


            // new product to test
            ProductMaster productMaster = new ProductMaster();
            orderDetail.ProductMaster = productMaster;
            Product product = new Product();
            product.ProductMaster = orderDetail.ProductMaster;
            orderDetail.Product = product;

            GoodsSaleController.PurchaseOrder.PurchaseOrderDetails =
                ObjectConverter.ConvertToNonGenericList<PurchaseOrderDetail>(pODList);
            bdsBill.EndEdit();
            //bdsBill.EndEdit();
        }

        #region IGoodsSaleView Members


        public event EventHandler<GoodsSaleEventArgs> LoadGoodsEvent;

        #endregion

        private void dgvBill_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvBill.CurrentCell == null)
            {
                return;
            }
            try
            {
                if (dgvBill.Columns[e.ColumnIndex].Name.Equals("columnProductId"))
                {
                    
                }
                else
                {
                    GoodsSaleController.PurchaseOrder.PurchasePrice = CalculateTotalPrice(pODList);
                    txtTotalAmount.Text = GoodsSaleController.PurchaseOrder.PurchasePrice.ToString();
                    bdsBill.EndEdit();
                    CalculateCharge();
                }
            }
            catch(Exception ex)
            {
                dgvBill[e.ColumnIndex, e.RowIndex].Value = "";
                //MessageBox.Show("Mã sản phẩm không hợp lệ hoặc lỗi khi nhập");
            }
            finally
            {
                RemoveEmptyProductMasterIdRow();
                bdsBill.EndEdit();
            }

        }

        private void CalculateCharge()
        {
            if (string.IsNullOrEmpty(txtPayment.Text))
            {
                long payment = 0;
                txtCharge.Text = (payment - long.Parse(txtTotalAmount.Text)).ToString();
            }
            else
            {
                if (!string.IsNullOrEmpty(txtPayment.Text) && !string.IsNullOrEmpty(txtTotalAmount.Text))
                {
                    txtCharge.Text = (long.Parse(txtPayment.Text) - long.Parse(txtTotalAmount.Text)).ToString();
                }
            }
        }

        private long CalculateTotalPrice(PurchaseOrderDetailCollection list)
        {
            long totalAmount = 0;
            if(pODList == null)
            {
                return totalAmount;
            }
            foreach(PurchaseOrderDetail purchaseOrderDetail in list)
            {
                totalAmount += purchaseOrderDetail.Price * purchaseOrderDetail.Quantity;                
            }
            return totalAmount;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //DataGridViewSelectedCellCollection rows = dgvBill.SelectedCells;
            if(dgvBill.CurrentCell!=null)
            {
                pODList.RemoveAt(dgvBill.CurrentCell.OwningRow.Index);
                GoodsSaleController.PurchaseOrder.PurchaseOrderDetails =
                ObjectConverter.ConvertToNonGenericList<PurchaseOrderDetail>(pODList);
                bdsBill.EndEdit();
                dgvBill.Focus();

                GoodsSaleController.PurchaseOrder.PurchasePrice = CalculateTotalPrice(pODList);
                txtTotalAmount.Text = GoodsSaleController.PurchaseOrder.PurchasePrice.ToString();
                CalculateCharge();
            }
            
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!CheckErrorOnForm())
            {
                return;
            }
            RemoveEmptyProductMasterIdRow();
            FormToModel();
            GoodsSaleEventArgs eventArgs = new GoodsSaleEventArgs();
            EventUtility.fireEvent(SavePurchaseOrderEvent, this, eventArgs);
            // clear form and add new
            if (!eventArgs.HasErrors)
            {
                MessageBox.Show("Lưu đơn hàng thành công!");
                ClearGoodsSaleForm();
            }
            else
            {
                MessageBox.Show(" Có lỗi khi lưu hoá đơn ");
            }
            //btnAdd_Click(this, null);
        }

        private void RemoveEmptyProductMasterIdRow()
        {
            int lastIndex = pODList.Count - 1;
            while (lastIndex >= 0)
            {
                PurchaseOrderDetail purchaseOrderDetail = pODList[lastIndex];
                if(string.IsNullOrEmpty(purchaseOrderDetail.ProductMaster.ProductMasterId))
                {
                    pODList.RemoveAt(lastIndex);
                }
                lastIndex -= 1;
            }
        }

        private bool CheckErrorOnForm()
        {
            if(pODList.Count == 0 )
            {
                MessageBox.Show("Đơn hàng rỗng, vì vậy không hợp lệ");
                return false;
            }
            
            if (int.Parse(txtCharge.Text) < 0)
            {
                if (string.IsNullOrEmpty(txtTotalAmount.Text) || int.Parse(txtTotalAmount.Text) <= 0)
                {
                    MessageBox.Show("Giá trị đơn hàng phải lớn hơn 0");
                    return false;
                }

                if (string.IsNullOrEmpty(txtPayment.Text))
                {
                    MessageBox.Show("Hãy nhập vào số tiền khách hàng trả !");
                    return false;
                }

                MessageBox.Show("Số tiền trả chưa đủ !");
                return false;
            }   
            
            return true;
        }

        public override void FormToModel()
        {
            PurchaseOrder purchaseOrder = GoodsSaleController.PurchaseOrder;
            purchaseOrder.DepartmentId = CurrentDepartment.Get().DepartmentId;
            
            purchaseOrder.CreateDate = DateTime.Now;
            purchaseOrder.CreateId = ClientInfo.getInstance().LoggedUser.Name;
            purchaseOrder.UpdateDate = DateTime.Now;
            purchaseOrder.UpdateId = ClientInfo.getInstance().LoggedUser.Name;            
            PurchaseOrderPK purchaseOrderPK = new PurchaseOrderPK();
            purchaseOrderPK.DepartmentId = CurrentDepartment.Get().DepartmentId;
            purchaseOrder.PurchasePrice = long.Parse(txtTotalAmount.Text);
            purchaseOrder.DelFlg = 0;
            purchaseOrder.PurchaseOrderPK = purchaseOrderPK;
            purchaseOrder.PurchaseOrderDetails = ObjectConverter.ConvertToNonGenericList<PurchaseOrderDetail>(pODList);
            GoodsSaleController.PurchaseOrder = purchaseOrder;
        }

        private void txtPayment_TextChanged(object sender, EventArgs e)
        {
           CalculateCharge();
        }

        private Bitmap printBitmap = null;
        GoodsSalePrintForm printForm=null;
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (!CheckErrorOnForm())
            {
                return;
            }
            if(GoodsSaleController.PurchaseOrder == null || pODList.Count == 0)
            {
                MessageBox.Show(" Không có hàng để lưu hóa đơn");
                return;
            }
            RemoveEmptyProductMasterIdRow();
            FormToModel();
            if(!string.IsNullOrEmpty(txtCustomer.Text))
            {
                GoodsSaleController.PurchaseOrder.Customer = new Customer{CustomerName = txtCustomer.Text};
            }
            Receipt receipt = new Receipt();
            receipt.PurchaseOrder = GoodsSaleController.PurchaseOrder;
            receipt.ReceiptPK = new ReceiptPK{ DepartmentId = CurrentDepartment.Get().DepartmentId};
            receipt.CreateDate = DateTime.Now;
            receipt.UpdateDate = DateTime.Now;
            receipt.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
            receipt.CreateId = ClientInfo.getInstance().LoggedUser.Name;
            receipt.ReceiptName = "HDBH";
            receipt.ReceiptNumber = GoodsSaleController.PurchaseOrder.PurchaseOrderPK.PurchaseOrderId;
            receipt.TotalAmount = Int64.Parse(string.IsNullOrEmpty(txtTotalAmount.Text)?"0":txtTotalAmount.Text);
            receipt.CustomerPayment = Int64.Parse(string.IsNullOrEmpty(txtPayment.Text)?"0":txtPayment.Text);
            receipt.Charge = Int64.Parse(string.IsNullOrEmpty(txtCharge.Text)?"0":txtCharge.Text);
            GoodsSaleController.PurchaseOrder.Receipts = new ArrayList();
            GoodsSaleController.PurchaseOrder.Receipts.Add(receipt);
                        
            GoodsSaleEventArgs eventArgs = new GoodsSaleEventArgs();
            if(ReturnPurchaseOrder!=null)
            {
                eventArgs.RefPurchaseOrder = ReturnPurchaseOrder;
            }
            EventUtility.fireEvent(SavePurchaseOrderEvent, this, eventArgs);
            if (eventArgs.HasErrors)
            {
                MessageBox.Show("Có lỗi khi lưu hoá đơn");
                return;
            }

            IList returnDetails = new ArrayList();
            IList purchaseDetails = GoodsSaleController.PurchaseOrder.PurchaseOrderDetails;
            int maxIndex = GoodsSaleController.PurchaseOrder.PurchaseOrderDetails.Count-1;
            PurchaseOrder purchaseOrder = GoodsSaleController.PurchaseOrder;
            while(maxIndex >= 0)
            {
                PurchaseOrderDetail detail = (PurchaseOrderDetail)purchaseDetails[maxIndex];
                if (detail.PurchaseOrder != null
                   && detail.PurchaseOrder.PurchaseOrderPK != null
                   && !string.IsNullOrEmpty(detail.PurchaseOrder.PurchaseOrderPK.PurchaseOrderId)
                   && !detail.PurchaseOrder.PurchaseOrderPK.PurchaseOrderId.Equals(purchaseOrder.PurchaseOrderPK.PurchaseOrderId) )
                {
                    if(detail.Price < 0 )
                    {
                        detail.Price = 0 - detail.Price;
                    }
                    returnDetails.Add(detail);
                    purchaseDetails.RemoveAt(maxIndex);
                }
                maxIndex -= 1;
            }

            /*printForm = new GoodsSalePrintForm();
            printForm.FillForm(GoodsSaleController.PurchaseOrder);
            printForm.Show();
            printForm.Shown += new EventHandler(printForm_Shown);*/

            
            /*reportPurchaseOrder.LocalReport.DataSources.Add(new ReportDataSource("Department",CurrentDepartment.Get()));
            reportPurchaseOrder.LocalReport.DataSources.Add(new ReportDataSource("PurchaseOrder",GoodsSaleController.PurchaseOrder));
            reportPurchaseOrder.LocalReport.DataSources.Add(new ReportDataSource("PurchaseOrderDetail", pODList));*/
            PurchaseOrderBill = new LocalReport();
            bool isReturnOrder = false;
            if(returnDetails.Count > 0 )
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

            this.PurchaseOrderBindingSource.DataSource = goodsSaleController.PurchaseOrder;
            PurchaseOrderDetailCollection printPOD = new PurchaseOrderDetailCollection();
            foreach (PurchaseOrderDetail detail in purchaseDetails)
            {
                printPOD.Add(detail);
            }
            this.PurchaseOrderDetailCollectionBindingSource.DataSource = CreateNonDuplicate(printPOD);
            this.ReceiptBindingSource.DataSource = receipt;
            this.DepartmentBindingSource.DataSource = CurrentDepartment.Get();

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
                
            

            /*this.PurchaseOrderDetailBindingSource.DataSource =
                ObjectConverter.ConvertGenericList<PurchaseOrderDetail>(args.ReturnPurchaseOrderDetails);

            this.PurchaseOrderDetailCollectionBindingSource.DataSource = pODNewList;



            this.DepartmentBindingSource.DataSource = CurrentDepartment.Get();

            this.PurchaseOrderBindingSource.DataSource = goodsSaleController.PurchaseOrder;
            this.PurchaseOrderDetailCollectionBindingSource.DataSource = CreateNonDuplicate(pODList);
            this.ReceiptBindingSource.DataSource = receipt;*/

            /*string deviceInfo = "<DeviceInfo>" +
            "  <OutputFormat>EMF</OutputFormat>" +
            "  <PageWidth>3.145in</PageWidth>" +
            "  <PageHeight>5.3in</PageHeight>" +
            "  <MarginTop>0.0in</MarginTop>" +
            "  <MarginLeft>0.0in</MarginLeft>" +
            "  <MarginRight>0.0in</MarginRight>" +
            "  <MarginBottom>0.0in</MarginBottom>" +
            "</DeviceInfo>";
            Warning[] warnings;*/

            this.reportPurchaseOrder.LocalReport.Refresh();
            PrintDirectlyToPrinter();
            ClearGoodsSaleForm();
            ClearReturnInput();
            ClearInput();

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
            
            printDoc.Print();
            

        }

        IList<Stream> streamList = new List<Stream>();
        private Stream CreateStream(string name, string fileNameExtension, Encoding encoding,
                              string mimeType, bool willSeek)
        {
            //Stream stream = new FileStream(name + "." + fileNameExtension, FileMode.Create);
            //Stream stream = new FileStream(name + "." + fileNameExtension, FileMode.Create,FileAccess.ReadWrite);
            Stream stream = new MemoryStream(new byte[1024*64]);
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
            if(PurchaseOrderBill == null)
            {
                return;
            }
            /*this.reportPurchaseOrder.LocalReport.Refresh();
            this.reportPurchaseOrder.LocalReport.Render("Image", deviceInfo, CreateStream, out warnings);*/
            PurchaseOrderBill.Render("Image", deviceInfo, CreateStream, out warnings);
            if (streamList.Count > 0)
            {
                foreach (Stream stream in streamList)
                {
                    stream.Position = 0;
                }
                Metafile pageImage = new Metafile(streamList[0]);
                
                e.Graphics.DrawImage(pageImage, 0,0);
            }

        }

        private PurchaseOrderDetailCollection CreateNonDuplicate(PurchaseOrderDetailCollection list)
        {
            PurchaseOrderDetailCollection newList = new PurchaseOrderDetailCollection();
            foreach (PurchaseOrderDetail detail in list)
            {
               PurchaseOrderDetail newDetail = null;
               if(!ExistInList(newList,detail,out newDetail))
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

        private bool ExistInList(PurchaseOrderDetailCollection newList,PurchaseOrderDetail detail, out PurchaseOrderDetail newDetail)
        {
            foreach (PurchaseOrderDetail orderDetail in newList)
            {
                if(orderDetail.ProductMaster.ProductName.Equals(detail.ProductMaster.ProductName))
                {
                    newDetail = orderDetail;
                    return true;
                }
            }
            newDetail = null;
            return false;
        }


        void printForm_Shown(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(500);
            printBitmap = printForm.CreateBitmap();
            //printForm.Close();
            //printBillDocument.Print();
            DialogResult result = printBillDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                printBillDocument.Print();
            }
            if (printForm != null)
            {
                printForm.Shown -= new EventHandler(printForm_Shown);
                printForm.Close();
            }
            printForm = null;
        }

        private void printBillDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if(printBitmap == null)
            {
                return;
            }
            e.Graphics.DrawImage(printBitmap, 0, 0);

        }

        private void printBillDocument_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            // clear form and add new
            //btnAdd_Click(this, null);
            ClearGoodsSaleForm();
        }

        private ProductMasterSearchDepartmentForm form = null;
        private PurchaseOrder ReturnPurchaseOrder = null;

        private void dgvBill_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /*if(dgvBill.CurrentCell.ColumnIndex == 0)
            {
                form = GlobalUtility.GetOnlyChildFormObject<ProductMasterSearchDepartmentForm>(GlobalCache.Instance().MainForm, FormConstants.PRODUCT_MASTER_SEARCH_DEPARMENT_FORM);
                form.SelectProductEvent += new EventHandler<AppFrame.Presenter.GoodsIO.ProductMasterSearchDepartmentEventArgs>(form_SelectProductEvent);
                if(form!=null)
                    form.Show();
            }*/
        }

        void form_SelectProductEvent(object sender, AppFrame.Presenter.GoodsIO.ProductMasterSearchDepartmentEventArgs e)
        {
            /*pODList[dgvBill.CurrentCell.OwningRow.Index].Product = e.ReturnProduct;
            GoodsSaleEventArgs goodsSaleEventArgs = new GoodsSaleEventArgs();
            int selectedIndex = dgvBill.CurrentCell.OwningRow.Index;
            goodsSaleEventArgs.SelectedIndex = selectedIndex;
            goodsSaleEventArgs.SelectedPurchaseOrderDetail = bdsBill[selectedIndex] as PurchaseOrderDetail;
            
            EventUtility.fireEvent(LoadGoodsEvent, this, goodsSaleEventArgs);

            // event has been modified
            pODList[selectedIndex] = goodsSaleEventArgs.SelectedPurchaseOrderDetail;
            GoodsSaleController.PurchaseOrder.PurchasePrice = CalculateTotalPrice(pODList);
            txtTotalAmount.Text = GoodsSaleController.PurchaseOrder.PurchasePrice.ToString();
            CalculateCharge();
            bdsBill.EndEdit();*/
            txtBarcode.Text = e.ReturnProduct.ProductId;
            //txtGoodsName.Text = e.ReturnProduct.ProductMaster.ProductFullName;
            txtQuantity.Text = "1";
            if(form!=null)
            {
                form.SelectProductEvent -= new EventHandler<AppFrame.Presenter.GoodsIO.ProductMasterSearchDepartmentEventArgs>(form_SelectProductEvent);
                form.Close();
            }
        }

        private void GoodsSaleForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            goodsSaleController.PurchaseOrder = null;
            timer1.Stop();
        }

        

        private void RemoveEmptyRowFromList(PurchaseOrderDetailCollection list)
        {
            int maxId = list.Count - 1;
            while (maxId >= 0)
            {
                PurchaseOrderDetail orderDetail = list[maxId];

                if (orderDetail.Product == null 
                    || orderDetail.Product.ProductMaster == null 
                   || string.IsNullOrEmpty(orderDetail.Product.ProductMaster.ProductMasterId))
                {
                    list.RemoveAt(maxId);
                }
                maxId -= 1;
            }

            if (list.Count < 2)
            {
                return;
            }
            for (int i = 0; i < list.Count - 1; i++)
            {
                PurchaseOrderDetail detail = (PurchaseOrderDetail)list[i];
                for (int j = list.Count - 1; j >= i + 1; j--)
                {
                    PurchaseOrderDetail compdetail = (PurchaseOrderDetail)list[j];
                    if (detail.Product.ProductId == compdetail.Product.ProductId
                        && (detail.PurchaseOrderDetailPK!=null && compdetail.PurchaseOrderDetailPK!= null)
                        && compdetail.PurchaseOrderDetailPK.PurchaseOrderId == detail.PurchaseOrderDetailPK.PurchaseOrderId)
                    {
                        detail.Quantity += compdetail.Quantity;
                        list.RemoveAt(j);
                    }
                }
            }

        }

        // ĐANG SỬA LẠI
        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {
            
                if (!string.IsNullOrEmpty(txtBarcode.Text) && txtBarcode.Text.Length == CommonConstants.PRODUCT_ID_LENGTH)
                {
                    try
                    {
                    GoodsSaleEventArgs goodsSaleEventArgs = new GoodsSaleEventArgs();
                    /*int selectedIndex = dgvBill.CurrentCell.OwningRow.Index;
                    goodsSaleEventArgs.SelectedIndex = selectedIndex;*/
                    btnAdd_Click(this, null);
                    goodsSaleEventArgs.SelectedPurchaseOrderDetail = pODList[pODList.Count - 1] as PurchaseOrderDetail;
                    goodsSaleEventArgs.SelectedPurchaseOrderDetail.Product.ProductId = txtBarcode.Text;
                    
                    // don ma
                    goodsSaleEventArgs.NotAvailableInStock = true;
                    EventUtility.fireEvent(LoadGoodsEvent, this, goodsSaleEventArgs);

                    // event has been modified
                    pODList[pODList.Count-1] = goodsSaleEventArgs.SelectedPurchaseOrderDetail;
                    int totalNumber = 1;
                    Int32.TryParse(txtQuantity.Text, out totalNumber);
                    if(totalNumber <= 0 )
                    {
                        pODList[pODList.Count - 1].Quantity = 1;
                    } else
                    {
                        pODList[pODList.Count - 1].Quantity = totalNumber;
                    }
                        if(GoodsSaleController.PurchaseOrder== null)
                        {
                            GoodsSaleController.PurchaseOrder = new PurchaseOrder();
                        }
                    GoodsSaleController.PurchaseOrder.PurchasePrice = CalculateTotalPrice(pODList);
                    txtTotalAmount.Text = GoodsSaleController.PurchaseOrder.PurchasePrice.ToString();
                    bdsBill.EndEdit();
                    
                    }
                    catch (Exception ex)
                    {
                        //throw new BusinessException("Mã vạch không hợp lệ hoặc hàng không tồn tại");
                        pODList.RemoveAt(pODList.Count - 1);
                    }
                    finally
                    {
                        CreateRowNumbers();
                        CalculateCharge();
                        RemoveEmptyRowFromList(pODList);
                        ClearInput();
                        txtBarcode.Focus();
                    }
            }
            

        }

        private void ClearInput()
        {
            txtBarcode.Text = "";
            txtGoodsName.Text = "";
            txtQuantity.Text = "1";
            txtTax.Text = "5%";
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            form = GlobalUtility.GetOnlyChildFormObject<ProductMasterSearchDepartmentForm>(GlobalCache.Instance().MainForm, FormConstants.PRODUCT_MASTER_SEARCH_DEPARMENT_FORM);
            form.SelectProductEvent += new EventHandler<AppFrame.Presenter.GoodsIO.ProductMasterSearchDepartmentEventArgs>(form_SelectProductEvent);
            if (form != null)
                form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtBarcode_TextChanged(this, e);
        }

        private void txtBarcode_Enter(object sender, EventArgs e)
        {
            txtBarcode.BackColor = Color.LightGreen;
        }

        private void txtBarcode_Leave(object sender, EventArgs e)
        {
            txtBarcode.BackColor = Color.White;
        }

        private void systemHotkey1_Pressed(object sender, EventArgs e)
        {
            txtBarcode.Focus();
        }

        private void GoodsSaleForm_Shown(object sender, EventArgs e)
        {
            txtBarcode.Focus();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearGoodsSaleForm();
            GoodsSaleController.PurchaseOrder = null;
            PurchaseOrderBill = null;
            ReturnPurchaseOrder = null;
        }

        private void systemHotkey2_Pressed(object sender, EventArgs e)
        {
            if(!dgvBill.Focused || dgvBill.CurrentCell==null)
            {
                return;
            }
            btnDelete_Click(sender,e);
            CreateRowNumbers();
            CalculateCharge();
            RemoveEmptyRowFromList(pODList);

        }

        private void txtCharge_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvBill_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //this method overrides the DataGridView's RowPostPaint event 
            //in order to automatically draw numbers on the row header cells
            //and to automatically adjust the width of the column containing
            //the row header cells so that it can accommodate the new row
            //numbers,

            //store a string representation of the row number in 'strRowNumber'
            string strRowNumber = (e.RowIndex + 1).ToString();

            //prepend leading zeros to the string if necessary to improve
            //appearance. For example, if there are ten rows in the grid,
            //row seven will be numbered as "07" instead of "7". Similarly, if 
            //there are 100 rows in the grid, row seven will be numbered as "007".
            while (strRowNumber.Length < dgvBill.RowCount.ToString().Length) strRowNumber = "0" + strRowNumber;

            //determine the display size of the row number string using
            //the DataGridView's current font.
            SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);

            //adjust the width of the column that contains the row header cells 
            //if necessary
            if (dgvBill.RowHeadersWidth < (int)(size.Width + 20)) dgvBill.RowHeadersWidth = (int)(size.Width + 20);

            //this brush will be used to draw the row number string on the
            //row header cell using the system's current ControlText color
            Brush b = SystemBrushes.ControlText;

            //draw the row number string on the current row header cell using
            //the brush defined above and the DataGridView's default font
            e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));

            //call the base object's OnRowPostPaint method
            //dgvBill.OnRowPostPaint(e);

        }

        private void btnPOLookup_Click(object sender, EventArgs e)
        {
            GoodsReturnChildForm form = GlobalUtility.GetFormObject<GoodsReturnChildForm>(FormConstants.GOODS_RETURN_CHILD_FORM);
            form.SelectReturnGoodsEvent += new EventHandler<GoodsSaleReturnEventArgs>(form_SelectReturnGoodsEvent);
            form.ShowDialog();
        }

        void form_SelectReturnGoodsEvent(object sender, GoodsSaleReturnEventArgs e)
        {
            if(GoodsSaleController.PurchaseOrder == null)
            {
                btnAdd_Click(null,null);
            }
            foreach (PurchaseOrderDetail returnPO in e.ReturnPurchaseOrderDetails)
            {
                returnPO.Price = 0 - returnPO.Price;
                pODList.Add(returnPO);
            }
            bdsBill.EndEdit();
            dgvBill.Refresh();
            dgvBill.Invalidate();
            GoodsSaleController.PurchaseOrder.PurchasePrice = CalculateTotalPrice(pODList);
            txtTotalAmount.Text = GoodsSaleController.PurchaseOrder.PurchasePrice.ToString();

            CreateRowNumbers();
            CalculateCharge();
            RemoveEmptyRowFromList(pODList);
            ClearReturnInput();
            ClearInput();
            txtBarcode.Focus();
            ReturnPurchaseOrder = e.RefPurchaseOrder;
        }

        private void ClearReturnInput()
        {
            txtRetBarCode.Text = "";
            txtRetPrice.Text = "";
            txtRetPrice.ReadOnly = true;
            txtRetProductName.Text = "";
            txtRetQuantity.Text = "1";
            txtRefPurchaseOrder.Text = "";
            txtNote.Text = "";
        }

        private void txtRetBarcodeShortcut_Pressed(object sender, EventArgs e)
        {
            txtRetBarCode.Focus();
        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            if(GoodsSaleController.PurchaseOrder == null)
            {
                btnAdd_Click(null,e);
            }
            string deptId = string.Format("{0:000}", CurrentDepartment.Get().DepartmentId);
            GoodsSaleEventArgs eventArgs = new GoodsSaleEventArgs();
            PurchaseOrder searchRetPurchaseOrder = new PurchaseOrder();
            searchRetPurchaseOrder.PurchaseOrderPK = new PurchaseOrderPK
                                                                       {
                                                                           PurchaseOrderId = txtRefPurchaseOrder.Text,
                                                                           DepartmentId =
                                                                               CurrentDepartment.Get().DepartmentId
                                                                       };
            
            // if purchase order id is UNDEFINED
            if (!string.IsNullOrEmpty(txtRefPurchaseOrder.Text) && txtRefPurchaseOrder.Text.Trim().Equals("000"))
            {
                
                if (string.IsNullOrEmpty(txtRetProductName.Text) // product id is notavailable
                   && string.IsNullOrEmpty(txtRetBarCode.Text)) // bar code is not available 
                {
                    MessageBox.Show(
                        "Nếu muốn trả hàng không đối chứng, xin nhập hoá đơn là 000 và chọn một mã vạch phù hợp.");
                    return;
                }
                
                //searchRetPurchaseOrder.PurchaseOrderPK.PurchaseOrderId = deptId + "UNDEF";
            }
            
            eventArgs.RefPurchaseOrder = searchRetPurchaseOrder;
            EventUtility.fireEvent(FindRefPurchaseOrder,this,eventArgs);

            PurchaseOrder retPurchaseOrder = eventArgs.RefPurchaseOrder;
            PurchaseOrderDetail retOrderDetail = null;
            if (retPurchaseOrder != null)
            {
                foreach (PurchaseOrderDetail orderDetail in retPurchaseOrder.PurchaseOrderDetails)
                {
                    if (orderDetail.Product.ProductId == txtRetBarCode.Text)
                    {
                        retOrderDetail = orderDetail;
                        break;
                    }
                }
            }
            if (retOrderDetail != null)
            {
                retOrderDetail.Quantity = Int64.Parse(txtRetQuantity.Text);
                retOrderDetail.Price = 0 - retOrderDetail.Price;
                pODList.Add(retOrderDetail);
                bdsBill.EndEdit();
                dgvBill.Refresh();
                dgvBill.Invalidate();

                GoodsSaleController.PurchaseOrder.PurchasePrice = CalculateTotalPrice(pODList);
                txtTotalAmount.Text = GoodsSaleController.PurchaseOrder.PurchasePrice.ToString();

                CreateRowNumbers();
                CalculateCharge();
                RemoveEmptyRowFromList(pODList);
                ClearReturnInput();
                ClearInput();
                txtBarcode.Focus();
            }
            else // in case undefined order
            {
                // if it's UNDEFINED purchase order
                if(!string.IsNullOrEmpty(txtRefPurchaseOrder.Text) && txtRefPurchaseOrder.Text.Trim().Equals("000"))
                {
                    // create new undefined order
                    PurchaseOrder undefPurchaseOrder = new PurchaseOrder();
                    undefPurchaseOrder.PurchaseOrderPK = new PurchaseOrderPK
                    {
                        PurchaseOrderId = txtRefPurchaseOrder.Text.Trim(),
                        DepartmentId =
                            CurrentDepartment.Get().DepartmentId
                    };
                    ReturnPurchaseOrder = undefPurchaseOrder;
                    // if defined barcode
                    /*if(!string.IsNullOrEmpty(txtRetProductName.Text))
                    {*/
                        PurchaseOrderDetail specialDetail = new PurchaseOrderDetail { Product = new Product()};
                        specialDetail.Product.ProductId = txtRetBarCode.Text;
                    
                    if (!string.IsNullOrEmpty(specialDetail.Product.ProductId)
                            && specialDetail.Product.ProductId.Equals(CommonConstants.UNDEFINED_BARCODE_MARK))
                        {
                            specialDetail.Product.ProductId = string.Format("{0:000000000000}", 0);
                            if(CheckUtility.IsNullOrEmpty(txtRetPrice.Text))
                            {
                                /*MessageBox.Show("Xin hãy nhập giá của sản phẩm không có mã vạch");
                                return;*/
                            }
                            specialDetail.Price = Int64.Parse(txtRetPrice.Text);
                        }
                        try    // if null , will go to exception
                        {
                            GoodsSaleEventArgs goodsSaleEventArgs = new GoodsSaleEventArgs();
                            goodsSaleEventArgs.SelectedPurchaseOrderDetail = specialDetail;
                            goodsSaleEventArgs.NotAvailableInStock = true;
                            EventUtility.fireEvent(LoadGoodsEvent, this, goodsSaleEventArgs);
                            
                            txtRetProductName.Text = goodsSaleEventArgs.SelectedPurchaseOrderDetail.Product.ProductMaster.ProductName;
                            txtRetPrice.Text = goodsSaleEventArgs.SelectedPurchaseOrderDetail.Price.ToString();
                            specialDetail = goodsSaleEventArgs.SelectedPurchaseOrderDetail;
                            specialDetail.PurchaseOrder = ReturnPurchaseOrder;
                            specialDetail.PurchaseOrderDetailPK = new PurchaseOrderDetailPK
                                                                      {
                                                                          DepartmentId = CurrentDepartment.Get().DepartmentId,
                                                                          PurchaseOrderId = ReturnPurchaseOrder.PurchaseOrderPK.PurchaseOrderId
                                                                      };
                            specialDetail.Quantity = 1;
                            specialDetail.Price = 0 - specialDetail.Price;
                            pODList.Add(specialDetail);
                            bdsBill.EndEdit();
                            dgvBill.Refresh();
                            dgvBill.Invalidate();
                        }
                        catch (Exception ex)
                        {
                            // do nothing
                            MessageBox.Show("Không có mã vạch này");
                        }
                        finally
                        {
                            GoodsSaleController.PurchaseOrder.PurchasePrice = CalculateTotalPrice(pODList);
                            txtTotalAmount.Text = GoodsSaleController.PurchaseOrder.PurchasePrice.ToString();

                            CreateRowNumbers();
                            CalculateCharge();
                            RemoveEmptyRowFromList(pODList);
                            ClearReturnInput();
                            ClearInput();
                            txtBarcode.Focus();
                        }
                    //}
                }
            }
        }
        public event EventHandler<GoodsSaleEventArgs> FindRefPurchaseOrder;

        private void txtRetBarCode_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtRetBarCode.Text))
            {   
                if (txtRetBarCode.Text.Length == CommonConstants.PRODUCT_ID_LENGTH)
                {
                    txtRetProductName.Text = "";
                    string returnBarcode = txtRetBarCode.Text.Trim();
                    try
                    {
                        GoodsSaleEventArgs goodsSaleEventArgs = new GoodsSaleEventArgs();
                        goodsSaleEventArgs.SelectedPurchaseOrderDetail = new PurchaseOrderDetail
                                                                             {Product = new Product()};
                        goodsSaleEventArgs.SelectedPurchaseOrderDetail.Product.ProductId = returnBarcode;
                        goodsSaleEventArgs.NotAvailableInStock = true; // load even it do not available in stock
                        EventUtility.fireEvent(LoadGoodsEvent, this, goodsSaleEventArgs);

                        txtRetProductName.Text =
                            goodsSaleEventArgs.SelectedPurchaseOrderDetail.Product.ProductMaster.ProductName;
                        txtRetPrice.Text = goodsSaleEventArgs.SelectedPurchaseOrderDetail.Price.ToString();

                    }
                    catch (Exception ex)
                    {
                        throw new BusinessException("Mã vạch không hợp lệ hoặc hàng không tồn tại");
                        //pODList.RemoveAt(pODList.Count - 1);
                    }
                    finally
                    {
                        //ClearReturnInput();
                    }
                }
            }
        }

        private ProductMasterSearchDepartmentForm goodsReturnForm = null;
        private void btnRetBarcodeLookup_Click(object sender, EventArgs e)
        {
            goodsReturnForm = GlobalUtility.GetOnlyChildFormObject<ProductMasterSearchDepartmentForm>(GlobalCache.Instance().MainForm, FormConstants.PRODUCT_MASTER_SEARCH_DEPARMENT_FORM);
            goodsReturnForm.SelectProductEvent += new EventHandler<AppFrame.Presenter.GoodsIO.ProductMasterSearchDepartmentEventArgs>(formReturn_SelectProductEvent);
            if (goodsReturnForm != null)
                goodsReturnForm.Show();
        }

        private void formReturn_SelectProductEvent(object sender, ProductMasterSearchDepartmentEventArgs e)
        {
            txtRetBarCode.Text = e.ReturnProduct.ProductId;
            //txtGoodsName.Text = e.ReturnProduct.ProductMaster.ProductFullName;
            txtRetQuantity.Text = "1";
            if (goodsReturnForm != null)
            {
                goodsReturnForm.SelectProductEvent -= new EventHandler<AppFrame.Presenter.GoodsIO.ProductMasterSearchDepartmentEventArgs>(formReturn_SelectProductEvent);
                goodsReturnForm.Close();
            }            
        }

        private void dgvBill_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnReturnOrder_Click(object sender, EventArgs e)
        {

        }

        private void txtRetBarCode_Enter(object sender, EventArgs e)
        {
            txtRetBarCode.BackColor = Color.LightGreen;
        }

        private void txtRetBarCode_Leave(object sender, EventArgs e)
        {
            txtRetBarCode.BackColor = Color.FromKnownColor(KnownColor.Control);
        }

        private void txtRetPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtRetPrice_Enter(object sender, EventArgs e)
        {
            if(!txtRetPrice.ReadOnly)
            {
                txtRetPrice.BackColor = Color.LightYellow;
            }
        }

        private void txtRetPrice_Leave(object sender, EventArgs e)
        {
            txtRetPrice.BackColor = Color.FromKnownColor(KnownColor.Control);
        }

        private void SaveOrderShortcut_Pressed(object sender, EventArgs e)
        {
            btnPrint_Click(null, e);
        }

        private void QuickSaveOrderShortcut_Pressed(object sender, EventArgs e)
        {
            txtPayment.Text = (0 - Int64.Parse(txtCharge.Text)).ToString();
            btnPrint_Click(null,e);
        }

        private void FindRetOrder_Pressed(object sender, EventArgs e)
        {
            btnPOLookup_Click(null,null);
        }

        private void FindRetBarcode_Pressed(object sender, EventArgs e)
        {
            btnRetBarcodeLookup_Click(null,null);
        }

        private void dgvBillRow1_Pressed(object sender, EventArgs e)
        {
            if(dgvBill.Rows.Count < 1 )
            {
                return;
            }
            dgvBill.CurrentCell = dgvBill[2, 0];
            dgvBill.Focus();
        }

        private void dgvBillRow2_Pressed(object sender, EventArgs e)
        {
            if (dgvBill.Rows.Count < 2)
            {
                return;
            }
            dgvBill.CurrentCell = dgvBill[2, 1];
            dgvBill.Focus();
        }

        private void dgvBillRow4_Pressed(object sender, EventArgs e)
        {
            if (dgvBill.Rows.Count < 4)
            {
                return;
            }
            dgvBill.CurrentCell = dgvBill[2, 3];
            dgvBill.Focus();
        }

        private void dgvBillRow3_Pressed(object sender, EventArgs e)
        {
            if (dgvBill.Rows.Count < 3)
            {
                return;
            }
            dgvBill.CurrentCell = dgvBill[2, 2];
            dgvBill.Focus();
        }

        private void dgvBillRow5_Pressed(object sender, EventArgs e)
        {
            if (dgvBill.Rows.Count < 5)
            {
                return;
            }
            dgvBill.CurrentCell = dgvBill[2, 4];
            dgvBill.Focus();
        }

        private void txtPayment_Enter(object sender, EventArgs e)
        {
            txtPayment.BackColor = Color.LightBlue;
        }

        private void txtPayment_Leave(object sender, EventArgs e)
        {
            txtPayment.BackColor = Color.FromKnownColor(KnownColor.Window);
        }

        private void btnPrint_Enter(object sender, EventArgs e)
        {
            btnPrint.BackColor = Color.LightBlue;
        }

        private void btnReset_Enter(object sender, EventArgs e)
        {
            btnReset.BackColor = Color.LightBlue;
        }

        private void btnClose_Enter(object sender, EventArgs e)
        {
            btnClose.BackColor = Color.LightBlue;
        }

        private void btnPrint_Leave(object sender, EventArgs e)
        {
            btnPrint.BackColor = Color.FromKnownColor(KnownColor.Control);
        }

        private void btnReset_Leave(object sender, EventArgs e)
        {
            btnReset.BackColor = Color.FromKnownColor(KnownColor.Control);
        }

        private void btnClose_Leave(object sender, EventArgs e)
        {
            btnClose.BackColor = Color.FromKnownColor(KnownColor.Control);
        }

        private void btnRetBarcodeLookup_Enter(object sender, EventArgs e)
        {
            btnRetBarcodeLookup.BackColor = Color.LightBlue;
        }

        private void txtRefPurchaseOrder_Enter(object sender, EventArgs e)
        {
            txtRefPurchaseOrder.BackColor = Color.LightBlue;
        }

        private void btnPOLookup_Enter(object sender, EventArgs e)
        {
            btnPOLookup.BackColor = Color.LightBlue;
        }

        private void txtNote_Enter(object sender, EventArgs e)
        {
            txtNote.BackColor = Color.LightBlue;
        }

        private void btnInput_Enter(object sender, EventArgs e)
        {
            btnInput.BackColor = Color.LightBlue;
        }

        private void dgvBill_Enter(object sender, EventArgs e)
        {
            dgvBill.BackgroundColor = Color.LightBlue;
        }

        private void btnRetBarcodeLookup_Leave(object sender, EventArgs e)
        {
            btnRetBarcodeLookup.BackColor = Color.FromKnownColor(KnownColor.Control);
        }

        private void txtRefPurchaseOrder_Leave(object sender, EventArgs e)
        {
            txtRefPurchaseOrder.BackColor = Color.FromKnownColor(KnownColor.Control);
        }

        private void btnPOLookup_Leave(object sender, EventArgs e)
        {
            btnPOLookup.BackColor = Color.FromKnownColor(KnownColor.Control);
        }

        private void txtNote_Leave(object sender, EventArgs e)
        {
            txtNote.BackColor = Color.FromKnownColor(KnownColor.Control);
        }

        private void btnInput_Leave(object sender, EventArgs e)
        {
            btnInput.BackColor = Color.FromKnownColor(KnownColor.Control);
        }

        private void dgvBill_Leave(object sender, EventArgs e)
        {
            dgvBill.BackgroundColor = Color.FromKnownColor(KnownColor.Control);
        }

        private void lblCharge_Click(object sender, EventArgs e)
        {

        }

        private void lblPayment_Click(object sender, EventArgs e)
        {

        }

        private void lblTax_Click(object sender, EventArgs e)
        {

        }

        private void lblTotalAmount_Click(object sender, EventArgs e)
        {
            txtWorkingTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txtWorkingTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }
    }
}
