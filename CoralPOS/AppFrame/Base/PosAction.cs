using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Caliburn.Core.Invocation;
using Caliburn.PresentationFramework;
using Caliburn.PresentationFramework.Actions;
using Caliburn.PresentationFramework.Filters;

namespace AppFrame.Base
{
    public class PosAction : BackgroundTask,IActionNode
    {

        public string Name
        {
            get; set;
        }

        public IFlow Flow
        {
            get; set;
        }

        public void GoToNextNode()
        {
            Flow.Next();
        }

        public virtual void DoExecute()
        {
            
        }

        public event EventHandler<EventArgs> DoExecuteCompleted;
    }
}
