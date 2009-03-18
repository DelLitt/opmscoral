using System;
using System.Collections;
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
                securityView.SaveUserEvent += new EventHandler<SecurityEventArgs>(securityView_SaveUserEvent);
            }
        }

        void securityView_SaveUserEvent(object sender, SecurityEventArgs e)
        {
            LoginLogic.ProcessUser(e.SaveModel);
        }

        void securityView_InitSecuritySettingsEvent(object sender, SecurityEventArgs e)
        {
            IList list = DepartmentLogic.FindAll(null);
            e.departmentList = list;
            IList loginList = LoginLogic.FindAll(null);
            e.userInfoList = loginList;

        }

        public AppFrame.Logic.ILoginLogic LoginLogic
        {
            get;set;
        }

        #endregion

        #region ISecurityController Members


        public AppFrame.Logic.IDepartmentLogic DepartmentLogic
        {
            get;set;
        }

        #endregion
    }
}
