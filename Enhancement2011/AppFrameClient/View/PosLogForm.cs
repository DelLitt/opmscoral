using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AppFrame.Common;
using AppFrame.Model;
using AppFrame.Presenter;
using AppFrame.Presenter.GoodsIO;
using AppFrame.Utility;
using AppFrame.View;
using AppFrame.View.GoodsIO;
using AppFrameClient.View.GoodsIO;

namespace AppFrameClient.View
{
    public partial class PosLogForm : BaseForm, IPosLogView
    {
        private const int MAX_COLUMN = 11;
        private const int BLOCK_ID_POS = 0;
        private const int PRODUCT_MASTER_ID_POS = 1;
        private const int STOCK_IN_DATE_ID_POS = 2;
        private const int PRODUCT_MASTER_NAME_POS = 3;
        private const int PRODUCT_PRICE_POS = 4;
        private const int PRODUCT_QUANTITY_POS = 5;
        private const int ACCEPT_QUANTITY_POS = 7;
        private const int RETURN_QUANTITY_POS = 8;
        private const int REMAIN_QUANTITY_POS = 6;
        private const int STOCK_QUANTITY_POS = 9;
        private PosLogEventArgs _currentEventArgs;

        public PosLogForm()
        {
            InitializeComponent();
        }

        private void StockCreateForm_Load(object sender, EventArgs e)
        {
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var eventArgs = new PosLogEventArgs
                                {
                                    LogDateFrom = chkImportDateFrom.Checked ? dtpImportDateFrom.Value : DateTime.MinValue,
                                    LogDateTo = chkImportDateTo.Checked ? dtpImportDateTo.Value : DateTime.MaxValue,
                                    Username = txtUsername.Text
                                };
            EventUtility.fireEvent(SearchPosLogEvent, this, eventArgs);
            PosLogList = eventArgs.PosLogList;

            posLogBindingSource.DataSource = PosLogList;
            _currentEventArgs = eventArgs;
        }

        public IList PosLogList { get; set; }
        private void chkImportDateFrom_CheckedChanged(object sender, EventArgs e)
        {
            dtpImportDateFrom.Enabled = chkImportDateFrom.Checked;
        }

        private void chkImportDateTo_CheckedChanged(object sender, EventArgs e)
        {
            dtpImportDateTo.Enabled = chkImportDateTo.Checked;
        }

        #region Implementation of IPosLogView

        private IPosLogController _posLogController;
        public IPosLogController PosLogController
        {
            set
            {
                _posLogController = value;
                _posLogController.PosLogView = this;
            }
        }

        public event EventHandler<PosLogEventArgs> GetPosLogEvent;
        public event EventHandler<PosLogEventArgs> SearchPosLogEvent;

        #endregion

        private void dgvStockInDetail_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dgvStockInDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (PosLogList != null && e.RowIndex < PosLogList.Count && e.RowIndex >= 0)
            {
                PosLogDetailForm form = new PosLogDetailForm();
                form.PosLog = (PosLog)PosLogList[e.RowIndex];
                form.ShowDialog();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
