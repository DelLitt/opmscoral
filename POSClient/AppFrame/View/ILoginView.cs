using System;
using System.Runtime.Serialization;
using AppFrame.Common;
using AppFrame.Model;
using AppFrame.Presenter;

namespace AppFrame.View
{

    public interface ILoginView<T> where T : BaseEventArgs 
    {
        ILoginController<T> LoginController { get;  set; } 
        event EventHandler<T> LoginEvent;
        event EventHandler<T> ConfirmLoginEvent;

    }
}