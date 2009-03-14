using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using AppFrame.Collection;
using AppFrame.Common;
using AppFrame.Model;
using AppFrame.Presenter.GoodsIO;
using AppFrame.Presenter.GoodsSale;
using AppFrame.Utility;
using AppFrame.View.GoodsSale;
using AppFrameClient.Common;
using AppFrameClient.View.GoodsIO.DepartmentStockData;

namespace AppFrameClient.View.GoodsSale
{
    public partial class GoodsSaleReturnForm : BaseForm, IGoodsSaleReturnView
    {
        private PurchaseOrderDetailCollection pODList = null;
        private PurchaseOrderDetailCollection pODReturnList = null;
        private PurchaseOrderDetailCollection pODNewList = null;
        public GoodsSaleReturnForm()
        {
            InitializeComponent();
            pODList = new PurchaseOrderDetailCollection(bdsBill);
            bdsBill.DataSource = pODList;

            pODReturnList = new PurchaseOrderDetailCollection(bdsReturnBill);
            bdsReturnBill.DataSource = pODReturnList;

            pODNewList = new PurchaseOrderDetailCollection(bdsNewBill);
            bdsNewBill.DataSource = pODNewList;


            txtDepartment.Text = CurrentDepartment.Get().DepartmentName;
            txtEmployee.Text = ClientInfo.getInstance().LoggedUser.Name;
            txtWorkingTime.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");


            txtBillNumber.Text = "";
            txtBillDate.Text = "";

        }

        #region IGoodsSaleReturnView Members

        private IGoodsSaleReturnController goodsSaleReturnController;
        public AppFrame.Presenter.GoodsSale.IGoodsSaleReturnController GoodsSaleReturnController
        {
            get
            {
                return goodsSaleReturnController;
            }
            set
            {
                goodsSaleReturnController = value;
                goodsSaleReturnController.GoodsSaleReturnView = this;
                goodsSaleReturnController.CompletedSavePurchaseOrderEvent += new EventHandler<GoodsSaleReturnEventArgs>(goodsSaleReturnController_CompletedSavePurchaseOrderEvent);
            }
        }

        void goodsSaleReturnController_CompletedSavePurchaseOrderEvent(object sender, GoodsSaleReturnEventArgs e)
        {
            MessageBox.Show("Lưu hoá đơn trả  thành công !");
            btnReset_Click(this, null);

        }

        public event EventHandler<AppFrame.Presenter.GoodsSale.GoodsSaleReturnEventArgs> AddGoodsEvent;

        public event EventHandler<AppFrame.Presenter.GoodsSale.GoodsSaleReturnEventArgs> DeleteGoodsEvent;

        public event EventHandler<AppFrame.Presenter.GoodsSale.GoodsSaleReturnEventArgs> LoadPurchaseOrderEvent;

        public event EventHandler<AppFrame.Presenter.GoodsSale.GoodsSaleReturnEventArgs> HelpEvent;

        public event EventHandler<AppFrame.Presenter.GoodsSale.GoodsSaleReturnEventArgs> FirstRecordEvent;

        public event EventHandler<AppFrame.Presenter.GoodsSale.GoodsSaleReturnEventArgs> PreviousRecordEvent;

        public event EventHandler<AppFrame.Presenter.GoodsSale.GoodsSaleReturnEventArgs> NextRecordEvent;

        public event EventHandler<AppFrame.Presenter.GoodsSale.GoodsSaleReturnEventArgs> LastRecordEvent;

        public event EventHandler<AppFrame.Presenter.GoodsSale.GoodsSaleReturnEventArgs> PrintCheckEvent;

        public event EventHandler<AppFrame.Presenter.GoodsSale.GoodsSaleReturnEventArgs> SaveCheckEvent;

        public event EventHandler<AppFrame.Presenter.GoodsSale.GoodsSaleReturnEventArgs> ResetCheckEvent;

        public event EventHandler<AppFrame.Presenter.GoodsSale.GoodsSaleReturnEventArgs> CloseFormEvent;

        public event EventHandler<AppFrame.Presenter.GoodsSale.GoodsSaleReturnEventArgs> FillProductToComboEvent;

        public event EventHandler<AppFrame.Presenter.GoodsSale.GoodsSaleReturnEventArgs> SavePurchaseOrderEvent;

        #endregion

