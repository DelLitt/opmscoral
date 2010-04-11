using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POSServer.Common
{
    public class CommonConstants
    {
        public const string IS_LOGGED ="IsLogged";
        public const string LOGGED_USER = "LoggedUser";
    }

    public enum StockOutType
    {
        Normal = 0,Error,Damage,Lost,Temporarily,
        ReturnToProducer,ReturnToStock,DeptToDept,DestroyDamageAndLost,
        Sample
    }
}