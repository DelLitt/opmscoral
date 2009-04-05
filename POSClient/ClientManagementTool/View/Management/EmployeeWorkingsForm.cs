using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppFrame.Collection;
using AppFrame.Common;
using AppFrame.Model;
using AppFrame.Utility;
using ClientManagementTool.Logic;

namespace ClientManagementTool.View.Management
{
    public partial class EmployeeWorkingsForm : BaseForm,IEmployeeWorkingsView
    {
        private EmployeeWorkingDaysCollection ewdList = null;
        public EmployeeWorkingsForm()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private IEmployeeWorkingsLogic employeeWorkingsLogic;
        public IEmployeeWorkingsLogic EmployeeWorkingsLogic
        {
            get { return employeeWorkingsLogic; }
            set
            {
                employeeWorkingsLogic = value;
                employeeWorkingsLogic.EmployeeWorkingView = this;
            }
        }

        public event EventHandler<EmployeeWorkingsLogicEventArg> SaveEmployeeWorkingDay;

        private void txtEmployeeId_TextChanged(object sender, EventArgs e)
        {
            if(!CheckUtility.IsNullOrEmpty(txtEmployeeId.Text) && txtEmployeeId.Text.Length ==CommonConstants.EMPLOYEE_BARCODE_LENGTH)
            {
                btnInput_Click(sender,e);
            }
        }

        private void txtEmployeeId_Enter(object sender, EventArgs e)
        {
            txtEmployeeId.BackColor = Color.LightGreen;
        }

        private void txtEmployeeId_Leave(object sender, EventArgs e)
        {
            txtEmployeeId.BackColor = Color.FromKnownColor(KnownColor.Control);
        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            EmployeeWorkingsLogicEventArg eventArg = new EmployeeWorkingsLogicEventArg();
            eventArg.EmployeeId = txtEmployeeId.Text;
            EmployeeWorkingDay day = GetFromWorkingList(txtEmployeeId.Text, ewdList);
            if(day!=null)
            {
                eventArg.EmployeeWorkingDay = day;
            }
            

            bool hasCheckOut = IsCheckOut(txtEmployeeId.Text, ewdList);
            if (!hasCheckOut)
            {

                EventUtility.fireEvent(SaveEmployeeWorkingDay, this, eventArg);
                if(eventArg.HasErrors)
                {
                    MessageBox.Show("Có lỗi khi quét mã vạch");
                }
                else
                {
                    MessageBox.Show("Có nhân viên quét thẻ ...");
                    if(eventArg.EmployeeWorkingDay!=null)
                    {
                        int listIndex = -1;
                        if(!UpdateEndTimeInList(ewdList,eventArg.EmployeeWorkingDay))
                        {
                            ewdList.Add(eventArg.EmployeeWorkingDay);    
                        }
                        
                        bdsEmployeeWorking.EndEdit();
                        dgvEmployeeWorking.Refresh();
                        dgvEmployeeWorking.Invalidate();
                    }
                }
                
            }
            else
            {
                MessageBox.Show("Nhân viên này đã check-out");
            }
            ClearInput();
        }

        private EmployeeWorkingDay GetFromWorkingList(string text, EmployeeWorkingDaysCollection collection)
        {
            if(string.IsNullOrEmpty(txtEmployeeId.Text))
            {
                return null;
            }
            foreach (EmployeeWorkingDay day in collection)
            {
                if(day.Employee.EmployeeInfo.Barcode.Equals(txtEmployeeId.Text))
                {
                    return day;
                }
            }
            return null;
        }

        private bool UpdateEndTimeInList(EmployeeWorkingDaysCollection collection, EmployeeWorkingDay day)
        {
            foreach (EmployeeWorkingDay workingDay in collection)
            {
                if(workingDay.EmployeeWorkingDayPK.EmployeeId.Equals(day.EmployeeWorkingDayPK.EmployeeId)
                    && workingDay.Department.DepartmentId == day.Department.DepartmentId
                    && workingDay.EmployeeWorkingDayPK.WorkingDay.CompareTo(day.EmployeeWorkingDayPK.WorkingDay) == 0
                    )
                {
                    workingDay.EndTime = day.EndTime;
                    return true;
                }
            }
            return false;
        }

        private void ClearInput()
        {
            txtEmployeeId.Text = "";
            txtEmployeeId.Focus();
        }

        private bool IsCheckOut(string text, EmployeeWorkingDaysCollection collection)
        {
            if(string.IsNullOrEmpty(text))
            {
                return false;
            }
            int count = 0;
            
            foreach (EmployeeWorkingDay day in collection)
            {
                if(day.Employee.EmployeeInfo.Barcode.Equals(text))
                {
                    //count += 1;
                    if(day.EndTime.CompareTo(day.StartTime)< 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void EmployeeWorkingsForm_Load(object sender, EventArgs e)
        {
            txtTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            ewdList = new EmployeeWorkingDaysCollection(bdsEmployeeWorking);

            EmployeeWorkingsLogicEventArg eventArg = new EmployeeWorkingsLogicEventArg();
            EventUtility.fireEvent(LoadEmployeesWorkingDay,this,eventArg);

            if(eventArg.EmployeeWorkingList != null && eventArg.EmployeeWorkingList.Count > 0)
            {
                foreach (EmployeeWorkingDay employeeWorkingDay in eventArg.EmployeeWorkingList)
                {
                    ewdList.Add(employeeWorkingDay);
                    
                }    
                bdsEmployeeWorking.EndEdit();
                dgvEmployeeWorking.Refresh();
                dgvEmployeeWorking.Invalidate();

            }
        }

        #region IEmployeeWorkingsView Members


        public event EventHandler<EmployeeWorkingsLogicEventArg> LoadEmployeesWorkingDay;

        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            txtTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            txtTime.Refresh();
            this.Refresh();
        }

        private void dgvEmployeeWorking_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}