using System;
using System.Collections.Generic;
using System.Text;
using Common.Logging;
using Spring.Aop;
using AppFrame.Common;
using AppFrame.Logic;

namespace AppFrame.Advice
{
    public class InsertUserInfoToLogicAdvice : IMethodBeforeAdvice
    {

        #region IMethodBeforeAdvice Members

        public void Before(System.Reflection.MethodInfo method, object[] args, object target)
        {
            ILog logger = LogManager.GetLogger("AppFrame");
            logger.Info("Go to InsertUserInfoToLogicAdvice");
            // create a new instance of BaseUser
            BaseUser currentUser = ClientInfo.getInstance().LoggedUser as BaseUser;
            BaseUser baseUser = new BaseUser();
            baseUser.Name = currentUser.Name;
            baseUser.Roles = currentUser.Roles;
            baseUser.IsGuest = currentUser.IsGuest;

            IAuthoriseLogic logic = target as IAuthoriseLogic;
            logic.CurrentUser = baseUser;
            logger.Info("Set BaseUser completed !");
        }

        #endregion
    }
}
