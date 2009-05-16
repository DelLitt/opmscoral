using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using AppFrame.Common;
using AppFrame.Model;
using NHibernate.Mapping;
using Spring.Data.NHibernate;
using Spring.Data.NHibernate.Support;


/// <summary>
/// Summary description for RoleDaoImpl
/// </summary>
namespace AppFrame.DataLayer
{
    public class RoleDaoImpl : HibernateDaoSupport, IRoleDao
    {  
        IList IRoleDao.getRoles(string Username)
        {
            LoginModel loginModel = HibernateTemplate.Get(typeof(LoginModel), Username) as LoginModel;
            IList listRoleModel = null;
            if (loginModel != null)
            {
                listRoleModel = loginModel.Roles;
            }
            return listRoleModel;
        }

    }

}
