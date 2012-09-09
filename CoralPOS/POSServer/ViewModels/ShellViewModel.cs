using System;
using AppFrame.Base;
using AppFrame.CustomAttributes;
using AppFrame.Extensions;
using Caliburn.Micro;
using POSServer.Common;

namespace POSServer.ViewModels
{
    //[Singleton(typeof(IShellViewModel))]
    //[Singleton(typeof(IShellViewModel))]
    [Singleton(Name = "IShellViewModel")]
    public class ShellViewModel : ShellNavigator<IScreen,INode>, IShellViewModel
    {
        
        //private readonly IServiceLocator _serviceLocator;
        private IScreen _dialogModel;

        public string CurrentPath { get;set; }
        private static ShellViewModel _currentShellNavigator;
        public static ShellViewModel Current
        {
            get { return _currentShellNavigator; }
            //private set { _currentShellNavigator = value; }
        }
        //public ShellViewModel(IServiceLocator serviceLocator) : base(serviceLocator) {}
        public ShellViewModel() : base()
        {
            if (_currentShellNavigator == null)
            {
                _currentShellNavigator = this;
            }
        }

        //public override void Activate() {}
        protected override void OnActivate()
        {
            DialogExtensions.HideDialog = HideDialog;
            DialogExtensions.ShowDialog = ShowDialog;
            base.OnActivate();
            //if(IsActive == false) Console.WriteLine("UI GIOI !");
            RootScreen = IoC.Get<MainViewModel>();
            MainScreen = RootScreen;
            bool isLogged = (bool)GlobalSession.Instance.Get(CommonConstants.IS_LOGGED);
            if (isLogged)
            {
                this.ActivateItem(MainScreen);
            }
            else
            {
                EnterFlow(FlowDefinition.LoginFlow);
            }
        }

        
        /*protected override void OnInitialize() 
        {
            base.OnInitialize();
            RootScreen = IoC.Get<IMainViewModel>();
            MainScreen = RootScreen;
            bool isLogged = (bool)GlobalSession.Instance.Get(CommonConstants.IS_LOGGED);
            if(isLogged)
            {
                this.ActivateItem(MainScreen);
            }
            else
            {
                EnterFlow(FlowDefinition.LoginFlow);    
            }
        }*/
        
    }
}