using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Presenter;

namespace AppFrameClient.Presenter
{
    public class SecurityController : ISecurityController
    {
        #region ISecurityController Members

        private AppFrame.View.ISecurityView securityView;
        public AppFrame.View.ISecurityView SecurityView
        {
            get
            {
                return securityView;
            }
            set
            {
                securityView = value;
                securityView.InitSecuritySettingsEvent += new EventHandler<SecurityEventArgs>(securityView_InitSecuritySettingsEvent);
            }
        }

        void securityView_InitSecuritySettingsEvent(object sender, SecurityEventArgs e)
        {
            
        }

        public AppFrame.Logic.ILoginLogic LoginLogic
        {
            get;set;
        }

        #endregion
    }
}
