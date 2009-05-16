using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppFrame.Collection;
using AppFrame.Common;
using AppFrame.Model;
using AppFrame.Presenter.GoodsSale;
using AppFrame.Utility;
using AppFrame.View.GoodsSale;
using AppFrameClient.Common;

namespace AppFrameClient.View.GoodsSale
{
    public partial class GoodsReturnChildForm : BaseForm, IGoodsSaleReturnView
    {

        private PurchaseOrderDetailCollection pODList = null;
        private PurchaseOrderDetailCollection pODReturnList = null;
        private PurchaseOrder ReturnPurchaseOrder = null;
        public GoodsReturnChildForm()
        {
            InitializeComponent();
        }
        public GoodsReturnChildForm(string refPurchaseOrderId)
        {
            InitializeComponent();
            
            
            
            if(ReturnPurchaseOrder== null)
            {
                ReturnPurchaseOrder = new PurchaseOrder();
                ReturnPurchaseOrder.PurchaseOrderPK = new 
                PurchaseOrderPK{DepartmentId = CurrentDepartment.Get().DepartmentId };
                if(CheckUtility.IsNullOrEmpty(refPurchaseOrderId))
                {
                    refPurchaseOrderId = "000000000000";
                }
                ReturnPurchaseOrder.PurchaseOrderPK.PurchaseOrderId = refPurchaseOrderId;
            }
            btnLoadPO_Click(null,null);
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
        private void btnSave_Click(object sender, EventArgs e)
        {
            GoodsSaleReturnEventArgs eventArgs = new GoodsSaleReturnEventArgs();
            eventArgs.RefPurchaseOrder = ReturnPurchaseOrder;
            eventArgs.ReturnPurchaseOrderDetails = ObjectConverter.ConvertToNonGenericList<PurchaseOrderDetail>(pODReturnList);
            if (SelectReturnGoodsEvent != null)
            {
                EventUtility.fireEvent(SelectReturnGoodsEvent, this, eventArgs);
                Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLoadPO_Click(object sender, EventArgs e)
        {
            pODReturnList.Clear();
            pODList.Clear();
            bdsReturnBill.EndEdit();

            try
            {
                GoodsSaleReturnEventArgs goodsSaleReturnEventArgs = new GoodsSaleReturnEventArgs();
                goodsSaleReturnEventArgs.SearchPurchaseOrderId = txtBillNumber.Text.Trim();
                EventUtility.fireEvent(LoadPurchaseOrderEvent, this, goodsSaleReturnEventArgs);

                ReturnPurchaseOrder = goodsSaleReturnEventArgs.RefPurchaseOrder;
                txtBillDate.Text = ReturnPurchaseOrder.CreateDate.ToString("dd/MM/yyyy hh:mm:ss");

                foreach (PurchaseOrderDetail purchaseOrderDetail in ReturnPurchaseOrder.PurchaseOrderDetails)
                {
                    pODList.Add(purchaseOrderDetail);
                }
                bdsBill.EndEdit();
                dgvBill.Focus();
            }
            catch (Exception)
            {
                
                // do nothing
            }
            
        }

        public event EventHandler<GoodsSaleReturnEventArgs> SelectReturnGoodsEvent;
        #region IGoodsSaleReturnView Members

        private IGoodsSaleReturnController goodsSaleReturnController;
        public IGoodsSaleReturnController GoodsSaleReturnController
        {
            get
            {
                return goodsSaleReturnController;                
            }
            set
            {
                goodsSaleReturnController = value;
                goodsSaleReturnController.GoodsSaleReturnView = this;
            }
        }

        private IGoodsSaleController goodsSaleController;
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

        public event EventHandler<GoodsSaleReturnEventArgs> AddGoodsEvent;

        public event EventHandler<GoodsSaleReturnEventArgs> DeleteGoodsEvent;

        public event EventHandler<GoodsSaleReturnEventArgs> HelpEvent;

        public event EventHandler<GoodsSaleReturnEventArgs> LoadPurchaseOrderEvent;

        public event EventHandler<GoodsSaleReturnEventArgs> FirstRecordEvent;

        public event EventHandler<GoodsSaleReturnEventArgs> PreviousRecordEvent;

        public event EventHandler<GoodsSaleReturnEventArgs> NextRecordEvent;

        public event EventHandler<GoodsSaleReturnEventArgs> LastRecordEvent;

        public event EventHandler<GoodsSaleReturnEventArgs> PrintCheckEvent;

        public event EventHandler<GoodsSaleReturnEventArgs> SaveCheckEvent;

        public event EventHandler<GoodsSaleReturnEventArgs> ResetCheckEvent;

        public event EventHandler<GoodsSaleReturnEventArgs> CloseFormEvent;

        public event EventHandler<GoodsSaleReturnEventArgs> FillProductToComboEvent;

        public event EventHandler<GoodsSaleEventArgs> LoadGoodsEvent;

        public event EventHandler<GoodsSaleReturnEventArgs> SavePurchaseOrderEvent;

        #endregion

        private void btnReturnGoods_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection returnGoods = dgvBill.SelectedRows;
            foreach (DataGridViewRow row in returnGoods)
            {
                if (NotReturnYet(row.Index, pODList, pODReturnList))
                {
                    pODReturnList.Add(DumpNewRow(pODList[row.Index]));

                    dgvBill.Rows[row.Index].DefaultCellStyle.BackColor = Color.DimGray;
                    dgvBill.Rows[row.Index].DefaultCellStyle.ForeColor = Color.White;
                }
            }
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

        private void GoodsReturnChildForm_Load(object sender, EventArgs e)
        {
            pODList = new PurchaseOrderDetailCollection(bdsBill);
            bdsBill.DataSource = pODList;

            pODReturnList = new PurchaseOrderDetailCollection(bdsReturnBill);
            bdsReturnBill.DataSource = pODReturnList;

            txtBillNumber.Text = "";
            txtBillDate.Text = "";
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

        private void dgvBill_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Add)
            {
                btnReturnGoods_Click(sender, null);
            }
            if(e.KeyCode == Keys.Subtract)
            {
                btnResetReturnGoods_Click(sender,null);
            }
        }
    }
}
