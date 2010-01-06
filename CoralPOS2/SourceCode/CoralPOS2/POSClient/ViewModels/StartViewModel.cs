using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Caliburn.Core;
using Caliburn.Core.Metadata;
using Caliburn.PresentationFramework.ApplicationModel;
using Microsoft.Practices.ServiceLocation;
using POSClient.ViewModels.Security;

namespace POSClient.ViewModels
{
    [Singleton(typeof(IStartViewModel))]
    public class StartViewModel : Navigator,IStartViewModel
    {
        private readonly IServiceLocator _serviceLocator;
        private IPresenter _dialogModel;

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

        public void Open<T>() where T : IPresenter
        {
            var presenter = _serviceLocator.GetInstance<T>();
            this.Open(presenter);
            CurrentPresenter = presenter;
            NotifyOfPropertyChange("CurrentPresenter");
        }
    }
}
