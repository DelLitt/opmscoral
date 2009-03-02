using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using AppFrame.Model;

namespace AppFrame.DataLayer
{
    public interface ILoginDao 
    {
        LoginModel getInfo(string Username, string Password);
        LoginModel getUser(string Username);
    }
}
