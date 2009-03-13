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
using AppFrame.Presenter.Report;
using AppFrame.Utility;
using AppFrame.View.GoodsIO;
using AppFrame.View.Reports;
using AppFrameClient.ViewModel;

namespace AppFrameClient.View.GoodsIO
{
    public partial class DepartmentStockOutConfirmForm : BaseForm,IDepartmentStockOutReportView
    {
        private DepartmentStockOutViewCollection deptStockOutList = null;
        private DepartmentStockOutDetailViewCollection deptStockOutDetailList = null;
        public DepartmentStockOutConfirmForm()
        {
            InitializeComponent();
        }

        #region IDepartmentStockOutReportView Members

        private AppFrame.Presenter.Report.IReportStockOutController reportStockOutController;
        public AppFrame.Presenter.Report.IReportStockOutController ReportStockOutController
        {
            get
            {
                return reportStockOutController;
            }
            set
            {
                reportStockOutController = value;
                reportStockOutController.DepartmentStockOutReportView = this;
            }
        }    

        #endregion

        private void btnSearch_Click(object sender, EventArgs e)
        {

            deptStockOutList.Clear();
            ReportStockOutEventArgs eventArgs = new ReportStockOutEventArgs();
            eventArgs.ReportDateStockOutParam =
                new ReportDateStockOutParam
                {
                    FromDate = DateUtility.ZeroTime(dtpFrom.Value),
                    ToDate = DateUtility.MaxTime(dtpTo.Value)
                };
            EventUtility.fireEvent(LoadDepartmentStockOutsEvent, this, eventArgs);

            if (eventArgs.ResultStockOutList != null)
            {
                foreach (IList result in eventArgs.ResultStockOutList)
                {
                    DepartmentStockOutView stockOutView = new DepartmentStockOutView();
                    stockOutView.DepartmentStockOut = (DepartmentStockOut)result[0];
                    stockOutView.TotalQuantity = (long)result[1];
                    stockOutView.Department = (Department)result[3];
                    if (stockOutView.Department != null)
                    {
                        stockOutView.DepartmentName = stockOutView.Department.DepartmentName;
                    }
                    else
                    {
                        stockOutView.DepartmentName = " Kho chinh";
                    }
                    stockOutView.CreateDate = stockOutView.DepartmentStockOut.CreateDate;
                    deptStockOutList.Add(stockOutView);
                }
            }
            else
            {
                MessageBox.Show(" Không có hoá đơn xuất kho của cửa hàng nào cần xác nhận.");
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
        

        #region IDepartmentStockOutReportView Members


        public event EventHandler<AppFrame.Presenter.Report.ReportStockOutEventArgs> ConfirmStockOutEvent;
        

        public event EventHandler<AppFrame.Presenter.Report.ReportStockOutEventArgs> DenyStockOutEvent;
        

        public event EventHandler<AppFrame.Presenter.Report.ReportStockOutEventArgs> LoadDepartmentStockOutsEvent;

        #endregion

        private void DepartmentStockOutConfirmForm_Load(object sender, EventArgs e)
        {
           deptStockOutList = new DepartmentStockOutViewCollection(bdsDeptStockOut);
            bdsDeptStockOut.DataSource = deptStockOutList;
            bdsDeptStockOut.ResetBindings(true);
            
            deptStockOutDetailList = new DepartmentStockOutDetailViewCollection(bdsDeptStockOutDetail);
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
            DepartmentStockOutView stockOut = deptStockOutList[dgvStockOut.CurrentCell.OwningRow.Index];
            IList stockOutDetails = stockOut.DepartmentStockOut.DepartmentStockOutDetails;
            foreach (DepartmentStockOutDetail stockOutDetail in stockOutDetails)
            {
                if (!HasCreatedView(stockOutDetail))
                {
                    DepartmentStockOutDetailView stockOutDetailView = new DepartmentStockOutDetailView();

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
            foreach (DepartmentStockOutDetailView detailView in deptStockOutDetailList)
            {
                grandTotal += detailView.TotalCount;
            }
            txtGrandTotalCount.Text = grandTotal.ToString("##,##0");
        }

        private bool HasCreatedView(DepartmentStockOutDetail detail)
        {
            foreach (DepartmentStockOutDetailView outDetailView in deptStockOutDetailList)
            {
                if (outDetailView.StockOutDetail.Product.ProductId == detail.Product.ProductId
                    && outDetailView.StockOutDetail.StockOutId == detail.DepartmentStockOut.DepartmentStockOutPK.StockOutId
                    && outDetailView.StockOutDetail.DepartmentId == detail.DepartmentStockOut.DepartmentStockOutPK.DepartmentId)
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

            ReportStockOutEventArgs eventArgs = new ReportStockOutEventArgs();

            IList list = new ArrayList();
            foreach (DataGridViewRow row in selectedRows)
            {
                list.Add(deptStockOutList[row.Index].DepartmentStockOut);
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

            ReportStockOutEventArgs eventArgs = new ReportStockOutEventArgs();

            IList list = new ArrayList();
            foreach (DataGridViewRow row in selectedRows)
            {
                list.Add(deptStockOutList[row.Index].DepartmentStockOut);          
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
    }
}
