using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame;
using AppFrame.Logic;
using AppFrame.Model;
using AppFrame.Presenter;
using AppFrame.Utility;
using AppFrame.View;

namespace AppFrameClient.Presenter
{
    public class ProcessPeriodMoneyController : IProcessPeriodMoneyControler
    {
        private IProcessPeriodMoneyView processPeriodMoneyView;
        public IProcessPeriodMoneyView ProcessPeriodMoneyView
        {
            get { return processPeriodMoneyView; }
            set 
            { 
                processPeriodMoneyView = value;
                processPeriodMoneyView.LoadProcessPeriodMoneyEvent += new EventHandler<ProcessPeriodMoneyEventArgs>(processPeriodMoneyView_LoadProcessPeriodMoneyEvent);
                processPeriodMoneyView.ProcessEmployeeMoneyEvent += new EventHandler<ProcessPeriodMoneyEventArgs>(processPeriodMoneyView_ProcessEmployeeMoneyEvent);
            }
        }

        void processPeriodMoneyView_ProcessEmployeeMoneyEvent(object sender, ProcessPeriodMoneyEventArgs e)
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

        void processPeriodMoneyView_LoadProcessPeriodMoneyEvent(object sender, ProcessPeriodMoneyEventArgs e)
        {
            DateTime toDay = DateUtility.DateOnly(DateTime.Now);
            ObjectCriteria objectCriteria = new ObjectCriteria();
            objectCriteria.AddEqCriteria("EmployeeMoneyPK.WorkingDay", toDay);
            IList list  = EmployeeMoneyLogic.FindAll(objectCriteria);
            e.PeriodMoneyList = list;
        }

        public IEmployeeMoneyLogic EmployeeMoneyLogic
        {
            get; set;
        }
    }
}