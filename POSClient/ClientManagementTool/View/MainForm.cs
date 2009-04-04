using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppFrame.Presenter;
using AppFrame.Utility;
using ClientManagementTool.Common;
using ClientManagementTool.View.Management;

namespace ClientManagementTool.View
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        
        private void employeeWorkingMenu_Click(object sender, EventArgs e)
        {
            Form form = GlobalUtility.GetOnlyChildFormObject<EmployeeWorkingsForm>(this,
                                                                                   FormConstants.EMPLOYEE_WORKINGS_FORM);
            form.Show();
        }

        public IAuthService AuthService
        {
            get; set;
        }
    }
}