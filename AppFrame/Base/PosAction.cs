using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Caliburn.Core.Invocation;
using Caliburn.PresentationFramework;
using Caliburn.PresentationFramework.Actions;
using Caliburn.PresentationFramework.Filters;

namespace AppFrame.Base
{
    public class PosAction : IActionNode
    {
        private BackgroundTask _backgroundTask = null;

        public void DoExecuteAsync(Func<object>theDelegate, object state)
        {
            _backgroundTask = new BackgroundTask(theDelegate);
            _backgroundTask.Completed += (s, e) => DoExecuteCompleted(this, e);
            _backgroundTask.Start(state);
        }
        public string Name
        {
            get; set;
        }

        public IFlow Flow
        {
            get; set;
        }
        public event RunWorkerCompletedEventHandler DoExecuteCompleted = delegate { };

        public void GoToNextNode()
        {
            Flow.Next();
        }

        public virtual void DoExecute()
        {
            
        }
    }
}
