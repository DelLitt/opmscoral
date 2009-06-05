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
                if (administratorRole == null)
                {
                    administratorRole = new Role("Supervisor");
                }
                return administratorRole;
            }
        }

        public static Role Manager
        {
            get
            {
                if (administratorRole == null)
                {
                    administratorRole = new Role("Manager");
                }
                return administratorRole;
            }
        }


    }
}