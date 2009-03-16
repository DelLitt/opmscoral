using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AppFrame.Collection;
using AppFrame.Common;
using AppFrame.Controls;
using AppFrame.Exceptions;
using AppFrame.Model;
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
            txtTax.Text = "";
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

        private void GoodsSaleForm_Load(object sender, EventArgs e)
        {
            Department currentDepartment = CurrentDepartment.Get();
            txtDepartment.Text = currentDepartment.DepartmentName;
            txtEmployee.Text = ClientInfo.getInstance().LoggedUser.Name;
            txtWorkingTime.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
            this.reportPurchaseOrder.RefreshReport();
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
                    /*string productIdValue = (string)dgvBill[e.ColumnIndex, e.RowIndex].Value;
                    if(string.IsNullOrEmpty(productIdValue) || productIdValue.Length != CommonConstants.PRODUCT_ID_LENGTH)
                    {
                        throw new PresentationException("InvalidBarCode");
                    }

                    GoodsSaleEventArgs goodsSaleEventArgs = new GoodsSaleEventArgs();
                    int selectedIndex = dgvBill.CurrentCell.OwningRow.Index;
                    goodsSaleEventArgs.SelectedIndex = selectedIndex;
                    goodsSaleEventArgs.SelectedPurchaseOrderDetail = bdsBill[selectedIndex] as PurchaseOrderDetail;
                    goodsSaleEventArgs.SelectedPurchaseOrderDetail.Product.ProductId =
                        dgvBill.CurrentCell.Value as string;
                    EventUtility.fireEvent(LoadGoodsEvent, this, goodsSaleEventArgs);

                    // event has been modified
                    pODList[selectedIndex] = goodsSaleEventArgs.SelectedPurchaseOrderDetail;
                    GoodsSaleController.PurchaseOrder.PurchasePrice = CalculateTotalPrice(pODList);
                    txtTotalAmount.Text = GoodsSaleController.PurchaseOrder.PurchasePrice.ToString();
                    
                    CalculateCharge();
                    
                    // check if last item of list has data, if has data then we add new row.
                    PurchaseOrderDetail lastDetail = pODList[pODList.Count - 1];
                    // in case has data we add new
                    if(!string.IsNullOrEmpty(lastDetail.ProductMaster.ProductMasterId))
                    {
                        btnAdd_Click(this, null);                        
                    }
                    else
                    {
                        // do nothing, because we has new row already
                    }*/
                }
                else
                {
                    GoodsSaleController.PurchaseOrder.PurchasePrice = CalculateTotalPrice(pODList);
                    txtTotalAmount.Text = GoodsSaleController.PurchaseOrder.PurchasePrice.ToString();
                    bdsBill.EndEdit();
                    
                }
            }
            catch(Exception ex)
            {
                dgvBill[e.ColumnIndex, e.RowIndex].Value = "";
                MessageBox.Show("Mã sản phẩm không hợp lệ hoặc lỗi khi nhập");
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
                txtCharge.Text = "0";
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
            foreach(PurchaseOrderDetail purchaseOrderDetail in list)
            {
                totalAmount += purchaseOrderDetail.Price * purchaseOrderDetail.Quantity;                
            }
            return totalAmount;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection rows = dgvBill.SelectedRows;
            foreach (DataGridViewRow row in rows)
            {
                pODList.RemoveAt(row.Index);                
            }
            GoodsSaleController.PurchaseOrder.PurchaseOrderDetails =
                ObjectConverter.ConvertToNonGenericList<PurchaseOrderDetail>(pODList);

            bdsBill.EndEdit();
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
            if(string.IsNullOrEmpty(txtTotalAmount.Text) || int.Parse(txtTotalAmount.Text) <= 0 )
            {
                MessageBox.Show("Giá trị đơn hàng phải lớn hơn 0");
                return false;
            }
            if(string.IsNullOrEmpty(txtPayment.Text))
            {
                MessageBox.Show("Hãy nhập vào số tiền khách hàng trả !");
                return false;
            }
            if(int.Parse(txtCharge.Text)<0)
            {
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
            RemoveEmptyProductMasterIdRow();
            FormToModel();
            GoodsSaleEventArgs eventArgs = new GoodsSaleEventArgs();
            EventUtility.fireEvent(SavePurchaseOrderEvent, this, eventArgs);
            if (eventArgs.HasErrors)
            {
                MessageBox.Show("Có lỗi khi lưu hoá đơn");
                return;
            }
            
            /*printForm = new GoodsSalePrintForm();
            printForm.FillForm(GoodsSaleController.PurchaseOrder);
            printForm.Show();
            printForm.Shown += new EventHandler(printForm_Shown);*/

            
            /*reportPurchaseOrder.LocalReport.DataSources.Add(new ReportDataSource("Department",CurrentDepartment.Get()));
            reportPurchaseOrder.LocalReport.DataSources.Add(new ReportDataSource("PurchaseOrder",GoodsSaleController.PurchaseOrder));
            reportPurchaseOrder.LocalReport.DataSources.Add(new ReportDataSource("PurchaseOrderDetail", pODList));*/
            this.DepartmentBindingSource.DataSource = CurrentDepartment.Get();
            this.PurchaseOrderBindingSource.DataSource = goodsSaleController.PurchaseOrder;
            this.PurchaseOrderDetailCollectionBindingSource.DataSource = CreateNonDuplicate(pODList);

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
            this.reportPurchaseOrder.PrintDialog();
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
                   newDetail.Price += detail.Price;
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
                    if (detail.Product.ProductId == compdetail.Product.ProductId)
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
    }
}
