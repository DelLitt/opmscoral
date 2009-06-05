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
using AppFrame.Model;
using AppFrame.Presenter;
using AppFrame.Utility;
using AppFrameClient.Common;
using AppFrameClient.Logic;
using AppFrameClient.Model;
using AppFrameClient.View.Management;

namespace AppFrameClient.View
{
    public partial class EmployeeManagementForm : BaseForm,IEmployeeManagementView
    {
        public EmployeeManagementForm()
        {
            InitializeComponent();
        }
        
        private void employeeWorkingMenu_Click(object sender, EventArgs e)
        {
            Form form = GlobalUtility.GetOnlyChildFormObject<EmployeeWorkingsForm>(this,
                                                                                   FormConstants.EMPLOYEE_WORKINGS_FORM);
            
            form.WindowState = FormWindowState.Maximized;
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
                MainLogicEventArgs eventArgs = new MainLogicEventArgs();
                eventArgs.Username = ClientInfo.getInstance().LoggedUser.Name;
                EventUtility.fireEvent(ProcessPeriodEvent,this,eventArgs);
                LoginModel userInfo = eventArgs.UserInfo;
                if(eventArgs.DepartmentManagement==null)
                {
                    DialogResult result = MessageBox.Show("Ca trực đang trống. Bạn có muốn vào ca hay không ? ",
                                                          "Vào ca trực", MessageBoxButtons.YesNo,
                                                          MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);                    
                    if(result == DialogResult.Yes)
                    {
                        EventUtility.fireEvent(StartPeriodEvent,this,eventArgs);
                        if(eventArgs.HasErrors)
                        {
                            MessageBox.Show("Có lỗi khi thực hiện vào ca. Liên hệ người quản trị.", "Lỗi");
                            return;
                        }
                    }
                }
            }
            AuthService.PostLogin -= new EventHandler<BaseEventArgs>(AuthService_PostLogin);
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

        #region IMainView Members

        IMainLogic mainLogic;
        public IMainLogic MainLogic
        {
            get
            {
                return mainLogic;
            }
            set
            {
                mainLogic = value;
                mainLogic.MainView = this;
            }
        }

        public event EventHandler<MainLogicEventArgs> ProcessPeriodEvent;

        public event EventHandler<MainLogicEventArgs> StartPeriodEvent;

        public event EventHandler<MainLogicEventArgs> EndPeriodEvent;

        #endregion

        private void mnuEnterPeriod_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn muốn vào ca trực ?", "Ca trực",MessageBoxButtons.YesNo);
            if(result == DialogResult.No)
            {
                return;    
            }
            BaseUser loggedUser = ClientInfo.getInstance().LoggedUser;
            if (loggedUser.IsInRole(PosRole.Manager))
            {
                // process period for manager here 
                MainLogicEventArgs eventArgs = new MainLogicEventArgs();
                eventArgs.Username = ClientInfo.getInstance().LoggedUser.Name;
                EventUtility.fireEvent(ProcessPeriodEvent, this, eventArgs);
                LoginModel userInfo = eventArgs.UserInfo;
                if (eventArgs.DepartmentManagement == null)
                {
                    EventUtility.fireEvent(StartPeriodEvent, this, eventArgs);
                    if (eventArgs.HasErrors)
                    {
                        MessageBox.Show("Có lỗi khi thực hiện vào ca. Liên hệ người quản trị.", "Lỗi");
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Bạn đã vào ca trực. Nhấn OK để thoát.");
                    }
                }
                else
                {
                    if (!userInfo.EmployeeInfo.EmployeePK.EmployeeId.Equals(eventArgs.DepartmentManagement.DepartmentManagementPK.EmployeeId))
                    {
                        MessageBox.Show("Ca trực đã có người quản lý.", "Lỗi");
                    }
                    else
                    {
                        MessageBox.Show("Bạn đã vào ca rồi.", "Lỗi");                        
                    }
                }
            }
            else
            {
                MessageBox.Show("Không đủ quyền hạn", "Lỗi");                                
            }
        }
        

        private void mnuLeavePeriod_Click(object sender, EventArgs e)
        {
            BaseUser loggedUser = ClientInfo.getInstance().LoggedUser;
            if (loggedUser.IsInRole(PosRole.Manager))
            {
                DialogResult result = MessageBox.Show("Bạn có muốn kết thúc ca trực hay không ? ",
                                                      "Thoát ca trực", MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    MainLogicEventArgs eventArgs = new MainLogicEventArgs();
                    eventArgs.Username = ClientInfo.getInstance().LoggedUser.Name;
                    EventUtility.fireEvent(ProcessPeriodEvent, this, eventArgs);
                    LoginModel userInfo = eventArgs.UserInfo;
                    if (eventArgs.DepartmentManagement == null)
                    {
                        MessageBox.Show("Chưa vào ca nên không thể chấm dứt ca.", "Lỗi");
                        return;
                        
                    }
                    if (!userInfo.EmployeeInfo.EmployeePK.EmployeeId.Equals(eventArgs.DepartmentManagement.DepartmentManagementPK.EmployeeId))
                    {
                        MessageBox.Show("Ca trực đã có người quản lý.", "Lỗi");
                        return;
                    }
                    EventUtility.fireEvent(EndPeriodEvent, this, eventArgs);
                    if (eventArgs.HasErrors)
                    {
                        MessageBox.Show("Có lỗi khi thoát ca. Liên hệ người quản trị");
                    }
                    else
                    {
                        MessageBox.Show("Bạn đã kết thúc ca trực. Nhấn OK để thoát.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Không đủ quyền hạn", "Lỗi");
            }
        }

        private void toolStripContainer1_TopToolStripPanel_Click(object sender, EventArgs e)
        {

        }

        private void toolStripContainer1_RightToolStripPanel_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {

        }
    }
}