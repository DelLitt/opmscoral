using System;
using System.Collections.Generic;
using System.Web;
using AppFrame.Model;
using Spring.Data.NHibernate.Support;

/// <summary>
/// Summary description for LoginDaoImpl
/// </summary>
/// 

namespace AppFrame.DataLayer
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



        #region ILoginDao Members


        public LoginModel FindById(object id)
        {
            throw new NotImplementedException();
        }

        public LoginModel Add(LoginModel data)
        {
            throw new NotImplementedException();
        }

        public void Update(LoginModel data)
        {
            throw new NotImplementedException();
        }

        public void Delete(LoginModel data)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(object id)
        {
            throw new NotImplementedException();
        }

        public System.Collections.IList FindAll(ObjectCriteria criteria)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}