        private void btnLoadPO_Click(object sender, EventArgs e)
        {
            pODReturnList.Clear();
            goodsSaleReturnController.ReturnPurchaseOrder = null;
            GoodsSaleReturnEventArgs goodsSaleReturnEventArgs = new GoodsSaleReturnEventArgs();
            goodsSaleReturnEventArgs.SearchPurchaseOrderId = txtBillNumber.Text.Trim();
            EventUtility.fireEvent(LoadPurchaseOrderEvent, this, goodsSaleReturnEventArgs);

            PurchaseOrder result = goodsSaleReturnEventArgs.RefPurchaseOrder;
            goodsSaleReturnController.ReturnPurchaseOrder = result;
            txtBillDate.Text = result.CreateDate.ToString("dd/MM/yyyy hh:mm:ss");
            pODList.Clear();
            foreach (PurchaseOrderDetail purchaseOrderDetail in result.PurchaseOrderDetails)
            {
                pODList.Add(purchaseOrderDetail);
            }
            bdsBill.EndEdit();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            SearchGoodsSaleListForm form = GlobalUtility.GetFormObject<SearchGoodsSaleListForm>(FormConstants.SEARCH_GOODS_SALE_LIST_FORM);
            form.SelectGoodsSaleEvent += new EventHandler<GoodsSaleListEventArgs>(form_SelectGoodsSaleEvent);
            form.ShowDialog();
        }

        void form_SelectGoodsSaleEvent(object sender, GoodsSaleListEventArgs e)
        {
            txtBillNumber.Text = e.SelectedOrder.PurchaseOrderPK.PurchaseOrderId;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnReturnGoods_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection returnGoods = dgvBill.SelectedRows;
            foreach (DataGridViewRow row in returnGoods)
            {
                if (NotReturnYet(row.Index, pODList, pODReturnList))
                {
                    pODReturnList.Add(DumpNewRow(pODList[row.Index]));

                    dgvBill.Rows[row.Index].DefaultCellStyle.BackColor = Color.Red;
                    dgvBill.Rows[row.Index].DefaultCellStyle.ForeColor = Color.White;
                }
            }
            CalculateReturnPrice(pODReturnList);
        }

        private PurchaseOrderDetail DumpNewRow(PurchaseOrderDetail detail)
        {
            PurchaseOrderDetail retDetail = new PurchaseOrderDetail();
            retDetail.PurchaseOrderDetailPK = detail.PurchaseOrderDetailPK;
            retDetail.Quantity = detail.Quantity;
            retDetail.Price = detail.Price;
            retDetail.ProductMaster = detail.ProductMaster;
            retDetail.Product = detail.Product;
            retDetail.PurchaseStatus = detail.PurchaseStatus;
            retDetail.PurchaseType = detail.PurchaseType;
            retDetail.CreateDate = detail.CreateDate;
            retDetail.DelFlg = detail.DelFlg;
            retDetail.DepartmentId = detail.DepartmentId;
            retDetail.ExclusiveKey = detail.ExclusiveKey;
            retDetail.PurchaseOrder = detail.PurchaseOrder;
            retDetail.PurchaseOrderDetailId = detail.PurchaseOrderDetailId;
            retDetail.PurchaseOrderId = detail.PurchaseOrderId;
            retDetail.PurchaseOrderPromotions = detail.PurchaseOrderPromotions;
            retDetail.Tax = detail.Tax;
            retDetail.UpdateDate = detail.UpdateDate;
            retDetail.UpdateId = detail.UpdateId;
            return retDetail;
        }

        private void CalculateReturnPrice(PurchaseOrderDetailCollection list)
        {
            long totalReturnAmount = 0;
            foreach (PurchaseOrderDetail detail in pODReturnList)
            {
                totalReturnAmount += detail.Quantity * detail.Price;
            }
            txtReturnPayment.Text = totalReturnAmount.ToString();
        }

        private bool NotReturnYet(int index, PurchaseOrderDetailCollection list, PurchaseOrderDetailCollection returnList)
        {
            PurchaseOrderDetail detail = pODList[index];
            foreach (PurchaseOrderDetail orderDetail in returnList)
            {
                if (orderDetail.PurchaseOrderDetailPK.PurchaseOrderDetailId == detail.PurchaseOrderDetailPK.PurchaseOrderDetailId
                    && orderDetail.PurchaseOrderDetailPK.DepartmentId == detail.PurchaseOrderDetailPK.DepartmentId
                    && orderDetail.PurchaseOrderDetailPK.PurchaseOrderId == detail.PurchaseOrderDetailPK.PurchaseOrderId
                    )
                {
                    return false;
                }
            }
            return true;
        }

