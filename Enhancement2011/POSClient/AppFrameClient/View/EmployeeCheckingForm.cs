using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using AppFrame.Common;
using AppFrame.Model;
using AppFrame.Presenter;
using AppFrame.Utility;
using AppFrame.View;
using AppFrameClient.Common;
using Spring.Context;
using Spring.Context.Support;

namespace AppFrameClient.View
{
    public partial class EmployeeCheckingForm : BaseForm, ILoginView<LoginEventArgs>
    {

        private ILoginController<LoginEventArgs> loginController;
        private BackgroundWorker backgroundWorker = new BackgroundWorker();
        public bool IsConfirmed { get; set; }
        public EmployeeCheckingForm()
        {
            InitializeComponent();
        }

        #region ILoginView Members

        public ILoginController<LoginEventArgs> LoginController
        {
            set
            {
                loginController = value;
                loginController.LoginView = this;
            }
            get
            {
                return loginController;
            }
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            
            if(string.IsNullOrEmpty(txtEmployeeId.Text))
            {
                MessageBox.Show("Nhập mã nhân viên bằng cách dùng máy quét mã vạch");
                return;
            }
            button1.Enabled = false;
            
            //backgroundWorker.DoWork += new DoWorkEventHandler(DoWorkUsingBackgroundHandler);
            //backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(DoWorkUsingBackgroundCompleted);
            //backgroundWorker.RunWorkerAsync();
            DoCheckingEmployeeId();
            //DoWorkUsingEvent();

        }

        private void DoCheckingEmployeeId()
        {
            button1.Enabled = false;
            // create model and raise event

            LoginEventArgs loginEventArgs = new LoginEventArgs();
            loginEventArgs.EmployeeBarcode = txtEmployeeId.Text.Trim();
            if (ConfirmJustEmployeeIdEvent != null)
            {
                EventUtility.fireEvent(ConfirmJustEmployeeIdEvent, this, loginEventArgs);
                if (!loginEventArgs.HasErrors)
                {
                    IsConfirmed = true;
                    GlobalCache.Instance().Session["EmployeeId"] = loginEventArgs.EmployeeId;
                }
                ReturnResult();
            } 
        }


        private void DoWorkUsingEvent()
        {
            button1.Enabled = false;
            // create model and raise event

            LoginEventArgs loginEventArgs = new LoginEventArgs();
            loginEventArgs.EmployeeId = txtEmployeeId.Text.Trim();
            if (LoginEvent != null)
            {
                EventUtility.fireEvent(ConfirmEmployeeIdEvent,this,loginEventArgs);
                if(!loginEventArgs.HasErrors)
                {
                    LocalCache.Instance().PreviousUser = ClientInfo.getInstance().LoggedUser;
                    EventUtility.fireEvent(LoginEvent, this, loginEventArgs);
                    if (!loginEventArgs.HasErrors)
                    {
                        IsConfirmed = true;
                    }
                    
                }
                ReturnResult();
            }
        }

        private void ReturnResult()
        {
            if (IsConfirmed)
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                DialogResult = DialogResult.Cancel;
            }
            Close();
        }

        #region ILoginView Members


        public event EventHandler<LoginEventArgs> LoginEvent;
        public event EventHandler<LoginEventArgs> ConfirmLoginEvent;
        public event EventHandler<LoginEventArgs> ConfirmEmployeeIdEvent;
        public event EventHandler<LoginEventArgs> ConfirmJustEmployeeIdEvent;

        #endregion

        private void EmployeeCheckingForm_Load(object sender, EventArgs e)
        {
            txtEmployeeId.Focus();
        }

        private void txtEmployeeId_Enter(object sender, EventArgs e)
        {
            txtEmployeeId.BackColor = Color.LightGreen;
        }

        private void txtEmployeeId_Leave(object sender, EventArgs e)
        {
            txtEmployeeId.BackColor = Color.White;
        }

        private void txtEmployeeId_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                button1_Click(sender,null);
            }
        }

        private void EmployeeCheckingForm_Shown(object sender, EventArgs e)
        {
            txtEmployeeId.Focus();
        }

        private void txtEmployeeId_TextChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtEmployeeId.Text))
            {
                if (txtEmployeeId.Text.Length == 8)
                {
                    button1_Click(null,e);
                }
            }
        }

        

    }
}