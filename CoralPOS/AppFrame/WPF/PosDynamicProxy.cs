using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Caliburn.Core.Behaviors;
using Caliburn.DynamicProxy;
using Castle.Core;

namespace AppFrame.WPF
{
    [Singleton]
    public class PosDynamicProxy : DynamicProxyFactory, IProxyFactory
    {
        public PosDynamicProxy()
        {
        }
    }
}
