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
        public static object CreateErrorInfoProxy<T>(T obj) where T:class
        {
            var type = typeof (T);
            var factory = ServiceLocator.Current.GetInstance<IProxyFactory>("IProxyFactory");
            if(type.ShouldCreateProxy())
            {
                return factory.CreateProxyWithTarget(typeof(T), obj, type.GetAttributes<IBehavior>(true));
            }
            else
            {
                return obj;
            }
        }
    }
}
