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
using AppFrame.Utility;
using AppFrameClient.View.Management;
using ClientManagementTool.Logic;

namespace AppFrameClient.Logic
{
    public class EmployeeWorkingsLogicImpl : IEmployeeWorkingsLogic
    {
        private IEmployeeWorkingsView employeeWorkingView;
        public IEmployeeWorkingsView EmployeeWorkingView
        {
            get { return employeeWorkingView; }
            set
            {
                employeeWorkingView = value;
                employeeWorkingView.SaveEmployeeWorkingDay += new EventHandler<EmployeeWorkingsLogicEventArg>(employeeWorkingView_SaveEmployeeWorkingDay);
                employeeWorkingView.LoadEmployeesWorkingDay += new EventHandler<EmployeeWorkingsLogicEventArg>(employeeWorkingView_LoadEmployeesWorkingDay);
            }
        }

        void employeeWorkingView_LoadEmployeesWorkingDay(object sender, EmployeeWorkingsLogicEventArg e)
        {
            ObjectCriteria wDayCrit = new ObjectCriteria();
            wDayCrit.AddEqCriteria("Department.DepartmentId", CurrentDepartment.Get().DepartmentId);
            wDayCrit.AddBetweenCriteria("EmployeeWorkingDayPK.WorkingDay", DateUtility.ZeroTime(DateTime.Now),
                                        DateUtility.MaxTime(DateTime.Now));

            IList wDayResult = EmployeeWorkingDayLogic.FindAll(wDayCrit);
            e.EmployeeWorkingList = wDayResult;
            if(wDayResult!=null && wDayResult.Count > 0)
            {
                foreach (EmployeeWorkingDay workingDay in wDayResult)
                {
                    ObjectCriteria criteria = new ObjectCriteria();
                    criteria.AddEqCriteria("EmployeePK.EmployeeId", workingDay.EmployeeWorkingDayPK.EmployeeId);
                    IList list = EmployeeLogic.FindAll(criteria);
                    workingDay.Employee = (Employee)list[0];
                }
            }
        }

        public IEmployeeWorkingDayLogic EmployeeWorkingDayLogic
        {
            get;
            set;
        }

        public IEmployeeDetailLogic EmployeeInfoLogic { get; set; }
        public IEmployeeLogic EmployeeLogic { get; set; }

        void employeeWorkingView_SaveEmployeeWorkingDay(object sender, EmployeeWorkingsLogicEventArg e)
        {
            string barCode = e.EmployeeId;
            ObjectCriteria criteria = new ObjectCriteria();
            criteria.AddEqCriteria("Barcode", barCode);
            IList list = EmployeeInfoLogic.FindAll(criteria);
            if (list != null && list.Count == 1)
            {
                EmployeeInfo info = (EmployeeInfo)list[0];
                EmployeeWorkingDay workingDay = e.EmployeeWorkingDay;
                if (workingDay == null)
                {
                    workingDay = new EmployeeWorkingDay();
                    workingDay.CreateDate = DateTime.Now;
                    workingDay.CreateId = ClientInfo.getInstance().LoggedUser.Name;
                    workingDay.UpdateDate = DateTime.Now;
                    workingDay.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                    //workingDay.StartTime = DateTime.Now;
                    
                    workingDay.EndTime = DateTime.MinValue;
                    workingDay.EmployeeWorkingDayPK = new EmployeeWorkingDayPK
                                                          {
                                                              //DepartmentId = CurrentDepartment.Get().DepartmentId,
                                                              EmployeeId = info.EmployeePK.EmployeeId,
                                                              WorkingDay = DateTime.Now
                                                          };

                    workingDay.Employee = info.Employee;
                    workingDay.Department = CurrentDepartment.Get();
                    workingDay.DelFlg = 0;
                    workingDay.ExclusiveKey = 1;
                }

                ObjectCriteria wDayCrit = new ObjectCriteria();
                wDayCrit.AddEqCriteria("Department.DepartmentId", workingDay.Department.DepartmentId);
                wDayCrit.AddEqCriteria("EmployeeWorkingDayPK.EmployeeId", workingDay.EmployeeWorkingDayPK.EmployeeId);
                wDayCrit.AddBetweenCriteria("EmployeeWorkingDayPK.WorkingDay", DateUtility.ZeroTime(DateTime.Now),
                                            DateUtility.MaxTime(DateTime.Now));

                IList wDayResult = EmployeeWorkingDayLogic.FindAll(wDayCrit);
                if (wDayResult == null || wDayResult.Count == 0)
                {
                    workingDay.StartTime = DateTime.Now;
                    EmployeeWorkingDayLogic.Add(workingDay);
                    
                }
                else
                {
                    EmployeeWorkingDay currWDay = (EmployeeWorkingDay) wDayResult[0];
                    currWDay.EndTime = DateTime.Now;
                    workingDay.EndTime = currWDay.EndTime;
                    EmployeeWorkingDayLogic.Update(currWDay);

                }

                e.EmployeeWorkingDay = workingDay;
                

                e.HasErrors = false;
            }
            else
            {
                e.HasErrors = true;
                throw new BusinessException("Mã vạch của nhân viên không đúng");
            }


        }
    }
}