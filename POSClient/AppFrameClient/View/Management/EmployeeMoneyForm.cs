using System;
using System.Collections;
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
using AppFrame.Presenter;
using AppFrame.Utility;
using AppFrame.View;

namespace AppFrameClient.View.Management
{
    public partial class EmployeeMoneyForm : BaseForm,IProcessPeriodMoneyView
    {
        private EmployeeMoneyCollection employeeMoneyList;
        public enum ChoosingResult { Next,Cancel }

        private ChoosingResult choosedResult = ChoosingResult.Cancel;
        public ChoosingResult ChoosedResult
        {
            get
            {
                return choosedResult;
            }
        }

        private long moneyEntered = 0;
        public long MoneyEntered
        {
            get
            {
                return moneyEntered;
            }
        }
        public EmployeeMoneyForm()
        {
            InitializeComponent();
        }

        private void lblStatus_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            choosedResult = ChoosingResult.Cancel;
            Close();
        }

        private void EmployeeMoneyForm_Load(object sender, EventArgs e)
        {
            employeeMoneyList = new EmployeeMoneyCollection(bdsMoney);
            bdsMoney.ResetBindings(true); 

            ProcessPeriodMoneyEventArgs eventArgs = new ProcessPeriodMoneyEventArgs();
            EventUtility.fireEvent(LoadProcessPeriodMoneyEvent,this,eventArgs);

            IList list = eventArgs.PeriodMoneyList;
            if(list!=null && list.Count > 0)
            {
                foreach (EmployeeMoney employeeMoney in list)
                {
                    employeeMoneyList.Add(employeeMoney);
                }
            }
            bdsMoney.ResetBindings(false);
            dgvMoney.Refresh();
            dgvMoney.Invalidate();

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            moneyEntered = Int64.Parse(txtMoney.Text.Trim());
            choosedResult = ChoosingResult.Next;
            Close();
        }

        private IProcessPeriodMoneyLogic processPeriodMoneyLogic;
        public IProcessPeriodMoneyLogic ProcessPeriodMoneyLogic
        {
            get
            {
                return processPeriodMoneyLogic;    
            }
            set
            {
                processPeriodMoneyLogic = value;
                processPeriodMoneyLogic.ProcessPeriodMoneyView = this;
            }
        }
        public event EventHandler<ProcessPeriodMoneyEventArgs> LoadProcessPeriodMoneyEvent;
    }
}