using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Caliburn.PresentationFramework.Screens;

namespace POSServer.ViewModels
{
    public class CircularLoadViewModel : Screen,AppFrame.WPF.Screens.ILoadViewModel
    {
        private IShellViewModel _startViewModel;

        public CircularLoadViewModel(IShellViewModel shellPresenter)
        {
            _startViewModel = shellPresenter;
            
        }
        public void StartLoading()
        {
           _startViewModel.ShowDialog(this); 
        }

        public void StopLoading()
        {
            Shutdown();
        }
    }
}
