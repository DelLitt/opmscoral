using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppFrame.Security
{
    [AttributeUsage(AttributeTargets.Class)]
    public class InRoleAttribute : Attribute
    {
        private IList<Role> roleList;
        public InRoleAttribute(string roles)
        {
            roleList = ParseRole(roles);
        }

        private IList<Role> ParseRole(string roles)
        {
            IList<Role> parsedRoles = new List<Role>();
            string[] rolearr = roles.Split(',');
            foreach (string roleName in rolearr)
            {
                Role role = new Role { Name = roleName };
                parsedRoles.Add(role);
            }
            return parsedRoles;
        }

        public IList<Role> AcceptRoles
        {
            get
            {
                return roleList;
            }
            set
            {
                roleList = value;
            }
        }
    }
}
