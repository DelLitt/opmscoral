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

        private AppFrame.View.Reports.IDepartmentStockOutReportView reportDepartmentStockOutView;
        public AppFrame.View.Reports.IDepartmentStockOutReportView ReportDepartmentStockOutView
        {
            get
            {
                return reportDepartmentStockOutView;
            }
            set
            {
                reportDepartmentStockOutView = value;
                reportDepartmentStockOutView.LoadAllDeparmentEvent+=new EventHandler<ReportStockOutEventArgs>(reportStockOutView_LoadAllDeparmentEvent);
                reportDepartmentStockOutView.LoadStockOutByRangeEvent += new EventHandler<ReportStockOutEventArgs>(reportStockOutView_LoadDepartmentStockOutByRangeEvent);
            }
        }

        void reportStockOutView_LoadDepartmentStockOutByRangeEvent(object sender, ReportStockOutEventArgs e)
        {
            ObjectCriteria criteria = new ObjectCriteria();
            criteria.AddBetweenCriteria("CreateDate", e.ReportDepartmentStockOutParam.FromDate, e.ReportDepartmentStockOutParam.ToDate);
            criteria.AddEqCriteria("DepartmentStockInPK.DepartmentId", e.SelectDepartment.DepartmentId);
            IList stockInList = DepartmentStockInLogic.FindAll(criteria);
            e.ResultStockOutList = stockInList;

            IList productMasterList = DepartmentStockInLogic.FindByProductMaster(e.SelectDepartment.DepartmentId,e.ReportDepartmentStockOutParam.FromDate, e.ReportDepartmentStockOutParam.ToDate);
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

        #region IReportStockOutController Members


        public AppFrame.View.Reports.IStockOutReportView MainStockOutReportView
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public AppFrame.Logic.IDepartmentStockInLogic DepartmentStockOutLogic
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public AppFrame.Logic.IDepartmentStockInDetailLogic DepartmentStockOutDetailLogic
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public AppFrame.Logic.IStockOutLogic StockOutLogic
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public AppFrame.Logic.IStockOutDetailLogic StockOutDetailLogic
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        #endregion
    }
}
