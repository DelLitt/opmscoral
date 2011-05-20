using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AppFrame.Model;
using AppFrame.Presenter.GoodsIO;
using AppFrame.View.GoodsIO;
using AppFrame.Utility;
using AppFrameClient.Common;

namespace AppFrameClient.View.GoodsIO
{
    public partial class GoodsIOSearchForm : Form, IGoodsIOSearchView
    {
        private static readonly int MAX_COLUMN = 6;
        public GoodsIOSearchForm()
        {
            InitializeComponent();
            dataTable.Columns.Add("Mã lô");
            dataTable.Columns.Add("Ngày nhập");
            dataTable.Columns.Add("Mô tả");
            dataTable.Columns.Add("Tồng sản phẩm");
            dataTable.Columns.Add("Tồng giá trị");
            dataTable.Columns.Add("Trạng thái");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var eventArgs = new GoodsIOSearchEventArgs
                                {
                                    BlockDetailId = txtBlockInDetailId.Text,
                                    ImportDateFrom = chkImportDateFrom.Checked ? dtpImportDateFrom.Value : DateTime.MinValue,
                                    ImportDateTo = chkImportDateTo.Checked ? dtpImportDateTo.Value : DateTime.MaxValue,
                                    IsNeedDelete = chkDelete.Checked
                                };
            EventUtility.fireEvent(SearchBlockInDetailEvent, this, eventArgs);
            _currentSearchCriteria = eventArgs;
            BlockInDetailList = eventArgs.BlockDetailList;
            PopulateDataGrid();
        }

        public IList BlockInDetailList { get; set; }
        private DataTable dataTable = new DataTable();
        private GoodsIOSearchEventArgs _currentSearchCriteria;
        private IGoodsIOSearchController _goodsIOSearchController;
        public IGoodsIOSearchController GoodsIOSearchController
        {
            set
            {
                _goodsIOSearchController = value;
                _goodsIOSearchController.GoodsIOSearchView = this;
            }
        }

        public event EventHandler<GoodsIOSearchEventArgs> SearchBlockInDetailEvent;
        public event EventHandler<GoodsIOSearchEventArgs> LoadBlockInDetailEvent;
        public event EventHandler<GoodsIOSearchEventArgs> DeleteBlockInDetailEvent;

        private void btnCreate_Click(object sender, EventArgs e)
        {
            var goodsForm = GlobalUtility.GetFormObject<GoodsInput>(FormConstants.IMPORT_GOODS_FORM);
            goodsForm.IsNeedClosing = true;
            goodsForm.ShowDialog();
        }

        public void PopulateDataGrid()
        {
            if (BlockInDetailList != null)
            {
                dataTable.Rows.Clear();
                for (int i = 0; i < BlockInDetailList.Count; i++)
                {
                    var blockInDetail = (BlockInDetail)BlockInDetailList[i];
                    dataTable.Rows.Add(AddBlockToDataGrid(blockInDetail));
                }
                dgvBlockInDetail.DataSource = dataTable;
                dgvBlockInDetail.Refresh();

                if (chkDelete.Checked)
                {
                    for (int i = 0; i < BlockInDetailList.Count; i++)
                    {
                        var detail = (BlockInDetail)BlockInDetailList[i];
                        if (detail.DelFlg == 1)
                        {
                            for (int j = 0; j < MAX_COLUMN; j++)
                            {
                                dgvBlockInDetail[j, i].Style.BackColor = Color.Gray;
                            }
                        }
                    }
                }
            }
        }

        private object[] AddBlockToDataGrid(BlockInDetail blockInDetail)
        {
            var obj = new object[6];
            obj[0] = blockInDetail.BlockInDetailPK.BlockDetailId;
            obj[1] = blockInDetail.ImportDate.ToString("dd/MM/yyyy HH:mm:ss");
            obj[2] = blockInDetail.DetailValue;
            Int64 sumOfProduct = 0;
            Int64 sumOfPrice = 0;
            foreach (Product product in blockInDetail.Products)
            {
                sumOfProduct += product.Quantity;
                sumOfPrice += (product.Quantity * product.Price);
            }
            obj[3] = sumOfProduct;
            obj[4] = sumOfPrice;
            if (blockInDetail.DelFlg == 1)
            {
                obj[5] = "Đã xóa";
            }
            return obj;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvBlockInDetail.SelectedRows.Count > 0)
            {
                IList<BlockInDetail> deleteList = new List<BlockInDetail>();
                foreach (DataGridViewRow selectedRow in dgvBlockInDetail.SelectedRows)
                {
                    if (selectedRow.Index < BlockInDetailList.Count && selectedRow.Index >= 0)
                    {
                        var detail = (BlockInDetail) BlockInDetailList[selectedRow.Index];
                        if (detail.DelFlg == 1)
                        {
                            MessageBox.Show("Không thể xóa những lô đã xóa");
                            return;
                        }
                        deleteList.Add((BlockInDetail) BlockInDetailList[selectedRow.Index]);
                    }
                }

                if (MessageBox.Show("Really delete?", "Confirm delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _currentSearchCriteria.DeleteList = deleteList;
                    EventUtility.fireEvent(DeleteBlockInDetailEvent, this, _currentSearchCriteria);
                    BlockInDetailList = _currentSearchCriteria.BlockDetailList;
                    PopulateDataGrid();
                }
            }
        }

        private void dgvBlockInDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (BlockInDetailList != null && e.RowIndex < BlockInDetailList.Count && e.RowIndex >= 0)
            {
                var goodsForm = GlobalUtility.GetFormObject<GoodsInput>(FormConstants.IMPORT_GOODS_FORM);
                goodsForm.BlockInDetail = (BlockInDetail)BlockInDetailList[e.RowIndex];
                goodsForm.IsNeedClosing = true;
                goodsForm.ShowDialog();
                dgvBlockInDetail.DataSource = BlockInDetailList;
                PopulateDataGrid();
                dgvBlockInDetail.Refresh();
            }
        }

        private void chkImportDateFrom_CheckedChanged(object sender, EventArgs e)
        {
            dtpImportDateFrom.Enabled = chkImportDateFrom.Checked;
        }

        private void chkImportDateTo_CheckedChanged(object sender, EventArgs e)
        {
            dtpImportDateTo.Enabled = chkImportDateTo.Checked;
        }
    }
}
