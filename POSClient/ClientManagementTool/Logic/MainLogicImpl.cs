using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame;
using AppFrame.Common;
using AppFrame.Logic;
using AppFrame.Model;
using AppFrameClient.Logic;

namespace ClientManagementTool.Logic
{
    public class MainLogicImpl : IMainLogic
    {
        #region IMainLogic Members

        private ClientManagementTool.View.IMainView mainView;
        public ClientManagementTool.View.IMainView MainView
        {
            get
            {
                return mainView;
            }
            set
            {
                mainView = value;
                mainView.ProcessPeriodEvent += new EventHandler<MainLogicEventArgs>(mainView_ProcessPeriodEvent);
                mainView.StartPeriodEvent += new EventHandler<MainLogicEventArgs>(mainView_StartPeriodEvent);
                mainView.EndPeriodEvent += new EventHandler<MainLogicEventArgs>(mainView_EndPeriodEvent);
            }
        }

        void mainView_EndPeriodEvent(object sender, MainLogicEventArgs e)
        {
            DepartmentManagement curDM = e.DepartmentManagement;
            curDM.EndTime = DateTime.Now;
            DepartmentManagementLogic.Update(curDM);
        }

        void mainView_StartPeriodEvent(object sender, MainLogicEventArgs e)
        {
            DepartmentManagement dm = new DepartmentManagement();
            dm.CreateId = e.UserInfo.Username;
            dm.UpdateId = e.UserInfo.Username;
            dm.CreateDate = DateTime.Now;
            dm.UpdateDate = DateTime.Now;
            dm.WorkingDay = DateTime.Now;
            dm.StartTime = DateTime.Now;
            dm.DepartmentManagementPK = new DepartmentManagementPK
                                            {
                                                DepartmentId = CurrentDepartment.Get().DepartmentId,
                                                EmployeeId = e.UserInfo.EmployeeInfo.EmployeePK.EmployeeId
                                            };
            DepartmentManagementLogic.Add(dm);
        }

        void mainView_ProcessPeriodEvent(object sender, MainLogicEventArgs e)
        {
            string UserId = e.Username;
            LoginModel UserInfo = LoginLogic.FindById(UserId);
            if(UserInfo.EmployeeInfo!=null)
            {
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
