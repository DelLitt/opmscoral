using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using AppFrame.Common;
using AppFrame.Model;

namespace AppFrame.DataLayer
{
    public interface IRoleDao
    {
        IList getRoles(string Username);
        IList FindAll();
        RoleModel Add(RoleModel model);
        void Update(RoleModel model);
        void Delete(RoleModel model);
    }
}
