using System;
using System.ComponentModel;
using AppFrame.Invocation;

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
