using AppFrame.Base;
using AppFrame.CustomAttributes;
using Caliburn.Micro;

namespace POSClient.ViewModels
{
    [Singleton(typeof(NavigationShellViewModel))]
    public class NavigationShellViewModel : Navigator<IScreen>, INavigationShellViewModel
    {
        /*private IServiceLocator _serviceLocator;
        public NavigationShellViewModel(IServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
        }*/

        protected override void OnActivate()
        {
            Open<INavLoginViewModel>();
        }

        public void Open<T>() where T:IScreen
        {
            this.ActivateItem(IoC.Get<T>());
            
        }
    }
}
