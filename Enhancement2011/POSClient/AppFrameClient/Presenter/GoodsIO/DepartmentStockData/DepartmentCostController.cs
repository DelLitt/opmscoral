using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame;
using AppFrame.Common;
using AppFrame.Exceptions;
using AppFrame.Logic;
using AppFrame.Model;
using AppFrame.Presenter.GoodsIO.DepartmentGoodsIO;
using AppFrame.Utility;
using AppFrame.View.GoodsIO.DepartmentGoodsIO;
using AppFrameClient.MasterDBTableAdapters;
using Microsoft.ReportingServices.Diagnostics.Utilities;

namespace AppFrameClient.Presenter.GoodsIO.DepartmentStockData
{
    public class DepartmentCostController : IDepartmentCostController
    {
        private IDepartmentCostCreateView departmentCostCreateView;
        public IDepartmentCostCreateView DepartmentCostCreateView
        {
            get
            {
                return departmentCostCreateView;
            }
            set
            {
                departmentCostCreateView = value;
                departmentCostCreateView.CreateDepartmentCostEvent += new EventHandler<DepartmentCostEventArgs>(departmentCostCreateView_CreateDepartmentCostEvent);
            }
        }

        void departmentCostCreateView_CreateDepartmentCostEvent(object sender, DepartmentCostEventArgs e)
        {
            try
            {
                if (e.CreateCost != null)
                    DepartmentCostLogic.Add(e.CreateCost);
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                e.HasErrors = true;               
                
            }
            

        }

        private IDepartmentCostEditView departmentCostEditView;
        public IDepartmentCostEditView DepartmentCostEditView
        {
            get
            {
                return departmentCostEditView;    
            }
            set
            {
                departmentCostEditView = value;
                departmentCostEditView.EditDepartmentCostEvent += new EventHandler<DepartmentCostEventArgs>(departmentCostEditView_EditDepartmentCostEvent);
            }
        }

        void departmentCostEditView_EditDepartmentCostEvent(object sender, DepartmentCostEventArgs e)
        {
            try
            {
                if (e.CreateCost != null)
                    DepartmentCostLogic.Update(e.UpdateCost);
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                e.HasErrors = true;

            }
        }

        private IDepartmentCostListView departmentCostListView;        
        public IDepartmentCostListView DepartmentCostListView
        {
            get
            {
                return departmentCostListView;                
            }
            set
            {
                departmentCostListView = value;
                departmentCostListView.SearchDepartmentCostEvent += new EventHandler<DepartmentCostEventArgs>(departmentCostListView_SearchDepartmentCostEvent);
            }
        }

        private IDepartmentCostSummaryView departmentCostSummaryView;
        public IDepartmentCostSummaryView DepartmentCostSummaryView
        {
            get
            {
                return departmentCostSummaryView; 
            }
            set
            {
                departmentCostSummaryView = value;
                departmentCostSummaryView.CommitDepartmentCostEvent += new EventHandler<DepartmentCostEventArgs>(departmentCostSummaryView_CommitDepartmentCostEvent);
            }
        }

