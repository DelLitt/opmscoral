using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppFrame.Common;
using AppFrame.Presenter;
using AppFrame.Utility;
using ClientManagementTool.Common;
using ClientManagementTool.Model;
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

        private void logoutMenu_Click(object sender, EventArgs e)
        {
           AuthService.logout();
           MenuUtility.setPermission(ClientInfo.getInstance().LoggedUser,ref this.menuStrip1,ClientInfo.getInstance().MenuPermissions);
        }

        private void loginMenu_Click(object sender, EventArgs e)
        {
            AuthService.PostLogin += new EventHandler<BaseEventArgs>(AuthService_PostLogin);
            AuthService.login();
        }

        void AuthService_PostLogin(object sender, BaseEventArgs e)
        {
            BaseUser loggedUser = ClientInfo.getInstance().LoggedUser;
            if(loggedUser.IsInRole(PosRole.Manager))
            {
                // process period for manager here 
            }

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Stream inStream = this.GetType().Assembly.GetManifestResourceStream("ClientManagementTool.MenuPermissions.xml");

            // load menu permission
            MenuItemPermission menuItemPermission = new MenuItemPermission(MenuItemPermission.INVISIBLE);
            menuItemPermission.loadRoles(inStream);
            ClientInfo clientInfo = ClientInfo.getInstance();
            clientInfo.MenuPermissions = menuItemPermission;

            // register main form
            GlobalCache.Instance().MainForm = this;

            // check menu permission
            MenuUtility.setPermission(clientInfo.LoggedUser, ref this.menuStrip1, menuItemPermission);
            //CheckClientServer();
        }

        private void exitMenu_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void employeeWorkingReport_Click(object sender, EventArgs e)
        {

        }
    }
}