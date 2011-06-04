using System;

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
		abstract public bool ValidateUser(string username,string password);

		/// <summary>
		/// create user
		/// </summary>
		/// <param name="username"></param>
		/// <returns></returns>
		abstract public AbstractUser CreateUser(string username);                   
	}
}
