using AppFrame.Base;
using Caliburn.Micro;

namespace POSServer.ViewModels
{
    public interface IShellViewModel
    {
        void Open<T>() where T : IScreen;
        void ShowDialog<U>(U screen) where U : IScreen;
        //IServiceLocator ServiceLocator { get; set; }
        IScreen ActiveMenu { get; set; }
        IFlow ActiveFlow { get; set; }

        bool EnterFlow(string flowName);
        bool StartFlow(string flowName);
        bool ResumeFlow(string flowName);
        void LeaveFlow();
        void EnterChildFlow(string childFlowName, IFlow parentFlow);

        void HideDialog<U>(U screen) where U : IScreen;
    }
}