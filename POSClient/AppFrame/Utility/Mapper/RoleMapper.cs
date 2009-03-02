using System;
using System.Collections.Generic;
using System.Text;
using AppFrame.Common;
using AppFrame.Model;

namespace AppFrame.Utility.Mapper
{
    /// <summary>
    /// Converter convert from RoleModel to Role
    /// </summary>
    class RoleMapper : BaseMapper<Role,RoleModel>
    {
        public Role Convert(RoleModel source)
        {
            Role role = new Role();
            role.Name = source.Name;
            return role;
        }
    }
}
