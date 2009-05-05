using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AppFrame.Common;
using AppFrame.Model;
using AppFrame.Presenter;
using AppFrame.Utility;
using AppFrame.View;

namespace AppFrameClient.View
{
    public partial class ChangePasswordForm : BaseForm,IChangePasswordView<LoginEventArgs>
    {
        public ChangePasswordForm()
        {
            InitializeComponent();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private ILoginController<LoginEventArgs> loginController; 
        public ILoginController<LoginEventArgs> LoginController 
        { 
            get
            {
                return loginController;
            }
            set
            {
                loginController = value;
                loginController.ChangePasswordView = this;
            }
        }
        public event EventHandler<LoginEventArgs> ChangePasswordEvent;

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            if(CheckIntegrity())
            {
               LoginEventArgs eventArg = new LoginEventArgs();
                eventArg.OldPassword = txtOldPassword.Text.Trim();
                eventArg.NewPassword = txtNewPassword.Text.Trim();
                EventUtility.fireEvent(ChangePasswordEvent,this,eventArg);
                if(!eventArg.HasErrors)
                {
                    MessageBox.Show("Đổi mật khẩu thành công !");
                    ClearForm();

                }
            }
        }

        private void ClearForm()
        {
            txtConfirmNewPass.Text = "";
            txtOldPassword.Text = "";
            txtNewPassword.Text = "";
        }

        private bool CheckIntegrity()
        {
            if(CheckUtility.IsNullOrEmpty(txtOldPassword.Text) 
                || CheckUtility.IsNullOrEmpty(txtNewPassword.Text)
                || CheckUtility.IsNullOrEmpty(txtConfirmNewPass.Text))
            {
                MessageBox.Show("Xin điền đầy đủ thông tin");
                return false;
            }
            if(!txtNewPassword.Text.Equals(txtConfirmNewPass.Text))
            {
                MessageBox.Show("Xin nhập xác nhận mật khẩu khớp với mật khẩu mới");
                return false; 
            }
            return true;
        }
    }
}
