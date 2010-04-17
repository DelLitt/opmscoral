
using System;
using System.Collections.Generic;
using System.Text;
using AppFrame.Utility;

namespace AppFrame.Common
{

    public class AppUserManager : IUserManager 
    {
     
        private string guestName= "Guest";

public string GuestName
{
  get { return guestName; }
  set { guestName = value; }
}

        private AbstractUser user;

        public AbstractUser User
        {
            get { return user; }
            set { user = value; }
        }
        
        /// <summary>
        /// get user base on username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public BaseUser getUser(string username)
        {

            if(username==null)
            {
                CreateGuestUser(); 
                return User;
            }   
            else
            {
                User.IsGuest = false;
                return User.createUser(username);
            }
        }
        private void CreateGuestUser()
        {
            // reset current user to guest
            User.IsGuest = true;
            User.Roles = null;
            User.Name = GuestName; 
        }
        /// <summary>
        /// validate user base on username and password
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool validateUser(string username, string password)
        {
            return User.validateUser(username, password);
        }

        

    }
}
