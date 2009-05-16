using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Common;
using AppFrame.Presenter;

namespace AppFrame.View
{
    public interface IChangePasswordView<T> where T : BaseEventArgs
    {
        ILoginController<T> LoginController { get; set; }
        event EventHandler<T> ChangePasswordEvent;
    }
}
