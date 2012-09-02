using AppFrame.Base;
using AppFrame.CustomAttributes;
using CoralPOS2.Models;
using POSServer.Common;

namespace POSServer.Actions.Security
{
    [PerRequest]
    public class RegisterUserAction : PosAction
    {
        public override void DoExecute()
        {
            RegisterUserToSession();
        }

        public void RegisterUserToSession()
        {
            bool isLogged = (bool)GlobalSession.Instance.Get(CommonConstants.IS_LOGGED);
            if(isLogged)
            {
                LoginModel model = (LoginModel)Flow.Session.Get(CommonConstants.LOGGED_USER);
                GoToNextNode();
            }
        }
    }
}