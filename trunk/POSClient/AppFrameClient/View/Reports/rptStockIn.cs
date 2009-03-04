﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
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
            stockInParam.FromDate = dtpFrom.Value;
            stockInParam.ToDate = dtpTo.Value;
            eventArgs.ReportStockInParam = stockInParam;
            EventUtility.fireEvent(LoadStockInByRangeEvent,this,eventArgs);

            // get result
            resultList = eventArgs.ResultStockInList;

            IList stockDetailByPMList = eventArgs.ProductMastersInList;
            
            
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
            bdsStockInResultDetail.EndEdit();
        }

        #region IReportStockInView Members


        public event EventHandler<ReportStockInEventArgs> LoadStockInByRangeEvent;

        #endregion

        private void frmStockinStatistic_Load(object sender, EventArgs e)
        {
            pSODetResultList = new StockInResultDetailCollection(bdsStockInResultDetail);
            bdsStockInResultDetail.DataSource = pSODetResultList;
        }

        private void dgvStockProducts_SelectionChanged(object sender, EventArgs e)
        {
            if(resultList == null)
            {
                return;
            }

        }
    }
}
