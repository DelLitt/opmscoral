using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Windows.Forms;
using AppFrame.Common;
using AppFrame.Model;
using AppFrame.Presenter;
using AppFrame.Utility;
using AppFrame.View;
using AppFrameClient.Common;

namespace AppFrameClient.View
{
    public partial class AuthForm : BaseForm, ILoginView<LoginEventArgs>
    {
        private ILoginController<LoginEventArgs> loginController;
        public event EventHandler<LoginEventArgs> LoginEvent;
        public event EventHandler<LoginEventArgs> ConfirmLoginEvent;
        public event EventHandler<LoginEventArgs> ConfirmEmployeeIdEvent;

        public event EventHandler<LoginEventArgs> LoginOKEvent;

        InputDevice id;
        int NumberOfKeyboards;

        public AuthForm()
        {
            InitializeComponent();
            
            lblStatus.Text = "";
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
            if (e.Keyboard.Name != null)
            {
                
                if (e.Keyboard.Name.IndexOf(LocalCache.HID_KEYBOARD_DEVICE) >= 0)
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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu bị trống");
                return;
            }
            
            btnLogin.Enabled = false;
            
            DoLogin();
        }
        private void DoLogin()
        {
            btnLogin.Enabled = false;
            
            Form form =GlobalCache.Instance().MainForm;
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
            if (LoginEvent != null)
            {
                EventUtility.fireEvent(LoginEvent,this,loginEventArgs);
            }
        }

        private void loginController_CompleteLoginEvent(object sender, LoginEventArgs e)
        {
            btnLogin.Enabled = true;
            Form form =GlobalCache.Instance().MainForm;
            if (form is AppFrame.View.MainForm)
            {
                ((AppFrame.View.MainForm)form).stopProgressBar();
            }
 
            if(e.IsValid)
            {

                this.Visible = false;
                var resManager = new ResourceManager("AppFrameClient.Global", Assembly.GetExecutingAssembly());
                if (form is AppFrame.View.MainForm)
                {
                    if (ClientInfo.getInstance().LoggedUser.IsGuest)
                    {
                        ((AppFrame.View.MainForm)form).lblStatus.Text = resManager.GetString("guestUserString");
                    }
                    else
                    {
                        ((AppFrame.View.MainForm)form).lblStatus.Text = resManager.GetString("loggedUserString");
                    }
                }
                CleanDatabase();
                Close();
                EventUtility.fireEvent(LoginOKEvent,this,null);
            }
            
            form.Focus();
            
            MenuUtility.setPermission(GlobalCache.Instance().MainForm, ClientInfo.getInstance());
            if (ClientSetting.IsClient())
            {
                MenuUtility.setPermission(GlobalCache.Instance().MainForm, ClientInfo.getInstance(), ref ((MainForm)GlobalCache.Instance().MainForm).toolStripClient,
                                          GlobalCache.Instance().ClientToolStripPermission);
            } else if (ClientSetting.IsSubStock())
            {
                MenuUtility.setPermission(GlobalCache.Instance().MainForm, ClientInfo.getInstance(), ref ((MainForm)GlobalCache.Instance().MainForm).toolStripClient,
                                          GlobalCache.Instance().ClientToolStripPermission);
            } else if (ClientSetting.IsServer())
            {
                MenuUtility.setPermission(GlobalCache.Instance().MainForm, ClientInfo.getInstance(), ref ((MainForm)GlobalCache.Instance().MainForm).toolStripClient,
                                          GlobalCache.Instance().ClientToolStripPermission);
            }
            ((MainForm)GlobalCache.Instance().MainForm).RenderFunctionKeysTextToToolStrip();
        }

        private void CleanDatabase()
        {
            
        }

        private void AuthForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            loginController.CompleteLoginLogicEvent -= loginController_CompleteLoginEvent;

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            this.lblStatus.Text = "";
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
           txtUsername_TextChanged(sender,e);
        }

        private void txtUsername_KeyUp(object sender, KeyEventArgs e)
        {
            lblStatus.Text = "";
            if(e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();                
            }
        }

        private void txtPassword_KeyUp(object sender, KeyEventArgs e)
        {
            lblStatus.Text = "";
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(this, null); 
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

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            txtPassword.BackColor = Color.FromKnownColor(KnownColor.Control);
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            txtPassword.BackColor = Color.LightGreen;
        }

        private void AuthForm_Load(object sender, EventArgs e)
        {
            txtBarcode.Focus();
        }

        private void txtBarcode_KeyUp(object sender, KeyEventArgs e)
        {
            lblStatus.Text = "";
            if (e.KeyCode == Keys.Enter)
            {
                txtUsername.Focus();
            }
        }

        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtBarcode.Text) && txtBarcode.Text.Length == LocalCache.USER_BARCODE_LENGTH)
            {
                if(!LocalCache.Instance().InputFromBarcodeReader)
                {
                    txtBarcode.Text = "";
                    //lblStatus.Text = "Không xác định!";
                    label4.Text = " From BR : " + LocalCache.Instance().InputFromBarcodeReader.ToString();
                    this.Text = " Has error when login !";
                    return;
                }
                    
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
                loginEventArgs.Barcode = txtBarcode.Text.Trim().ToUpper();
                
                EventUtility.fireEvent(ConfirmEmployeeIdEvent, this, loginEventArgs);

                if(!loginEventArgs.HasErrors)
                {
                    EventUtility.fireEvent(LoginEvent, this, loginEventArgs);
                }
                else
                {
                    this.Text = " Has error when login !";
                }
                
            }
        }

        
    }
}