using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using AppFrame.Base;
using AppFrame.WPF.Screens;
using Caliburn.Core.Invocation;
using Caliburn.PresentationFramework.RoutedMessaging;
using Microsoft.Practices.ServiceLocation;

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
        public void Execute(ResultExecutionContext context)
        {
            _loadScreen = context.ServiceLocator.GetInstance<T>();
            _loadScreen.StartLoading();
            //if you would rather disable the control that caused the service to be called, you could do this:
            //ChangeAvailability(message, false);
            Caliburn.PresentationFramework.Invocation.Execute.OnBackgroundThread(_methodCall, WorkCompleted);
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

        public event EventHandler<ResultCompletionEventArgs> Completed;
    }
}