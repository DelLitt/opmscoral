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
using RawInput;
using Spring.Context;
using Spring.Context.Support;

namespace AppFrameClient.View
{
    public partial class LoginForm : BaseForm, ILoginView<LoginEventArgs>
    {

        private ILoginController<LoginEventArgs> loginController;
        private BackgroundWorker backgroundWorker = new BackgroundWorker();
        public bool IsConfirmed { get; set; }
        public bool ConfirmNegativeSelling { get; set;  }

        InputDevice id;
        int NumberOfKeyboards;

        public LoginForm()
        {
            InitializeComponent();


            // Create a new InputDevice object, get the number of
            // keyboards, and register the method which will handle the 
            // InputDevice KeyPressed event
            id = new InputDevice(Handle);
            NumberOfKeyboards = id.EnumerateDevices();
            id.KeyPressed += new InputDevice.DeviceEventHandler(m_KeyPressed);
        }

        // The WndProc is overridden to allow InputDevice to intercept
        // messages to the window and thus catch WM_INPUT messages
        protected override void WndProc(ref Message message)
        {
            if (id != null)
            {
                id.ProcessMessage(message);
            }
            base.WndProc(ref message);
        }

        private void m_KeyPressed(object sender, InputDevice.KeyControlEventArgs e)
        {
            if(e.Keyboard.Name!= null)
            {
                if(e.Keyboard.Name.IndexOf(LocalCache.HID_KEYBOARD_DEVICE) > 0 )
                {
                    LocalCache.Instance().InputFromBarcodeReader = true;
                }
                else
                {
                    LocalCache.Instance().InputFromBarcodeReader = false;
                }
            }
        }

        #region ILoginView Members

        public ILoginController<LoginEventArgs> LoginController
        {
            set
            {
                loginController = value;
                loginController.LoginView = this;
                loginController.CompleteLoginLogicEvent += loginController_CompleteLoginEvent;
            }
            get
            {
                return loginController;
            }
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            
            if(string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu bị trống");
                return;
            }
            /*validationProvider.Enabled = true;
            if (!ValidateChildren())
            {
                return;
            }

            validationProvider.Enabled = false;*/
            button1.Enabled = false;
            
            //backgroundWorker.DoWork += new DoWorkEventHandler(DoWorkUsingBackgroundHandler);
            //backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(DoWorkUsingBackgroundCompleted);
            //backgroundWorker.RunWorkerAsync();
            DoWorkUsingEvent();

        }

        private void DoWorkUsingBackgroundCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // do nothing
            button1.Enabled = true;
            
            lblStatus.Text = result;
        }

        private void DoWorkUsingEvent()
        {
            button1.Enabled = false;
            // create model and raise event
            LoginModel model = new LoginModel();
            model.Username = txtUsername.Text.Trim();
            model.Password = txtPassword.Text.Trim();
            if(ConfirmNegativeSelling && ClientSetting.IsClient())
            {
                if(!LocalCache.ADHOC_USERNAME.Equals(model.Username))
                {
                    IsConfirmed = false;
                    ReturnResult();
                    return;
                }
            }

            LoginEventArgs loginEventArgs = new LoginEventArgs();
            loginEventArgs.ConfirmType = "Manager,Supervisor,Administrator";
            loginEventArgs.LoginModel = model;
            if (LoginEvent != null)
            {
                EventUtility.fireEvent(ConfirmLoginEvent,this,loginEventArgs);
                if(!loginEventArgs.HasErrors)
                {
                    IsConfirmed = true;
                    ReturnResult();
                }
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

        private string result;
        void DoWorkUsingBackgroundHandler(object sender, DoWorkEventArgs e)
        {
            // create model and raise event
            LoginModel model = new LoginModel();
            model.Username = txtUsername.Text;
            model.Password = txtPassword.Text;
            result = LoginController.doLogin(model);

            //lblStatus.Text = result;
        }
        
        
        private void loginController_CompleteLoginEvent(object sender, LoginEventArgs e)
        {
            // It's on a different thread, so use Invoke.
            //SetEnableButton d = ShowResult;
            //this.Invoke(d, sender, e);
            button1.Enabled = true;
            // end invoke in thread safe way
            if (e != null)
            {
                lblStatus.Text = e.EventResult as string;
            }
            this.Visible = false;

            IApplicationContext ctx = ContextRegistry.GetContext();
            MainForm mainForm = ctx.GetObject("MainView") as MainForm;
            mainForm.lblStatus.Text = " You are logged in !";
            MenuUtility.setPermission(mainForm,ClientInfo.getInstance());
        }                  

        

        #region ILoginView Members


        public event EventHandler<LoginEventArgs> LoginEvent;
        public event EventHandler<LoginEventArgs> ConfirmLoginEvent;
        public event EventHandler<LoginEventArgs> ConfirmEmployeeIdEvent;

        #endregion

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                button1_Click(sender,e);
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            txtBarcode.BackColor = Color.LightGreen;
        }

        private void txtBarcode_Leave(object sender, EventArgs e)
        {
            txtBarcode.BackColor = Color.FromKnownColor(KnownColor.Control);
        }

        private void txtUsername_Enter(object sender, EventArgs e)
        {
            txtUsername.BackColor = Color.LightGreen;
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            txtUsername.BackColor = Color.FromKnownColor(KnownColor.Control);
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            txtPassword.BackColor = Color.LightGreen;
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            txtPassword.BackColor = Color.FromKnownColor(KnownColor.Control);
        }

        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtUsername.Focus();
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBarcode.Text) && txtBarcode.Text.Length == LocalCache.USER_BARCODE_LENGTH)
            {
                Form form = GlobalCache.Instance().MainForm;
                if (form is AppFrame.View.MainForm)
                {
                    ((AppFrame.View.MainForm)form).showProgressBar();
                }
                // create model and raise event
                LoginModel model = new LoginModel();
                model.Username = txtUsername.Text;
                model.Password = txtPassword.Text;
                LoginEventArgs loginEventArgs = new LoginEventArgs();
                loginEventArgs.LoginModel = model;
                loginEventArgs.Barcode = txtBarcode.Text;

                EventUtility.fireEvent(ConfirmEmployeeIdEvent, this, loginEventArgs);

                if (!loginEventArgs.HasErrors)
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
        

    }
}