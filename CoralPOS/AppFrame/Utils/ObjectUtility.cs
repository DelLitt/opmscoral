using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spring.Context;
using Spring.Context.Support;

namespace AppFrame.Utils
{
    public class ObjectUtility
    {
        public static T GetObject<T>(string name)
        {
            IApplicationContext ctx = ContextRegistry.GetContext();
            var obj = ctx.GetObject(name);
            return (T) obj;
        }
    }
}
