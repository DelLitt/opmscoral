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
        where T: IActionNode
        where K:EventArgs
    {
        private readonly Action<K> _callback;
        private readonly Expression<Action<T>> _methodCall;
        private T _action;

        public FlowBackgroundTaskResult(T action,Expression<Action<T>> methodCall)
        {
            _action = action;
            _methodCall = methodCall;
        }

        public FlowBackgroundTaskResult(T action,Expression<Action<T>> methodCall, Action<K> callback)
        {
            _action = action;
            _methodCall = methodCall;
            _callback = callback;
        }
        public void Execute(ResultExecutionContext context)
        {
            context.ServiceLocator.GetInstance<ILoadViewModel>().StartLoading();
            //if you would rather disable the control that caused the service to be called, you could do this:
            //ChangeAvailability(message, false);

            var lambda = (LambdaExpression)_methodCall;
            var executeMethod = (MethodCallExpression)lambda.Body;
            var eventName = executeMethod.Method.Name.Replace("Async","Completed");

            EventHelper.WireEvent(
                _action,
                _action.GetType().GetEvent(eventName),
                OnEvent
                );

            _methodCall.Compile()(_action);                       
        }
        private void OnEvent(object s, EventArgs e)
        {
            ServiceLocator.Current.GetInstance<ILoadViewModel>().StopLoading();
            //or re-enable the control that caused the service to be called:
            //ChangeAvailability(message, true);

            if (_callback != null)
                _callback((K)e);

            Completed(this, new ResultCompletionEventArgs());
        }

        public event EventHandler<ResultCompletionEventArgs> Completed;
    }
}