        void departmentCostSummaryView_CommitDepartmentCostEvent(object sender, DepartmentCostEventArgs e)
        {
            
            // Save the end of period
            // select 5 day nearest
            //IList departmentTimelineList = new ArrayList();
            ObjectCriteria crit = new ObjectCriteria();
            crit.AddOrder("EmployeeMoneyPK.WorkingDay", false);
            crit.MaxResult = 5;
            IList prevList = EmployeeMoneyLogic.FindAll(crit);
            DateTime startTime = DateUtility.ZeroTime(DateTime.Now);
            if (prevList != null && prevList.Count > 0)
            {
                // update end time of nearest 5 timeline for sure transparency
                EmployeeMoney fixEmpMoney = (EmployeeMoney)prevList[0];
                DateTime lastSubmitEndTime = fixEmpMoney.EmployeeMoneyPK.WorkingDay;

                // get days which customer do not submit period 
                TimeSpan timeSpan = DateUtility.ZeroTime(DateTime.Now).Subtract(DateUtility.ZeroTime(lastSubmitEndTime));
                // fix those days in order we can sync for today.

                //startTime = lastSubmitEndTime.AddSeconds(1);
                for (int i = 0; i < timeSpan.Days - 1; i++)
                {
                    DateTime nextDateTime = lastSubmitEndTime.AddDays(i + 1);
                    EmployeeMoney fixEmplMoney = new EmployeeMoney();
                    fixEmplMoney.WorkingDay = DateUtility.DateOnly(nextDateTime);
                    fixEmplMoney.CreateDate = DateUtility.MaxTime(nextDateTime);
                    fixEmplMoney.UpdateDate = DateUtility.MaxTime(nextDateTime);
                    fixEmplMoney.CreateId = ClientInfo.getInstance().LoggedUser.Name;
                    fixEmplMoney.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                    fixEmplMoney.DateLogin = DateUtility.MaxTime(nextDateTime);
                    fixEmplMoney.DateLogout = DateUtility.MaxTime(nextDateTime);
                    fixEmplMoney.InMoney = 0;
                    fixEmplMoney.OutMoney = 0;
                    EmployeeMoneyPK fixTimelinePK = new EmployeeMoneyPK
                    {
                        DepartmentId = CurrentDepartment.Get().DepartmentId,
                        EmployeeId = ClientInfo.getInstance().LoggedUser.Name,
                        WorkingDay = DateUtility.DateOnly(nextDateTime)
                    };

                    fixEmplMoney.EmployeeMoneyPK = fixTimelinePK;
                    EmployeeMoneyLogic.Add(fixEmplMoney);
                    //startTime = fixEmplMoney.EndTime.AddSeconds(1);
                }

            }
            #region unused code
            // If submit period ( ket so ) then we ' ket so '
            /*DepartmentTimeline timeline = null;
            if (isSubmitPeriod)
            {
                timeline = new DepartmentTimeline();
                timeline.WorkingDay = DateUtility.ZeroTime(DateTime.Now);
                timeline.CreateDate = DateTime.Now;
                timeline.UpdateDate = DateTime.Now;
                timeline.CreateId = ClientInfo.getInstance().LoggedUser.Name;
                timeline.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                timeline.StartTime = startTime;
                timeline.EndTime = DateTime.Now;
                DepartmentTimelinePK timelinePK = new DepartmentTimelinePK
                {
                    DepartmentId = CurrentDepartment.Get().DepartmentId,
                    Period = DateTime.Now.DayOfYear
                };
                var dbTimeline = DepartmentTimelineDAO.FindById(timelinePK);
                if (dbTimeline != null)
                {
                    throw new BusinessException("Ngày hôm nay đã kết sổ");
                }
                timeline.DepartmentTimelinePK = timelinePK;
                DepartmentTimelineDAO.Add(timeline);

                //departmentTimelineList.Add(timeline);
            }*/
            
            #endregion
            DateTime toDay = DateUtility.DateOnly(DateTime.Now);



            EmployeeMoney employeeMoney = new EmployeeMoney();
            employeeMoney.EmployeeMoneyPK = new EmployeeMoneyPK
                                                {
                                                    DepartmentId = CurrentDepartment.Get().DepartmentId,
                                                    EmployeeId = ClientInfo.getInstance().LoggedUser.Name,
                                                    WorkingDay = toDay
                                                };
            employeeMoney.WorkingDay = toDay;
            employeeMoney.CreateDate = DateTime.Now;
            employeeMoney.UpdateDate = DateTime.Now;
            employeeMoney.CreateId = ClientInfo.getInstance().LoggedUser.Name;
            employeeMoney.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
            employeeMoney.DateLogin = DateTime.Now;
            employeeMoney.DateLogout = DateTime.Now;
            employeeMoney.InMoney = 0;

            DateTime nextDay = toDay.AddDays(1);
            EmployeeMoney nextMoney = new EmployeeMoney();
            nextMoney.EmployeeMoneyPK = new EmployeeMoneyPK
            {
                DepartmentId = CurrentDepartment.Get().DepartmentId,
                EmployeeId = ClientInfo.getInstance().LoggedUser.Name,
                WorkingDay = nextDay
            };
            nextMoney.WorkingDay = nextDay;
            nextMoney.CreateDate = nextDay;
            nextMoney.UpdateDate = nextDay;
            nextMoney.CreateId = ClientInfo.getInstance().LoggedUser.Name;
            nextMoney.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
            nextMoney.DateLogin = DateTime.Now;
            nextMoney.DateLogout = DateTime.Now;
            employeeMoney.InMoney = e.OutMoney;

            EmployeeMoney nextMoneyInDB = EmployeeMoneyLogic.FindById(employeeMoney.EmployeeMoneyPK);
            if (nextMoneyInDB != null)
            {
                throw new BusinessException("Ngày hôm nay đã kết sổ !");
            }
            
            ObjectCriteria objectCriteria = new ObjectCriteria();
            objectCriteria.AddEqCriteria("EmployeeMoneyPK.WorkingDay", toDay);
            objectCriteria.AddEqCriteria("EmployeeMoneyPK.DepartmentId", CurrentDepartment.Get().DepartmentId);    
            IList list = EmployeeMoneyLogic.FindAll(objectCriteria);
            if(list!=null && list.Count == 1)
            {
                employeeMoney = (EmployeeMoney)list[0];
                // count out money
                employeeMoney.OutMoney = e.OutMoney;
                employeeMoney.UpdateDate = DateTime.Now;
                employeeMoney.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                EmployeeMoneyLogic.Update(employeeMoney);
            }
            else
            {
                employeeMoney.OutMoney = e.OutMoney;
                EmployeeMoneyLogic.Add(employeeMoney);    
            }

            EmployeeMoneyLogic.Add(nextMoney);
            e.EventResult = "Success";
            
        }

        void departmentCostListView_SearchDepartmentCostEvent(object sender, DepartmentCostEventArgs e)
        {
           if(e.FromDate == DateTime.MinValue && e.ToDate == DateTime.MinValue)
           {
                ObjectCriteria objectCriteria = new ObjectCriteria();
                objectCriteria.AddBetweenCriteria("DepartmentCostPK.CostDate", DateUtility.ZeroTime(DateTime.Now),
                                                 DateUtility.MaxTime(DateTime.Now));
                objectCriteria.AddEqCriteria("DepartmentCostPK.DepartmentId", CurrentDepartment.Get().DepartmentId);
               IList list = DepartmentCostLogic.FindAll(objectCriteria);
               e.CostList = list;
           }
        }
        public IDepartmentCostLogic DepartmentCostLogic { get; set; }
        public IEmployeeMoneyLogic EmployeeMoneyLogic
        {
            get; set;
        }
    }
}
