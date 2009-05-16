using System;
using System.Collections.Generic;
using System.Text;
using AppFrame.Common;

namespace AppFrame.Presenter
{
    public interface IAuthService
    {
        void login();
        void logout();

        event EventHandler<BaseEventArgs> PostLogin;
        event EventHandler<BaseEventArgs> PreLogout;
    }
}
