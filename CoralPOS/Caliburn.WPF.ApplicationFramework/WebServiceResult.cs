using AppFrame.Invocation;
using Caliburn.Micro;

namespace Caliburn.WPF.ApplicationFramework
{
    using System;
    using System.Linq.Expressions;

    public class WebServiceResult<T, K> : IResult
        where T : new()
        where K : EventArgs
    {
        private readonly Action<K> _callback;
        private readonly Expression<Action<T>> _serviceCall;

        public WebServiceResult(Expression<Action<T>> serviceCall)
        {
            _serviceCall = serviceCall;
        }

        public WebServiceResult(Expression<Action<T>> serviceCall, Action<K> callback)
        {
            _serviceCall = serviceCall;
            _callback = callback;
        }

        public void Execute(ActionExecutionContext context)
        {
            IoC.Get<ILoadScreen>().StartLoading();
            //if you would rather disable the control that caused the service to be called, you could do this:
            //ChangeAvailability(message, false);

            var lambda = (LambdaExpression)_serviceCall;
            var methodCall = (MethodCallExpression)lambda.Body;
            var eventName = methodCall.Method.Name.Replace("Async", "Completed");

            var service = new T();

            EventHelper.WireEvent(
                service,
                service.GetType().GetEvent(eventName),
                OnEvent
                );

            _serviceCall.Compile()(service);
        }

        public event EventHandler<ResultCompletionEventArgs> Completed = delegate { };

        private void OnEvent(object s, EventArgs e)
        {
            IoC.Get<ILoadScreen>().StopLoading();
            //or re-enable the control that caused the service to be called:
            //ChangeAvailability(message, true);

            if (_callback != null)
                _callback((K)e);

            Completed(this, new ResultCompletionEventArgs());
        }

    }
}