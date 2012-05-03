using System.Collections;
using Caliburn.Micro;

namespace AppFrame.Base
{
    public interface IFlow
    {
        ShellNavigator<IScreen,INode> Navigator 
        {
            get;
            set;
        }

        void InitFlow();
        INode CurrentNode { get; set; }
        string StartNodeName { get; }
        string Name { get; set; }
        bool IsEndFlow { get; }

        bool CanGoBack { get; }
        bool CanGoForward { get; }
        void Back();
        void Forward();
        void Next();
        void Start();
        void Resume();
        void End();
        bool IsRepeated { get; set; }
        IDictionary FlowSteps { get; set; }

        IFlowSession Session { get; set; }
        
    }
}
