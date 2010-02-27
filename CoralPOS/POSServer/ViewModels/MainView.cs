using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using Caliburn.Core.IoC;
using Caliburn.PresentationFramework.Screens;
using POSServer.ViewModels.Menu;

namespace POSServer.ViewModels
{
    [PerRequest(typeof(IMainView))]
    public class MainView : Screen, IMainView
    {
        private IShellViewModel _startViewModel;
        public MainView(IShellViewModel startViewModel)
        {
            _startViewModel = startViewModel;
        }

        private IScreen _activeMenu;
        public IScreen ActiveMenu
        {
            get
            {
                return _activeMenu;
            }
            set
            {
                _activeMenu = value;
                NotifyOfPropertyChange(() => ActiveMenu);    
            }
        }
        protected override void OnActivate()
        {
            base.OnActivate();
            ActiveMenu = _startViewModel.ServiceLocator.GetInstance<IMainMenuViewModel>();
            _startViewModel.ActiveMenu = ActiveMenu;
        }
    }
}