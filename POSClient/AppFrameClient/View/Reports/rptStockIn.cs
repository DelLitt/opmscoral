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
using AppFrame.View.Reports;
using AppFrameClient.ViewModel;

namespace AppFrameClient.View.Reports
{
    public partial class frmStockinStatistic : BaseForm,IReportStockInView
    {
        private StockInResultDetailCollection pSODetResultList = null;
        private StockInDetailCollection pSODetList = null;
        public frmStockinStatistic()
        {
            InitializeComponent();
            
        }

       #region IReportStockInView Members


        private AppFrame.Presenter.Report.IReportStockInController reportStockInController;
        public AppFrame.Presenter.Report.IReportStockInController ReportStockInController
        {
            get
            {
                return reportStockInController;
            }
            set
            {
                reportStockInController = value;
                reportStockInController.ReportStockInView = this;

            }
        }

        public ReportStockInParam ReportStockInParam
        {
            get;set;
        }

        #endregion

        private IList resultList = null;
        private void ok_Click(object sender, EventArgs e)
        {
            pSODetResultList.Clear();
           ReportStockInEventArgs eventArgs = new ReportStockInEventArgs();
            ReportStockInParam stockInParam = new ReportStockInParam();
            stockInParam.FromDate = DateUtility.ZeroTime(dtpFrom.Value);
            stockInParam.ToDate = DateUtility.MaxTime(dtpTo.Value);
            eventArgs.ReportStockInParam = stockInParam;
            EventUtility.fireEvent(LoadStockInByRangeEvent,this,eventArgs);

            // get result
            resultList = eventArgs.ResultStockInList;

            IList stockDetailByPMList = eventArgs.ProductMastersInList;
            
            if(stockDetailByPMList.Count == 0)
            {
                MessageBox.Show("Không tìm thấy hàng nào","Kết quả");
            }
            
            foreach (var o in stockDetailByPMList)
            {
                IList stockDetailByPM = (IList) o;
                ProductMasterGlobal productMasterGlobal = new ProductMasterGlobal();
                productMasterGlobal.ProductName = ((ProductMaster) stockDetailByPM[0]).ProductName;
                productMasterGlobal.ProductMaster = (ProductMaster)stockDetailByPM[0];
                StockInResultDetail stockInResultDetail = new StockInResultDetail();
                stockInResultDetail.ProductMasterGlobal = productMasterGlobal;
                stockInResultDetail.StockInQuantities = (long)stockDetailByPM[1];
                stockInResultDetail.StockInTotalAmounts = (long) stockDetailByPM[2];
                pSODetResultList.Add(stockInResultDetail);
            }
            bdsStockInResultPM.EndEdit();
            PopulateGrid();

        }

        private void PopulateGrid()
        {
            for(int i =0;i<dgvStockProducts.Rows.Count;i++)
            {
                dgvStockProducts[0, i].Value = i + 1;
            }


            for (int i = 0; i < dgvStockProductsDetail.Rows.Count; i++)
            {
                dgvStockProductsDetail[0, i].Value = i + 1;    
            }

        }

        #region IReportStockInView Members


        public event EventHandler<ReportStockInEventArgs> LoadStockInByRangeEvent;

        #endregion

        private void frmStockinStatistic_Load(object sender, EventArgs e)
        {
            pSODetResultList = new StockInResultDetailCollection(bdsStockInResultPM);
            bdsStockInResultPM.DataSource = pSODetResultList;

            pSODetList = new StockInDetailCollection(bdsStockInResultDetail);
            bdsStockInResultDetail.DataSource = pSODetList;
            dgvStockProductsDetail.Columns[1].DefaultCellStyle.Format = "dd/MM/yyyy hh:mm:ss";
        }

        private void dgvStockProducts_SelectionChanged(object sender, EventArgs e)
        {
            pSODetList.Clear();
            if(resultList == null)
            {
                return;
            }
            DataGridViewSelectedRowCollection selectedRows = dgvStockProducts.SelectedRows;
            if(selectedRows.Count > 0)
            {
                StockInResultDetail siRetDetail = pSODetResultList[selectedRows[0].Index];

                foreach (StockIn stockIn in resultList)
                {
                    foreach (StockInDetail stockInDetail in stockIn.StockInDetails)
                    {
                        if(stockInDetail.Product.ProductMaster.ProductName.Equals(siRetDetail.ProductMasterGlobal.ProductName))
                        {
                            pSODetList.Add(stockInDetail);
                        }
                    }    
                }
                bdsStockInResultDetail.EndEdit();
                PopulateGrid();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvStockProductsDetail_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            
        }
    }
}
