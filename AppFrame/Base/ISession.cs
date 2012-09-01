using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppFrame.Base
{
    public interface ISession
    {
        void Put(string key, object value);
        object Get(string key);
        void Remove(string key);
        bool IsSet(string key);
    }
}
