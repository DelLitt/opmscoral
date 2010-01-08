using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Caliburn.Core;
using Caliburn.PresentationFramework.ApplicationModel;
using Caliburn.PresentationFramework.ViewModels;
using Microsoft.Practices.ServiceLocation;

namespace AppFrame.WPF
{
    public class NavigationWindowStrategy : DefaultViewLocator
    {
        public NavigationWindowStrategy(IAssemblySource assemblySource, IServiceLocator serviceLocator) : base(assemblySource, serviceLocator)
        {
        }


    }
}
