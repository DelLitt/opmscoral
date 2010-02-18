using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Caliburn.PresentationFramework.ApplicationModel;
using Caliburn.PresentationFramework.ViewModels;

namespace AppFrame.WPF
{
    public class NavigationViewManager : DefaultWindowManager
    {
        public NavigationViewManager(IViewLocator viewLocator, IViewModelBinder viewModelBinder) : base(viewLocator, viewModelBinder)
        {
        }

        public override void Show(object rootModel, object context, Action<ISubordinate, Action> handleShutdownModel)
        {
            var window = CreateWindow(rootModel, context, handleShutdownModel);
            if(window is Page)
            {
                ((NavigationWindow) Application.Current.MainWindow).Navigate(window);
            }
            else
            {
                window.Show();
            }
        }
    }
}
