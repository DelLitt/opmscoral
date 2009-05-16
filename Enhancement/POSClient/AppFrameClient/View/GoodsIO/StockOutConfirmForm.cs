using System;
using System.Collections;
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
using AppFrame.Presenter;
using AppFrame.Presenter.Report;
using AppFrame.Utility;
using AppFrame.View.GoodsIO;
using AppFrame.View.Reports;
using AppFrameClient.ViewModel;

namespace AppFrameClient.View.GoodsIO
{
    public partial class StockOutConfirmForm : BaseForm,IStockOutConfirmView
    {
        private StockOutViewCollection deptStockOutList = null;
        private StockOutDetailViewCollection deptStockOutDetailList = null;
        public StockOutConfirmForm()
        {
            InitializeComponent();
        }

        

        private void btnSearch_Click(object sender, EventArgs e)
        {

            deptStockOutList.Clear();
            StockOutConfirmEventArgs eventArgs = new StockOutConfirmEventArgs();
            eventArgs.ReportDateStockOutParam =
                new ReportDateStockOutParam
                {
                    FromDate = DateUtility.ZeroTime(dtpFrom.Value),
                    ToDate = DateUtility.MaxTime(dtpTo.Value)
                };
            EventUtility.fireEvent(LoadStockOutsEvent, this, eventArgs);

            if (eventArgs.ResultStockOutList != null)
            {
                foreach (IList result in eventArgs.ResultStockOutList)
                {
                    StockOutView stockOutView = new StockOutView();
                    stockOutView.StockOut = (StockOut)result[0];
                    stockOutView.TotalQuantity = (long)result[1];
                    stockOutView.Department = (Department)result[3];
                    if (stockOutView.Department != null)
                    {
                        stockOutView.DepartmentName = stockOutView.Department.DepartmentName;
                    }
                    else
                    {
                        stockOutView.DepartmentName = " Kho chính";
                    }
                    stockOutView.CreateDate = stockOutView.StockOut.CreateDate;
                    deptStockOutList.Add(stockOutView);
                }
            }
            else
            {
                MessageBox.Show(" Không có hoá đơn xuất kho nào cần xác nhận.");
            }

            bdsDeptStockOut.EndEdit();
            dgvStockOutDetail.Refresh();
            dgvStockOutDetail.Invalidate();
            CreateCountOnList();
        }

        
            private void CreateCountOnList()
            {
            for (int i = 0; i < dgvStockOut.Rows.Count;i++ )
            {
                dgvStockOut[0, dgvStockOut.Rows[i].Index].Value = i + 1;
            }
            }
        

        
        private void DepartmentStockOutConfirmForm_Load(object sender, EventArgs e)
        {
           deptStockOutList = new StockOutViewCollection(bdsDeptStockOut);
            bdsDeptStockOut.DataSource = deptStockOutList;
            bdsDeptStockOut.ResetBindings(true);
            
            deptStockOutDetailList = new StockOutDetailViewCollection(bdsDeptStockOutDetail);
            bdsDeptStockOutDetail.DataSource = deptStockOutDetailList;
            bdsDeptStockOutDetail.ResetBindings(true);
        }

        private void dgvStockOut_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvStockOut.CurrentCell == null)
            {
                return;
            }
            deptStockOutDetailList.Clear();
            StockOutView stockOut = deptStockOutList[dgvStockOut.CurrentCell.OwningRow.Index];
            IList stockOutDetails = stockOut.StockOut.StockOutDetails;
            foreach (StockOutDetail stockOutDetail in stockOutDetails)
            {
                if (!HasCreatedView(stockOutDetail))
                {
                    StockOutDetailView stockOutDetailView = new StockOutDetailView();

                    stockOutDetailView.StockOutDetail = stockOutDetail;
                    stockOutDetailView.TotalCount = stockOutDetail.Quantity;
                    stockOutDetailView.GoodCount = stockOutDetail.GoodQuantity;
                    stockOutDetailView.DamageCount = stockOutDetail.DamageQuantity;
                    stockOutDetailView.ErrorCount = stockOutDetail.ErrorQuantity;
                    stockOutDetailView.LostCount = stockOutDetail.LostQuantity;
                    stockOutDetailView.UnconfirmCount = stockOutDetail.UnconfirmQuantity;
                    deptStockOutDetailList.Add(stockOutDetailView);
                }

            }
            bdsDeptStockOutDetail.EndEdit();
            dgvStockOutDetail.Refresh();
            dgvStockOutDetail.Invalidate();
            CalculateGrandTotalCount();
        }

        private void CalculateGrandTotalCount()
        {
            long grandTotal = 0;
            foreach (StockOutDetailView detailView in deptStockOutDetailList)
            {
                grandTotal += detailView.TotalCount;
            }
            txtGrandTotalCount.Text = grandTotal.ToString("##,##0");
        }

        private bool HasCreatedView(StockOutDetail detail)
        {
            foreach (StockOutDetailView outDetailView in deptStockOutDetailList)
            {
                if (outDetailView.StockOutDetail.Product.ProductId == detail.Product.ProductId
                    && outDetailView.StockOutDetail.StockOutDetailId == detail.StockOutDetailId)
                    //&& outDetailView.StockOutDetail.DepartmentId == detail.DepartmentStockOut.DepartmentStockOutPK.DepartmentId)
                {
                    return true;
                }
            }
            return false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            DataGridViewSelectedRowCollection selectedRows = dgvStockOut.SelectedRows;
            if (!(selectedRows.Count > 0))
            {
                return;
            }

            StockOutConfirmEventArgs eventArgs = new StockOutConfirmEventArgs();

            IList list = new ArrayList();
            foreach (DataGridViewRow row in selectedRows)
            {
                list.Add(deptStockOutList[row.Index].StockOut);
            }

            eventArgs.ConfirmDepartmentStockOutList = list;
            EventUtility.fireEvent(ConfirmStockOutEvent, this, eventArgs);
            if (!eventArgs.HasErrors)
            {

            }
            ClearForm();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selectedRows = dgvStockOut.SelectedRows;
            if(!(selectedRows.Count >0) )
            {
                return;                
            }

            StockOutConfirmEventArgs eventArgs = new StockOutConfirmEventArgs();

            IList list = new ArrayList();
            foreach (DataGridViewRow row in selectedRows)
            {
                list.Add(deptStockOutList[row.Index].StockOut);          
            }
            
            eventArgs.DenyDepartmentStockOutList = list;
            EventUtility.fireEvent(DenyStockOutEvent,this,eventArgs);
            if(!eventArgs.HasErrors)
            {
                
            }
            ClearForm();

        }

        private void ClearForm()
        {
            deptStockOutList.Clear();
            deptStockOutDetailList.Clear();
        }

        #region Implementation of IStockOutConfirmView

        private IStockOutConfirmController stockOutConfirmController;
        public IStockOutConfirmController StockOutConfirmController
        {
            get
            {
                return stockOutConfirmController;
            }
            set
            {
                stockOutConfirmController = value;
                stockOutConfirmController.MainStockOutReportView = this;
            }
        }
        public event EventHandler<StockOutConfirmEventArgs> ConfirmStockOutEvent;
        public event EventHandler<StockOutConfirmEventArgs> DenyStockOutEvent;
        public event EventHandler<StockOutConfirmEventArgs> LoadStockOutsEvent;

        #endregion
    }
}
