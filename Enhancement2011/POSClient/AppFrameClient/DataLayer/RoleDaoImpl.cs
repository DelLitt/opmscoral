using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using AppFrame.DataLayer;
using AppFrame.Model;
using Spring.Data.NHibernate;
using Spring.Data.NHibernate.Support;

namespace AppFrameClient.DataLayer
{
    public class RoleDaoImpl : HibernateDaoSupport, IRoleDao
    {
        IList IRoleDao.getRoles(string Username)
        {
            LoginModel loginModel = HibernateTemplate.Get(typeof(LoginModel), Username) as LoginModel;
            System.Collections.IList listRoleModel = null;
            if (loginModel != null)
            {
                listRoleModel = loginModel.Roles;
            }
            return listRoleModel;
        }

        public IList FindAll()
        {
            return HibernateTemplate.LoadAll(typeof (RoleModel));
        }

        public RoleModel Add(RoleModel data)
        {
            HibernateTemplate.Save(data);
            return data;
        }

        public void Update(RoleModel data)
        {
            HibernateTemplate.Update(data);
        }

        public void Delete(RoleModel data)
        {
            HibernateTemplate.Delete(data);
        }
    }
}
