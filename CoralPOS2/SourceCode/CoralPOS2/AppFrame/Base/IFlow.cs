using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Caliburn.PresentationFramework.Screens;

namespace AppFrame.Base
{
    public interface IFlow
    {
        INode CurrentNode { get; set; }
        INode StartNode { get; }
        bool IsEndFlow { get; }

        bool CanGoBack { get; }
        bool CanGoForward { get; }
        void Back();
        void Forward();
        void Next();
        void Start();
        void Resume();
        void End();
        IList<INode> FlowSteps { get; set; }

        ISession Session { get; set; }
    }
}
