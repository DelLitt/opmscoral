using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AppFrame.Presenter;
using AppFrame.Utility;
using AppFrame.View;

namespace AppFrameClient.View
{
    public partial class SecuritySettings : AppFrame.Common.BaseForm, ISecurityView
    {
        public SecuritySettings()
        {
            InitializeComponent();
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #region ISecurityView Members

        AppFrame.Presenter.ISecurityController securityController;
        public AppFrame.Presenter.ISecurityController SecurityController
        {
            get
            {
                return securityController;
            }
            set
            {
                securityController = value;
                securityController.SecurityView = this;
            }
        }

        public event EventHandler<AppFrame.Presenter.SecurityEventArgs> InitSecuritySettingsEvent;

        public event EventHandler<AppFrame.Presenter.SecurityEventArgs> SaveUserEvent;

        public event EventHandler<AppFrame.Presenter.SecurityEventArgs> EditUserEvent;

        #endregion

        private void SecuritySettings_Load(object sender, EventArgs e)
        {
            SecurityEventArgs eventArgs = new SecurityEventArgs();
            EventUtility.fireEvent(InitSecuritySettingsEvent,this,eventArgs);
        }
    }
}
