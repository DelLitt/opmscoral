using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Common;

namespace AppFrameClient.Model
{
    [Serializable]
    public class PosRole : Role
    {
        private static Role administratorRole;
        private static Role supervisorRole;
        private static Role managerRole;
        private static Role accountantRole;
        private static Role loggedManagerRole;

        public PosRole(string name) : base(name)
        {
        
        }
        public static Role Administrator
        {
            get
            {
                if(administratorRole == null)
                {
                    administratorRole = new Role("Administrator");
                }
                return administratorRole;
            }
        }

        public static Role Supervisor
        {
            get
            {
                if (supervisorRole == null)
                {
                    supervisorRole = new Role("Supervisor");
                }
                return supervisorRole;
            }
        }

        public static Role Manager
        {
            get
            {
                if (managerRole == null)
                {
                    managerRole = new Role("Manager");
                }
                return managerRole;
            }
        }

        public static Role LoggedManager
        {
            get
            {
                if (loggedManagerRole == null)
                {
                    loggedManagerRole = new Role("LoggedManager");
                }
                return loggedManagerRole;
            }
        }

    }
}