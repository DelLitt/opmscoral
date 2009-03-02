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
            eventArgs.SelectedOrder = bdsPurchaseOrders[dgvSaleList.CurrentCell.OwningRow.Index] as PurchaseOrder;
            EventUtility.fireEvent(SelectGoodsSaleEvent,this,eventArgs);
            Close();
        }
    }
}
