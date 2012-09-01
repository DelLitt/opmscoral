using System;
using System.ComponentModel;
using AppFrame.Invocation;

namespace AppFrame.Utils
{
    public class TaskUtils
    {
        public static void DoExecuteAsync(Func<object> theDelegate, object state, Func<object, object, RunWorkerCompletedEventArgs> completed)
        {
            BackgroundTask _backgroundTask = null;
            _backgroundTask = new BackgroundTask(theDelegate);
            _backgroundTask.Completed += (s, e) => completed(s, e);
            _backgroundTask.Start(state);
        }
    }
}