        private void btnResetReturnGoods_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection returnGoods = dgvBill.SelectedRows;
            foreach (DataGridViewRow row in returnGoods)
            {
                int rowIndex = 0;
                RemoveReturnPurchaseOrder(pODList[row.Index], ref pODReturnList, out rowIndex);
                dgvBill.Rows[rowIndex].DefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.Window);
                dgvBill.Rows[rowIndex].DefaultCellStyle.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
            }
            CalculateReturnPrice(pODReturnList);
        }

        private void RemoveReturnPurchaseOrder(PurchaseOrderDetail detail, ref PurchaseOrderDetailCollection list, out int index)
        {
            for (int i = 0; i < list.Count; i++)
            {
                PurchaseOrderDetail orderDetail = list[i];
                if (orderDetail.PurchaseOrderDetailPK.PurchaseOrderDetailId == detail.PurchaseOrderDetailPK.PurchaseOrderDetailId
                    && orderDetail.PurchaseOrderDetailPK.DepartmentId == detail.PurchaseOrderDetailPK.DepartmentId
                    && orderDetail.PurchaseOrderDetailPK.PurchaseOrderId == detail.PurchaseOrderDetailPK.PurchaseOrderId
                    )
                {
                    list.RemoveAt(i);
                    index = i;
                    return;
                }
            }
            index = 0;
        }

        private void btnNewOrderNewRow_Click(object sender, EventArgs e)
        {
            PurchaseOrderDetail orderDetail = pODNewList.AddNew();
            orderDetail.CreateId = ClientInfo.getInstance().LoggedUser.Name;
            orderDetail.CreateDate = DateTime.Now;
            orderDetail.UpdateDate = DateTime.Now;
            orderDetail.UpdateId = orderDetail.CreateId;
            orderDetail.DelFlg = 0;
            orderDetail.DepartmentId = CurrentDepartment.Get().DepartmentId;
            orderDetail.Quantity = 1;
            if (GoodsSaleReturnController.NextPurchaseOrder == null)
            {
                PurchaseOrder order = new PurchaseOrder();
                GoodsSaleReturnController.NextPurchaseOrder = order;
            }
            orderDetail.PurchaseOrder = GoodsSaleReturnController.NextPurchaseOrder;
            PurchaseOrderDetailPK purchaseOrderDetailPK = new PurchaseOrderDetailPK();
            purchaseOrderDetailPK.DepartmentId = CurrentDepartment.Get().DepartmentId;
            orderDetail.PurchaseOrderDetailPK = purchaseOrderDetailPK;


            // new product to test
            ProductMaster productMaster = new ProductMaster();
            orderDetail.ProductMaster = productMaster;
            Product product = new Product();
            product.ProductMaster = orderDetail.ProductMaster;
            orderDetail.Product = product;
            pODNewList.EndNew(pODNewList.Count - 1);
            bdsNewBill.EndEdit();

            GoodsSaleReturnController.NextPurchaseOrder.PurchaseOrderDetails =
                ObjectConverter.ConvertToNonGenericList<PurchaseOrderDetail>(pODNewList);
            
        }

        private void btnNewOrderRemoveRow_Click(object sender, EventArgs e)
        {



        }

        private ProductMasterSearchDepartmentForm form = null;
        private void dgvReturnBill_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        void form_SelectProductEvent(object sender, AppFrame.Presenter.GoodsIO.ProductMasterSearchDepartmentEventArgs e)
        {
            pODReturnList[dgvBill.CurrentCell.OwningRow.Index].Product = e.ReturnProduct;
            GoodsSaleEventArgs goodsSaleEventArgs = new GoodsSaleEventArgs();
            int selectedIndex = dgvBill.CurrentCell.OwningRow.Index;
            goodsSaleEventArgs.SelectedIndex = selectedIndex;
            goodsSaleEventArgs.SelectedPurchaseOrderDetail = bdsBill[selectedIndex] as PurchaseOrderDetail;
            /*goodsSaleEventArgs.SelectedPurchaseOrderDetail.Product.ProductId =
                dgvBill.CurrentCell.Value as string;*/
            EventUtility.fireEvent(LoadGoodsEvent, this, goodsSaleEventArgs);

            // event has been modified
            pODReturnList[selectedIndex] = goodsSaleEventArgs.SelectedPurchaseOrderDetail;
            bdsReturnBill.EndEdit();

            if (form != null)
            {
                form.SelectProductEvent -= new EventHandler<AppFrame.Presenter.GoodsIO.ProductMasterSearchDepartmentEventArgs>(form_SelectProductEvent);
                form.Close();
            }
        }

        #region IGoodsSaleReturnView Members

        public IGoodsSaleController goodsSaleController;
        public IGoodsSaleController GoodsSaleController
        {
            get
            {
                return goodsSaleController;
            }
            set
            {
                goodsSaleController = value;

            }
        }

        public event EventHandler<GoodsSaleEventArgs> LoadGoodsEvent;

        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (pODReturnList.Count <= 0)
            {
                MessageBox.Show("Không có hàng để trả !");
                return;
            }
            if(Int64.Parse(txtCharge.Text) < 0)
            {
                MessageBox.Show("Hãy nhập vào số tiền khách hàng trả !");
                return;    
            }
            if (goodsSaleReturnController.ReturnPurchaseOrder == null)
            {
                // tra hang nghi van
            }
            else
            {
                // tra hang da co doi chieu
                GoodsSaleReturnEventArgs eventArgs = new GoodsSaleReturnEventArgs();
                eventArgs.RefPurchaseOrder = goodsSaleReturnController.ReturnPurchaseOrder;
                eventArgs.ReturnPurchaseOrderDetails = ObjectConverter.ConvertToNonGenericList<PurchaseOrderDetail>(pODReturnList);
                eventArgs.NextPurchaseOrder = goodsSaleReturnController.NextPurchaseOrder;
                EventUtility.fireEvent(SavePurchaseOrderEvent, this, eventArgs);
                if(!eventArgs.HasErrors)
                {
                    MessageBox.Show("Lưu thành công !");
                    ClearForm();
                }
            }
        }

        private void ClearForm()
        {
            pODList.Clear();
            pODNewList.Clear();
            pODReturnList.Clear();
            txtCharge.Text = "0";
            txtPayment.Text = "0";
            txtTotalAmount.Text = "0";
            txtReturnPayment.Text = "0";
            txtTax.Text = "0";
            txtCustomer.Text = "";
            txtBillNumber.Text = "";
            txtBillDate.Text = "";
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            goodsSaleReturnController.ReturnPurchaseOrder = null;
            goodsSaleReturnController.NextPurchaseOrder = null;
            pODList.Clear();
            pODReturnList.Clear();
            txtBillNumber.Text = "";
            txtBillDate.Text = "";
            txtPayment.Text = "0";
            txtCharge.Text = "0";
        }

        private void GoodsSaleReturnForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            goodsSaleReturnController.ReturnPurchaseOrder = null;
            goodsSaleReturnController.NextPurchaseOrder = null;
            goodsSaleReturnController.CompletedSavePurchaseOrderEvent -= new EventHandler<GoodsSaleReturnEventArgs>(goodsSaleReturnController_CompletedSavePurchaseOrderEvent);
        }

        private void lblTotalAmount_Click(object sender, EventArgs e)
        {

        }

        private void txtPayment_TextChanged(object sender, EventArgs e)
        {
            txtCharge.Text = CalculateCharge().ToString();
        }

        private void GoodsSaleReturnForm_Load(object sender, EventArgs e)
        {
            //btnAddUncheck_Click(this, null);

        }

        private ProductMasterSearchDepartmentForm newForm = null;
        private void dgvNewBill_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvNewBill.CurrentCell == null)
            {
                return;
            }
            if (dgvNewBill.CurrentCell.ColumnIndex == 0)
            {
                newForm = GlobalUtility.GetOnlyChildFormObject<ProductMasterSearchDepartmentForm>(GlobalCache.Instance().MainForm, FormConstants.PRODUCT_MASTER_SEARCH_DEPARMENT_FORM);
                newForm.SelectProductEvent += new EventHandler<AppFrame.Presenter.GoodsIO.ProductMasterSearchDepartmentEventArgs>(form_SelectNewProductEvent);
                if (newForm != null)
                    newForm.Show();
            }
        }

        private void form_SelectNewProductEvent(object sender, ProductMasterSearchDepartmentEventArgs e)
        {
            pODNewList[dgvNewBill.CurrentCell.OwningRow.Index].Product = e.ReturnProduct;
            GoodsSaleEventArgs goodsSaleEventArgs = new GoodsSaleEventArgs();
            int selectedIndex = dgvNewBill.CurrentCell.OwningRow.Index;
            goodsSaleEventArgs.SelectedIndex = selectedIndex;
            goodsSaleEventArgs.SelectedPurchaseOrderDetail = bdsNewBill[selectedIndex] as PurchaseOrderDetail;
            /*goodsSaleEventArgs.SelectedPurchaseOrderDetail.Product.ProductId =
                dgvBill.CurrentCell.Value as string;*/
            EventUtility.fireEvent(LoadGoodsEvent, this, goodsSaleEventArgs);

            // event has been modified
            pODNewList[selectedIndex] = goodsSaleEventArgs.SelectedPurchaseOrderDetail;
            bdsNewBill.EndEdit();

            if (newForm != null)
            {
                newForm.SelectProductEvent -= new EventHandler<AppFrame.Presenter.GoodsIO.ProductMasterSearchDepartmentEventArgs>(form_SelectProductEvent);
                newForm.Close();
            }
        }

        private void tToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btnAddUncheck_Click(object sender, EventArgs e)
        {
            CreateNewBlankPurchaseOrderDetail(bdsReturnBill);

        }



        private void btnRemoveUncheck_Click(object sender, EventArgs e)
        {
            if (dgvReturnBill.CurrentRow != null)
            {
                PurchaseOrderDetail removeDetail = pODReturnList[dgvReturnBill.CurrentRow.Index];
                int index = 0;
                RemoveReturnPurchaseOrder(removeDetail, ref pODList, out index);
                pODReturnList.RemoveAt(dgvReturnBill.CurrentRow.Index);
                CalculateReturnPrice(pODReturnList);

            }
        }

        private void CreateNewBlankPurchaseOrderDetail(BindingSource bill)
        {

            PurchaseOrderDetail orderDetail = (PurchaseOrderDetail)bill.AddNew();
            orderDetail.CreateId = ClientInfo.getInstance().LoggedUser.Name;
            orderDetail.CreateDate = DateTime.Now;
            orderDetail.UpdateDate = DateTime.Now;
            orderDetail.UpdateId = orderDetail.CreateId;
            orderDetail.DelFlg = 0;
            orderDetail.DepartmentId = CurrentDepartment.Get().DepartmentId;
            orderDetail.Quantity = 1;


            PurchaseOrderDetailPK purchaseOrderDetailPK = new PurchaseOrderDetailPK();
            purchaseOrderDetailPK.DepartmentId = CurrentDepartment.Get().DepartmentId;
            orderDetail.PurchaseOrderDetailPK = purchaseOrderDetailPK;


            // new product to test
            ProductMaster productMaster = new ProductMaster();
            orderDetail.ProductMaster = productMaster;
            Product product = new Product();
            product.ProductMaster = orderDetail.ProductMaster;
            orderDetail.Product = product;
            bill.EndEdit();

        }

        private void dgvNewBill_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            GoodsSaleReturnController.NextPurchaseOrder.PurchasePrice = CalculateTotalPrice(pODNewList);
            txtTotalAmount.Text = GoodsSaleReturnController.NextPurchaseOrder.PurchasePrice.ToString();
            //txtTotalAmount.Text = CalculateTotalAmount().ToString();
            txtCharge.Text = CalculateCharge().ToString();
            RemoveEmptyAndDuplicateRowFromList(pODNewList);
            ClearInput();
            txtBarcode.Focus();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBarcode.Text) && txtBarcode.Text.Length == CommonConstants.PRODUCT_ID_LENGTH)
            {
                try
                {
                    GoodsSaleEventArgs goodsSaleEventArgs = new GoodsSaleEventArgs();
                    /*int selectedIndex = dgvBill.CurrentCell.OwningRow.Index;
                    goodsSaleEventArgs.SelectedIndex = selectedIndex;*/
                    btnNewOrderNewRow_Click(this, null);
                    goodsSaleEventArgs.SelectedPurchaseOrderDetail = pODNewList[pODNewList.Count - 1] as PurchaseOrderDetail;
                    goodsSaleEventArgs.SelectedPurchaseOrderDetail.Product.ProductId = txtBarcode.Text;
                    EventUtility.fireEvent(LoadGoodsEvent, this, goodsSaleEventArgs);

                    // event has been modified
                    pODList[pODList.Count - 1] = goodsSaleEventArgs.SelectedPurchaseOrderDetail;
                    int totalNumber = 1;

                    GoodsSaleReturnController.NextPurchaseOrder.PurchasePrice = CalculateTotalPrice(pODNewList);
                    bdsBill.EndEdit();

                }
                catch (Exception ex)
                {
                    //throw new BusinessException("Mã vạch không hợp lệ hoặc hàng không tồn tại");
                    pODList.RemoveAt(pODNewList.Count - 1);
                }
                finally
                {
                    txtTotalAmount.Text = GoodsSaleReturnController.NextPurchaseOrder.PurchasePrice.ToString();
                    //txtTotalAmount.Text = CalculateTotalAmount().ToString();
                    txtCharge.Text = CalculateCharge().ToString();
                    RemoveEmptyAndDuplicateRowFromList(pODNewList);
                    ClearInput();
                    txtBarcode.Focus();
                }
            }

        }

        private long CalculateCharge()
        {
            if(string.IsNullOrEmpty(txtTotalAmount.Text))
            {
                txtTotalAmount.Text = "0";
            }
            long newTotalAmount = Int64.Parse(txtTotalAmount.Text);

            if (string.IsNullOrEmpty(txtReturnPayment.Text))
            {
                txtReturnPayment.Text = "0";
            }
            long returnPayment = Int64.Parse(txtReturnPayment.Text);
            long totalAmount = newTotalAmount - returnPayment;
            long payment = string.IsNullOrEmpty(txtPayment.Text) ? 0 : Int64.Parse(txtPayment.Text);
            long charge = payment - totalAmount;
            return charge;
        }

        private void ClearInput()
        {
            txtBarcode.Text = "";
            txtBarcode.Focus();
        }

        private void RemoveEmptyAndDuplicateRowFromList(PurchaseOrderDetailCollection list)
        {
            int maxId = list.Count - 1;
            while(maxId >= 0)
            {
                PurchaseOrderDetail detail = (PurchaseOrderDetail) list[maxId];
                if(string.IsNullOrEmpty(detail.Product.ProductMaster.ProductName))
                {
                    list.RemoveAt(maxId);
                }
                maxId -= 1;
            }
            if(list.Count < 2)
            {
                return;
            }
            for(int i = 0;i<list.Count - 1;i++)
            {
                PurchaseOrderDetail detail = (PurchaseOrderDetail)list[i];                
                for(int j = list.Count-1;j>=i+1;j--)
                {
                    PurchaseOrderDetail compdetail = (PurchaseOrderDetail)list[j];                    
                    if(detail.Product.ProductId == compdetail.Product.ProductId)
                    {
                        detail.Quantity += compdetail.Quantity;
                        list.RemoveAt(j);
                    }
                }
            }
        }

        private long CalculateTotalAmount()
        {
            long newTotalAmount = Int64.Parse(txtTotalAmount.Text);
            long returnPayment = Int64.Parse(txtReturnPayment.Text);
            long totalAmount = newTotalAmount - returnPayment;
            return totalAmount;
        }

        private long CalculateTotalPrice(PurchaseOrderDetailCollection list)
        {
            long totalAmount = 0;
            if (list == null || list.Count == 0)
                return 0;
            foreach (PurchaseOrderDetail detail in list)
            {
                totalAmount += detail.Price*detail.Quantity;
            }
            return totalAmount;
        }

        private void dgvReturnBill_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            CalculateReturnPrice(pODReturnList);
            GoodsSaleReturnController.ReturnPurchaseOrder.PurchasePrice = CalculateTotalPrice(pODReturnList);
            //txtTotalAmount.Text = GoodsSaleReturnController.NextPurchaseOrder.PurchasePrice.ToString();
            //txtTotalAmount.Text = CalculateTotalAmount().ToString();
            txtCharge.Text = CalculateCharge().ToString();
            //RemoveEmptyAndDuplicateRowFromList(pODNewList);
            ClearInput();
            txtBarcode.Focus();
        }

        private void dgvReturnBill_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtBarcode_Enter(object sender, EventArgs e)
        {
            txtBarcode.BackColor = Color.LightGreen;
        }

        private void txtBarcode_Leave(object sender, EventArgs e)
        {
            txtBarcode.BackColor = Color.White;
        }
    }
}
