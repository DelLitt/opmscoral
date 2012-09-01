using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoralPOS.Common
{
    public enum StockOutType
    {
        Normal = 0, Error, Damage, Lost, Temporarily,
        ReturnToProducer, ReturnToStock, DeptToDept, DestroyDamageAndLost,
        Sample
    }
}
