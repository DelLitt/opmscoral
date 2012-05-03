using System;
using System.ComponentModel;

namespace AppFrame.Base
{
    public interface IActionNode : INode
    {
        void DoExecute();
        void DoExecuteAsync(Func<object> theDelegate, object state);
        event RunWorkerCompletedEventHandler DoExecuteCompleted;
    }
}
