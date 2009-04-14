using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Common;

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
            }
        }

        void mainView_ProcessPeriodEvent(object sender, MainLogicEventArgs e)
        {
            BaseUser loggedUser = ClientInfo.getInstance().LoggedUser;
            
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
    }
}
