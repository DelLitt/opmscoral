using System;
using System.Collections.Generic;
using System.Text;
using AppFrame.Model;
using AppFrame.Common;

namespace AppFrame.Utility.Mapper
{
    /// <summary>
    /// Class Convert from LoginModel to BaseUser
    /// </summary>
    public class BaseUserMapper : BaseMapper<BaseUser,LoginModel>
    {

        public BaseUser Convert(LoginModel source)
        {
            if(source == null )
                return null;

            AppFrame.Common.BaseUser user = new AppFrame.Common.BaseUser();
            user.Name = source.Username;
            return user;
        }
    }
}
