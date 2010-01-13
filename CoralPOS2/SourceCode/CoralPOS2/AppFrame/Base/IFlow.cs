using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using Caliburn.PresentationFramework.Screens;

namespace AppFrame.Base
{
    public interface IFlow
    {
        ShellNavigator<IScreen,INode> Navigator 
        {
            get;
            set;
        }
        INode CurrentNode { get; set; }
        string StartNodeName { get; }
        bool IsEndFlow { get; }

        bool CanGoBack { get; }
        bool CanGoForward { get; }
        void Back();
        void Forward();
        void Next();
        void Start();
        void Resume();
        void End();
        IDictionary FlowSteps { get; set; }

        IFlowSession Session { get; set; }
    }
}
