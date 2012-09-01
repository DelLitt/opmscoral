using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace AppFrame.Base
{
    public static class AppFrameCommands
    {
        public static CanExecuteRoutedEventHandler CanExecute { get; set; }
        public static RoutedUICommand Cut { get; set; }
        public static RoutedUICommand Copy { get; set; }
        public static RoutedUICommand Paste { get; set; }
        public static ExecutedRoutedEventHandler CutExecuted { get; set; }
        public static ExecutedRoutedEventHandler CopyExecuted { get; set; }
        public static ExecutedRoutedEventHandler PasteExecuted { get; set; }
    }
}
