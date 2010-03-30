using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using AppFrame.Utils;
using Caliburn.Core;
using Caliburn.Core.IoC;

using Caliburn.PresentationFramework.ApplicationModel;
using Caliburn.PresentationFramework.Screens;
using Microsoft.Practices.ServiceLocation;
using POSServer.Common;
using Spring.Context;
using Spring.Context.Support;

namespace POSServer.ViewModels
{
    //[Singleton(typeof(IShellViewModel))]
    public class ShellViewModel : ShellNavigator<IScreen,INode>, IShellViewModel
    {
        
        //private readonly IServiceLocator _serviceLocator;
        private IScreen _dialogModel;

        public string CurrentPath { get;set; }

        public ShellViewModel(IServiceLocator serviceLocator) : base(serviceLocator) {}
        public ShellViewModel() : base() { }

        public override void Activate() {}

        public override void Initialize() 
        {
            RootScreen = ServiceLocator.GetInstance<IMainView>();
            MainScreen = RootScreen;
            bool isLogged = (bool)GlobalSession.Instance.Get(CommonConstants.IS_LOGGED);
            if(isLogged)
            {
                this.OpenScreen(MainScreen);
            }
            else
            {
                EnterFlow("LoginFlow");    
            }
        }
        
    }
}