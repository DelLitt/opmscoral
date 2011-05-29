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
using AppFrame.Logic;
using AppFrame.Model;
using AppFrame.Presenter;
using AppFrame.Utility;
using AppFrame.View;


namespace AppFrameClient.View.Management
{
    public partial class ClosedPeriodForm : BaseForm,IClosedPeriodView
    {
        private EmployeeMoneyCollection employeeMoneyList;
        public ClosedPeriodForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private IClosedPeriodLogic closedPeriodLogic;
        public IClosedPeriodLogic ClosedPeriodLogic
        {
            get
            {
                return closedPeriodLogic; 
            }
            set
            {
                closedPeriodLogic = value;
                closedPeriodLogic.ClosedPeriodView = this;
            }
        }

        public event EventHandler<ClosedPeriodEventArgs> LoadClosedPeriodEvent;

        private void ClosedPeriodForm_Load(object sender, EventArgs e)
        {
            employeeMoneyList = new EmployeeMoneyCollection(bdsMoney);
            bdsMoney.ResetBindings(true);

            ClosedPeriodEventArgs eventArgs = new ClosedPeriodEventArgs();
            eventArgs.FromDate = DateTime.Now;
            eventArgs.ToDate = DateTime.Now;
            EventUtility.fireEvent(LoadClosedPeriodEvent,this,eventArgs);
            if(eventArgs.EmployeeMoneyList !=null && eventArgs.EmployeeMoneyList.Count > 0)
            {
                foreach (EmployeeMoney employeeMoney in eventArgs.EmployeeMoneyList)
                {
                    employeeMoneyList.Add(employeeMoney);
                }
                bdsMoney.ResetBindings(false); 
                dgvMoney.Refresh();
                dgvMoney.Invalidate();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ClosedPeriodEventArgs eventArgs = new ClosedPeriodEventArgs();
            eventArgs.FromDate = dtpFrom.Value;
            eventArgs.ToDate = dtpTo.Value;
            EventUtility.fireEvent(LoadClosedPeriodEvent, this, eventArgs);
            if (eventArgs.EmployeeMoneyList != null && eventArgs.EmployeeMoneyList.Count > 0)
            {
                employeeMoneyList.Clear();
                foreach (EmployeeMoney employeeMoney in eventArgs.EmployeeMoneyList)
                {
                    employeeMoneyList.Add(employeeMoney);
                }
                bdsMoney.ResetBindings(false);
                dgvMoney.Refresh();
                dgvMoney.Invalidate();
            }
        }
    }
}