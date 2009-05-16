using System;
using System.Collections.Generic;
using System.Text;

namespace AppFrame.Common
{
    [Serializable]
    public abstract class AbstractUser : BaseUser
    {
        /// <summary>
        /// validate user
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
	    abstract public bool validateUser(string username,string password);

        /// <summary>
        /// create user
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
	    abstract public AbstractUser createUser(string username);                   
    }
}
