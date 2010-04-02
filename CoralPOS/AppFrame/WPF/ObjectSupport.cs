using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Caliburn.Core;
using Caliburn.Core.Behaviors;
using Microsoft.Practices.ServiceLocation;

namespace AppFrame.WPF
{
    public class ObjectSupport
    {
        public static T CreateErrorInfoProxy<T>(T obj) where T:class
        {
            var type = typeof (T);
            var factory = new PosDynamicProxy();
            if(type.ShouldCreateProxy())
            {
                return factory.CreateProxyWithTarget(typeof (IDataErrorInfo), obj, type.GetAttributes<IBehavior>(true)) as T;
            }
            else
            {
                return obj;
            }
        }
    }
}
