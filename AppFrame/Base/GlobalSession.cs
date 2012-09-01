using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppFrame.Base
{
    public class GlobalSession : DefaultSession
    {
        private static ISession _session = null;
        private GlobalSession() : base()
        {
            
        }

        public static ISession Instance
        {
            get
            {
                if (_session == null) _session = new GlobalSession();
                return _session;
            }
        }
        
    }
}
