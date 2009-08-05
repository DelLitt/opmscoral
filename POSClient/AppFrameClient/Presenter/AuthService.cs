using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using AppFrame.Common;
using AppFrame.Model;
using AppFrame.Utility;
using AppFrame.View;
using AppFrameClient.Common;
using AppFrameClient.Logic;
using AppFrameClient.Model;
using AppFrameClient.View;

namespace AppFrame.Presenter
{
    public class AuthService : IAuthService,IEmployeeManagementView
    {

        #region IAuthService Members

        private IMainLogic _mainLogic;

        public void login()
        {
            //Form loginForm = GlobalUtility.GetFormObject(FormConstants.LOGIN_FORM);
            AuthForm loginForm = GlobalUtility.GetOnlyChildFormObject<AuthForm>(GlobalCache.Instance().MainForm, FormConstants.LOGIN_FORM);
            loginForm.StartPosition = FormStartPosition.CenterScreen;
            //loginForm.ShowDialog();
            loginForm.LoginOKEvent += new EventHandler<LoginEventArgs>(loginForm_LoginOKEvent);
            loginForm.Show();
            //GlobalCache.Instance().MainForm.Focus();
            
        }

        void loginForm_LoginOKEvent(object sender, LoginEventArgs e)
        {
            if (!ClientInfo.getInstance().LoggedUser.IsGuest)
            {
                EnterPeriod();
                if (PostLogin != null)
                {
                    EventUtility.fireEvent(PostLogin, this, new BaseEventArgs());
                }
            }
        }

        public void logout()
        {
            
            AuthManager authManager = SecurityUtility.LoadAuthenticationModule();
            authManager.logout();
            GlobalUtility.CloseAllChildForm(GlobalUtility.GetFormObject(FormConstants.MAIN_FORM));
            MenuUtility.setPermission(GlobalCache.Instance().MainForm, ClientInfo.getInstance(), ref ((MainForm)GlobalCache.Instance().MainForm).toolStripClient,
                                          GlobalCache.Instance().ClientToolStripPermission);

            if (ClientInfo.getInstance().LoggedUser.IsGuest && PreLogout != null)
            {
                EventUtility.fireEvent(PreLogout, this, new BaseEventArgs());
            }
        }

        #endregion

        #region IAuthService Members


        public event EventHandler<BaseEventArgs> PostLogin;

        public event EventHandler<BaseEventArgs> PreLogout;
        public void EnterPeriod()
        {
            BaseUser user = ClientInfo.getInstance().LoggedUser;
            // if has entered period then return
            if(user.IsInRole(PosRole.LoggedManager))
            {
                return;
            }
            
            // if not then try to enter period
            if(user.IsInRole(PosRole.Manager))
            {
                //EmployeeInfo employeeInfo = LoginLogic.GetEmployeeInfo(user.Name);
                DialogResult result = MessageBox.Show("Bạn muốn vào ca trực ?", "Ca trực", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
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
                            loggedUser.Roles.Add(PosRole.LoggedManager);
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
                            loggedUser.Roles.Add(PosRole.LoggedManager);
                            MessageBox.Show("Bạn đã trở lại ca trực.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Không đủ quyền hạn", "Lỗi");
                } 
            }
        }

        public void LeavePeriod()
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
        
        #endregion

        public IMainLogic MainLogic
        {
            get { return _mainLogic; }
            set
            {
                _mainLogic = value;
                _mainLogic.MainView = this;
            }
        }

        public event EventHandler<MainLogicEventArgs> ProcessPeriodEvent;
        public event EventHandler<MainLogicEventArgs> StartPeriodEvent;
        public event EventHandler<MainLogicEventArgs> EndPeriodEvent;
    }
}
