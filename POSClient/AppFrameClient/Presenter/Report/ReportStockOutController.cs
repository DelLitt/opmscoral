using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame;
using AppFrame.Model;
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
            criteria.AddBetweenCriteria("CreateDate", e.ReportDateStockOutParam.FromDate, e.ReportDateStockOutParam.ToDate);
            criteria.AddEqCriteria("DepartmentStockInPK.DepartmentId", e.SelectDepartment.DepartmentId);
            IList stockInList = DepartmentStockInLogic.FindAll(criteria);
            e.ResultStockOutList = stockInList;

            IList productMasterList = DepartmentStockInLogic.FindByProductMaster(e.SelectDepartment.DepartmentId,e.ReportDateStockOutParam.FromDate, e.ReportDateStockOutParam.ToDate);
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

        private AppFrame.View.Reports.IStockOutReportView mainStockOutReportView;
        public AppFrame.View.Reports.IStockOutReportView MainStockOutReportView
        {
            get
            {
                return mainStockOutReportView;
            }
            set
            {
                mainStockOutReportView = value;
                mainStockOutReportView.LoadStockOutsEvent += new EventHandler<ReportStockOutEventArgs>(mainStockOutReportView_LoadStockOutsEvent);
            }
        }

        void mainStockOutReportView_LoadStockOutsEvent(object sender, ReportStockOutEventArgs e)
        {
            IList list = StockOutLogic.FindStockOut(e.ReportDateStockOutParam.FromDate, e.ReportDateStockOutParam.ToDate);
            if (list != null)
            {
                IList parentList = new ArrayList();
                for (int i = 0; i < list.Count; i++)
                {
                    IList childList = new ArrayList();
                    childList.Add(((IList)list[i])[0]);
                    childList.Add(((IList)list[i])[1]);
                    childList.Add(((IList)list[i])[2]);
                    long departmentId = (long) ((IList) list[i])[2];
                    Department dep = DepartmentLogic.FindById(departmentId);
                    childList.Add(dep);
                    parentList.Add(childList);
                }
                e.ResultStockOutList = parentList;
            }
        }

        public AppFrame.Logic.IDepartmentStockOutLogic DepartmentStockOutLogic
        {
            get;set;
        }

        public AppFrame.Logic.IDepartmentStockOutDetailLogic DepartmentStockOutDetailLogic
        {
            get;set;
        }

        public AppFrame.Logic.IStockOutLogic StockOutLogic
        {
            get;set;
            
        }

        public AppFrame.Logic.IStockOutDetailLogic StockOutDetailLogic
        {
            get;set;
        }

        #endregion
    }
}
