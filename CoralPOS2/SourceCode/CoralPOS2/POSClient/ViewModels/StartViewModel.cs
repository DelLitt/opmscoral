using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Caliburn.Core;
using Caliburn.Core.IoC;
using Caliburn.Core.Metadata;
using Caliburn.PresentationFramework.ApplicationModel;
using Caliburn.PresentationFramework.Screens;
using Microsoft.Practices.ServiceLocation;
using POSClient.ViewModels.Security;

namespace POSClient.ViewModels
{
    [Singleton(typeof(IStartViewModel))]
    public class StartViewModel : Navigator<IScreen>,IStartViewModel
    {
        
        private readonly IServiceLocator _serviceLocator;
        private IScreen _dialogModel;

        public string CurrentPath { get;set; }
        public StartViewModel(IServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
        }

        public override void Activate()
        {
            
        }

        public override void Initialize() 
        {
            Open<ILoginViewModel>();
        }

        public void Open<T>() where T : IScreen
        {
            var screen = _serviceLocator.GetInstance<T>();
            this.OpenScreen(screen);
            //CurrentPresenter = presenter;

        }
    }
}
