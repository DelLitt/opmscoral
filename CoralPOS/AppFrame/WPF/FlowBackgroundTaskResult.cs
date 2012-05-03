using System;
using AppFrame.WPF.Screens;
using Caliburn.Micro;
using Action = System.Action;

namespace AppFrame.WPF
{
    public class FlowBackgroundTaskResult<T,K> : IResult 
        where T: ILoadViewModel
        where K:FlowBackgroundTaskResultEventArgs,new()
    {
        private readonly Action<K> _callback;
        private readonly Action _methodCall;
        private T _loadScreen;

        public FlowBackgroundTaskResult(Action methodCall)
        {
            _methodCall = methodCall;
        }

        public FlowBackgroundTaskResult(Action methodCall,Action<K> callback)
        {
            _methodCall = methodCall;
            _callback = callback;
        }
        
        void WorkCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if(_loadScreen!= null) _loadScreen.StopLoading();

            if (_callback != null)
            {
                K eventArgs = new K();
                eventArgs.Result = e.Result;
                _callback(eventArgs);
            }
            Completed(this, new ResultCompletionEventArgs());
        }

        public void Execute(ActionExecutionContext context)
        {
            /*
            _loadScreen = (T)context.IoC.Get(typeof(T), null);
            _loadScreen.StartLoading();
            //if you would rather disable the control that caused the service to be called, you could do this:
            //ChangeAvailability(message, false);
            Caliburn.PresentationFramework.Invocation.Execute.OnBackgroundThread(_methodCall, WorkCompleted);*/
        }

        public event EventHandler<ResultCompletionEventArgs> Completed;
    }
}