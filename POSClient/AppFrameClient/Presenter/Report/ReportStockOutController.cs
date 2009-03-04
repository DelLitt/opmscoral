using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame;
using AppFrame.Presenter.Report;
using AppFrame.Presenter.SalePoints;

namespace AppFrameClient.Presenter.Report
{
    public class ReportStockOutController : IReportStockOutController
    {
        #region IReportStockOutController Members

        private AppFrame.View.Reports.IDepartmentGoodsExportReportView reportStockOutView;
        public AppFrame.View.Reports.IDepartmentGoodsExportReportView ReportStockOutView
        {
            get
            {
                return reportStockOutView;
            }
            set
            {
                reportStockOutView = value;
                reportStockOutView.LoadAllDeparmentEvent+=new EventHandler<ReportStockOutEventArgs>(reportStockOutView_LoadAllDeparmentEvent);
                reportStockOutView.LoadStockOutByRangeEvent += new EventHandler<ReportStockOutEventArgs>(reportStockOutView_LoadStockOutByRangeEvent);
            }
        }

        void reportStockOutView_LoadStockOutByRangeEvent(object sender, ReportStockOutEventArgs e)
        {
            ObjectCriteria criteria = new ObjectCriteria();
            criteria.AddBetweenCriteria("CreateDate", e.ReportStockOutParam.FromDate, e.ReportStockOutParam.ToDate);
            criteria.AddEqCriteria("DepartmentStockInPK.DepartmentId", e.SelectDepartment.DepartmentId);
            IList stockInList = DepartmentStockInLogic.FindAll(criteria);
            e.ResultStockOutList = stockInList;

            IList productMasterList = DepartmentStockInLogic.FindByProductMaster(e.SelectDepartment.DepartmentId,e.ReportStockOutParam.FromDate, e.ReportStockOutParam.ToDate);
            e.ProductMastersInList = productMasterList;
        }

        void  reportStockOutView_LoadAllDeparmentEvent(object sender, ReportStockOutEventArgs e)
        {
            ObjectCriteria criteria = new ObjectCriteria();
            criteria.AddEqCriteria("DelFlg", (long)0);
            IList departmentList = DepartmentLogic.FindAll(criteria);
            e.DepartmentsList = departmentList;
            
        }



        public AppFrame.Logic.IDepartmentStockInLogic DepartmentStockInLogic
        {
            get;set;
            
        }

        public AppFrame.Logic.IDepartmentStockInDetailLogic DepartmentStockInDetailLogic
        {
            get;set;
            
        }

        public AppFrame.Logic.IDepartmentLogic DepartmentLogic
        {
            get;set;
            
        }

        #endregion
    }
}
