using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AppFrame.Collection;
using AppFrame.Model;
using AppFrame.Presenter.Report;
using AppFrame.Utility;
using AppFrame.View.Reports;
using AppFrameClient.ViewModel;

namespace AppFrameClient.View.Reports
{
    public partial class MainStockOutReportForm : AppFrame.Common.BaseForm,IStockOutReportView
    {
        private StockOutViewCollection stockOutList = null;
        private StockOutDetailViewCollection stockOutDetailViewList = null;
        private const int GOOD_COUNT = 0;
        private const int ERROR_COUNT = 1;
        private const int DAMAGE_COUNT = 2;
        private const int LOST_COUNT = 3;

        public MainStockOutReportForm()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            stockOutList.Clear();
                   ReportStockOutEventArgs eventArgs = new ReportStockOutEventArgs();
                   eventArgs.ReportDateStockOutParam =
                       new ReportDateStockOutParam
                           {
                               FromDate = DateUtility.ZeroTime(dtpFrom.Value),
                               ToDate = DateUtility.MaxTime(dtpTo.Value)
                           };
            EventUtility.fireEvent(LoadStockOutsEvent,this,eventArgs);
            
            if(eventArgs.ResultStockOutList!=null)
            {
                foreach (IList result in eventArgs.ResultStockOutList)
                {
                    StockOutView stockOutView = new StockOutView();
                    stockOutView.StockOut = (StockOut)result[0];
                    stockOutView.TotalQuantity = (long) result[1];
                    stockOutView.Department = (Department) result[3];
                    if (stockOutView.Department != null)
                    {
                        stockOutView.DepartmentName = stockOutView.DepartmentName;
                    }
                    else
                    {
                        stockOutView.DepartmentName = " Kho chinh";
                    }
                    stockOutView.CreateDate = stockOutView.StockOut.CreateDate;
                    bdsStockOut.Add(stockOutView);
                }     
            }

            bdsStockOut.EndEdit();
            dgvStock.Refresh();
            dgvStock.Invalidate();
            CreateCountOnList();
        }

        private void CreateCountOnList()
        {
            for (int i = 0; i < dgvStockOut.Rows.Count;i++ )
            {
                dgvStockOut[0, dgvStockOut.Rows[i].Index].Value = i + 1;
            }
        }

        #region IStockOutReportView Members

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
                reportStockOutController.MainStockOutReportView = this;
            }
        }

        public event EventHandler<AppFrame.Presenter.Report.ReportStockOutEventArgs> LoadStockOutsEvent;

        public event EventHandler<AppFrame.Presenter.Report.ReportStockOutEventArgs> LoadStockOutDetailEvent;

        #endregion

        private void MainStockOutReportForm_Load(object sender, EventArgs e)
        {
            stockOutList = new StockOutViewCollection(bdsStockOut);
            bdsStockOut.DataSource = stockOutList;
            bdsStockOut.ResetBindings(true);

            stockOutDetailViewList = new StockOutDetailViewCollection(bdsStockOutDetail);
            bdsStockOutDetail.DataSource = stockOutDetailViewList;
            bdsStockOutDetail.ResetBindings(true);

        }
        
    

        private void dgvStockOut_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvStockOut.CurrentCell ==null)
            {
                return;
            }
            stockOutDetailViewList.Clear();
            StockOutView stockOut = stockOutList[dgvStockOut.CurrentCell.OwningRow.Index];
            IList stockOutDetails = stockOut.StockOut.StockOutDetails;
            foreach (StockOutDetail stockOutDetail in stockOutDetails)
            {
                if (!HasCreatedView(stockOutDetail))
                {
                    StockOutDetailView stockOutDetailView = new StockOutDetailView();

                        stockOutDetailView.StockOutDetail = stockOutDetail;
                        
                        stockOutDetailView.GoodCount = stockOutDetail.GoodQuantity;
                        stockOutDetailView.ErrorCount = stockOutDetail.ErrorQuantity;
                        stockOutDetailView.DamageCount = stockOutDetail.DamageQuantity;
                        stockOutDetailView.UnconfirmCount = stockOutDetail.UnconfirmQuantity;
                    stockOutDetailView.LostCount = stockOutDetail.LostQuantity;

                    stockOutDetailView.TotalCount = stockOutDetail.Quantity;
                    stockOutDetailViewList.Add(stockOutDetailView);
                }

            }
            
            CalculateGrandTotalCount();

        }

        private void CalculateGrandTotalCount()
        {
            long grandTotal = 0;
            foreach (StockOutDetailView detailView in stockOutDetailViewList)
            {
                grandTotal += detailView.TotalCount;                
            }
            txtGrandTotalCount.Text = grandTotal.ToString("##,##0");
        }

        private long GetSpecificQuantity(StockOutDetail searchDetail,IList details, int specificCount)
        {
            foreach (StockOutDetail detail in details)
            {
                if ( detail.Product.ProductId == searchDetail.Product.ProductId &&
                    detail.DefectStatus.DefectStatusId == specificCount)
                {
                    return detail.Quantity;
                }
            }
            return 0;
        }

        private bool HasCreatedView(StockOutDetail detail)
        {
            foreach (StockOutDetailView outDetailView in stockOutDetailViewList)
            {
                if(outDetailView.StockOutDetail.Product.ProductId == detail.Product.ProductId
                   && outDetailView.StockOutDetail.StockOut.StockoutId == detail.StockOut.StockoutId )
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
    }
}
