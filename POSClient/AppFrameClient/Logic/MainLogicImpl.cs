using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame;
using AppFrame.Common;
using AppFrame.Logic;
using AppFrame.Model;
using AppFrameClient.View;

namespace AppFrameClient.Logic
{
    public class MainLogicImpl : IMainLogic
    {
        #region IMainLogic Members

        private IEmployeeManagementView mainView;
        public IEmployeeManagementView MainView
        {
            get
            {
                return mainView;
            }
            set
            {
                mainView = value;
                mainView.ProcessPeriodEvent += new EventHandler<EmployeeManagementEventArgs>(mainView_ProcessPeriodEvent);
                mainView.StartPeriodEvent += new EventHandler<EmployeeManagementEventArgs>(mainView_StartPeriodEvent);
                mainView.EndPeriodEvent += new EventHandler<EmployeeManagementEventArgs>(mainView_EndPeriodEvent);
                mainView.ProcessEmployeeMoneyEvent += new EventHandler<EmployeeManagementEventArgs>(mainView_ProcessEmployeeMoneyEvent);
            }
        }

        void mainView_ProcessEmployeeMoneyEvent(object sender, EmployeeManagementEventArgs e)
        {
            if (e.InMoney > 0)
            {
                EmployeeMoney employeeMoney = new EmployeeMoney();
                employeeMoney.EmployeeMoneyPK = new EmployeeMoneyPK
                {
                    DepartmentId = e.DepartmentManagement.DepartmentManagementPK.DepartmentId,
                    EmployeeId = e.DepartmentManagement.DepartmentManagementPK.EmployeeId,
                    WorkingDay = e.DepartmentManagement.DepartmentManagementPK.WorkingDay
                };
                employeeMoney.DateLogin = e.DepartmentManagement.StartTime;
                employeeMoney.InMoney = e.InMoney;
                employeeMoney.CreateDate = e.DepartmentManagement.CreateDate;
                employeeMoney.CreateId = e.DepartmentManagement.CreateId;
                employeeMoney.UpdateDate = e.DepartmentManagement.UpdateDate;
                employeeMoney.UpdateId = e.DepartmentManagement.UpdateId;
                EmployeeMoneyLogic.Add(employeeMoney);
            }
        }

        void mainView_EndPeriodEvent(object sender, EmployeeManagementEventArgs e)
        {
            DepartmentManagement curDM = e.DepartmentManagement;
            curDM.EndTime = DateTime.Now;
            DepartmentManagementLogic.Update(curDM);

            if (e.OutMoney > 0)
            {
                EmployeeMoneyPK employeeMoneyPk = new EmployeeMoneyPK
                {
                    DepartmentId = e.DepartmentManagement.DepartmentManagementPK.DepartmentId,
                    EmployeeId = e.DepartmentManagement.DepartmentManagementPK.EmployeeId,
                    WorkingDay = e.DepartmentManagement.DepartmentManagementPK.WorkingDay
                };
                EmployeeMoney employeeMoney = EmployeeMoneyLogic.FindById(employeeMoneyPk);
                employeeMoney.DateLogout = curDM.EndTime;
                employeeMoney.UpdateDate = DateTime.Now;
                employeeMoney.UpdateId = curDM.UpdateId;
                employeeMoney.OutMoney = e.OutMoney;
                EmployeeMoneyLogic.Update(employeeMoney);
            }

        }

        void mainView_StartPeriodEvent(object sender, EmployeeManagementEventArgs e)
        {
            DepartmentManagement dm = new DepartmentManagement();
            dm.CreateId = e.UserInfo.Username;
            dm.UpdateId = e.UserInfo.Username;
            dm.CreateDate = DateTime.Now;
            dm.UpdateDate = DateTime.Now;
            dm.StartTime = DateTime.Now;
            dm.DepartmentManagementPK = new DepartmentManagementPK
                                            {
                                                DepartmentId = CurrentDepartment.Get().DepartmentId,
                                                EmployeeId = e.UserInfo.EmployeeInfo.EmployeePK.EmployeeId,
                                                WorkingDay = DateTime.Now
                                            };
            DepartmentManagementLogic.Add(dm);
        }

        void mainView_ProcessPeriodEvent(object sender, EmployeeManagementEventArgs e)
        {
            string UserId = e.Username;
            LoginModel UserInfo = LoginLogic.FindById(UserId);
            if(UserInfo.EmployeeInfo!=null)
            {
                e.UserInfo = UserInfo;
                DepartmentManagement lastManagement = DepartmentManagementLogic.FindLastPeriod();
                e.DepartmentManagement = lastManagement;
            }
        }

        #endregion

        #region IMainLogic Members


        public AppFrame.Logic.IEmployeeWorkingDayLogic EmployeeWorkingDayLogic
        {
            get;set;
        }

        public AppFrame.Logic.IEmployeeDetailLogic EmployeeInfoLogic
        {
            get;set;
        }

        public AppFrame.Logic.IEmployeeLogic EmployeeLogic
        {
            get;set;
        }

        public IEmployeeMoneyLogic EmployeeMoneyLogic
        {
            get; set;
        }

        public AppFrame.Logic.IDepartmentTimelineLogic DepartmentTimelineLogic
        {
            get;set;
        }


        #endregion

        #region IMainLogic Members


        public AppFrame.Logic.IDepartmentManagementLogic DepartmentManagementLogic
        {
            get;set;
        }

        public ILoginLogic LoginLogic
        {
            get; set;
        }

        #endregion
    }
}