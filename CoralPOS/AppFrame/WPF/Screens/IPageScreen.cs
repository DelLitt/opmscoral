using Caliburn.Micro;

namespace AppFrame.WPF.Screens
{
    public interface IPageScreen : IScreen
    {
        string Path { get; set; }
    }
}
