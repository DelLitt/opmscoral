using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using AppFrameControls.Controls;

namespace POSClient
{
    public class CoralUserControlFunctionConfiguration
    {
        private static CoralUserControlFunctionConfiguration _functionConfiguration;
        private CoralUserControlFunctionConfiguration()
        {
        }
        public static CoralUserControlFunctionConfiguration Instance
        {
            get
            {
                if(_functionConfiguration == null)
                    _functionConfiguration = new CoralUserControlFunctionConfiguration();
                return _functionConfiguration;
            }
        }
        public void Config()
        {
            CoralUserControl.LostFocus = LostFocus;
            CoralUserControl.GotFocus=GotFocus;
            CoralUserControl.KeyDown=KeyDown;
        }

        private void KeyDown(object sender, KeyEventArgs keyEventArgs)
        {
            if (keyEventArgs.Key == Key.F2)
            {
                // focus to text box has name is Barcode.
                // Magic string is used here :(
                Control box = (Control)((UserControl)sender).FindName("Barcode");
                if (box != null) box.Focus();
            }
        }

        private void GotFocus(object sender, RoutedEventArgs e)
        {
            if (   e.OriginalSource is TextBox
                || e.OriginalSource is DataGrid)
            {
                Control box = (Control)e.OriginalSource;
                box.Effect = new System.Windows.Media.Effects.DropShadowEffect();
                box.Background = System.Windows.Media.Brushes.LightGreen;
            }

        }

        private void LostFocus(object sender, RoutedEventArgs e)
        {
            if (   e.OriginalSource is TextBox
                || e.OriginalSource is DataGrid)
            {
                Control box = (Control)e.OriginalSource;
                box.Effect = null;
                box.Background = System.Windows.Media.Brushes.White;
            }
        }
    }
}
