using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POSClient.DataLayer.Models;

namespace POSClient.BusinessLogic.Logic.Security
{
    public interface ILoginLogic
    {
        bool Login(LoginModel loginInfo);
    }
}