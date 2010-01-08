using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Caliburn.PresentationFramework.ApplicationModel;
using Caliburn.PresentationFramework.ViewModels;

namespace AppFrame.WPF
{
    public class NavigationWindowManager : DefaultWindowManager
    {
        public NavigationWindowManager(IViewLocator viewLocator, IViewModelBinder viewModelBinder) : base(viewLocator, viewModelBinder)
        {
        }
    }
}
