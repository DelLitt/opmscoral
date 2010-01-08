using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Caliburn.PresentationFramework.ApplicationModel;

namespace AppFrame.WPF
{
    public class NavigationWindowManager : DefaultWindowManager
    {
        public NavigationWindowManager(IViewStrategy viewStrategy, IBinder binder) : base(viewStrategy, binder)
        {
        }

    }
}
