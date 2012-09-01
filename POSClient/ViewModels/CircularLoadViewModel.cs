using AppFrame.WPF.Screens;
using AppFrame.CustomAttributes;
using Caliburn.Micro;

namespace POSClient.ViewModels
{
    public class CircularLoadViewModel : Screen,ICircularLoadViewModel
    {
        private IShellViewModel _startViewModel;

        public CircularLoadViewModel()
        {
            _startViewModel = ShellViewModel.Current;
            
        }
        public void StartLoading()
        {
           _startViewModel.ShowDialog(this); 
        }

        public void StopLoading()
        {
            ShellViewModel.Current.HideDialog(this);
            //Shutdown();
        }
    }
}
