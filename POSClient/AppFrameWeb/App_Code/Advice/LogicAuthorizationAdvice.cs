using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using AopAlliance.Intercept;
using AppFrame.Common;
using System.Windows.Forms;
using AppFrame.Logic;
using System.Collections;
using System.Runtime.Remoting;
using System.IO;
using AppFrame.Utility;
using Common.Logging;

namespace AppFrame.Advice
{
    public class LogicAuthorizationAdvice : IMethodInterceptor
    {

        #region IMethodInterceptor Members

        public object Invoke(IMethodInvocation invocation)
        {
            // if it's setter method
            if (invocation.Method.Name.StartsWith("set_"))
            {
                return invocation.Proceed();
            }
            ILog logger = LogManager.GetLogger("AppFrame");
            logger.Info("Go to LogicAuthorizationAdvice");
            LogicItemPermission logicItemPermission = LogicItemPermission.Instance();
            IAuthoriseLogic authorLogic = invocation.Target as IAuthoriseLogic;
            BaseUser user = authorLogic.CurrentUser;
            logger.Info("user name null is " + (user == null));
            logger.Info("user name " + user.Name);
            string targetName = invocation.Target.ToString();
            logger.Info("class name " + targetName);
            if (logicItemPermission.HasPermission(targetName, user))
            {

                return invocation.Proceed();
            }
            else
                return null;            

        }

        #endregion
    }
}
