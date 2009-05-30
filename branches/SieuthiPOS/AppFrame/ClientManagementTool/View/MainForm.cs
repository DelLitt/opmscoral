﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppFrame.Common;
using AppFrame.Utility;
using CoralPOS.Interfaces.Common;
using CoralPOS.Interfaces.Model;
using CoralPOS.Interfaces.Presenter;
using CoralPOS.Interfaces.Utility;
using ClientManagementTool.Common;
using ClientManagementTool.Logic;
using ClientManagementTool.Model;
using ClientManagementTool.View.Management;

namespace ClientManagementTool.View
{
    public partial class MainForm : BaseForm,IMainView
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

        private ClientManagementTool.Logic.IMainLogic mainLogic;
        public ClientManagementTool.Logic.IMainLogic MainLogic
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
        public event EventHandler<MainLogicEventArgs> ProcessEmployeeMoneyEvent;

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
                        EmployeeMoneyForm form =
                            GlobalUtility.GetFormObject<EmployeeMoneyForm>(FormConstants.EMPLOYEE_MONEY_FORM);
                        form.lblStatus.Text = "VÀO CA";
                        form.ShowDialog();
                        EmployeeMoneyForm.ChoosingResult choosingResult = form.ChoosedResult;
                        if(choosingResult == EmployeeMoneyForm.ChoosingResult.Next)
                        {
                            long inMoney = form.MoneyEntered;
                            eventArgs.InMoney = inMoney;
                            EventUtility.fireEvent(ProcessEmployeeMoneyEvent, this, eventArgs);
                            if(eventArgs.HasErrors)
                            {
                                MessageBox.Show("Có lỗi khi thực hiện vào ca. Liên hệ người quản trị.", "Lỗi");
                                return;
                            }
                        }

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
                    EmployeeMoneyForm form =
                            GlobalUtility.GetFormObject<EmployeeMoneyForm>(FormConstants.EMPLOYEE_MONEY_FORM);
                    form.lblStatus.Text = "CHỐT CA";
                    form.ShowDialog();
                    EmployeeMoneyForm.ChoosingResult choosingResult = form.ChoosedResult;
                    if (choosingResult == EmployeeMoneyForm.ChoosingResult.Next)
                    {
                        long outMoney = form.MoneyEntered;
                        eventArgs.OutMoney = outMoney;
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

        private void watchClosedPeriodMenu_Click(object sender, EventArgs e)
        {
            Form form = GlobalUtility.GetOnlyChildFormObject<ClosedPeriodForm>(this, FormConstants.CLOSED_PERIOD_FORM);
            form.Show();
        }
    }
}