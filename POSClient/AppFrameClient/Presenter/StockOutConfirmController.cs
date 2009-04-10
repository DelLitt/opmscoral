using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Logic;
using AppFrame.Model;
using AppFrame.Presenter;
using AppFrame.View.GoodsIO;

namespace AppFrameClient.Presenter
{
    public class StockOutConfirmController : IStockOutConfirmController
    {
        #region Implementation of IStockOutConfirmController

        private IStockOutConfirmView mainStockOutReportView;
        public IStockOutConfirmView MainStockOutReportView
        {
            get
            {
                return mainStockOutReportView;
            }
            set
            {
                mainStockOutReportView = value;
                mainStockOutReportView.LoadStockOutsEvent += new EventHandler<StockOutConfirmEventArgs>(mainStockOutReportView_LoadStockOutsEvent);
            }
        }

        void mainStockOutReportView_LoadStockOutsEvent(object sender, StockOutConfirmEventArgs e)
        {
            DateTime startTime = e.ReportDateStockOutParam.FromDate;
            DateTime endTime = e.ReportDateStockOutParam.ToDate;

            IList list = StockOutLogic.FindStockOut(startTime, endTime);
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

        public IDepartmentStockInLogic DepartmentStockInLogic { get; set; }
        public IDepartmentStockInDetailLogic DepartmentStockInDetailLogic { get; set; }
        public IDepartmentLogic DepartmentLogic { get; set; }
        public IDepartmentStockOutLogic DepartmentStockOutLogic { get; set; }
        public IDepartmentStockOutDetailLogic DepartmentStockOutDetailLogic { get; set; }
        public IStockOutLogic StockOutLogic { get; set; }
        public IStockOutDetailLogic StockOutDetailLogic { get; set; }
        public IStockLogic StockLogic { get; set; }

        #endregion
    }
}
