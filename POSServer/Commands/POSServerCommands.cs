using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using AppFrame.Helpers;

namespace POSServer.Commands
{
    public class POSServerCommands
    {
        public static void CommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        public static void CutExecutedEventHandler(object sender, ExecutedRoutedEventArgs e)
        {

        }
        public static void CopyExecutedEventHandler(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.OriginalSource is DataGrid)
            {
                DataGrid source = (DataGrid)e.OriginalSource;
                if (source.SelectedCells != null && source.SelectedCells.Count > 0)
                {
                    DataGridCellInfo cellInfo = source.SelectedCells[0];
                    string proposedValue = source.GetValue(cellInfo) as string;
                    Thread thread = new Thread(() => TryToSetClipboard(proposedValue));
                    thread.SetApartmentState(ApartmentState.STA);
                    thread.Start();
                }
            }
        }

        private static void TryToSetClipboard(String proposedValue)
        {
            int i = 3;
            do
            {
                try
                {
                    if (!Clipboard.GetText().Equals(proposedValue))
                    {
                        Clipboard.SetText((proposedValue ?? ""));
                        break;
                    }
                }
                catch (Exception ex)
                {
                }
            } while (i-- > 0);
        }

        public static void PasteExecutedEventHandler(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.OriginalSource is DataGrid)
            {
                DataGrid source = (DataGrid)e.OriginalSource;
                if (source.SelectedCells != null && source.SelectedCells.Count > 0)
                {
                    foreach (DataGridCellInfo cellInfo in source.SelectedCells)
                    {
                        TryHelper.Try(() => source.SetValue(cellInfo, Clipboard.GetText()), 2);
                    }

                }
            }
        }
    }
}
