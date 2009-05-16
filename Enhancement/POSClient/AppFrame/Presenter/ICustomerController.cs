using System;
using AppFrame.Common;
using AppFrame.Logic;
using AppFrame.Model;
using AppFrame.View;

namespace AppFrame.Presenter
{
    public interface ICustomerController<T> : IBaseController<T> where T:BaseEventArgs
    {
        INewCustomerView<T> NewCustomerView { get; set; }
        IEditCustomerView<T> EditCustomerView { get; set; }

        ITestCustomerLogic CustomerLogic { set; get;}
        event EventHandler<T> CompleteSaveCustomerEvent;
        event EventHandler<T> CompleteEditCustomerEvent;
        event EventHandler<T> CompleteDeleteCustomerEvent;
        event EventHandler<T> CompleteLoadAllCustomerEvent;
        event EventHandler<T> CompleteLoadCustomerEvent;
        event EventHandler<T> CompleteUpdateCustomerEvent;
    }
}