using AppFrame.WPF.Screens;
using Caliburn.PresentationFramework.Screens;

namespace POSClient.ViewModels
{
    public class CircularLoadViewModel : Screen,ICircularLoadViewModel
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
