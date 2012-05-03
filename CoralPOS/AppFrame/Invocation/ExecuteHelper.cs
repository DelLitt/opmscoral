using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Threading;

namespace AppFrame.Invocation
{
    /// <summary>
    /// Utility methods supporting various forms of method execution.
    /// </summary>
    public static class ExecuteHelper
    {
        static IBackgroundTask ExecuteOnBackgroundThread(Func<object> backgroundAction, RunWorkerCompletedEventHandler uiCallback, ProgressChangedEventHandler progressChanged)
        {
            var task = new BackgroundTask(backgroundAction);

            if (uiCallback != null)
                task.Completed += uiCallback;

            if (progressChanged != null)
                task.ProgressChanged += progressChanged;

            task.Start(null);

            return task;
        }

        /// <summary>
        /// Executes the backgroundAction on a background thread.
        /// </summary>
        /// <param name="backgroundAction">The action.</param>
        public static IBackgroundTask OnBackgroundThread(Func<object> backgroundAction)
        {
            return ExecuteOnBackgroundThread(backgroundAction, null, null);
        }

        /// <summary>
        /// Executes the backgroundAction on a background thread.
        /// </summary>
        /// <param name="backgroundAction">The action.</param>
        /// <param name="uiCallback">The UI callback.</param>
        public static IBackgroundTask OnBackgroundThread(Func<object> backgroundAction, RunWorkerCompletedEventHandler uiCallback)
        {
            return ExecuteOnBackgroundThread(backgroundAction, uiCallback, null);
        }

        /// <summary>
        /// Executes the backgroundAction on a background thread.
        /// </summary>
        /// <param name="backgroundAction">The action.</param>
        /// <param name="uiCallback">The UI callback.</param>
        /// <param name="progressChanged">The progress change callback.</param>
        public static IBackgroundTask OnBackgroundThread(Func<object> backgroundAction, RunWorkerCompletedEventHandler uiCallback, ProgressChangedEventHandler progressChanged)
        {
            return ExecuteOnBackgroundThread(backgroundAction, uiCallback, progressChanged);
        }

        /// <summary>
        /// Executes the backgroundAction on a background thread.
        /// </summary>
        /// <param name="backgroundAction">The action.</param>
        /// <param name="progressChanged">The progress change callback.</param>
        public static IBackgroundTask OnBackgroundThread(Func<object> backgroundAction, ProgressChangedEventHandler progressChanged)
        {
            return ExecuteOnBackgroundThread(backgroundAction, null, progressChanged);
        }
    }

}
