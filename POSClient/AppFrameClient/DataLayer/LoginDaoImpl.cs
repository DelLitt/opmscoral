using System;
using System.Collections.Generic;
using System.Text;
using AppFrame.DataLayer;
using AppFrame.Model;
using Spring.Data.NHibernate;
using Spring.Data.NHibernate.Support;

namespace AppFrameClient.DataLayer
{
    public class LoginDaoImpl : HibernateDaoSupport, ILoginDao
    {
        
        
        public global::AppFrame.Model.LoginModel getInfo(string Username, string Password)
        {
            LoginModel model = null;
            
                model = HibernateTemplate.Get(typeof(LoginModel), Username) as LoginModel;
            
            if (model != null)
            {
                if (Username.Equals(model.Username) && Password.Equals(model.Password))
                {
                    return model;
                }
            }
            return null;
        }


        public LoginModel getUser(string Username)
        {
            return HibernateTemplate.Get(typeof (LoginModel), Username) as LoginModel;
        }

        
    }
}
