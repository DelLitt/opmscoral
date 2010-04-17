using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppFrame.Model;
using AppFrame.Presenter.GoodsSale;
using AppFrame.Utility;
using AppFrameClient.ViewModel;

namespace AppFrameClient.View.GoodsSale
{
    public partial class SearchGoodsSaleListForm : GoodsSaleListForm
    {
        public SearchGoodsSaleListForm()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        public event EventHandler<GoodsSaleListEventArgs> SelectGoodsSaleEvent;
        private void btnBillChoosing_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selectedRows = dgvSaleList.SelectedRows;
            GoodsSaleListEventArgs eventArgs = new GoodsSaleListEventArgs();
            PurchaseOrderView view = bdsPurchaseOrders[dgvSaleList.CurrentCell.OwningRow.Index] as PurchaseOrderView;
            if(view == null || view.PurchaseOrder == null)
            {
                MessageBox.Show("Bạn nên chọn hóa đơn bán hàng, không nên chọn hóa đơn trả hàng");
                return;
            }

            eventArgs.SelectedOrder = view.PurchaseOrder;
            EventUtility.fireEvent(SelectGoodsSaleEvent,this,eventArgs);
            Close();
        }

        private void txtBillNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void systemHotkey1_Pressed(object sender, EventArgs e)
        {
            btnSearch_Click(sender,null);
        }
    }
}
