
using System;
using System.Collections.Generic;
using System.Text;

namespace AppFrame.Common
{

    public interface IUserManager
    {
        string GuestName { set;get;}
        /**
         * Returns a user instance given the user name.
         * @param string user name, null if it is a guest.
         * @return TUser the user instance, null if the specified username is not in the user database.
         */
        BaseUser getUser(string username);

        /*public BaseUser activateUser(object cookie);
	
        public bool passivateUser(object cookie);*/

        /**
         * Validates if the username and password are correct.
         * @param string user name
         * @param string password
         * @return boolean true if validation is successful, false otherwise.
         */
        bool validateUser(string Username, string Password);

    }
}
