using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Caliburn.PresentationFramework;
using AppFrame.DataLayer;

namespace AppFrame.WPF
{
    public class BindableList<T> : BindableCollection<T>
    {
        protected override void SetItem(int index, T item)
        {
            var proxy = ApplyProxy(item);
            base.SetItem(index,proxy);
        }

        protected override void InsertItem(int index, T item)
        {
            var proxy = ApplyProxy(item);
            base.InsertItem(index,proxy);
        }
        private T ApplyProxy<T>(T item)
        {
            var proxy = item;
            if (!(item is IDataErrorInfo))
            {
                proxy = DataErrorInfoFactory.CreateProxyFor<T>(item);
            }
            return proxy;
        }
    }
}
