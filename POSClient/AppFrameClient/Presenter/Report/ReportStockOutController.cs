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

        #region IReportStockOutController Members

        AppFrame.View.GoodsIO.IDepartmentStockOutReportView departmentStockOutReportView;
        public AppFrame.View.GoodsIO.IDepartmentStockOutReportView DepartmentStockOutReportView
        {
            get
            {
                return departmentStockOutReportView;
            }
            set
            {
                departmentStockOutReportView = value;
                departmentStockOutReportView.LoadDepartmentStockOutsEvent += new EventHandler<ReportStockOutEventArgs>(departmentStockOutReportView_LoadDepartmentStockOutsEvent);
                departmentStockOutReportView.ConfirmStockOutEvent += new EventHandler<ReportStockOutEventArgs>(departmentStockOutReportView_ConfirmStockOutEvent);
                departmentStockOutReportView.DenyStockOutEvent += new EventHandler<ReportStockOutEventArgs>(departmentStockOutReportView_DenyStockOutEvent);    
            }
        }

        void departmentStockOutReportView_DenyStockOutEvent(object sender, ReportStockOutEventArgs e)
        {
            
        }

        void departmentStockOutReportView_ConfirmStockOutEvent(object sender, ReportStockOutEventArgs e)
        {
            
        }

        void departmentStockOutReportView_LoadDepartmentStockOutsEvent(object sender, ReportStockOutEventArgs e)
        {
            IList list = DepartmentStockOutLogic.FindStockOut(e.ReportDateStockOutParam.FromDate, e.ReportDateStockOutParam.ToDate);
            if (list != null)
            {
                IList parentList = new ArrayList();
                for (int i = 0; i < list.Count; i++)
                {
                    IList childList = new ArrayList();
                    childList.Add(((IList)list[i])[0]);
                    childList.Add(((IList)list[i])[1]);
                    childList.Add(((IList)list[i])[2]);
                    long departmentId = (long)((IList)list[i])[2];
                    Department dep = DepartmentLogic.FindById(departmentId);
                    childList.Add(dep);
                    parentList.Add(childList);
                }
                e.ResultStockOutList = parentList;
            }            
        }

        #endregion
    }
}
