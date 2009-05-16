using System;
using System.Collections.Generic;
using System.Text;
using Spring.Aop.Framework;
using AppFrame.Logic;
using AppFrame.Common;
using Spring.Aop.Support;

namespace AppFrame.Advice
{
    public class AuthoriseLogicMixin : IAuthoriseLogic,ITargetAware
    {
        private BaseUser user;
        private IAopProxy targetProxy;



        #region IAuthoriseLogic Members

        public BaseUser CurrentUser
        {
            get
            {
                return user;
            }
            set
            {
                user = value;
            }
        }
        

        #endregion



        #region ITargetAware Members

        public IAopProxy TargetProxy
        {
            set { targetProxy = value; }
        }

        #endregion



        #region ITargetAware Members

        IAopProxy ITargetAware.TargetProxy
        {
            set { throw new NotImplementedException(); }
        }

        #endregion

        
    }
    
}
