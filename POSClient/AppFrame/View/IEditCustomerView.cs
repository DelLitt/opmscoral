using System;
using System.Collections.Generic;
using System.Text;
using AppFrame.Common;
using AppFrame.Model;
using AppFrame.Presenter;

namespace AppFrame.View
{
    public interface IEditCustomerView<T>:ICustomerView<T> where T : BaseEventArgs 
    {
        
        event EventHandler<T> LoadAllCustomerEventEvent;
        event EventHandler<T> LoadCustomerEvent;
        event EventHandler<T> UpdateCustomerEvent;
        event EventHandler<T> DeleteCustomerEvent;    
    }
}
