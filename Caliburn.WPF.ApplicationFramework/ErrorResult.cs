using Caliburn.Micro;

namespace Caliburn.WPF.ApplicationFramework
{
    using System;
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Controls.Primitives;

    public class ErrorResult : IResult
    {
        private readonly IList<IValidationResult> _results;

        public ErrorResult(IList<IValidationResult> results)
        {
            _results = results;
        }

        public void Execute(ActionExecutionContext context)
        {
            //just demonstrating the power of a custom IExecutableResult

            var source = context.Source;
            var popup = source.FindName("dirtyPopup") as Popup;

            var itemsControl = (ItemsControl)popup.FindName("messageHost");
            itemsControl.ItemsSource = _results;

            var visualOffset = source.TransformToVisual(Application.Current.MainWindow).Transform(new Point(0, 0));
            var popupOffset = popup.TransformToVisual(Application.Current.MainWindow).Transform(new Point(0, 0));

            popup.HorizontalOffset = (visualOffset.X - popupOffset.X) / 2;
            popup.IsOpen = true;
            popup.CaptureMouse();

            popup.Child.MouseLeave += delegate { popup.IsOpen = false; };

            Completed(this, new ResultCompletionEventArgs());
        }

        public event EventHandler<ResultCompletionEventArgs> Completed = delegate { };
       
    }
}