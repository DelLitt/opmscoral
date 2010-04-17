using System;
using AppFrame.Common;
using AppFrame.Model;
using AppFrame.Presenter;

namespace AppFrame.View
{
    public interface ICustomerView<T> where T:BaseEventArgs 
    {
        ICustomerController<T> CustomerController { set; }
    }
}