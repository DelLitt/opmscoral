using AppFrame.Base;

namespace POSClient.ViewModels.Security
{
    public interface ILoginViewModel : IScreenNode
    {
        string Path { get; set; }
    }
}