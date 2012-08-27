using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Collections;
using System.Windows.Controls;
using System.ComponentModel;

namespace AppFrame.Extensions.DataGrid
{
    /// <summary>
    /// Provides extended support for the ListBox and ListView controls.
    /// </summary>
    public static class DataGridExtension
    {

        #region Attached Property Declaration

        /// <summary>
        /// Identifies the ListBoxExtension.SelectedItemsSource attached property.
        /// </summary>
        public static readonly DependencyProperty SelectedItemsSourceProperty =
            DependencyProperty.RegisterAttached(
                "SelectedItemsSource",
                typeof(IList),
                typeof(DataGridExtension),
                new FrameworkPropertyMetadata(
                    OnSelectedItemsSourceChanged));
        #endregion

        #region Attached Property Accessors

        /// <summary>
        /// Gets the IList that contains the values that should be selected.
        /// </summary>
        /// <param name="element">The ListBox to check.</param>
        public static IList GetSelectedItemsSource(DependencyObject element)
        {
            if (element == null)
                throw new ArgumentNullException("element");

            return (IList)element.GetValue(SelectedItemsSourceProperty);
        }

        /// <summary>
        /// Sets the IList that contains the values that should be selected.
        /// </summary>
        /// <param name="element">The ListBox being set.</param>
        /// <param name="value">The value of the property.</param>
        public static void SetSelectedItemsSource(DependencyObject element, IList value)
        {
            if (element == null)
                throw new ArgumentNullException("element");

            element.SetValue(SelectedItemsSourceProperty, value);
        }

        #endregion

        #region IsResynchingProperty

        // Used to set a flag on the DataGrid to avoid reentry of SelectionChanged due to
        // a full syncronisation pass
        private static readonly DependencyPropertyKey IsResynchingPropertyKey =
            DependencyProperty.RegisterAttachedReadOnly(
                "IsResynching",
                typeof(bool),
                typeof(DataGridExtension),
                new PropertyMetadata(false));

        #endregion

        #region Private Static Methods

        private static void OnSelectedItemsSourceChanged(DependencyObject d,
                                                         DependencyPropertyChangedEventArgs e)
        {
            var dataGrid = d as System.Windows.Controls.DataGrid;
            if (dataGrid == null)
                throw new InvalidOperationException("The DataGridExtension.SelectedItemsSource attached " +
                                                    "property can only be applied to DataGrid controls.");

            dataGrid.SelectionChanged -= OnDataGridSelectionChanged;
            dataGrid.SelectedCellsChanged -=OnDataGridOnSelectedCellsChanged;
            if (e.NewValue != null)
            {
                ListenForChanges(dataGrid);
            }
        }

        private static void OnDataGridOnSelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            var dataGrid = sender as System.Windows.Controls.DataGrid;
            if (dataGrid != null)
            {
                IList removedItems = new ArrayList();
                IList addedItems = new ArrayList();
                foreach (DataGridCellInfo cell in e.RemovedCells)
                {
                    object obj = cell.Item;
                    removedItems.Add(obj);
                }
                foreach (DataGridCellInfo cell in e.AddedCells)
                {
                    object obj = cell.Item;
                    addedItems.Add(obj);
                }
                ProcessDataGridSelectedItems(dataGrid, removedItems, addedItems);
            }
        }

        private static void ProcessDataGridSelectedItems(System.Windows.Controls.DataGrid dataGrid, IList removedItems, IList addedItems)
        {
           bool isResynching = (bool)dataGrid.GetValue(IsResynchingPropertyKey.DependencyProperty);
           if (isResynching) return;

                IList list = GetSelectedItemsSource(dataGrid);
                if (list != null)
                {
                    foreach (object obj in removedItems)
                    {
                        if (list.Contains(obj))
                            list.Remove(obj);
                    }
                    foreach (object obj in addedItems)
                    {
                        if (!list.Contains(obj))
                            list.Add(obj);
                    }
                    //SetSelectedItemsSource(dataGrid, list);
                }
            
        }

        private static void ListenForChanges(System.Windows.Controls.DataGrid dataGrid)
        {
            // Wait until the element is initialised
            if (!dataGrid.IsInitialized)
            {
                EventHandler callback = null;
                callback = delegate
                               {
                                   dataGrid.Initialized -= callback;
                                   ListenForChanges(dataGrid);
                               };
                dataGrid.Initialized += callback;
                return;
            }

            dataGrid.SelectionChanged += OnDataGridSelectionChanged;
            dataGrid.SelectedCellsChanged += OnDataGridOnSelectedCellsChanged;
            ResynchList(dataGrid);
        }

        private static void OnDataGridSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var dataGrid = sender as System.Windows.Controls.DataGrid;
            if (dataGrid != null)
            {
                IList removedItems = new ArrayList();
                IList addedItems = new ArrayList();
                foreach (object obj in e.RemovedItems)
                {
                    removedItems.Add(obj);
                }
                foreach (object obj in e.AddedItems)
                {
                    addedItems.Add(obj);
                }
                ProcessDataGridSelectedItems(dataGrid, removedItems, addedItems);
            }
        }

        private static void ResynchList(System.Windows.Controls.DataGrid dataGrid)
        {
            if (dataGrid != null)
            {
                dataGrid.SetValue(IsResynchingPropertyKey, true);
                IList list = GetSelectedItemsSource(dataGrid);

                if (dataGrid.SelectionUnit == DataGridSelectionUnit.FullRow)
                {
                    if (dataGrid.SelectionMode == DataGridSelectionMode.Single)
                    {
                        dataGrid.SelectedItem = null;
                        if (list != null)
                        {
                            if (list.Count > 1)
                            {
                                // There is more than one item selected, but the listbox is in Single selection mode
                                throw new InvalidOperationException(
                                    "DataGrid is in Single selection mode, but was given more than one selected value.");
                            }

                            if (list.Count == 1)
                                dataGrid.SelectedItem = list[0];
                        }
                    }
                    else
                    {
                        dataGrid.SelectedItems.Clear();
                        if (list != null)
                        {
                            foreach (object obj in dataGrid.Items)
                                if (list.Contains(obj))
                                    dataGrid.SelectedItems.Add(obj);
                        }
                    }
                }
                dataGrid.SetValue(IsResynchingPropertyKey, false);
            }
        }

        #endregion

    }
}