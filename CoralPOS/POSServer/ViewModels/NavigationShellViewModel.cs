using AppFrame.Base;
using AppFrame.CustomAttributes;
using Caliburn.Micro;

namespace POSServer.ViewModels
{
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

        public void Open<T>() where T : IScreen
        {
            /*T scr = _IoC.Get<T>();
            this.OpenScreen(scr);*/
            this.ActivateItem(IoC.Get<T>());
            
        }
    }
}