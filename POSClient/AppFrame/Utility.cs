using System;
using System.Collections.Generic;
using System.Text;
using Spring.Context;
using Spring.Context.Support;

namespace AppFrame
{
    public sealed class ObjectUtility
    {
        private static readonly IApplicationContext ctx = ContextRegistry.GetContext();

        public static Object GetObject(Type type)
        {
            //IApplicationContext ctx = ContextRegistry.GetContext();
            return ctx.GetObject(type.ToString());
        }

        public static Object GetObject(string type)
        {
            //IApplicationContext ctx = ContextRegistry.GetContext();
            return ctx.GetObject(type);
        }
    }
}
