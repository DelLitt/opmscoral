using System;
using AppFrame.Common;
using AppFrame.Logic;
using AppFrame.Model;
using AppFrame.View;

namespace AppFrame.Presenter
{
    public interface ILoginController<T> : IBaseController<T> where T:BaseEventArgs
    {
        event EventHandler<T> CompleteLoginLogicEvent;
        ILoginView<T> LoginView { get; set;}
        IChangePasswordView<T> ChangePasswordView { get; set; }
        #region logic using in controller

        ILoginLogic LoginLogic { get; set; }

        #endregion
        
        string doLogin(LoginModel loginModel);
    }
}