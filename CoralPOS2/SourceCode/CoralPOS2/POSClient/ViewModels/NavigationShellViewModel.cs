using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Caliburn.Core.IoC;
using Caliburn.PresentationFramework.ApplicationModel;
using Caliburn.PresentationFramework.Screens;
using Microsoft.Practices.ServiceLocation;

namespace POSClient.ViewModels
{
    [Singleton(typeof(NavigationShellViewModel))]
    public class NavigationShellViewModel : Navigator<IScreen>, INavigationShellViewModel
    {
        private IServiceLocator _serviceLocator;
        public NavigationShellViewModel(IServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
        }

        protected override void OnActivate()
        {
            Open<INavLoginViewModel>();
        }

        public void Open<T>() where T : IScreen
        {
            T scr = _serviceLocator.GetInstance<T>();
            this.OpenScreen(scr);
            
        }
    }
}
