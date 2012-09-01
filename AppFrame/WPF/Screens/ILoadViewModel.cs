using Caliburn.Micro;

namespace AppFrame.WPF.Screens
{
    public interface ILoadViewModel : IScreen
    {
        void StartLoading();
        void StopLoading();
    }
}
