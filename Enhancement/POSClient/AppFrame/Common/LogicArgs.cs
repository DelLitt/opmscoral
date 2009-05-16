using System;
using System.Collections.Generic;
using System.Text;

namespace AppFrame.Common
{
    public class LogicArgs
    {
        private BaseUser currentUser;

        public BaseUser CurrentUser
        {
            get { return currentUser; }
            set { currentUser = value; }
        }

    }
}
