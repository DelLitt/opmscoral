using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace AppFrame.Extensions.DataGrid
{
    public static class SelectedItemsBehavior
    {
        public static readonly DependencyProperty SelectedItemsChangedHandlerProperty =
            DependencyProperty.RegisterAttached("SelectedItemsChangedHandler",
                typeof(RelayCommand),
                typeof(SelectedItemsBehavior),
                new FrameworkPropertyMetadata(new PropertyChangedCallback(OnSelectedItemsChangedHandlerChanged)));


        public static RelayCommand GetSelectedItemsChangedHandler(DependencyObject element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }
            return element.GetValue(SelectedItemsChangedHandlerProperty) as RelayCommand;
        }

        public static void SetSelectedItemsChangedHandler(DependencyObject element, RelayCommand value)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }
            element.SetValue(SelectedItemsChangedHandlerProperty, value);
        }

        public static void OnSelectedItemsChangedHandlerChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

            var dataGrid = (System.Windows.Controls.DataGrid)d;

            if (e.OldValue == null && e.NewValue != null)
            {
                dataGrid.SelectionChanged += ItemsControl_SelectionChanged;
            }

            if (e.OldValue != null && e.NewValue == null)
            {
                dataGrid.SelectionChanged -= ItemsControl_SelectionChanged;
            }
        }


        public static void ItemsControl_SelectionChanged(Object sender, SelectionChangedEventArgs e)
        {

            var dataGrid = (System.Windows.Controls.DataGrid)sender;

            RelayCommand itemsChangedHandler = GetSelectedItemsChangedHandler(dataGrid);

            itemsChangedHandler.Execute(dataGrid.SelectedItems);
        }
    }
}
